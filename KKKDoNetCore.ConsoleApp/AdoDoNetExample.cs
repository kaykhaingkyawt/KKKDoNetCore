using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection.Metadata;

namespace KKKDoNetCore.ConsoleApp
{
    internal class AdoDoNetExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {

            DataSource = ".", //Server name
            InitialCatalog = "KKKDoNetCore",//database name
            UserID = "sa", // Server Id
            Password = "sa@123",// Server password

        };

        //Read
     public void Read()
        {
           
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection Open.");

            string query = "select * from tbl_blog";
            SqlCommand cmd = new SqlCommand(query, connection); // select * from command call tar
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); // new qurery call p command write lo ya aung load tar
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);


            connection.Close();
            Console.WriteLine("Connection Close.");

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Blog Id => " + dr["BlogId"]);
                Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
                Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content => " + dr["BlogContent"]);
                Console.WriteLine("--------------------------------------------");
            }

           

        }

        //Edit

        public void Edit(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection Open.");

            string query = "select * from tbl_blog where BlogId=@BlogId;";
            SqlCommand cmd = new SqlCommand(query, connection); // select * from command call tar

            //Insert parameter
            cmd.Parameters.AddWithValue("@BlogId", id);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); // new qurery call p command write lo ya aung load tar
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);


            connection.Close();
            Console.WriteLine("Connection Close.");

            if(dt.Rows.Count == 0)
            {
                Console.WriteLine("Data not found.");
                return;
            }

            DataRow dr = dt.Rows[0];
            
                Console.WriteLine("Blog Id => " + dr["BlogId"]);
                Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
                Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content => " + dr["BlogContent"]);
                Console.WriteLine("--------------------------------------------");
            
        }


        // Create
        public void Create(string title,string author,string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection Open.");

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            SqlCommand cmd = new SqlCommand(query, connection);

            //Insert Parameter
            cmd.Parameters.AddWithValue("@BlogTitle",title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            //Make Execute
            int result= cmd.ExecuteNonQuery();

            connection.Close();
            Console.WriteLine("Connection Close.");

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }

        // Update

        public void Update(int id,string title,string author,string content)
        {

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection Open.");

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId =@BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);

            //Insert Parameter
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            //Make Execute
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            Console.WriteLine("Connection Close.");

            string message = result > 0 ? "Updating Successful." : "Updating Failed";
            Console.WriteLine(message);
        }

        //Delete
        public void Delete(int id)
        {

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection Open.");

            string query = @"delete from Tbl_Blog where BlogId =@BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);

            //Insert Parameter
            cmd.Parameters.AddWithValue("@BlogId", id);
           
            //Make Execute
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            Console.WriteLine("Connection Close.");

            string message = result > 0 ? "Delete Successful." : "Delete Failed";
            Console.WriteLine(message);
        }
    }
}
