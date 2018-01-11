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
            MapPath(".") + "/Files/Amit Article Text/Not_all_is_Gold_that_Glitters_Response_t.txt"));
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

        // var topResults = results.OrderByDescending(pair => pair.Value).Take(5); 
        //var topResults = GetTopResults(results, amountOfResults);

        Dictionary<string, double> f = GetTopResults2(results, amountOfResults);
        lbl_res.Text = ToLabelString(f);
    }

    protected List<string> GetTopResults(Dictionary<string, double> dict, int top)
    {


        var maxRating = dict.Values.Max();
        maxRating = Math.Round(maxRating);
        List<string> best = new List<string>();

        for (int i = (int)maxRating; i > 0; i--)
        {

            foreach (var item in dict.Keys)
            {
                if (dict[item] >= i && !best.Contains(item))
                {
                    best.Add(item + ", " + dict[item]);
                    if (best.Count == top)
                    {
                        return best;
                    }
                }
            }

        }

        return best;

    }


    protected Dictionary<string, double> GetTopResults2(Dictionary<string, double> dict, int top)
    {
        List<KeyValuePair<string, double>> dictList = dict.ToList();

        dictList.Sort(
            delegate (KeyValuePair<string, double> pair1,
            KeyValuePair<string, double> pair2)
            {
                return pair2.Value.CompareTo(pair1.Value);
            }
        );

        Dictionary<string, double> res = new Dictionary<string, double>();
        foreach (var item in dictList)
        {
            res.Add(item.Key, item.Value);
            if (res.Count == top)
            {
                return res;
            }
        }


        return res;
    }
    protected string ToLabelString(Dictionary<string, double> dict)
    {
        List<string> list = dict.Keys.ToList();
        string res = "";
        int counter = 1;
        foreach (var item in list)
        {
            res += (counter++) + ") " + item + ", " + dict[item] + "<br>";
        }
        return res;
    }

    protected void SubmitBtn_Click(object sender, EventArgs e)
    {

        RunRakeWithUserParams();
        //BigRakeTestAttempt(); - Database ! 

    }

    protected void BigRakeTestAttempt()
    {
        string stopListPath = MapPath(".") + "/Files/SmartStoplist.txt";
        int minCharLength = 1;
        int maxWordsLength = 1;
        int minWordsFreq = 1;
        string articleTitle = articleDDL.Items[articleDDL.SelectedIndex].ToString();
        string text = File.ReadAllText(articleDDL.SelectedValue);
        Rake rake;
        RAKETest rt = new RAKETest();



        int id = 1;
        List<Dictionary<string, double>> allResults = new List<Dictionary<string, double>>();
        for (int i = 1; i < 4; i++)
        {
            for (int j = 1; j < 5; j++)
            {
                for (int k = 1; k < 6; k++)
                {
                    maxWordsLength = i;
                    minCharLength = j;
                    minWordsFreq = k;
                    rake = new Rake(stopListPath, minCharLength, maxWordsLength, minWordsFreq);
                    var results = rake.Run(text);
                    var temp = GetTopResults2(results, 30);
                    allResults.Add(temp);


                    rt.AddTest(new RAKETest(temp, (id), minCharLength, maxWordsLength, minWordsFreq, articleTitle));

                    id++;
                }
            }
        }

        //Console.WriteLine(allResults);
    }



}