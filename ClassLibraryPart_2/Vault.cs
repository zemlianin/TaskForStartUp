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
        //Имена должны быть уникальны, требуется для скорости
        private Dictionary<string,Node<T>> nodes = new Dictionary<string, Node<T>>();
        public void Add(Node<T> node)
        {
            nodes.Add(node.Name,node);
        }
        /// <summary>
        /// Сохранение
        /// </summary>
        /// <summary>
        /// Сохранение первых 10
        /// </summary>
        public void Save()
        {
            foreach (Node<T> node in nodes.Values)
            {
                node.NodeToFile($"..\\..\\..\\..\\ClassLibraryPart_2\\nodes");
            }


        }

        /// <summary>
        /// Выполнение метода подгрузки
        /// </summary>
        /// <param name="number">Номер метода</param>
        /// <exception cref="ArgumentOutOfRangeException">Если номер меньше 0</exception>
        public void Download(int number)
        {
            if (number > 0)
            {
                AutoDownload(number, this);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        /// <summary>
        /// Автогенерируемый метод, объявление
        /// </summary>
        /// <param name="number">номер</param>
        /// <param name="v">объект сохранения</param>
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
                return nodes[otherNodeName];
            }
        }
        /// <summary>
        /// Итерирование
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Node<T>> GetEnumerator()
        {
            foreach (var it in nodes)
            {
                yield return it.Value;
            }
        }
    }
}
