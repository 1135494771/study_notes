# [C# 新语法](#新语法)

## 目录

- ### 顶级语法（c# 9.0）

  - #### 1、直接在C#文件中直接编写入口方法的代码，不用类、不用Main。也支持经典写法

  - #### 2、同一个项目中只能有一个文件具有顶级语句

  - #### 3、顶级语句中可以直击使用await语法，可以声明函数

    ![Image text](http://rgdm6sj3v.hn-bkt.clouddn.com/%E5%BE%AE%E4%BF%A1%E5%9B%BE%E7%89%87_20220810095700.png)

  - #### 4、顶级语句中可以直击写类方法，并调用

    ![Image text](http://rgdm6sj3v.hn-bkt.clouddn.com/%E5%BE%AE%E4%BF%A1%E5%9B%BE%E7%89%87_20220810100524.png)

- ### 全局using 指令（c# 10.0）

  - #### 1、将global 修饰符添加到using前，这个命名空间就应用到整个项目，不用引用重复using

  - #### 2、通常创建一个专门管理全局using代码的C#文件

  - #### 3、如果csproj中启用了 <ImplicitUsings>enable</ImplicitUsings>，编译器会自动隐试增加对于System、System.Linq常用命名空间的引入，不同各类型项目引入的命名空间也不一样

- ### using资源管理（c# 10.0）

  - #### 当代码执行离开作用域时，对象就会被释放
  
    - ``` 实例1
      //原来写法
      using (var conn_1 = new SqlConnection(""))
      {
          conn_1.Open();
      }

      //新的语法
      using var conn_2 = new SqlConnection("");
      ```

    - ``` 实例2
      //手动创建代码块-作用域
      {
          using var stream = File.OpenWrite(@"E:\practice\C#\ConsoleApp2\测试.txt");
          using var writer = new StreamWriter(stream);
          writer.Write("你好，傻逼2");
      }
      var context = File.ReadAllText(@"E:\practice\C#\ConsoleApp2\测试.txt");
      Console.WriteLine(context);
      ```
      ![Image text](http://rgdm6sj3v.hn-bkt.clouddn.com/%E5%BE%AE%E4%BF%A1%E5%9B%BE%E7%89%87_20220810215926.png)

- ### 文件范围的命名空间声明（c# 10.0）

  - #### 区别：在以前版本中，类型或者方法必须定义在namespace中；在新版本中 取消了namespace下的大括号，可以把namespace 当作一个引用来使用，类型或者方法可以不用定义在namespace 中

  - ``` 实例
    //原来写法
    namespace 新语法
    {
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
    }


    //新的写法
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
    ```
    ![Image text](http://rgdm6sj3v.hn-bkt.clouddn.com/%E5%BE%AE%E4%BF%A1%E5%9B%BE%E7%89%87_20220810220235.png)

  - ### record 类型（c# 9.0）

    - 