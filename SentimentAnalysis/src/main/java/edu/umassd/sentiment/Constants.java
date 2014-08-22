package edu.umassd.sentiment;

import java.nio.file.Path;
import java.nio.file.Paths;

public class Constants
{
	public static final Path APP_DATA = Paths
			.get(System.getProperty("user.home"), ".IntelligentReviews",
					"sentiment");

	public static final Path SENTIMENT_INDEX = APP_DATA.resolve("index");
}
