package edu.umassd.sentiment;

import java.nio.file.Path;

import edu.stanford.nlp.sentiment.Evaluate;

public class EvaluateRunner
{
	public static void main(String... args)
	{
		Path location = Constants.APP_DATA.resolve("review1_Engadget.treebank");

		evaluate("-model",
				"edu/stanford/nlp/models/sentiment/sentiment.ser.gz",
				"-treebank", location.toString());
	}

	private static void evaluate(String... args)
	{
		Evaluate.main(args);
	}
}
