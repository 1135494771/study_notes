using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//取消了namespace下的大括号
namespace 新语法;

internal class AAA
{
    public void SSS()
    {
        //原来写法
        using (var conn_1 = new SqlConnection(""))
        {
            conn_1.Open();
        }

        //新的语法
        using var conn_2 = new SqlConnection("");
    }
}



