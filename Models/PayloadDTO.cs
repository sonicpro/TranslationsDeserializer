using System.Text.Json;

namespace TranslationsDeserializer.Models
{
    public class PayloadDTO
    {
        public TransientFile[] FileList { get; set; }

        public string SessionId { get; set; }

        public object Cover { get; set; }

        public JsonElement? Translations { get; set; }

        public string Title { get; set; }
    }
}
