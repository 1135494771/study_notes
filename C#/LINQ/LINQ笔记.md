# [LINQ](#LINQ)

## 目录

- ### 委托
  
  - 概念:委托是可以指向方法的类型，调用委托变量时执行的就是变量指向的方法
  - 基础概述：
    - 委托类型派生自.NET Framework中的System.Delegate类，委托类型是封装的，所以不能被派生
    - 委托是一种数据类型，和类是同级的
    - 通常将委托分为命名方法委托、多播委托、匿名委托
  - 语法使用：
    - 委托的声明：delegate  返回类型  委托名 (参数)
    - 委托的实例化：委托名 实例化名 = new 委托名 (函数名) 或 委托名 实例化名=函数名
    - 匿名方法实例化：委托类型  实例化名 = delegate ( 函数参数 ) { 函数体 }
    - 调用委托：委托名( 参数 )

    - ```说明：
      举例：int i=5； 这句意思，整数类型i 指向 整数类型 5
      ```

    - ```例子：
      //自定义命名委托
      public delegate void dele_method();

      public class Program
      {
          static void Main(string[] args)
          {
              //对委托进行实例化
              dele_method dele = method;
              //调用委托
              dele();
          }

          //定义方法
          static void method()
          {
              Console.WriteLine("hello world ！");
          }
      }

      总结：dele_method 这个委托 指向 method 这个方法
      ```

  - .NET 中定义了泛型类型的委托Action(无返回值)和Func(有返回值)，所以一般不需要我们自己定义委托

    - ``` 案例
        //命名委托、匿名委托以及lambda 委托写法
        public class Program
        {
            static void Main(string[] args)
            {
                #region Action委托
                //无返回值的委托实例化
                Action action1 = actionMethod1;
                //调用委托
                action1();

                //匿名无参无返回值委托
                Action nmAction1 = delegate ()
                {
                    Console.WriteLine("无参的匿名方法");
                };

                //lambda 无参委托
                Action labmdaAction1 = () => Console.WriteLine("lambda写法的无参的匿名方法");

                //有参无返回值的委托实例化
                Action<int, string> action2 = actionMethod2;
                //调用委托
                action2(10, "命名委托有参无返回值");

                //匿名有参无返回值委托
                Action<int, string> nmAction2 = delegate (int n, string str)
                {
                    Console.WriteLine(n + " " + str);
                };
                nmAction2(10, "匿名有参无返回值方法！");

                // lambda 有参无返回委托
                Action<int, string> labmdaAction2 = (n, str) => Console.WriteLine(n + " " + str);
                nmAction2(10, "lambda写法的有参无返回值方法！");


                #endregion

                #region Func委托
                //无参有返回值的委托实例化
                Func<string> func1 = funcMehtod1;
                //调用委托
                Console.WriteLine(func1());

                //匿名无参有返回值的委托
                Func<string> nmFunc1 = delegate ()
                {
                    return "匿名无参有返回值的委托";
                };

                //lambda 无参有返回值的委托
                Func<string> labmdaFunc1 = () => "匿名无参有返回值的委托";



                //命名委托 有参返回值的委托实例化
                Func<int, string, bool> func2 = funcMehtod2;
                //调用委托
                Console.WriteLine(func2(20, "命名委托有参有返回值"));

                // 匿名 有参有返回值的委托
                Func<int, string, bool> nmFunc2 = delegate (int n, string str)
                {
                    if (n > str.Length)
                        return true;
                    else
                        return false;
                };
                //调用委托
                Console.WriteLine(nmFunc2(20, "匿名有参有返回值的委托"));


                //lambda 有参有返回值的委托实例化
                Func<int, string, bool> labmdaFunc2 = (n, str) =>
                {
                    if (n > str.Length)
                        return true;
                    else
                        return false;
                };
                //调用委托
                Console.WriteLine(labmdaFunc2(20, "lambda 有参有返回值的委托"));
                #endregion


                //作业
                Func<int, bool> f = i => i > 5;

                //反推匿名函数
                Func<int, bool> nmf = delegate (int n)
                {
                    if (n > 5)
                    {
                        return true;
                    }
                    return false;
                };

                //反推命名函数
                Func<int, bool> func = zyFunc;
                Console.WriteLine(func(6));
            }

            #region 无返回值的函数方法
            //无参
            static void actionMethod1()
            {
                Console.WriteLine("hello world ！");
            }

            //有参
            static void actionMethod2(int n, string str)
            {
                Console.WriteLine(n + " " + str);
            }
            #endregion

            #region 有返回值的函数方法
            //无参
            static string funcMehtod1()
            {
                return "hello world ！";
            }

            //有参
            static bool funcMehtod2(int n, string str)
            {
                if (n > str.Length)
                    return true;
                else
                    return false;
            }

            //作业
            static bool zyFunc(int n)
            {
                if (n > 5)
                    return true;
                else
                    return false;
            }
            #endregion
        }
      ```

- ### lambda表达式

  - 通过linq，手写一个lambda 的匿名委托

  - ```案例：
    public class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 10, 1, 20, 3, 44, 50, 22, 4, 884, 9 };
            #region Linq 写法
            IEnumerable<int> ints = nums.Where(x => x > 10);
            foreach (var item in ints)
            {
                Console.WriteLine(item);
            }
            #endregion

            Console.WriteLine("------------------");

            #region 通过匿名委托方式，手写where方法
            IEnumerable<int> writeInts = writeWhere(nums, x => x > 10);
            foreach (var item in writeInts)
            {
                Console.WriteLine(item);
            }
            #endregion
        }

        //手写where方法
        static IEnumerable<int> writeWhere(IEnumerable<int> ints, Func<int, bool> func)
        {
            foreach (var item in ints)
            {
                if (func(item))
                {
                    yield return item;
                }
            }
        }
    }
    ```

- ### Linq 语法

  - ``` LINQ方法语法
    LINQ方法语法

    使用Where、OrderBy、Select等 扩展方法进行数据查询的写法叫做'LINQ方法语法'
    写法：var item = list.Where(w=>w.id>2).OrderBy(o=>o.name).Select(s=>new { s.id,s.name });
    一般使用最多的还时linq方法这种写法
    ```

  - ``` LINQ查询语法
    这种写法叫 LINQ查询语法

    var item =  from e in list
                where e.id >2
                orderby e.name
                select new { e.id,e.name };
    ```

  - ``` 例子
    /*
    * 统计一个字符串中每个字母出现的频率
    */
    string chars = "Hello World,js,sfs,dsf dsfs";
    var temp = chars.Where(w => char.IsLetter(w)).Select(s => char.ToLower(s)).GroupBy(g => g).Select(s => new { key = s.Key, count = s.Count() }).OrderByDescending(o => o.key).Where(w => w.count > 2).Select(s => new { s.key, s.count });
    //.Where(w => w.Count() > 2).Select(s => new { key = s.Key, count = s.Count() });
    foreach (var item in temp)
    {
        Console.WriteLine(item);
    }
    ```
