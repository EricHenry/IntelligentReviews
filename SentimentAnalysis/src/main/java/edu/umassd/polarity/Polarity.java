package edu.umassd.polarity;

import java.io.IOException;
import java.net.URISyntaxException;
import java.nio.file.Files;
import java.nio.file.Path;
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

		Path script = new ClassPathResource("/findPolarizedWords.R").getFile()
				.toPath();

		ReviewFileWalker walker = new ReviewFileWalker();

		ClasspathUtil.walkClasspath(walker);

		// for (Path review : walker.getFiles())
		// {
		// polarity(script, review, walker);
		// }

		Path review = ClasspathUtil.path("5S_reviews/review1_engadget.txt");

		polarity(script, review, walker);
	}

	private static final void polarity(Path script, Path review,
			ReviewFileWalker walker) throws InterruptedException, IOException
	{
		Path relativeDir = walker.getRelativeToRoot(review);
		Path workingDir = Constants.POLARITY_HOME.resolve(relativeDir);
		Files.createDirectories(workingDir);

		String scriptPath = script.toAbsolutePath().toString();
		String input = review.toAbsolutePath().toString();

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
