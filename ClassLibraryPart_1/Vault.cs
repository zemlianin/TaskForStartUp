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
            for(int i = 0; i < nodes.Count;i++)
            {
                nodes[i].NodeToFile($"..\\..\\..\\..\\ClassLibraryPart_1\\nodes");
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
        /// Объявление автоматически генерируемого метода
        /// </summary>
        /// <param name="number"></param>
        /// <param name="v"></param>
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
