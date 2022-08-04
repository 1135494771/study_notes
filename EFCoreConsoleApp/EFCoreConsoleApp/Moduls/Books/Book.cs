using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleApp.Moduls.Books
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime? PubTime { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public string Introduction { get; set; }

        public override string ToString()
        {
            return @$"Books --> id：{Id}；title：{Title}；price：{Price}；pubTime：{PubTime}；
                            author：{Author}；introduction：{Introduction}；";
        }
    }
}
