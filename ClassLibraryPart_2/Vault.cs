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
        public void Save()
        {
            foreach (var it in nodes)
            {
              
                using (FileStream stream = new FileStream($"..\\..\\..\\..\\ClassLibraryPart_2\\nodes\\{it.Value.Name}.json", 
                    FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize(stream, it.Value);
                }
            }


        }
        /// <summary>
        /// Выполнение метода подгрузки
        /// </summary>
        /// <param name="number">Номер метода</param>
        /// <exception cref="ArgumentOutOfRangeException">Если номер не лежит в промежутке от 0 до 10</exception>
        public void Download(int number)
        {
            switch (number)
            {
                case 0:
                    Load0(this);
                    break;
                case 1:
                    Load1(this);
                    break;
                case 2:
                    Load2(this);
                    break;
                case 3:
                    Load3(this);
                    break;
                case 4:
                    Load4(this);
                    break;
                case 5:
                    Load5(this);
                    break;
                case 6:
                    Load6(this);
                    break;
                case 7:
                    Load7(this);
                    break;
                case 8:
                    Load8(this);
                    break;
                case 9:
                    Load9(this);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(number));
            }
        }
        /// <summary>
        /// Методы подгрузки
        /// </summary>
        /// <param name="v">Объект в который происходит подгрузка</param>
        static partial void Load0(Vault<T> v);
        static partial void Load1(Vault<T> v);
        static partial void Load2(Vault<T> v);
        static partial void Load3(Vault<T> v);
        static partial void Load4(Vault<T> v);
        static partial void Load5(Vault<T> v);
        static partial void Load6(Vault<T> v);
        static partial void Load7(Vault<T> v);
        static partial void Load8(Vault<T> v);
        static partial void Load9(Vault<T> v);
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
