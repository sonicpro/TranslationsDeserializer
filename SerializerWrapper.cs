using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Amazon.Lambda.Serialization.SystemTextJson;
using TranslationsDeserializer.Models;

namespace TranslationsDeserializer
{
    public class SerializerWrapper : DefaultLambdaJsonSerializer
    {
        // We can access SomeConstant and SomeMethod here:
        public string GetBaseMessage(byte[] json)
        {
            var messageDto = InternalDeserialize<BaseMessageDTO>(json);
            var message = new BaseMessage
            {
                Type = messageDto.Type,
                Body = new GenerateSubmittalPayload
                {
                    FileList = messageDto.Body.FileList,
                    SessionId = messageDto.Body.SessionId,
                    Cover = messageDto.Body.Cover,
                    Translations = new Dictionary<string, string>(),
                    Title = messageDto.Body.Title
                },
            };
            var translationsElement = messageDto.Body.Translations.GetValueOrDefault();
            // TODO: make use of paths
            IEnumerable<string> paths = EnumeratePaths(translationsElement);
            return System.Text.Json.JsonSerializer.Serialize(message);
        }

        private static IEnumerable<string> EnumeratePaths(JsonElement doc)
        {
            var queue = new Queue<(string ParentPath, JsonElement element)>();
            queue.Enqueue(("", doc));
            while (queue.Any())
            {
                var (parentPath, element) = queue.Dequeue();
                switch (element.ValueKind)
                {
                    case JsonValueKind.Object:
                        parentPath = parentPath == ""
                            ? parentPath
                            : parentPath + ".";
                        foreach (var nextEl in element.EnumerateObject())
                        {
                            queue.Enqueue(($"{parentPath}{nextEl.Name}", nextEl.Value));
                        }
                        break;
                    case JsonValueKind.Array:
                        foreach (var (nextEl, i) in element.EnumerateArray().Select((jsonElement, i) => (jsonElement, i)))
                        {
                            queue.Enqueue(($"{parentPath}[{i}]", nextEl));
                        }
                        break;
                    case JsonValueKind.Undefined:
                    case JsonValueKind.String:
                    case JsonValueKind.Number:
                    case JsonValueKind.True:
                    case JsonValueKind.False:
                    case JsonValueKind.Null:
                        yield return parentPath;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
