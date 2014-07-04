using System;
using IO;
/// <summary>
/// Summary description for Class1
/// </summary>
public class ReviewCleaner
{
    private static String[] wordFilter = {"a", "then", "that", "when", "of", "the", "and", "there", "where", "what", 
											"or", " ", "\n", " to", "from", "your", "not", "get", "you", "this", "", 
											"it", "to", "is", "in", "as", "for", "its", "but", "on", "than", "at", "an",
											"i", "my", "if", "with", "can", "Samsung", "s5", "S5", "Galaxy", "galaxy", "more", 
											"use", "HTC", "M8", "about", "much", "thats", "like", "isnt", "still", "even", "phone",
											 "terms", "been", "will", "be", "5s", "5S", "iPhone", "LG", "G3", "Id", "LG G3", "One",
											 "look", "so", "were", "any", "we", "which", "are", "iOS", "all", "Apple", "now", "have",
											 "Moto", "X", "Moto X", "MotoX", "Droid", "Motorola", "Motorolas", "S4", "Jelly", "Bean",
											 "Android", "Xs", "youll", "out", "Nexus", "5", "KitKat", "Google", "GS4", "Now", "Microsoft", "Microsofts", 
											 "Nokia", "Lumia", "1520", "Windows", "by"};

    private int wordCount;
    private StreamReader inputReview;
    //private 

	public ReviewCleaner()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /**
     * Controller method envokes other methods to clean reviews
     */
    public void cleanReviews(){
        // get text file
        inputReview = new StreamReader(@"Review Collection\5S_reviews\review2_TheVerge.txt");
        
    }



}
