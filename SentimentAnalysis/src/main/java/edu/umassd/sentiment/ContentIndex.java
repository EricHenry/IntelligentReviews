package edu.umassd.sentiment;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.StandardOpenOption;
import java.util.Properties;

import javax.annotation.PostConstruct;

import org.jasypt.util.digest.Digester;
import org.springframework.stereotype.Component;

/**
 * This class maintains a list of hashes for the specified files. It is used to
 * index files and prevent recalculating results if the data hasn't changed.
 * 
 * @author Dan Avila
 */
@Component
public final class ContentIndex
{
	private Properties props = new Properties();
	private Digester digestor = new Digester("SHA-1");

	@PostConstruct
	protected void loadIndex() throws IOException
	{
		Path index = Constants.SENTIMENT_INDEX;

		if (!Files.exists(Constants.SENTIMENT_INDEX))
		{
			Files.createFile(index);
		}

		try (InputStream stream = Files.newInputStream(index,
				StandardOpenOption.READ))
		{
			props.load(stream);
		}
	}

	/**
	 * 
	 * 
	 * @param root
	 * @throws IOException
	 */
	public void updateIndex(Path root) throws IOException
	{
		String digest = getDigest(root);
		props.put(root.getFileName().toString(), new String(digest));

		Path index = Constants.SENTIMENT_INDEX;

		try (OutputStream stream = Files.newOutputStream(index,
				StandardOpenOption.WRITE))
		{
			props.store(stream,
					"This file is auto-generated, please do not modify.");
		}
	}

	public boolean hasFileContentChanged(Path root) throws IOException
	{
		Object hash = props.get(root);
		String digest = getDigest(root);

		return digest.equals(hash);
	}

	private String getDigest(Path file) throws IOException
	{
		byte[] data = Files.readAllBytes(file);
		return new String(digestor.digest(data));

	}
}
