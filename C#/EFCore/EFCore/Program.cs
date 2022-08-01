using System;
using System.Threading.Tasks;

namespace EFCore
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (MyDbContext db = new MyDbContext())
            {
                Book book = new Book();
                book.Title = "小黄书";
                book.Price = 10.233M;
                book.Author = "程某人";
                book.PubTime = DateTime.Now;
                db.Add(book);
                await db.SaveChangesAsync();
            } 
        }
    }
}
