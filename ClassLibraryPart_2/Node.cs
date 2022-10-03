using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPart_2
{
    public class Node<T>
    {

        public string Name { get; set; } = "";
        public string Text { get; set; } = "";
        public T? Obj { get; set; } = default(T);
        public Node(string name, string text, T obj)
        {
            Name = name;
            Text = text;
            Obj = obj;
        }

        public Node()
        {
            Name = "";
            Text = "";
        }

    }
}
