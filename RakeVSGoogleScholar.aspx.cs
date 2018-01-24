using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RakeVSGoogleScholar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       List<string> results = new TextCheating().BestResultsOnHackers();
        
    }

    protected IList<string> CompareRake(ExampleArticles article, KeywordResources resource = KeywordResources.ALL, int minCharLength = 1, int maxWordsLength = 5, double minWordFreq = 1)
    {
        string stopListPath = MapPath(".") + "/Files/SmartStoplist.txt";
        TextCheating txtCheats = new TextCheating();
        IList<string> keywords = txtCheats.ExpectedKeywords(ExampleArticles.HackersTopologyMatterGeography, KeywordResources.ALL);
        Rake rake = new Rake(stopListPath, minCharLength, maxWordsLength, minWordFreq);
        var resultsDict = rake.Run(txtCheats.GetArticleText(ExampleArticles.HackersTopologyMatterGeography));
        var results = resultsDict.Keys.ToList();


        List<string> fullMatch = new List<string>();
        Dictionary<string, string> resultsInKeywords = new Dictionary<string, string>();
        Dictionary<string, string> keywordsInResults = new Dictionary<string, string>();
        List<string> missedYouNoob = new List<string>();
        for (int i = 0; i < keywords.Count; i++)
        {
            bool match = false;
            for (int j = 0; j < results.Count; j++)
            {
                string _res = results[j].ToLower().Trim();
                string _keyword = keywords[i].ToLower().Trim();
                if (_res == _keyword)
                {
                    match = true;
                    if (!fullMatch.Contains(_keyword))
                    {
                        fullMatch.Add(_keyword);
                    }
                }
                else if (_res.Contains(" " + _keyword + " "))
                {
                    if (!keywordsInResults.Keys.Contains(_keyword))
                    {
                        keywordsInResults.Add(_keyword, _res);
                    }
                }
                else if (_keyword.Contains(" " + _res + " "))
                {
                    if (!resultsInKeywords.Keys.Contains(_res))
                    {
                        resultsInKeywords.Add(_res, _keyword);
                    }
                }
            }
            if (!match)
            {
                missedYouNoob.Add(keywords[i]);
            }
        }
        var t = "";
        Dictionary<string, double> fullMatchScores = new Dictionary<string, double>();
        for (int i = 0; i < fullMatch.Count; i++)
        {
            fullMatchScores.Add(fullMatch[i], resultsDict[fullMatch[i]]);
            t += fullMatch[i] + "\r\n";
        }

        return fullMatch;


    }

    /// <summary>
    /// Gets the 4 and 3 words phrases 
    /// </summary>
    /// <param name="article">Which article to extract from</param>
    /// <returns>List of phrases with 3 or 4 words</returns>
    protected List<string> GetLongPhrases(ExampleArticles article)
    {
        string stopListPath = MapPath(".") + "/Files/SmartStoplist.txt";
        TextCheating txtCheats = new TextCheating();
        string articleText = new TextCheating().GetArticleText(ExampleArticles.HackersTopologyMatterGeography);
        Rake rake = new Rake(stopListPath, 1, 4, 2); 
        var resultsDict = rake.Run(articleText);
        List<string> fourWordsList = new List<string>();
        List<string> threeWordsList = new List<string>();

        foreach (string phrase in resultsDict.Keys)
        {
            int numOfWords = phrase.Split(' ').Length;
            if (numOfWords == 4)
            {
                
                fourWordsList.Add(phrase);
            }
            else if (numOfWords == 3)
            {
                threeWordsList.Add(phrase );
            }
        }
        List<string> FinalKeywordsCandidates = new List<string>();
        FinalKeywordsCandidates.AddRange(fourWordsList);
        FinalKeywordsCandidates.AddRange(threeWordsList);
        return FinalKeywordsCandidates;
    }

    protected List<string> GetTwoWordPhrases(ExampleArticles article)
    {
        int minCharLength = 1; //I fuck up when i change this
        int maxWordsCount = 2;//we need 2 words for this
        int minWordFreq = 2; //When i do 3, i miss most of the 2 word phrases found by scholar

        string stopListPath = MapPath(".") + "/Files/SmartStoplist.txt";
        TextCheating txtCheats = new TextCheating();
        string articleText = new TextCheating().GetArticleText(ExampleArticles.HackersTopologyMatterGeography);
        Rake rake = new Rake(stopListPath, minCharLength, maxWordsCount,minWordFreq); 
        var resultsDict = rake.Run(articleText);
        List<string> twoWordsList = new List<string>();

        foreach (string phrase in resultsDict.Keys)
        {
            int numOfWords = phrase.Split(' ').Length;
            if (numOfWords == 2)
            {

                twoWordsList.Add(phrase);
            }
            
        }
        return twoWordsList;
    }

    protected List<string> GetOneWordKeywords(ExampleArticles article)
    {
        int minCharLength = 1; //I fuck up when i change this
        int maxWordsCount = 2;//we need one word, but how does that effect our scoring?
        int minWordFreq = 7; //When i do 3, i miss most of the 2 word phrases found by scholar

        string stopListPath = MapPath(".") + "/Files/SmartStoplist.txt";
        TextCheating txtCheats = new TextCheating();
        string articleText = new TextCheating().GetArticleText(ExampleArticles.HackersTopologyMatterGeography);
        Rake rake = new Rake(stopListPath, minCharLength, maxWordsCount, minWordFreq);
        var resultsDict = rake.Run(articleText);
        List<string> oneWordList = new List<string>();

        foreach (string phrase in resultsDict.Keys)
        {
            int numOfWords = phrase.Split(' ').Length;
            if (numOfWords == 1)
            {
                oneWordList.Add(phrase);
            }

        }
        return oneWordList;
    }
}