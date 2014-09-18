package edu.umassd.polarity;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Iterator;
import java.util.List;

/**
 * 
 * @author Dan
 *
 */
public class PolarityExtracter
{
	private List<String> sentence;
	private List<String> polarizedWords;

	public List<String> extract()
	{
		List<String> content = new ArrayList<>();

		for (int i = 0; i < sentence.size(); i++)
		{
			String word = sentence.get(i).toLowerCase();
			word = word.replaceAll("[,.():;?!\"]", "");

			Iterator<String> pIter = polarizedWords.iterator();

			while (pIter.hasNext())
			{
				String polarizedWord = pIter.next();

				if (word.equals(polarizedWord))
				{
					String grouping = extractGrouping(4, i, 2);

					content.add(extractGrouping(4, i, 2));
					pIter.remove();
					break;
				}
			}
		}

		if (polarizedWords.size() > 0)
		{
			throw new IllegalStateException("Missed some polarized words: "
					+ polarizedWords);
		}

		return content;
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

				builder.append(word(i, index));
				count++;
			}
			catch (IndexOutOfBoundsException e)
			{
				// not in bounds
			}
		}

		return builder.toString();
	}

	private String word(int index, int primaryIndex)
	{
		String word = sentence.get(index);

		if (index == primaryIndex)
		{
			return word;
		}

		String caseInsenstiveWord = word.toLowerCase();

		for (String polarizedWord : polarizedWords)
		{
			if (caseInsenstiveWord.contains(polarizedWord))
			{
				return "NEUTRAL";
			}
		}

		return word;
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
