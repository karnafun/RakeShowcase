using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShowDatabaseTestResults : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDropDownList();
        }
        ShowResults();
    }

    protected void FillDropDownList()
    {

        ddl_maxWords.Items.Add("1");
        ddl_maxWords.Items.Add("2");
        ddl_maxWords.Items.Add("3");
        ddl_maxWords.SelectedIndexChanged += Ddl_maxWords_SelectedIndexChanged;
    }
    protected void ShowResults()
    {
        int length = int.Parse(ddl_maxWords.SelectedValue);
        List<Keyword> res = new Keyword().KeywordsByWordsLength(length);

        string htmlSTR = "<table>";
        htmlSTR += "<thead><tr>";
        htmlSTR += "<th>Test Id </th>";
        htmlSTR += "<th>Minimum char Length</th>";
        htmlSTR += "<th>Maximum Words Lenght</th>";
        htmlSTR += "<th>Minimum Word Frequency</th>";
        htmlSTR += "<th>Keyword</th>";
        htmlSTR += "<th>Score </th>";
        htmlSTR += "</tr></thead>";
        htmlSTR += "<tbody>";
        for (int i = 0; i < res.Count; i++)
        {
            htmlSTR += "<tr>";

            htmlSTR += "<td> " + res[i].testId + " </td>";
            htmlSTR += "<td> " + res[i].minCharLength + " </td>";
            htmlSTR += "<td> " + res[i].maxWordsLength + " </td>";
            htmlSTR += "<td> " + res[i].minWordsFreq + " </td>";
            htmlSTR += "<td> " + res[i].name + " </td>";
            htmlSTR += "<td> " + res[i].score + " </td>";
            htmlSTR += "</tr>";

        }
        htmlSTR += "</tbody></table>";
        div_res.InnerHtml = htmlSTR;
    }
    private void Ddl_maxWords_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowResults();
    }
}