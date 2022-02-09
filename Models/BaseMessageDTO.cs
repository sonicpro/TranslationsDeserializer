namespace TranslationsDeserializer.Models
{
    public class BaseMessageDTO
    {
        public string Type { get; set; }

        public PayloadDTO Body { get; set; }

        public string RequestId { get; set; }

        public BaseMessageDTO()
        {
        }

        public BaseMessageDTO(PayloadDTO body, string requestId)
        {
            this.Body = body;
            this.RequestId = requestId;
        }
    }
}
