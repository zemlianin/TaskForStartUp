using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibraryPart_2
{
    public class Node<T>
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
        /// Объект
        /// </summary>
        public T? Obj { get; set; } = default(T);
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="text">Текст</param>
        /// <param name="obj">Объект</param>
        public Node(string name, string text, T obj)
        {
            Name = name;
            Text = text;
            Obj = obj;
        }
        /// <summary>
        /// Конструктор
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
            using (FileStream stream = new FileStream(path + $"\\{Name}.json",
                    FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(stream, this);
            }

        }

    }
}