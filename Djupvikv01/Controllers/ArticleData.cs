using Djupvikv01.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;



namespace Djupvikv01.Controllers
{
internal class ArticleData
{


private string connectionString = @"Data Source = (localdb)\mssqllocaldb;Initial Catalog = djupvikdb; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
// Here we the operations for the database, select, delete,update,


public List<ArticleModel> hamta()
{
List<ArticleModel> dataList = new List<ArticleModel>();
// Access the database

using (SqlConnection connection = new SqlConnection(connectionString))
{
// string sqlQuery = "SELECT * from dbo.artikel";

// string sqlQuery = "SELECT  artikel.id,  artikel.rubrik, artikeltyp.artikeltyp FROM artikel INNER JOIN artikeltyp ON artikeltyp.id = artikel.artikeltyp";


string sqlQuery = "SELECT artikel.id,  users.namn , artikeltyp.artikeltyp, artikel.rubrik,  artikel.sammanfattning, artikel.innehall,  artikel.bild,  artikel.datum  FROM((artikel INNER JOIN artikeltyp ON artikel.artikeltyp = artikeltyp.id) INNER JOIN users ON artikel.forfattare = users.id)";


SqlCommand command = new SqlCommand(sqlQuery, connection);
connection.Open();
SqlDataReader lasIn = command.ExecuteReader();


if (lasIn.HasRows)
{
while (lasIn.Read())
{
ArticleModel article = new ArticleModel();
article.id = lasIn.GetInt32(0);
article.forfattare = lasIn.GetString(1);
article.artikeltyp = lasIn.GetString(2);
article.rubrik = lasIn.GetString(3);

article.sammanfattning = lasIn.GetString(4);
article.innehall = lasIn.GetString(5);
article.bild = lasIn.GetString(6);
article.datum = lasIn.GetString(7);
dataList.Add(article);
}}}


return dataList;
}



public ArticleModel hamtaDetail(int id)
{

using (SqlConnection connection = new SqlConnection(connectionString))
{
string sqlQuery = "SELECT artikel.id,  users.namn , artikeltyp.artikeltyp, artikel.rubrik,  artikel.sammanfattning, artikel.innehall,  artikel.bild,  artikel.datum  FROM (((artikel INNER JOIN artikeltyp ON artikel.artikeltyp = artikeltyp.id) INNER JOIN users ON artikel.forfattare = users.id)) WHERE artikel.id = @id";

SqlCommand command = new SqlCommand(sqlQuery, connection);
command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
connection.Open();
SqlDataReader lasIn = command.ExecuteReader();

ArticleModel article = new ArticleModel();
if (lasIn.HasRows)
{
while (lasIn.Read())
{

article.id = lasIn.GetInt32(0);
article.forfattare = lasIn.GetString(1);
article.artikeltyp = lasIn.GetString(2);
article.rubrik = lasIn.GetString(3);
article.sammanfattning = lasIn.GetString(4);
article.innehall = lasIn.GetString(5);
article.bild = lasIn.GetString(6);
article.datum = lasIn.GetString(7);

}
}
return article;
}
}





 



public int CreateOrUpdate(ArticleModel arModel)
{
using (SqlConnection connection = new SqlConnection(connectionString))
{

string sqlQuery = "";
if (arModel.id <= 0)
{
sqlQuery = "INSERT INTO dbo.artikel Values(@forfattare,@artikeltyp,@rubrik,@sammanfattning,@innehall,@bild,@datum)";
}
else
{
//  sqlQuery = "UPDATE dbo.artikel SET forfattare = @forfattare, artikeltyp = @artikeltyp, rubrik = @rubrik, sammanfattning = @sammanfattning , innehall = @innehall , bild = @bild , datum = @datum  WHERE id = @id";
sqlQuery = "UPDATE dbo.artikel SET artikeltyp = @artikeltyp,  rubrik = @rubrik, sammanfattning = @sammanfattning , innehall = @innehall , bild = @bild , datum = @datum  WHERE id = @id";

}

SqlCommand command = new SqlCommand(sqlQuery, connection);
command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = arModel.id;
command.Parameters.Add("@forfattare", System.Data.SqlDbType.VarChar, 1000).Value = arModel.forfattare;
command.Parameters.Add("@artikeltyp", System.Data.SqlDbType.VarChar, 1000).Value = arModel.artikeltyp;
command.Parameters.Add("@rubrik", System.Data.SqlDbType.VarChar, 1000).Value = arModel.rubrik;
command.Parameters.Add("@sammanfattning", System.Data.SqlDbType.VarChar, 1000).Value = arModel.sammanfattning;
command.Parameters.Add("@innehall", System.Data.SqlDbType.VarChar, 1000).Value = arModel.innehall;
command.Parameters.Add("@bild", System.Data.SqlDbType.VarChar, 1000).Value = arModel.bild;
command.Parameters.Add("@datum", System.Data.SqlDbType.VarChar, 1000).Value = arModel.datum;

connection.Open();
int newItem = command.ExecuteNonQuery();
return newItem;
}
}




     
internal int Delete(int id)
{
using (SqlConnection connection = new SqlConnection(connectionString))
{
string sqlQuery = "DELETE From dbo.artikel WHERE id = @id";


SqlCommand command = new SqlCommand(sqlQuery, connection);
command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

connection.Open();
int RemovedItem = command.ExecuteNonQuery();
return RemovedItem;
}
}


 
  internal List<ArticleModel> Find(string keyword)
{
List<ArticleModel> dataList = new List<ArticleModel>();
// Access the database
using (SqlConnection connection = new SqlConnection(connectionString))
{
string sqlQuery = "SELECT artikel.id,  users.namn , artikeltyp.artikeltyp, artikel.rubrik,  artikel.sammanfattning, artikel.innehall,  artikel.bild,  artikel.datum  FROM (((artikel INNER JOIN artikeltyp ON artikel.artikeltyp = artikeltyp.id) INNER JOIN users ON artikel.forfattare = users.id)) WHERE artikel.rubrik  LIKE @keyword";

SqlCommand command = new SqlCommand(sqlQuery, connection);
command.Parameters.Add("@keyword", System.Data.SqlDbType.NVarChar).Value = "%" + keyword + "%";
connection.Open();
SqlDataReader lasIn = command.ExecuteReader();
if (lasIn.HasRows)
{
while (lasIn.Read())
{
ArticleModel article = new ArticleModel();
article.id = lasIn.GetInt32(0);
article.forfattare = lasIn.GetString(1);
article.artikeltyp = lasIn.GetString(2);
article.rubrik = lasIn.GetString(3);
article.sammanfattning = lasIn.GetString(4);
article.innehall = lasIn.GetString(5);
article.bild = lasIn.GetString(6);
article.datum = lasIn.GetString(7);
dataList.Add(article);
}
}
}

return dataList;
}




internal List<ArticleModel> Fil(string author)
{
    List<ArticleModel> filtList = new List<ArticleModel>();
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string sqlQuery = "SELECT artikel.id,  users.namn , artikeltyp.artikeltyp, artikel.rubrik,  artikel.sammanfattning, artikel.innehall,  artikel.bild,  artikel.datum  FROM (((artikel INNER JOIN artikeltyp ON artikel.artikeltyp = artikeltyp.id) INNER JOIN users ON artikel.forfattare = users.id)) WHERE artikel.forfattare  = @author";
        SqlCommand command = new SqlCommand(sqlQuery, connection);
        command.Parameters.Add("@author", System.Data.SqlDbType.NVarChar).Value = author;
        connection.Open();
        SqlDataReader lasIn = command.ExecuteReader();
        if (lasIn.HasRows)
        {
            while (lasIn.Read())
            {
                ArticleModel articlefilt = new ArticleModel();
                articlefilt.id = lasIn.GetInt32(0);
                articlefilt.forfattare = lasIn.GetString(1);
                articlefilt.artikeltyp = lasIn.GetString(2);
                articlefilt.rubrik = lasIn.GetString(3);
                articlefilt.sammanfattning = lasIn.GetString(4);
                articlefilt.innehall = lasIn.GetString(5);
                articlefilt.bild = lasIn.GetString(6);
                articlefilt.datum = lasIn.GetString(7);
                filtList.Add(articlefilt);
            }
        }
    }

    return filtList;
}



  internal List<ArticleModel> Sorting(string sort)
        {
            List<ArticleModel> filtList = new List<ArticleModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";
               if (@sort=="id")
                {
                  sqlQuery = "SELECT artikel.id,  users.namn , artikeltyp.artikeltyp, artikel.rubrik,  artikel.sammanfattning, artikel.innehall,  artikel.bild,  artikel.datum  FROM (((artikel INNER JOIN artikeltyp ON artikel.artikeltyp = artikeltyp.id) INNER JOIN users ON artikel.forfattare = users.id)) Order By id Desc";

                }
               else if (@sort == "datum")
                {
                sqlQuery = "SELECT artikel.id,  users.namn , artikeltyp.artikeltyp, artikel.rubrik,  artikel.sammanfattning, artikel.innehall,  artikel.bild,  artikel.datum  FROM (((artikel INNER JOIN artikeltyp ON artikel.artikeltyp = artikeltyp.id) INNER JOIN users ON artikel.forfattare = users.id)) Order By datum ASC";

                }

                else if (@sort == "title")
                {
                    sqlQuery = "SELECT artikel.id,  users.namn , artikeltyp.artikeltyp, artikel.rubrik,  artikel.sammanfattning, artikel.innehall,  artikel.bild,  artikel.datum  FROM (((artikel INNER JOIN artikeltyp ON artikel.artikeltyp = artikeltyp.id) INNER JOIN users ON artikel.forfattare = users.id)) Order By rubrik ASC";
                }


               else
                {
               sqlQuery = "SELECT artikel.id,  users.namn , artikeltyp.artikeltyp, artikel.rubrik,  artikel.sammanfattning, artikel.innehall,  artikel.bild,  artikel.datum  FROM (((artikel INNER JOIN artikeltyp ON artikel.artikeltyp = artikeltyp.id) INNER JOIN users ON artikel.forfattare = users.id)) Order By id Desc";

                }
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.Add("@sort", System.Data.SqlDbType.NVarChar).Value = sort;
                connection.Open();
                SqlDataReader lasIn = command.ExecuteReader();
                if (lasIn.HasRows)
                {
                    while (lasIn.Read())
                    {
                        ArticleModel articlefilt = new ArticleModel();
                        articlefilt.id = lasIn.GetInt32(0);
                        articlefilt.forfattare = lasIn.GetString(1);
                        articlefilt.artikeltyp = lasIn.GetString(2);
                        articlefilt.rubrik = lasIn.GetString(3);
                        articlefilt.sammanfattning = lasIn.GetString(4);
                        articlefilt.innehall = lasIn.GetString(5);
                        articlefilt.bild = lasIn.GetString(6);
                        articlefilt.datum = lasIn.GetString(7);
                        filtList.Add(articlefilt);
                    }
                }
            }

            return filtList;
        }





    }
}
 