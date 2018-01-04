using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TryRake : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submitBTN_Click(object sender, EventArgs e)
    {
        string stopListPath = MapPath(".") + "/Files/SmartStoplist.txt";
        Rake rake = new Rake(stopListPath, 1, 20, 1);
        string text = textTB.Text;
        var results = rake.Run(text);

        string res = "";
        int counter = 1;
        foreach (var item in results.Keys)
        {
            if (results[item] >= 4)
            {
                res += (counter++) + ") " + item;
                if (results.Keys.Last() != item)
                {
                    res += "<br>";
                }
            }
        }

        lbl_results.Text = res;
    }
}