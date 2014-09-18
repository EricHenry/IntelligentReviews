package edu.umassd.polarity;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * 
 * @author Dan
 *
 */
public class PolarityExtracter
{
	private List<String> sentence;
	private List<String> polarizedWords;

	private Map<String, Integer> occurences = new HashMap<String, Integer>();

	public List<String> extract()
	{
		for (String polarizedWord : polarizedWords)
		{
			occurences.put(polarizedWord, 0);
		}

		List<String> content = new ArrayList<>();
		for (String polarizedWord : polarizedWords)
		{
			Integer count = occurences.get(polarizedWord);

			String next = findNextOccurence(count, polarizedWord);
			content.add(next);

			occurences.put(polarizedWord, count + 1);
		}

		return content;
	}

	private String findNextOccurence(Integer count, String polarizedWord)
	{
		for (int i = 0; i < sentence.size(); i++)
		{
			String word = sentence.get(i);

			if (word.contains(polarizedWord))
			{
				if (count == 0)
				{
					return extractGrouping(4, i, 2);
				}
				else
				{
					count--;
				}
			}
		}

		throw new IllegalStateException("Count not find word: " + polarizedWord);
	}

	private String extractGrouping(int wordsBefore, int index, int wordsAfter)
	{
		StringBuilder builder = new StringBuilder();

		int count = 0;
		for (int i = index - wordsBefore; i <= index + wordsAfter; i++)
		{
			try
			{
				if (count > 0)
				{
					builder.append(" ");
				}

				builder.append(sentence.get(i));
				count++;
			}
			catch (IndexOutOfBoundsException e)
			{
				// not in bounds
			}
		}

		return builder.toString();
	}

	public static PolarityExtracter create(String sentence, String posWords,
			String negWords)
	{
		PolarityExtracter extractor = new PolarityExtracter();

		extractor.sentence = Arrays.asList(sentence.split(" "));
		extractor.polarizedWords = new ArrayList<String>();
		extractor.polarizedWords.addAll(Arrays.asList(posWords.split(" ")));
		extractor.polarizedWords.addAll(Arrays.asList(negWords.split(" ")));

		while (extractor.polarizedWords.remove(""))
			;
		while (extractor.polarizedWords.remove("-"))
			;

		return extractor;
	}
}
