using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 新语法
{
    /* recored 也是一种的类,和类的用法差不多 */

    //第一种定义 实现属性只读
    public record Records(int Id, string Name);



    //第二种定义 实现部分属性只读，而部分属性可写
    public record Records2(int Id, string Name)
    {
        public int Age { get; set; }
        public string? Address { get; set; }

        public Records2(int Id, string Name, string Address)
            : this(Id, Name)
        {
            this.Address = Address;
        }

    }
}
