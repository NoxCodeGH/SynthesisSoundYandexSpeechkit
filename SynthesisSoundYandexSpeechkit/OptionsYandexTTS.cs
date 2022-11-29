using System.Text.Json.Serialization;
using YandexSpeechkit.API.V1;

namespace SynthesisSoundYandexSpeechkit
{
    public class OptionsYandexTTS
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TextType TextType { get; set; } = TextType.text;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Lang Lang { get; set; } = Lang.ru_RU;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Voice Voice { get; set; } = Voice.alena;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Emotion Emotion { get; set; } = Emotion.neutral;
        public double Speed { get; set; } = 1.0;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Format Format { get; set; } = Format.oggopus;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SampleRateHertz SampleRateHertz { get; set; } = SampleRateHertz.none;
    }
}
