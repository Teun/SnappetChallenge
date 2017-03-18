using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Snappet.Borisov.Test.Domain;
using Snappet.Borisov.Test.Domain.Processing;

namespace Snappet.Borisov.Test.Infrastructure
{
    public class SubmittedAnswerProvider : IProvideSubmittedAnswers
    {
        private readonly IConvertSubmittedAnswers _convertSubmittedAnswers;
        private readonly IReadSubmittedAnswers _readSubmittedAnswers;
        private readonly JsonSerializer _serializer;

        public SubmittedAnswerProvider(
            IReadSubmittedAnswers readSubmittedAnswers,
            IConvertSubmittedAnswers convertSubmittedAnswers
        )
        {
            _readSubmittedAnswers = readSubmittedAnswers;
            _convertSubmittedAnswers = convertSubmittedAnswers;
            _serializer = new JsonSerializer();
        }

        public IEnumerable<SubmittedAnswer> GetAll()
        {
            var stream = _readSubmittedAnswers.Read();
            var streamReader = new StreamReader(stream);
            var jsonTextReader = new JsonTextReader(streamReader);
            var endOfStream = !ReadOrDispose(jsonTextReader, stream);
            if (endOfStream)
            {
                stream.Dispose();
                var message = "Nothing to read";
                throw new FormatException(message);
            }
            if (jsonTextReader.TokenType != JsonToken.StartArray)
            {
                stream.Dispose();
                var message = $"JsonToken.StartArray expected but was {jsonTextReader.TokenType}";
                throw new FormatException(message);
            }
            while (ReadOrDispose(jsonTextReader, stream))
            {
                if (jsonTextReader.TokenType == JsonToken.EndArray) break;
                var model = _serializer.Deserialize<SubmittedAnswerModel>(jsonTextReader);
                var answer = _convertSubmittedAnswers.ConvertFrom(model);
                yield return answer;
            }
        }

        private static bool ReadOrDispose(JsonReader jsonTextReader, IDisposable disposable)
        {
            try
            {
                return jsonTextReader.Read();
            }
            catch (Exception)
            {
                disposable.Dispose();
                throw;
            }
        }
    }
}