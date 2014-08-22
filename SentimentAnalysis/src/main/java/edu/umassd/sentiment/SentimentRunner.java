package edu.umassd.sentiment;

import java.io.IOException;
import java.io.PrintStream;
import java.net.URISyntaxException;
import java.net.URL;
import java.nio.file.FileVisitResult;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.SimpleFileVisitor;
import java.nio.file.attribute.BasicFileAttributes;
import java.util.Arrays;
import java.util.Collections;
import java.util.Enumeration;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import org.springframework.core.io.ClassPathResource;

import edu.stanford.nlp.sentiment.SentimentPipeline;

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

		ClassLoader loader = Thread.currentThread().getContextClassLoader();
		Enumeration<URL> en = loader.getResources("");
		List<URL> resources = Collections.list(en);

		TextFileWalker walker = new TextFileWalker();

		for (URL url : resources)
		{
			Path p = Paths.get(url.toURI());

			Files.walkFileTree(p, walker);
		}

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

	public static class TextFileWalker extends SimpleFileVisitor<Path>
	{
		private Set<Path> files = new HashSet<Path>();

		@Override
		public FileVisitResult visitFile(Path file, BasicFileAttributes attrs)
				throws IOException
		{
			if (file.toString().endsWith(".txt"))
			{
				files.add(file.toAbsolutePath());
			}

			return super.visitFile(file, attrs);
		}

		public Set<Path> getFiles()
		{
			return files;
		}
	}
}
