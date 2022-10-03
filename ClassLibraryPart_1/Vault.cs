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

        private List<Node> nodes = new List<Node>();

        delegate  void Load();
        public void Add(Node node)
        {  
            nodes.Add(node);
        }
        public void Save()
        {
            for(int i = 0; i < nodes.Count;i++)
            {
                Console.WriteLine( nodes[i].Name);
                File.WriteAllText($"nodes\\{nodes[i].Name}.node", $"text{i}");
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
        static partial void Load0(Vault v);
        static partial void Load1(Vault v);
        static partial void Load2(Vault v);

        //   delegate void Loading();
        //  static partial void LoadAll(string name);

        public Node? this[string otherNodeName]
        {
            get 
            {
                return nodes.Find((Node a) => a.Name == otherNodeName);   
            }  
        }

        public IEnumerator<Node> GetEnumerator()
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                yield return nodes[i];
            }
        }
    }
}
