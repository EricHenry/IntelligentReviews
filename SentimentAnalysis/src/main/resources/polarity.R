# This script runs polarity on the file provided to it. Usage:
#
# RScript polarity.R <input file>
#
# The input file must be separated onto individual lines by sentence.
# Stray punctuation must be removed.
#
# Java must be installed or the script won't run. Ensure the jvm.dll is
# available on the path.
#
# Perform the following steps in the R Console:
# > install.packages('rJava', .libPaths()[1], 'http://www.rforge.net/')

# Simple script that runs 

# Load the qdap package
library("qdap", character.only=TRUE)

args <- commandArgs(trailingOnly = TRUE)
# print(args)

sentence.data <- scan(file=args[1], what=character(), sep="\n")
graph = polarity(sentence.data)

sink("polarity-results.txt", append = FALSE)

size = length(graph$all$polarity)

for(i in 1:size) {
	
	count = 0
		
	for(word in graph$all$pos.words[i]){
		if(word != "-"){
			wordlist = word
			count = count + 1
		}
	}

	for(word in graph$all$neg.words[i]){
		if(word != "-"){
			wordlist = word
			count = count + 1
		}
	}
	
	cat(wordlist)
	cat(",")
	cat(graph$all$polarity[i])
	cat("\n")
	
	if(count != 1) {
		sink()
		print("Expected exactly 1 result, but got: ")
		print(count)
		quit(save = "default", status = 1, runLast = TRUE)
	}
}

sink()

