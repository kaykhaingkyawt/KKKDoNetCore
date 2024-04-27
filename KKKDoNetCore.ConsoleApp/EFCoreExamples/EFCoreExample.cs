using KKKDoNetCore.ConsoleApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKKDoNetCore.ConsoleApp.EFCoreExamples;

internal class EFCoreExample
{
    private readonly AppDbContext db = new AppDbContext();
    public void Run()
    {
        //Read();
        //Edit(1);
        //Edit(8);
        //Create("title11", "author11", "content11");
        // Update(14, "title13", "authorA", "content13");
        Delete(14);
    }
    //Read
    private void Read()
    {
        var lst = db.Blogs.ToList();

        foreach (var item in lst)
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
        var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            Console.WriteLine("No Data Found");
            return;
        }
        Console.WriteLine(item.BlogId);
        Console.WriteLine(item.BlogTitle);
        Console.WriteLine(item.BlogAuthor);
        Console.WriteLine(item.BlogContent);
    }
    //Create
    private void Create(string title, string author, string content)
    {
        var item = new BlogDto
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };
        db.Blogs.Add(item);
        int result = db.SaveChanges();

        string message = result > 0 ? "Saving Successful." : "Saving Failed.";
        Console.WriteLine(message);
    }
    //Update
    private void Update(int id, string title, string author, string content)
    {
        var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            Console.WriteLine("No Data Found");
            return;
        }
        item.BlogTitle = title;
        item.BlogAuthor = author;
        item.BlogContent = content;

        int result = db.SaveChanges();

        string message = result > 0 ? "Updating Successful." : "Updating Failed.";
        Console.WriteLine(message);
    }
    //Delete
    private void Delete(int id)
    {
        var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            Console.WriteLine("No Data Found");
            return;
        }

        db.Blogs.Remove(item);

        int result = db.SaveChanges();

        string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
        Console.WriteLine(message);
    }
}
