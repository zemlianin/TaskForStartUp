using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

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
        /// <summary>
        /// Запись ноды в файл
        /// </summary>
        /// <param name="path">Путь к директории</param>
        public void NodeToFile(string path)
        {
            File.WriteAllText(path+$"\\Name.node", "text");
        }
       
    }
}
