using EFCoreConsoleApp.Moduls;
using EFCoreConsoleApp.Moduls.Books;
using EFCoreConsoleApp.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ////查询语句
            //var data = QueryData();
            //foreach (var item in data)
            //{
            //    Console.WriteLine(item);
            //}

            ////异步批量添加
            //await BulkInsert();

            ////异步批量修改
            //await BatchUpdate();

            ////异步批量删除
            //await BatchDelete();

        }

        static async Task BulkInsert()
        {
            List<Book> books = new List<Book>();
            for (int i = 0; i < 2; i++)
            {
                int rand = RandomHelper.GetRandom();
                books.Add(new Book { Title = "图书名" + rand, Price = rand, PubTime = DateTime.Now, Author = "无名氏" + rand, Introduction = (rand * 3).ToString() });
            }
            using (CqxDBContext Db = new CqxDBContext())
            {
                await Db.BulkInsertAsync(books);
            }
        }

        static async Task BatchUpdate()
        {
            using (CqxDBContext Db = new CqxDBContext())
            {
                await Db.BatchUpdate<Book>()
                    .Set(b => b.Price, b => b.Price + 3)
                    .Set(b => b.Title, b => b.Title + b.Title)
                    .Set(b => b.Author, b => b.Title.Substring(1, 3) + b.Author.ToUpper())
                    .Set(b => b.PubTime, DateTime.Now)
                    .Where(b => b.Id > 1 && b.Introduction.Contains("9"))
                    .ExecuteAsync();
            }
        }
        static async Task BatchDelete()
        {
            using (CqxDBContext Db = new CqxDBContext())
            {
                await Db.DeleteRangeAsync<Book>(x => x.Price < 30 || x.Introduction.Contains("6"));
            }
        }

        static IEnumerable<Book> QueryData()
        {
            using (CqxDBContext Db = new CqxDBContext())
            {
                IQueryable<Book> temp = Db.Books.Skip(1).Take(2);
                string str = temp.ToQueryString();
                return temp.ToList();
            }
        }
    }
}
