namespace TranslationsDeserializer.Models
{
    public class BaseMessage
    {
        public string Type { get; set; }

        public GenerateSubmittalPayload Body { get; set; }

        public string RequestId { get; set; }
    }
}
