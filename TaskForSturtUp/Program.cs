using System;
using System.Xml.Linq;
using ClassLibraryPart_1;


namespace TaskForSturtUp
{

    public  partial class Program
    {
        static void Main(string[] args)
        {
            var v = new Vault();
            /*v.Add(new Node() { Name = "node1", Text = "text1" });
            v.Add(new Node() { Name = "node2", Text = "text2" });
            v.Add(new Node() { Name = "node3", Text = "text3" });*/

            //v.Add(new Node()  { Name = file, Text = System.IO.File.ReadAllText("nodes/file") } );
            //v.Save();
            v.Download0();
            v.Download1();
            v.Download2();
            foreach (var item in v)
            {
                Console.WriteLine(item.Text);
            }
            v.Save();
           // v.Download2();
            //  HelloFrom("Generated Code");
        }
       // static partial void HelloFrom(string name);

    }
}