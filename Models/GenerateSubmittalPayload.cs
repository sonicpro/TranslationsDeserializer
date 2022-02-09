using System.Collections.Generic;

namespace TranslationsDeserializer.Models
{
    public class GenerateSubmittalPayload
    {
        public TransientFile[] FileList { get; set; }

        public string SessionId { get; set; }

        public object Cover { get; set; }

        public Dictionary<string, string> Translations { get; set; }

        public string Title { get; set; }
    }
}
