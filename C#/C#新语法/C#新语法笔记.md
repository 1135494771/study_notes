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

    ``` 实例
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

    - #### 关于属性赋值一些扩展说明

      ``` init 属性赋值一些扩展说明
      1. init; 只能在构函数初始化赋值 

        Records records = new Records(2);
        records.Id = 1;
        Console.WriteLine(records.Id.ToString() + " --- " + records.Name);

        public class Records
        {
          public Records(int Id)
          {
              this.Id = Id;
          }

          public int Id { get; init; }
          public string Name { get; set; } = "";
        }
      ```

      ![Image text](http://rgdm6sj3v.hn-bkt.clouddn.com/%E5%BE%AE%E4%BF%A1%E5%9B%BE%E7%89%87_20220811095054.png)

      ``` private set 属性赋值一些扩展说明
      1. private set; 可以在构造函数赋值，也可以在类内部重新赋值

        Records records = new Records(2);
        records.Id = 1;
        Console.WriteLine(records.Id.ToString() + " --- " + records.Name);

        public class Records
        {
            public Records(int Id)
            {
                this.Id = Id;
            }

            public int Id { get; private set; }
            public string Name { get; set; } = "";

            // private set 可以通过构造函数赋值、也可以通过类内部赋值
            void SetId()
            {
                this.Id = 3;
            }
        }
      ```

      ![Image text](http://rgdm6sj3v.hn-bkt.clouddn.com/%E5%BE%AE%E4%BF%A1%E5%9B%BE%E7%89%87_20220811095709.png)

    - #### Record [ˈrekɔːd] 的使用

      - #### 1. record 可以实现部分属性是只读，而部分属性是可以读写的。 record 重写了ToString()和 Equals 方法

        ```record 使用
          /* recored 也是一种的类,和类的用法差不多 */

          //第一种定义 实现属性只读
          public record Records(int Id, string Name);



          //第二种定义 实现部分属性只读，而部分属性可写
          public record Records2(int Id, string Name)
          {
              public int Age { get; set; }
              public string Address { get; set; }
          }


          /* record 练习 */

          //属性只读
          Records records = new Records(2, "小傻瓜");
          Console.WriteLine(records.ToString());

          Records2 records2 = new Records2(3, "小呆瓜");
          //部分属性可以读写
          records2.Address = "中国";
          records2.Age = 100;

          //重写了ToString 方法
          Console.WriteLine(records2.ToString());

          //重写了Equals 方法
          Console.WriteLine(Object.Equals(records, records2));

          //对比俩个对象引用地址是否相同
          Console.WriteLine(Object.ReferenceEquals(records, records2));
        ```

      - #### 2. 默认生成的构造方法的行为不能修改，我们可以为类型提供多个构造方法，然后其他构造方法通过this调用默认的构造方法

        ```record 构造方法
        public record Records2(int Id, string Name)
        {
            public int Age { get; set; }
            public string? Address { get; set; }

            //使用this 给默认构造方法赋值
            public Records2(int Id, string Name, string Address)
                : this(Id, Name)
            {
                this.Address = Address;
            }

        }
        ```

      - #### 3. record也是普通的类，变量的赋值是引用传递

      - #### 4. record创建对象副本，也叫做拷贝。赋值：引用类型而言地址值一样，如果修改了原来引用地址值，那新的对象值也会相应的发生改变；拷贝：快速的重新创建一个新的对象，地址值不相同，修改了原来引用地址值，新的修值不会发生改变。使用方法：Record cord=Recode2 with { }；

        ```record 拷贝用法
        //创建一个record对象，并通过原始构造函数初始化值
        Records2 records = new Records2(2, "小傻瓜");

        //用法一：通过拷贝的方式创建新的对象
        Records2 records2 = records with { };

        //用法二：通过拷贝的方式创建新的对象，并重新修改某些字段的值
        Records2 records3 = records with { Age=30 };

        //对比俩个对象引用地址是否相同
        Console.WriteLine(Object.ReferenceEquals(records, records3));
        ```