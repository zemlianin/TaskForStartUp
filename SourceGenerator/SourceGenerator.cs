﻿using Microsoft.CodeAnalysis;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace SourceGenerator
{
    [Generator]
    public class HelloSourceGenerator : ISourceGenerator
    {

        public void Execute(GeneratorExecutionContext context)
        {
            var files = System.IO.Directory.GetFiles($"nodes");
            for (int i = 0; i < files.Length; i++)
            {
                var path = files[i].Replace("\\","\\\\");
            
                string source = $@"// <auto-generated/>
                
using System;
using System.Text.Json;

namespace  ClassLibraryPart_2
{{
    /////
    public partial class Vault<T>
    {{
        static partial void Load{i}(Vault<T> v) 
        {{
            string data = File.ReadAllText(""..\\..\\..\\..\\ClassLibraryPart_2\\{path}"");
            var node = JsonSerializer.Deserialize<Node<T>>(data);
            v.Add(node);
//
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