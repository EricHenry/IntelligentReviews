package edu.umassd.util;

import java.io.IOException;
import java.net.URISyntaxException;
import java.net.URL;
import java.nio.file.FileVisitor;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Collections;
import java.util.Enumeration;
import java.util.List;

import org.springframework.core.io.ClassPathResource;

public final class ClasspathUtil
{
	private ClasspathUtil()
	{

	}

	public static Path path(String name) throws IOException
	{
		return new ClassPathResource(name).getFile().toPath();
	}

	public static void walkClasspath(FileVisitor<Path> visitor)
			throws IOException, URISyntaxException
	{
		ClassLoader loader = Thread.currentThread().getContextClassLoader();
		Enumeration<URL> en = loader.getResources("");
		List<URL> resources = Collections.list(en);

		for (URL url : resources)
		{
			Path p = Paths.get(url.toURI());

			Files.walkFileTree(p, visitor);
		}
	}
}
