using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DisplayResults();
    }






    protected void DisplayResults()
    {
           //get rake and text reults
           TextCheating cheat = new TextCheating();
        string stopListPath = MapPath(".") + "/Files/SmartStoplist.txt";
        Rake rake = new Rake(stopListPath,1,20,1);
        sample1.Text = cheat.Sample1();
        var results = rake.Run(cheat.Sample1());

        //calculate results vs expected
        var resultsString = results.Keys.ToArray();
        var expected = cheat.Expected();
        var match = KeywordsFound(resultsString, expected);
        var topResults = TopResults(results);
        var missed = KeywordsMissed(resultsString, expected);
        var newKeywords = NewKeywords(topResults, expected);
        //place in form

        lbl_expected.Text = ReadyForDisplayLabel(expected,"Expected:");
        lbl_newWords.Text = ReadyForDisplayLabel(newKeywords, "New Keywords:");
        lbl_match.Text = ReadyForDisplayLabel(match,"Matches:");
        lbl_misses.Text = ReadyForDisplayLabel(missed,"Missed Keywords:");


    }


    protected IList<string> KeywordsFound(IList<string> results, IList<string> expected)
    {
        List<string> res = new List<string>();
        foreach (string item in results)
        {
            if (item == "upper bound")
            {
                var t = 0;
            }
            if (expected.Contains(item))
            {
                res.Add(item);
            }
        }
        return res;
    }


    protected IList<string> KeywordsMissed(IList<string> results, IList<string> expected)
    {
        List<string> res = new List<string>();
        foreach (string item in expected)
        {
            if (!results.Contains(item))
            {
                res.Add(item);
            }
        }
        return res;
    }

    protected IList<string> NewKeywords(IList<string> results, IList<string> expected)
    {
        List<string> res = new List<string>();
        foreach (var item in results)
        {
            if (!expected.Contains(item))
            {
                res.Add(item);
            }
        }
        return res;
    }


    protected IList<string> TopResults(Dictionary<string, double> dict)
    {
        List<string> res = new List<string>();
        foreach (string item in dict.Keys)
        {
            if (dict[item] >= 4)
            {
                res.Add(item);
            }
        }
        return res;
    }
    protected IList<string> TrimAndLower(IList<string> list)
    {
        List<string> res = new List<string>();
        foreach (var item in list)
        {
            res.Add(item.Trim().ToLower());
        }
        return res;
    }



    protected string ReadyForDisplayLabel(IList<string> list,string title)
    {
        string res ="<span style='color:red;'>"+ title+"</span><br>";

        int counter = 1; //Why not use for loop ya lazy fucker?
        foreach (var item in list)
        {
            res += "<span style='color:darkBlue;'>"+ (counter++)+")  "+item+"</span>";

            if (list.Last()!=item)
            {
                res += "<br> ";
            }
        }

        return res;
    }
}