using EFCoreConsoleApp.Moduls;
using EFCoreConsoleApp.Moduls.Books;
using EFCoreConsoleApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //查询语句
            var data= Select();
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }

            ////批量添加
            //BulkInsert();
        }

        static void BulkInsert()
        {
            List<Book> books = new List<Book>();
            for (int i = 0; i < 2; i++)
            {
                int rand = RandomHelper.GetRandom();
                books.Add(new Book { Title = "图书名" + rand, Price = rand, PubTime = DateTime.Now, Author = "无名氏" + rand, Introduction = (rand * 3).ToString() });
            }
            using (CqxDBContext Db = new CqxDBContext())
            {
                Db.BulkInsert(books);
            }
        }

        static IEnumerable<Book> Select()
        {
            using (CqxDBContext Db = new CqxDBContext())
            {
                var temp = Db.Books.Skip(1).Take(2).ToList();
                return temp;
            }
        }
    }
}
