__author__ = 'Eric Henry'

import Orange

def clean():
    print

try:
    data = Orange.data.Table("results3.basket")
except IOError:
    print "Error can\'t find file or read data"

minimumSupport = 0.01
supportToLow = True

#Find the lowest support value that gives an output
while supportToLow:
    try:
        rules = Orange.associate.AssociationRulesSparseInducer(data, support = minimumSupport)
        supportToLow = False
    except:
        minimumSupport += 0.001


try:
    resultsFile = open('test1.txt', 'w')
except IOError:
    print "Error can\'t find file or read data"

resultsFile.write("%5s    %5s     %s\n" % ("supp", "conf", "Rule"))
#print "%5s  %5s   %s" % ("supp", "conf", "Rule")
i = 0
for r in rules:
    resultsFile.write("%5.5f   %5.5f   %s\n" % (r.support, r.confidence, r))
   # print "%5.3f   %5.3f   %s" % (r.support, r.confidence, r)

resultsFile.close();

#resultsFile.close()

#try to find associations based on the frequency of an adjective or
# verb phrases.

#write file instead of on console.

#find the key word
    #use the polarity to find a sentence
    #use the found sentence to run through NLP
    #look through type dependency to see what polarity word is matched with

#to-do
#use nlp to parse through reviews
#try to reconfigure orange 
