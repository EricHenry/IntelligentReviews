package edu.umassd.polarity;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.net.URISyntaxException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.StandardOpenOption;
import java.util.Arrays;
import java.util.List;

import org.springframework.core.io.ClassPathResource;

import edu.umassd.sentiment.Constants;
import edu.umassd.util.ClasspathUtil;
import edu.umassd.util.ReviewFileWalker;

public class Polarity
{
	public static void main(String... args) throws InterruptedException,
			IOException, URISyntaxException
	{
		Files.createDirectories(Constants.POLARITY_HOME);

		ReviewFileWalker walker = new ReviewFileWalker();

		ClasspathUtil.walkClasspath(walker);

		// for (Path review : walker.getFiles())
		// {
		// polarity(script, review, walker);
		// }

		Path review = ClasspathUtil.path("5S_reviews/review1_engadget.txt");

		polarity(review, walker);
	}

	private static final void polarity(Path review, ReviewFileWalker walker)
			throws InterruptedException, IOException
	{
		Path relativeDir = walker.getRelativeToRoot(review);
		Path workingDir = Constants.POLARITY_HOME.resolve(relativeDir);
		Files.createDirectories(workingDir);

		Path script = new ClassPathResource("/findPolarizedWords.R").getFile()
				.toPath();
		String scriptPath = script.toAbsolutePath().toString();
		String input = review.toAbsolutePath().toString();
		runScript(workingDir, scriptPath, input);

		Path posWordsPath = workingDir.resolve("positive-words.txt");
		Path negWordsPath = workingDir.resolve("negative-words.txt");
		Path polarizedChunksPath = workingDir.resolve("polarized-chunks.txt");

		BufferedReader reviewReader = Files.newBufferedReader(review);
		BufferedReader posWordsReader = Files.newBufferedReader(posWordsPath);
		BufferedReader negWordsReader = Files.newBufferedReader(negWordsPath);

		BufferedWriter polarizedChunksWriter = Files.newBufferedWriter(
				polarizedChunksPath, StandardOpenOption.CREATE,
				StandardOpenOption.WRITE, StandardOpenOption.TRUNCATE_EXISTING);

		String nextLine = null;

		while ((nextLine = reviewReader.readLine()) != null)
		{
			String posWords = posWordsReader.readLine();
			String negWords = negWordsReader.readLine();

			PolarityExtracter ex = PolarityExtracter.create(nextLine, posWords,
					negWords);

			List<String> content = ex.extract();

			for (String chunk : content)
			{
				polarizedChunksWriter.write(chunk);
				polarizedChunksWriter.newLine();
			}
		}

		polarizedChunksWriter.close();

		script = new ClassPathResource("/polarity.R").getFile().toPath();
		scriptPath = script.toAbsolutePath().toString();
		input = polarizedChunksPath.toAbsolutePath().toString();
		runScript(workingDir, scriptPath, input);
	}

	private static final void runScript(Path workingDir, String scriptPath,
			String input) throws InterruptedException, IOException
	{
		List<String> args = Arrays.asList("RScript", scriptPath, input);

		ProcessBuilder b = new ProcessBuilder(args);
		b.inheritIO();

		b.directory(workingDir.toFile());
		b.start().waitFor();
	}

	private static final Path changeExtension(Path p, String extension)
	{
		String name = p.getFileName().toString();

		int index = name.lastIndexOf(".");
		String baseName = index < 0 ? name : name.substring(0, index);

		return p.getParent().resolve(baseName + extension);
	}
}
