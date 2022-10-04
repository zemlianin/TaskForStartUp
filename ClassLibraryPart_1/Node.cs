using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPart_1
{
    public class Node
    {
       /// <summary>
       /// Имя
       /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// Текст
        /// </summary>
        public string Text { get; set; } = "";
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="text">Текст</param>
        public Node(string name, string text)
        {
            Name = name;
            Text = text;
        }
        /// <summary>
        /// Дефолтный конструктор
        /// </summary>
        public Node()
        {
            Name = "";
            Text = "";
        }
       
    }
}
