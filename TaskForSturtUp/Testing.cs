using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryPart_1;

namespace TaskForSturtUp
{
    internal class Testing
    {
        public void TestAdd()
        {
            var v = new Vault();
            v.Add(new Node("node1", "text1"));
            v.Add(new Node("node2", "text2"));
            v.Add(new Node("node3", "text3"));
            v.Add(new Node("node4", "text4"));
            v.Add(new Node("node5", "text5"));
            v.Add(new Node("node6", "text6"));
            v.Add(new Node("node7", "text7"));
            v.Add(new Node("node8", "text8"));
            v.Add(new Node("node9", "text9"));

            foreach (var item in v)
            {
                Console.WriteLine(item.Text);
            }
        }
        public void TestDownload()
        {
            var v2 = new Vault();
            //Требуется раскоментировать для сохранения в текущий объект
           /* v2.Add(new Node("node1", "text1"));
            v2.Add(new Node("node2", "text2"));
            v2.Add(new Node("node3", "text3"));
            v2.Add(new Node("node4", "text4"));
            v2.Add(new Node("node5", "text5"));
            v2.Add(new Node("node6", "text6"));
            v2.Add(new Node("node7", "text7"));
            v2.Add(new Node("node8", "text8"));
            v2.Add(new Node("node9", "text9"));
            v2.Save();*/
            v2.Download(0);
            v2.Download(1);
            v2.Download(2);
            v2.Download(3);
            v2.Download(4);
            v2.Download(5);
            v2.Download(8);
            //Подгрузка неопределенного метода, как видно, ошибок нет
            v2.Download(9);
            foreach (var item in v2)
            {
                Console.WriteLine(item.Text);
            }
        }

        public void TestFind()
        {
            var v = new Vault();
            v.Add(new Node("node1", "text1"));
            v.Add(new Node("node2", "text2"));
            v.Add(new Node("node3", "text3"));
            v.Add(new Node("node4", "text4"));
            v.Add(new Node("node5", "text5"));
            v.Add(new Node("node6", "text6"));
            v.Add(new Node("node7", "text7"));
            v.Add(new Node("node8", "text8"));
            v.Add(new Node("node9", "text9"));

            Console.WriteLine(v["node1"]);
            Console.WriteLine(v["node2"]);
            Console.WriteLine(v["node7"]);
            try
            {
                Console.WriteLine(v["node9"]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}