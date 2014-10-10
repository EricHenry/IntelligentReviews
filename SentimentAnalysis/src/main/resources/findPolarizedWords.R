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

export <- function(wordVector, fileName) {
	# Output to the given file.
	sink(fileName, append = FALSE)
	
	for(wordGroup in wordVector){
		
		size = length(wordGroup)
		
		for(i in 1:size){
		
			if(i > 1) { cat(",") }
			cat(wordGroup[i])
		}
		
		cat("\n")
	}
	
	sink()
}

# Load the qdap package
library("qdap", character.only=TRUE)

args <- commandArgs(trailingOnly = TRUE)
print(args)

sentence.data <- scan(file=args[1], what=character(), sep="\n")
graph = polarity(sentence.data)

export(graph$all$pos.words, "positive-words.txt")
export(graph$all$neg.words, "negative-words.txt")