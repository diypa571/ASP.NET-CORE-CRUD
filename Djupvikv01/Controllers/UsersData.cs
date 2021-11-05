using Djupvikv01.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;



namespace Djupvikv01.Controllers
{
internal class UsersData
{


private string connectionString = @"Data Source = (localdb)\mssqllocaldb;Initial Catalog = djupvikdb; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


public List<UsersModel> hamtaUsers()
{
List<UsersModel> userslist = new List<UsersModel>();

using (SqlConnection connection = new SqlConnection(connectionString))
{
string sqlQuery = "SELECT * FROM  users";
SqlCommand command = new SqlCommand(sqlQuery, connection);
connection.Open();
SqlDataReader lasIn = command.ExecuteReader();

if (lasIn.HasRows)
{
while (lasIn.Read())
{
   UsersModel user = new UsersModel();
user.id = lasIn.GetInt32(0);
user.anvandarnamn = lasIn.GetString(1);
user.namn = lasIn.GetString(2);
user.email = lasIn.GetString(3);
user.losenord = lasIn.GetString(4);
user.datum = lasIn.GetString(5);
userslist.Add(user);
}}}
return userslist;
}







/*

// Följande metod för att hämta en post för detaljer  om posten 
public UsersModel hamtaDetailUsers(int id)
{


using (SqlConnection connection = new SqlConnection(connectionString))
{


// string sqlQuery = "SELECT * from dbo.artikel";

// string sqlQuery = "SELECT  artikel.id,  artikel.rubrik, artikeltyp.artikeltyp FROM artikel INNER JOIN artikeltyp ON artikeltyp.id = artikel.artikeltyp";

string sqlQuery = "SELECT artikel.id,  users.namn , artikeltyp.artikeltyp, artikel.rubrik,  artikel.sammanfattning, artikel.innehall,  artikel.bild,  artikel.datum  FROM (((artikel INNER JOIN artikeltyp ON artikel.artikeltyp = artikeltyp.id) INNER JOIN users ON artikel.forfattare = users.id)) WHERE artikel.id = @id";


SqlCommand command = new SqlCommand(sqlQuery, connection);
command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
connection.Open();
SqlDataReader lasIn = command.ExecuteReader();

UsersModel article = new UsersModel();
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









public int CreateOrUpdateUsers(UsersModel arModel)
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
sqlQuery = "UPDATE dbo.artikel SET rubrik = @rubrik, sammanfattning = @sammanfattning , innehall = @innehall , bild = @bild , datum = @datum  WHERE id = @id";

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






internal int DeleteUsers(int id)
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





// Search for
internal List<UsersModel> FindUsers(string keyword)
{
List<UsersModel> dataList = new List<UsersModel>();
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
UsersModel article = new UsersModel();
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

*/
}




}
