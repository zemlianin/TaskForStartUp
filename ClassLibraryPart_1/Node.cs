using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPart_1
{
    public class Node
    {
       
        public string Name { get; set; } = "";
        public string Text { get; set; } = "";
        public Node(string name, string text)
        {
            Name = name;
            Text = text;
        }

        public Node()
        {
            Name = "";
            Text = "";
        }
       
    }
}
