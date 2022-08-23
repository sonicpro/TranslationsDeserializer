using Amazon.Lambda.Serialization.SystemTextJson;
using System;
using System.IO;
namespace TranslationsDeserializer
{
    class Program
    {
        static void Main()
        {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            byte[] json = File.ReadAllBytes($"{path}\\GENERATE_TITLE_PAGE_captured.json");
            var serializer = new SerializerWrapper();
            Console.WriteLine(serializer.GetBaseMessage(json));
        }
    }
}
