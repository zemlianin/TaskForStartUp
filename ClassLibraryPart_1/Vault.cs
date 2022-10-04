using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClassLibraryPart_1
{
    public partial class Vault
    {
        /// <summary>
        /// Записи
        /// </summary>
        private List<Node> nodes = new List<Node>();
        /// <summary>
        /// Добавить запись
        /// </summary>
        /// <param name="node">Запись</param>
        public void Add(Node node)
        {  
            nodes.Add(node);
        }
        /// <summary>
        /// Сохранить записи
        /// </summary>
        public void Save()
        {
            //Сохраняются только первые 10 записей, в дальнейшем число можно изменить.
            for(int i = 0; i < Math.Min(nodes.Count,10);i++)
            {
                File.WriteAllText($"..\\..\\..\\..\\ClassLibraryPart_1\\nodes\\{nodes[i].Name}.node", $"text{i}");
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
       /// Методы подгрзуки
       /// </summary>
       /// <param name="v">Сссылка на контейнер в который требуется подгрузка</param>
        static partial void Load0(Vault v);
        static partial void Load1(Vault v);
        static partial void Load2(Vault v);
        static partial void Load3(Vault v);
        static partial void Load4(Vault v);
        static partial void Load5(Vault v);
        static partial void Load6(Vault v);
        static partial void Load7(Vault v);
        static partial void Load8(Vault v);
        static partial void Load9(Vault v);
        /// <summary>
        /// Поиск по названию
        /// </summary>
        /// <param name="otherNodeName">название</param>
        /// <returns></returns>
        public Node? this[string otherNodeName]
        {
            get 
            {
                return nodes.Find((Node a) => a.Name == otherNodeName);   
            }  
        }
        /// <summary>
        /// Итерация
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Node> GetEnumerator()
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                yield return nodes[i];
            }
        }
    }
}
