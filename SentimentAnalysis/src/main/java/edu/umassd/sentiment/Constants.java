package edu.umassd.sentiment;

import java.nio.file.Path;
import java.nio.file.Paths;

public class Constants
{
	public static final Path APP_DATA = Paths.get(
			System.getProperty("user.home"), ".IntelligentReviews");

	public static final Path SENTIMENT_HOME = APP_DATA.resolve("sentiment");
	public static final Path SENTIMENT_INDEX = SENTIMENT_HOME.resolve("index");

	public static final Path POLARITY_HOME = APP_DATA.resolve("polarity");
}
