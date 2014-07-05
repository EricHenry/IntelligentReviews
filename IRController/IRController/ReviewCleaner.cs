using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
/// <summary>
/// Summary description for Class1
/// </summary>
namespace IRController
{
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
        private List<string> sentenceList;
        private List<string> cleanedSentenceList;

        public ReviewCleaner()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        /**
         * Controller method envokes other methods to clean reviews
         */
        //public void cleanReviews(string inputFile, string outputFile)
        public void cleanReviews()
        {
            // get text file
            inputReview = new StreamReader(@"C:\Users\Eric Henry\Documents\GitHub\IntelligentReviews\IRController\IRController\resources\Review Collection\5S_reviews\review2_TheVerge.txt");

            Console.WriteLine("got review");

            sentenceList = getSentences(inputReview);

            Console.WriteLine("got sentence list");

            cleanedSentenceList = convertToCommaSeparated(sentenceList);

            Console.WriteLine("got cleaned list");

            System.IO.File.WriteAllLines(@"C:\Users\Eric Henry\Documents\GitHub\IntelligentReviews\IRController\IRController\resources\CleanTester.basket", cleanedSentenceList);

            Console.WriteLine("write to file");
        }

        /**
         * TODO -> comment
         * 
         */
        public List<string> getSentences(StreamReader review)
        {
            string line;
            List<string> list = new List<string>();

            //read in each line of the file
            while ((line = review.ReadLine()) != null)
            {
                //check if the line read in is empty
                if (!String.IsNullOrWhiteSpace(line))
                {
                    //multiple sentences can be in a line, split each one
                    string[] splitSentences = Regex.Split(line, @"(?<=[\.!\?])\s");
                    Console.WriteLine("ADD SENTENCE");
                    //store each senetence in a list
                    foreach (string sentence in splitSentences)
                    {
                        Console.WriteLine(sentence);
                        list.Add(sentence);
                    }
                }
            }

            return list;
        }

        /**
         * 
         * 
         */
        private List<string> convertToCommaSeparated(List<string> sentenceCollection)
        {
            List<string> CSList = new List<string>();

            //go through each sentence in the list
            foreach (string sentence in sentenceCollection)
            {
                //split each sentence at the black space separating them
                string[] wordCollection = sentence.Split(' ');

                string commaSeparatedSentence = "";

                //for each word in current sentence
                for (int i = 0; i < wordCollection.Length; i++)
                {
                    string currentWord = wordCollection[i];
                    //check if the current word should be filtered.
                    if (keepWord(currentWord))
                    {
                        //check to see if at the last word of sentence
                        if (i != (wordCollection.Length - 1))
                            currentWord += ", ";

                        //add each word into a sentence
                        commaSeparatedSentence += currentWord;
                    }

                }

                //insert comma separated sentence into a list
                CSList.Add(commaSeparatedSentence);
            }

            return CSList;

        }


        /**
         * Returns true if the word is in the list of words to be filtered
         */
        private bool keepWord(String word)
        {
            foreach (string garbageWord in wordFilter)
            {
                //check the word passed to the function is part of the filtering list
                if (word.Equals(garbageWord, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }

    }
}