using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassLibraryPart_2
{
    public partial class Vault<T>
    {

        private List<Node<T>> nodes = new List<Node<T>>();

        delegate void Load();
        public void Add(Node<T> node)
        {
            nodes.Add(node);
        }
        public void Save()
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                using (FileStream stream = new FileStream($"nodes\\{nodes[i].Name}.json", 
                    FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize(stream, nodes[i]);
                }
            }


        }
        public void Download0()
        {
            Load0(this);
        }
        public void Download1()
        {
            Load1(this);
        }
        public void Download2()
        {
            Load2(this);
        }
        static partial void Load0(Vault<T> v);
        static partial void Load1(Vault<T> v);
        static partial void Load2(Vault<T> v);

        public Node<T>? this[string otherNodeName]
        {
            get
            {
                return nodes.Find((Node<T> a) => a.Name == otherNodeName);
            }
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                yield return nodes[i];
            }
        }
    }
}
