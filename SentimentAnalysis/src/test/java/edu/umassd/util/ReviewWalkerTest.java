package edu.umassd.util;

import java.io.IOException;
import java.net.URISyntaxException;
import java.nio.file.Path;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import org.junit.Test;

import edu.umassd.sentiment.Constants;

public class ReviewWalkerTest
{
	@Test
	public void verifyWalker() throws IOException, URISyntaxException
	{
		ReviewFileWalker walker = new ReviewFileWalker();
		ClasspathUtil.walkClasspath(walker);

		List<Path> paths = new ArrayList<>(walker.getFiles());
		Collections.sort(paths);

		for (Path p : paths)
		{
			Path rel = walker.getRelativeToRoot(p);

			System.err.println(Constants.APP_DATA.resolve(rel));
		}
	}
}
