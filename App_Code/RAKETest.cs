using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RAKETest
/// </summary>
public class RAKETest
{
    public int minCharLength, maxWordsLength, minWordsFreq, id;
    public Dictionary<string,double> testResults;
    public string articleTitle;
   
    public RAKETest()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public RAKETest(Dictionary<string, double> testResults, int id,int minCharLength, int maxWordsLength, int minWordsFreq,string articleTitle)
    {
        this.testResults = testResults;
        this.minCharLength = minCharLength;
        this.maxWordsLength = maxWordsLength;
        this.minWordsFreq = minWordsFreq;
        this.articleTitle = articleTitle;
        this.id = id;
    }

    public void AddTest(RAKETest test)
    {
        new DBServices().UploadTestResults(test);
    }

    public List<RAKETest> GetTests()
    {
        return null;
    }
}