library("qdap", character.only=TRUE)

export <- function(wordVector, fileName) {
	# Output to the given file.
	sink(fileName, append = FALSE)
	
	for(word in wordVector){
		cat(word, "\n")
	}
	
	sink()
}

export(qdapDictionaries::positive.words, "positive.txt")
export(qdapDictionaries::negative.words, "negative.txt")
export(qdapDictionaries::amplification.words, "amplifiers.txt")
export(qdapDictionaries::deamplification.words, "deamplification.txt")
export(qdapDictionaries::negation.words, "negators.txt")