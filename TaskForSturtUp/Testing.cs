using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryPart_2;

namespace TaskForSturtUp
{
    internal class Testing
    {
        public void TestAdd()
        {
            var v = new Vault<int>();
            v.Add(new Node<int>("node1", "text1", 115));
            v.Add(new Node<int>("node2", "text2", 225));
            v.Add(new Node<int>("node3", "text3", 335));
            v.Add(new Node<int>("node4", "text4", 115));
            v.Add(new Node<int>("node5", "text5", 225));
            v.Add(new Node<int>("node6", "text6", 335));
            v.Add(new Node<int>("node7", "text7", 115));
            v.Add(new Node<int>("node8", "text8", 225));
            v.Add(new Node<int>("node9", "text9", 335));

            foreach (var item in v)
            {
                Console.WriteLine(item.Text + "_" + item.Obj);
            }
        }
        public void TestDownload()
        {
            var v2 = new Vault<int>();
            //Требуется раскоментировать для сохранения в текущий объект
            /*v2.Add(new Node<int>("node1", "text1", 115));
            v2.Add(new Node<int>("node2", "text2", 225));
            v2.Add(new Node<int>("node3", "text3", 335));
            v2.Add(new Node<int>("node4", "text4", 115));
            v2.Add(new Node<int>("node5", "text5", 225));
            v2.Add(new Node<int>("node6", "text6", 335));
            v2.Add(new Node<int>("node7", "text7", 115));
            v2.Add(new Node<int>("node8", "text8", 225));
            v2.Add(new Node<int>("node9", "text9", 335));
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
                Console.WriteLine(item.Text + "_" + item.Obj);
            }
        }

        public void TestFind()
        {
            var v = new Vault<int>();
            v.Add(new Node<int>("node1", "text1", 115));
            v.Add(new Node<int>("node2", "text2", 225));
            v.Add(new Node<int>("node3", "text3", 335));
            v.Add(new Node<int>("node4", "text4", 115));
            v.Add(new Node<int>("node5", "text5", 225));
            v.Add(new Node<int>("node6", "text6", 335));
            v.Add(new Node<int>("node7", "text7", 115));
            v.Add(new Node<int>("node8", "text8", 225));
            v.Add(new Node<int>("node9", "text9", 335));

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