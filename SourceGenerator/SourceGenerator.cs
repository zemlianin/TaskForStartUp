﻿using Microsoft.CodeAnalysis;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.IO;

namespace SourceGenerator
{
    [Generator]
    public class HelloSourceGenerator : ISourceGenerator
    {

        public void Execute(GeneratorExecutionContext context)
        {
            var files = Directory.GetFiles("nodes");
            for (int i = 0; i < files.Length; i++)
            {
                //Получение ссылок и имени
                var path = files[i].Replace("\\", "\\\\");
                var name = files[i].Replace('\\', '-');
                name = name.Substring(6);
                name = name.Remove(name.IndexOf('.'));
                string source = $@"// <auto-generated/>
                
using System;

namespace  ClassLibraryPart_1
{{
    
    public partial class Vault
    {{
        static partial void Load{i}(Vault v) 
        {{
            string data = File.ReadAllText(""..\\..\\..\\..\\ClassLibraryPart_1\\{path}"");
            v.nodes.Add(new Node(""{name}"",data));
        }}
    }}
}}
";
                context.AddSource($"{i}.g.cs", source);
            }

        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // No initialization required for this one
        }
    }
}