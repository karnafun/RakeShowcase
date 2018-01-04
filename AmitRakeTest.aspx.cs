using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AmitRakeTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillArticleTable();
            minCharLengthDDL.SelectedIndex = 0;
            maxWordsLengthDDL.SelectedIndex = 2;
            minKeywordFreqDDL.SelectedIndex = 4;
            topTB.Text = "10";
        }

    }

    protected void FillArticleTable()
    {

        List<ListItem> items = new List<ListItem>();
        items.Add(new ListItem("Not all is Gold that Glitters...",
            MapPath(".") + "/Files/Amit Article Text/EngagingStudentsinanMISCoursethroughtheCreationofE-Busi.txt"));
        items.Add(new ListItem("Knowledge and Social Networks In Yahoo...",
           MapPath(".") + "/Files/Amit Article Text/knowledge_and_Social_Networks_in_Yahoo_Answers_HICSS_12092011.txt"));
        items.Add(new ListItem("Hackers Tepology Matter Geography...",
           MapPath(".") + "/Files/Amit Article Text/Hackers_Topology_Matter_Geography.txt"));
        items.Add(new ListItem("Engraging Students in an MISC Course...",
            MapPath(".") + "/Files/Amit Article Text/EngagingStudentsinanMISCoursethroughtheCreationofE-Busi.txt"));

        foreach (var item in items)
        {
            articleDDL.Items.Add(item);
        }
    }

    protected void RunRakeWithUserParams()
    {
        string stopListPath = MapPath(".") + "/Files/SmartStoplist.txt";
        int minCharLength = int.Parse(minCharLengthDDL.SelectedValue);
        int maxWordsLength = int.Parse(maxWordsLengthDDL.SelectedValue);
        int minWordsFreq = int.Parse(minKeywordFreqDDL.SelectedValue);
        int amountOfResults = int.Parse(topTB.Text);
        Rake rake = new Rake(stopListPath, minCharLength, maxWordsLength, minWordsFreq);

        string text = File.ReadAllText(articleDDL.SelectedValue);
        var results = rake.Run(text);

        int minRating;
        if (minKeywordRatingDDL.SelectedValue.ToLower() == "optional")
        {
            minRating = 0;
        }
        else
        {
            minRating = int.Parse(minKeywordRatingDDL.SelectedValue);
        }



        //Get top results


        var topResults = GetTopResults(results, amountOfResults);


        //print to screen
        //string res = "";

        //foreach (var item in results.Keys)
        //{
        //    if (results[item] >= minRating)
        //    {
        //        res += item + "<br>";
        //    }
        //}

        lbl_res.Text = ToLabelString(topResults) ;
    }

   protected IList<string> GetTopResults(Dictionary<string,double> dict,int top)
    {
        var maxRating = dict.Values.Max();
        maxRating = Math.Round(maxRating);
        List<string> best = new List<string>();

        for (int i = (int)maxRating; i > 0; i--)
        {

            foreach (var item in dict.Keys)
            {
                if (dict[item]>=i &&!best.Contains(item))
                {
                    best.Add(item);
                    if (best.Count==top)
                    {
                        return best;
                    }
                }
            }

        }

        return best;
       
    }

    protected string ToLabelString(IList<string> list)
    {
        string res = "";
        int counter = 1;
        foreach (var item in list)
        {
            res += (counter++) + ") " + item + "<br>";
        }
        return res;
    }

    protected void SubmitBtn_Click(object sender, EventArgs e)
    {

        RunRakeWithUserParams();
       
    }

}