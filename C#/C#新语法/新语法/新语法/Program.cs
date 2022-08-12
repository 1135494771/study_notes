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

//属性只读
Records records = new Records(2, "小傻瓜");
Console.WriteLine(records.ToString());

Records2 records2 = new Records2(3, "小呆瓜", "中国");
//部分属性可以读写
records2.Address = "北京";
records2.Age = 100;

//重写了ToString 方法
Console.WriteLine(records2.ToString());

//重写了Equals 方法
Console.WriteLine(Object.Equals(records, records2));

//对比俩个对象引用地址是否相同
Console.WriteLine(Object.ReferenceEquals(records, records2));

