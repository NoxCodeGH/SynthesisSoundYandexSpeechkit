using YandexSpeechkit.API.V1;

namespace SynthesisSoundYandexSpeechkit
{
    public class DataApiV1
    {
        public TextType TextType { get; }
        public string Text { get; }
        public Lang Lang { get; }
        public Voice Voice { get; }
        public Emotion Emotion { get; }
        public double Speed { get; }
        public Format Format { get; }
        public SampleRateHertz SampleRateHertz { get; }
        public string FolderId { get; }

        public DataApiV1(TextType textType, string text, Lang lang, Voice voice,
            Emotion emotion, double speed, Format format, SampleRateHertz sampleRateHertz, string folderId)
        {
            TextType = textType;
            Text = text;
            Lang = lang;
            Voice = voice;
            Emotion = emotion;
            Speed = speed;
            Format = format;
            SampleRateHertz = sampleRateHertz;
            FolderId = folderId;
        }
    }
}
