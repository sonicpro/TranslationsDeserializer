using System.Collections.Generic;

namespace TranslationsDeserializer.Models
{
    public class TransientFile
    {
        public string Name { get; set; }

        public string InternalName { get; set; }

        public int Order { get; set; }

        public int? Page { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public DocumentType? Type { get; set; }

        public string Category { get; set; }

        public string Url { get; set; }

        public string Path { get; set; }

        public bool? UseAuth { get; set; }

        public bool? FetchFromLocalS3 { get; set; }

        public string ProductName { get; set; }

        public string DocType { get; set; }

        public int Hash => this.Url.GetHashCode();

        public string HashedFileName
        {
            get
            {
                //bool fetchFromLocalS3 = this.FetchFromLocalS3.GetValueOrDefault();
                //if (!fetchFromLocalS3)
                //{
                //    return $"{Hash}.pdf";
                //}
                return Url.Split('/')[^1];
            }
        }

    }
}
