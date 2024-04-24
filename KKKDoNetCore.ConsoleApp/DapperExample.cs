using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KKKDoNetCore.ConsoleApp;

internal class DapperExample
{
    public void Run()
    {
        //Read();
        //Edit(1);
        //Edit(11);
        //Create("title11", "author11", "content11");
        //Update(13, "title13", "authorA", "content13");
        Delete(13);
    }
    //Read
    private void Read()
    {
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        List<BlogDto> lst = db.Query<BlogDto>("select * from tbl_blog").ToList();

        foreach(var item in lst)
        {
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("----------------------------------");
        }
    }
    //Edit
    private void Edit(int id)
    {
       using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
       var item= db.Query("select * from tbl_blog where BlogId=@BlogId", new BlogDto { BlogId = id }).FirstOrDefault();
        if(item is null)
        {
            Console.WriteLine("Data not found.");
            return;
        }
        Console.WriteLine(item.BlogId);
        Console.WriteLine(item.BlogTitle);
        Console.WriteLine(item.BlogAuthor);
        Console.WriteLine(item.BlogContent);
    }
    //Create
    private void Create(string title,string author,string content)
    {
        var item = new BlogDto
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        int result= db.Execute(query, item);

        string message = result > 0 ? "Saving Successful." : "Saving Failed.";
        Console.WriteLine(message);
    }
    //Update
    private void Update( int id,string title, string author, string content)
    {
        var item = new BlogDto
        {
            BlogId=id,
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId =@BlogId";
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, item);

        string message = result > 0 ? "Updating Successful." : "Updating Failed.";
        Console.WriteLine(message);
    }
    //Delete
    private void Delete(int id)
    {
        var item = new BlogDto
        {
            BlogId = id,
        };
        string query = @"DELETE [dbo].[Tbl_Blog] WHERE BlogId =@BlogId";
        using IDbConnection db = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, item);

        string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
        Console.WriteLine(message);
    }
}
