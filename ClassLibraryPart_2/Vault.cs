using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace ClassLibraryPart_2
{
    public partial class Vault<T>
    {

        private List<Node<T>> nodes = new List<Node<T>>();

        /// <summary>
        /// Добавление ноды
        /// </summary>
        /// <param name="node"></param>
        public void Add(Node<T> node)
        {
            nodes.Add(node);
        }
        /// <summary>
        /// Сохранение первых 10
        /// </summary>
        public void Save()
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].NodeToFile($"..\\..\\..\\..\\ClassLibraryPart_2\\nodes");
            }


        }

        /// <summary>
        /// Выполнение метода подгрузки
        /// </summary>
        /// <param name="number">Номер метода</param>
        /// <exception cref="ArgumentOutOfRangeException">Если номер не лежит в промежутке от 0 до 10</exception>
        public void Download(int number)
        {
            if (number > 0)
            {
                AutoDownload(number, this);
            }
        }
        /// <summary>
        /// Выполнение метода подгрузки
        /// </summary>
        /// <param name="number">Номер метода</param>
        /// <exception cref="ArgumentOutOfRangeException">Если номер не лежит в промежутке от 0 до 10</exception>
        static partial void AutoDownload(int number, Vault<T> v);
        /// <summary>
        /// Поиск по имени
        /// </summary>
        /// <param name="otherNodeName">Имя</param>
        /// <returns></returns>
        public Node<T>? this[string otherNodeName]
        {
            get
            {
                return nodes.Find((Node<T> a) => a.Name == otherNodeName);
            }
        }
        /// <summary>
        /// Итерация
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Node<T>> GetEnumerator()
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                yield return nodes[i];
            }
        }
    }
}
