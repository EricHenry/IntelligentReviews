using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace IRController
{
    public class ReviewCleaner
    {
        private static string[] wordFilter = {"a", "then", "that", "when", "of", "the", "and", "there", "where", "what", 
											"or", " ", "\n", " to", "from", "your", "not", "get", "you", "this", "", 
											"it", "to", "is", "in", "as", "for", "its", "but", "on", "than", "at", "an",
											"i", "my", "if", "with", "can", "Samsung", "s5", "S5", "Galaxy", "galaxy", "more", 
											"use", "HTC", "M8", "about", "much", "thats", "like", "isnt", "still", "even", "phone",
											 "terms", "been", "will", "be", "5s", "5S", "iPhone", "LG", "G3", "Id", "LG G3", "One",
											 "look", "so", "were", "any", "we", "which", "are", "iOS", "all", "Apple", "now", "have",
											 "Moto", "X", "Moto X", "MotoX", "Droid", "Motorola", "Motorolas", "S4", "Jelly", "Bean",
											 "Android", "Xs", "youll", "out", "Nexus", "5", "KitKat", "Google", "GS4", "Now", "Microsoft", "Microsofts", 
											 "Nokia", "Lumia", "1520", "Windows", "by", "has", "", " "};

        private static string[] punctuationFilter = { "(", ")", ",", "\"", "&", "^", "", "?", "!", ".", "", };
        
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
        public void cleanReviews(String input, String output)
        {
            // get text file
            try
            {
                inputReview = new StreamReader(@input);
            }
            catch (Exception e)
            {
                MessageBox.Show("Invalid Input File");
            }

            //maniplulate data
            sentenceList = getSentences(inputReview);
            cleanedSentenceList = convertToCommaSeparated(sentenceList);

            //final check before writing to file
            finalCheck();

            //write to new file
            try
            {
                System.IO.File.WriteAllLines(@output, cleanedSentenceList);
            }
            catch(Exception e)
            {
                MessageBox.Show("Could Not Save");
            }
            MessageBox.Show("Review converted to CSV!");
        }

        /**
         * place all sentences in a file into a list
         * each node in that list will be one sentence
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
                   
                    //store each senetence in a list
                    foreach (string sentence in splitSentences)
                    {
                        //sentence.Replace
                     // Console.WriteLine(sentence);
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
                        currentWord = clearPunctuation(currentWord);
                        
                        //check to see if at the last word of sentence
                        if (i != (wordCollection.Length - 1))
                            currentWord += ", ";

                        //Console.WriteLine(currentWord);

                        //add each word into a sentence
                        if (!currentWord.Equals(", ", StringComparison.OrdinalIgnoreCase))
                            commaSeparatedSentence += currentWord;

                       // Console.WriteLine(currentWord);
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

        /**
         * Remove punctuation from the word.
         */
        private string clearPunctuation(string toBeCleaned)
        {
            //checks to see if the current word contains a hyphen or a forward slash
            //replaces them with a space character
            if (toBeCleaned.Contains("-"))
                return toBeCleaned = toBeCleaned.Replace("-", ", ");

            if (toBeCleaned.Contains("/"))
                return toBeCleaned = toBeCleaned.Replace("/", ", ");

            //checks if the current word does not contain a period followed by a number. 
            //for cases ex:"4.4.2"
            if (!toBeCleaned.Contains(@"(?<=\.)\d\b"))
            {
                toBeCleaned = Regex.Replace(toBeCleaned, @"[^\w\s]", "");
            }

            return toBeCleaned;
        }

        private void finalCheck()
        {
            String currentSentence;
            for (int i = 0; i < cleanedSentenceList.Count; i++)
            {
                currentSentence = cleanedSentenceList[i];
                if (currentSentence.Contains(",,") || currentSentence.Contains(" ,"))
                {
                    //Console.WriteLine(currentSentence);
                    currentSentence = currentSentence.Replace(",,", ",");
                    currentSentence = currentSentence.Replace(" ,", "");
                    cleanedSentenceList.RemoveAt(i);
                    cleanedSentenceList.Insert(i, currentSentence);
                   // Console.WriteLine(currentSentence);

                }
            }
        }

    }
}