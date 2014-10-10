package edu.umassd.polarity;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.StandardOpenOption;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collection;
import java.util.List;

public class PolarityToCSV
{
	public static final PolarityToCSV create(Path workingDir)
	{
		PolarityToCSV polarity = new PolarityToCSV();
		polarity.negWordsPath = workingDir.resolve("negative-words.txt");
		polarity.posWordsPath = workingDir.resolve("positive-words.txt");
		polarity.results = workingDir.resolve("polarity-results.txt");
		polarity.output = workingDir.resolve("polarity.csv");
		polarity.polarizedChunk = workingDir.resolve("polarized-chunks.txt");

		return polarity;
	}

	private Path results;
	private Path output;

	private Path posWordsPath;
	private Path negWordsPath;
	private Path polarizedChunk;

	public void export() throws IOException
	{
		BufferedReader resultsReader = Files.newBufferedReader(results);
		BufferedReader posWordsReader = Files.newBufferedReader(posWordsPath);
		BufferedReader negWordsReader = Files.newBufferedReader(negWordsPath);
		BufferedReader polarizedChunkReader = Files
				.newBufferedReader(polarizedChunk);

		BufferedWriter outputWriter = Files.newBufferedWriter(output,
				StandardOpenOption.CREATE, StandardOpenOption.WRITE,
				StandardOpenOption.TRUNCATE_EXISTING);

		String nextPosList = null;
		String nextNegList = null;
		String nextPolarizedChunk = null;

		int line = 0;
		while ((nextPosList = posWordsReader.readLine()) != null)
		{
			nextNegList = negWordsReader.readLine();
			nextPolarizedChunk = polarizedChunkReader.readLine();

			List<String> polarizedWords = new ArrayList<String>();
			polarizedWords.addAll(Arrays.asList(nextPosList.split(",")));
			polarizedWords.addAll(Arrays.asList(nextNegList.split(",")));

			while (polarizedWords.remove(""))
				;
			while (polarizedWords.remove("-"))
				;

			int size = polarizedWords.size();

			List<Result> positives = new ArrayList<>();
			List<Result> negatives = new ArrayList<>();

			while (size > 0)
			{
				Result result = Result.buildFrom(resultsReader.readLine(),
						nextPolarizedChunk);

				if (result.getPolarity() >= 0.0)
				{
					positives.add(result);
				}
				else
				{
					negatives.add(result);
				}

				size--;
			}

			Double sum = 0.0;
			sum = sentenceVector(positives, sum);
			sum = sentenceVector(negatives, sum);

			outputWriter.write(Integer.toString(line));
			outputWriter.write(",");
			outputWriter.write(Double.toString(sum));
			outputWriter.write(",");
			write(positives, outputWriter);
			outputWriter.write(",");
			write(negatives, outputWriter);
			outputWriter.newLine();

			line++;
		}

		outputWriter.close();
	}

	private void write(List<Result> results, BufferedWriter outputWriter)
			throws IOException
	{
		for (int i = 0; i < results.size(); i++)
		{
			Result result = results.get(i);
			outputWriter.write(result.toString());
			outputWriter.write(";");
		}

		if (results.size() == 0)
		{
			outputWriter.write("-");
		}
	}

	private Double sentenceVector(Collection<Result> results, Double base)
	{
		double value = base;

		for (Result result : results)
		{
			value += result.getPolarity();
		}

		return value;
	}

	private static final class Result
	{
		private Double polarity;
		private String word;

		public Double getPolarity()
		{
			return polarity;
		}

		private static final Result buildFrom(String value,
				String polarizedChunk)
		{
			if (value == null)
			{
				throw new IllegalArgumentException("value cannot be null.");
			}

			double multiplier = Math.sqrt(polarizedChunk.split(" ").length);

			Result r = new Result();

			String[] data = value.split(":");
			r.word = data[0];
			r.polarity = Double.valueOf(data[1]) * multiplier;
			return r;
		}

		@Override
		public String toString()
		{
			return word + ":" + polarity;
		}
	}
}
