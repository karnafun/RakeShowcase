using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TestResult
/// </summary>
public class Keyword
{
    public int testId,minCharLength,maxWordsLength,minWordsFreq;
    public double score;
    public string name;
    public Keyword()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Keyword(int testId, int minCharLength, int maxWordsLength, int minWordsFreq, string name,double score)
    {
        this.testId = testId;
        this.minCharLength = minCharLength;
        this.maxWordsLength = maxWordsLength;
        this.minWordsFreq = minWordsFreq;
        this.name = name;
        this.score = score;
    }

    public List<Keyword> KeywordsByWordsLength(int length)
    {
        return new DBServices().GetKeywordsByWordsLength(length);
    }
}