package edu.umassd.sentiment;

import java.io.IOException;
import java.io.PrintStream;
import java.net.URISyntaxException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

import org.springframework.core.io.ClassPathResource;

import edu.stanford.nlp.sentiment.SentimentPipeline;
import edu.umassd.util.ClasspathUtil;
import edu.umassd.util.ReviewFileWalker;

/**
 * Loads all text files on the classpath into the java file.
 * 
 * @author Dan Avila
 *
 */
public class SentimentRunner
{
	public static void main(String[] args) throws IOException,
			URISyntaxException
	{
		Files.createDirectories(Constants.APP_DATA);

		ReviewFileWalker walker = new ReviewFileWalker();
		ClasspathUtil.walkClasspath(walker);

		Map<Path, Path> filesToTreebank = new HashMap<>();

		// for (Path source : walker.getFiles())
		for (Path source : Arrays.asList(new ClassPathResource(
				"SamsungReviews/Samsung_review_3.txt").getFile().toPath()))
		{
			Path treebank = createTreebankFile(source);
			filesToTreebank.put(source, treebank);

			System.setOut(new PrintStream(treebank.toFile()));

			createTreebank("-file", source.toString(), "-output", "PENNTREES");
		}
	}

	private static Path createTreebankFile(Path file)
	{
		String treeBankName = file.getFileName().toString();
		treeBankName = treeBankName.substring(0, treeBankName.lastIndexOf("."));
		treeBankName = treeBankName + ".treebank";

		return Constants.APP_DATA.resolve(treeBankName);
	}

	private static void createTreebank(String... args) throws IOException
	{
		SentimentPipeline.main(args);
	}
}
