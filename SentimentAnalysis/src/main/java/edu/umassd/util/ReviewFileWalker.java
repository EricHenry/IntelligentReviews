package edu.umassd.util;

import java.io.IOException;
import java.nio.file.FileVisitResult;
import java.nio.file.Path;
import java.nio.file.SimpleFileVisitor;
import java.nio.file.attribute.BasicFileAttributes;
import java.util.Arrays;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class ReviewFileWalker extends SimpleFileVisitor<Path>
{
	private static final List<String> IGNORE = Arrays.asList("CombinedReviews",
			"CleanedReviews");

	private Set<Path> files = new HashSet<Path>();

	private Path root = null;

	@Override
	public FileVisitResult preVisitDirectory(Path dir, BasicFileAttributes attrs)
			throws IOException
	{
		if (root == null)
		{
			root = dir;
		}

		String name = dir.getFileName().toString();

		if (IGNORE.contains(name))
		{
			return FileVisitResult.SKIP_SUBTREE;
		}

		return super.preVisitDirectory(dir, attrs);
	}

	@Override
	public FileVisitResult visitFile(Path file, BasicFileAttributes attrs)
			throws IOException
	{
		String name = file.toString();

		if (name.endsWith(".txt") && !name.contains("_comb"))
		{
			files.add(file.toAbsolutePath());
		}

		return super.visitFile(file, attrs);
	}

	public Path getRoot()
	{
		return root;
	}

	public Set<Path> getFiles()
	{
		return files;
	}

	public Path getRelativeToRoot(Path file)
	{
		return root.relativize(file);
	}
}