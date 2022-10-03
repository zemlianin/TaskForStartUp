using System;
using System.Xml.Linq;
using ClassLibraryPart_2;


namespace TaskForSturtUp
{

    public  partial class Program
    {
        static void Main(string[] args)
        {
            var v = new Vault<int>();
            /*v.Add(new Node<int>("node1", "text1", 11));
            v.Add(new Node<int>("node2", "text2", 22));
            v.Add(new Node<int>("node3", "text3", 33));*/

            //v.Add(new Node()  { Name = file, Text = System.IO.File.ReadAllText("nodes/file") } );
            // v.Save();
            v.Download0();
             v.Download1();
           
            foreach (var item in v)
            {
                Console.WriteLine(item.Text+"_"+item.Obj);
            }
            v.Save();
            //v.Download2();
            //  HelloFrom("Generated Code");
        }
       // static partial void HelloFrom(string name);

    }
}