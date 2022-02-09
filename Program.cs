using Amazon.Lambda.Serialization.SystemTextJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TranslationsDeserializer.Models;

namespace TranslationsDeserializer
{
    class Program
    {
        static void Main()
        {
            byte[] json = File.ReadAllBytes(@"C:\Workitems\SG POC\GENERATE_TITLE_PAGE_captured.json");
            var serializer = new SerializerWrapper();
            Console.WriteLine(serializer.GetBaseMessage(json));
        }
    }
}
