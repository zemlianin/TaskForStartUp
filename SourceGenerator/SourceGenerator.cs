﻿using Microsoft.CodeAnalysis;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SourceGenerator
{
    [Generator]
    public class HelloSourceGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var files = Directory.GetFiles("nodes");
            string listNames = "[";
            string listTexts = "[";
            for (int i = 0; i < files.Length; i++)
            {
                // Я не знаю почему, но если я подключаю нугет пакет джейсонсериализации, то оно перестает линковаться,
                // я долго бился и не нашел лучшего способа чем просто сериализовать списки руками, это же несложно
                // (предложенная в условии сериализация без нугетов не катит, тк генератор поддерживает только 2ая версия нета, 
                // А та сериализация появилась в 3 версии)
                if (i != 0)
                {
                    listNames += ",";
                    listTexts += ",";
                }
                var path = files[i].Replace("\\", "\\\\");
                var name = files[i].Replace('\\', '-');
                name = name.Substring(6);
                name = name.Remove(name.IndexOf('.'));
                listNames += "\\\""+(name + " ")+"\\\"";
                listTexts += "\\\"" + (File.ReadAllText(path) + " ") + "\\\"";
            }
            listNames += "]";
            listTexts += "]";
            string source = $@"// <auto-generated/>
                
using System;
using System.Text.Json;


namespace  ClassLibraryPart_1
{{
    public partial class Vault
    {{
        static partial void AutoDownload(int index, Vault v) 
        {{
            List<string> listNames = JsonSerializer.Deserialize<List<string>>(""{listNames}"");
            List<string> listTexts = JsonSerializer.Deserialize<List<string>>(""{listTexts}"");
            v.Add(new Node(listNames[index],listTexts[index]));
        }}
    }}
}}
";
            context.AddSource($"Vault.g.cs", source);
        }
        public void Initialize(GeneratorInitializationContext context)
        {
            // No initialization required for this one
        }
    }
}