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
        static partial void AutoDownload(int number, Vault v);

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
