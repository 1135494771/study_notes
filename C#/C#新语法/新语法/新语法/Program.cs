// See https://aka.ms/new-console-template for more information

//// using 作用域
//{
//    using var stream = File.OpenWrite(@"E:\practice\C#\ConsoleApp2\测试.txt");
//    using var writer = new StreamWriter(stream);
//    writer.Write("你好，傻逼2");
//}
//var context = File.ReadAllText(@"E:\practice\C#\ConsoleApp2\测试.txt");
//Console.WriteLine(context);


/* record 练习 */

//创建一个record对象，并通过原始构造函数初始化值
Records2 records = new Records2(2, "小傻瓜");

//用法一：通过拷贝的方式创建新的对象
Records2 records2 = records with { };

//用法二：通过拷贝的方式创建新的对象，并重新修改某些字段的值
Records2 records3 = records with { Age=30 };

//对比俩个对象引用地址是否相同
Console.WriteLine(Object.ReferenceEquals(records, records3));


