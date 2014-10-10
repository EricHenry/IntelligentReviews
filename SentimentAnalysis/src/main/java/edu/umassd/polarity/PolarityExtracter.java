package edu.umassd.polarity;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Iterator;
import java.util.List;

/**
 * This class converts R's standard output into polarity for individual words.
 * 
 * @author Dan Avila
 *
 */
public class PolarityExtracter
{
	private List<String> sentence;
	private List<String> polarizedWords;

	/**
	 * Creates sentence chunks around each polarized word, which are then fed
	 * into R for an actual polarity.
	 * 
	 * @return a list of context clusters.
	 */
	public List<String> extract()
	{
		List<String> remainingPolWords = new ArrayList<>(polarizedWords);
		List<String> content = new ArrayList<>();

		for (int i = 0; i < sentence.size(); i++)
		{
			Iterator<String> pIter = remainingPolWords.iterator();

			while (pIter.hasNext())
			{
				String[] polarizedWord = pIter.next().split(" ");

				if (checkForPolarizedWord(i, polarizedWord))
				{
					int start = i;
					int end = start + polarizedWord.length - 1;

					String grouping = extractGrouping(4, start, end, 2);

					content.add(grouping);
					pIter.remove();
					break;
				}
			}
		}

		if (remainingPolWords.size() > 0)
		{
			throw new IllegalStateException("Missed some polarized words: "
					+ remainingPolWords);
		}

		return content;
	}

	private boolean checkForPolarizedWord(int index, String[] polarizedWord)
	{
		String[] words = new String[polarizedWord.length];

		for (int i = 0; i < polarizedWord.length; i++)
		{
			words[i] = sentence.get(index + i).toLowerCase();
			words[i] = clean(words[i]);
		}

		return Arrays.equals(words, polarizedWord);
	}

	private String extractGrouping(int wordsBefore, int startIndex,
			int endIndex, int wordsAfter)
	{
		StringBuilder builder = new StringBuilder();

		int count = 0;
		for (int i = startIndex - wordsBefore; i <= endIndex + wordsAfter; i++)
		{
			try
			{
				if (count > 0)
				{
					builder.append(" ");
				}

				count += word(i, startIndex, endIndex, builder);
				count++;
			}
			catch (IndexOutOfBoundsException e)
			{
				// not in bounds
			}
		}

		return builder.toString();
	}

	private String clean(String word)
	{
		return word.replaceAll("[,.():;?!\"]", "").replace("-", "");
	}

	private int word(int index, int startIndex, int endIndex, StringBuilder b)
	{
		if (startIndex <= index && index <= endIndex)
		{
			b.append(sentence.get(index));
			return 1;
		}

		for (String polarizedWord : polarizedWords)
		{
			String[] words = polarizedWord.split(" ");
			int match = 0;

			for (int i = 0; i < words.length; i++)
			{
				int targetIndex = index + i;

				if (startIndex <= targetIndex && targetIndex <= endIndex)
				{
					break;
				}

				String word = sentence.get(targetIndex);
				String caseInsenstiveWord = clean(word.toLowerCase());

				if (caseInsenstiveWord.equals(words[i]))
				{
					match++;
				}
			}

			if (match == words.length)
			{
				for (int i = 0; i < words.length; i++)
				{
					b.append("NEUTRAL ");
				}

				return match;
			}
		}

		b.append(sentence.get(index));
		return 1;
	}

	public static PolarityExtracter create(String sentence, String posWords,
			String negWords)
	{
		PolarityExtracter extractor = new PolarityExtracter();

		extractor.sentence = Arrays.asList(sentence.split(" "));
		extractor.polarizedWords = new ArrayList<String>();
		extractor.polarizedWords.addAll(Arrays.asList(posWords.split(",")));
		extractor.polarizedWords.addAll(Arrays.asList(negWords.split(",")));

		while (extractor.polarizedWords.remove(""))
			;
		while (extractor.polarizedWords.remove("-"))
			;

		return extractor;
	}
}
