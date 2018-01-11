using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for DBServices
/// </summary>
public class DBServices
{
    string connectionString = WebConfigurationManager.ConnectionStrings["test2DBConnectionString"].ConnectionString;
    protected SqlConnection con;
    protected SqlCommand cmd;
    protected DataTable dt;
    protected SqlDataAdapter da;
    protected SqlDataReader reader;

    public DBServices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void UploadTestResults(RAKETest test)
    {
        try
        {
            con = new SqlConnection(connectionString);
            string cmdStr = "insert into RakeTestResults values(" + test.id + ",' " + test.articleTitle + "', " + test.minCharLength +
                ", " + test.maxWordsLength + ", " + test.minWordsFreq + ")";
            cmd = new SqlCommand(cmdStr, con);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmdStr = "";
            foreach (var keyword in test.testResults)
            {
                //cmdStr= 
                cmd.CommandText = "insert into KeywordsInTest values(" + test.id + ",'" + keyword.Key + "','"+keyword.Value+"')";
                cmd.ExecuteNonQuery();
            }
            
            cmd.Connection.Close();
        }
        catch (Exception ex)
        {
            var t = ex;

        }
        finally { cmd.Connection.Close(); }
    }

    public RAKETest GetTestById(int id)
    {
        try
        {
            con = new SqlConnection(connectionString);
            con.Open();

            string cmdStr = "select * from KeywordsInTest where testId = " + id;
            Dictionary<string,double> results = new Dictionary<string, double>();
            cmd = new SqlCommand(cmdStr, con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                results.Add(reader[1].ToString(),int.Parse(reader[2].ToString()));
            }

             cmdStr = "select top(1) from RakeTestResults where testId = " + id;
            cmd = new SqlCommand(cmdStr, con);
            reader = cmd.ExecuteReader();
            reader.Read();
            int minCharLength = int.Parse(reader[2].ToString());
            int maxWordsLength = int.Parse(reader[3].ToString());
            int minWordsFreq = int.Parse(reader[4].ToString());
            string articleTitle = reader[1].ToString();

            return new RAKETest(results, id, minCharLength, maxWordsLength, minWordsFreq, articleTitle);
           
        }
        catch (Exception ex)
        {

            var t = ex;
            return null;
        }
        finally { con.Close(); }
    }



    public List<Keyword> GetKeywordsByWordsLength(int length)
    {
        try
        {
            con = new SqlConnection(connectionString);
            List<Keyword> res = new List<Keyword>();
            con.Open();

            string cmdSTR = "select * from TestAndResults where maxWordsLength =" + length;
            cmdSTR += "order by score desc";
            cmd = new SqlCommand(cmdSTR, con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int testId = int.Parse(reader[0].ToString()); ;
                string articleTitle = reader[1].ToString();
                int minCharLength = int.Parse(reader[2].ToString());
                int maxWordsLength = int.Parse(reader[3].ToString());
                int minWordsFreq = int.Parse(reader[4].ToString());
                string name= reader[5].ToString();
                double score = double.Parse(reader[6].ToString());
                res.Add(new Keyword(testId, minCharLength, maxWordsLength, minWordsFreq, name, score));
            }
            return res;
            




            

        }
        catch (Exception ex)
        {

            var t = ex;
            return null;
        }
        finally { con.Close(); }
    }
}