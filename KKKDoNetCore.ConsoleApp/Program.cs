using KKKDoNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//Connect Database
/*SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = "."; //Server name
stringBuilder.InitialCatalog = "KKKDoNetCore"; //database name
stringBuilder.UserID = "sa"; // Server Id
stringBuilder.Password = "sa@123";// Server password

SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

connection.Open();
Console.WriteLine("Connection Open.");

string query = "select * from tbl_blog";
SqlCommand cmd = new SqlCommand(query, connection); // select * from command call tar
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); // new qurery call p command write lo ya aung load tar
DataTable dt = new DataTable();
sqlDataAdapter.Fill(dt);


connection.Close(); 
Console.WriteLine("Connection Close.");

foreach(DataRow dr in dt.Rows)
{
    Console.WriteLine("Blog Id => " + dr["BlogId"]);
    Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
    Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
    Console.WriteLine("Blog Content => " + dr["BlogContent"]);
    Console.WriteLine("--------------------------------------------");
}


Console.ReadKey();*/
//Ado.net (CRUD)
//AdoDoNetExample adoDoNetExample = new AdoDoNetExample();
////adoDoNetExample.Read();
//adoDoNetExample.Create("title", "author", "content");
////adoDoNetExample.Update(10, "title 1", "author 1", "content 1");
////adoDoNetExample.Delete(10);
////adoDoNetExample.Update(9, "title test", "test author","test content");
////adoDoNetExample.Delete(11);
////adoDoNetExample.Edit(11);
////adoDoNetExample.Edit(1);

//Dapper (CRUD)
DapperExample dapperExample = new DapperExample();
dapperExample.Run();
Console.ReadLine();