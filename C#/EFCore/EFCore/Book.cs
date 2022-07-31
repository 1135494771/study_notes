using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public class Book
    {
        //主键
        public long Id { get; set; }

        //标题
        public string Title { get; set; }

        //发布日期
        public DateTime PubTime { get; set; }

        //单价
        public double Price { get; set; }
    }
}
