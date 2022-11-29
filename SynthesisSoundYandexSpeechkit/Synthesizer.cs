namespace SynthesisSoundYandexSpeechkit
{
    internal class Synthesizer
    {
        private readonly ConnectYandexTTS _сonnectYandexTTS;

        public Synthesizer(ConnectYandexTTS сonnectYandexTTS) => _сonnectYandexTTS = сonnectYandexTTS;

        public async Task<Stream> Synthesize(Dictionary<string, string> data)
        {
            ClientYandexSpeechkit client = new(_сonnectYandexTTS.URI, _сonnectYandexTTS.IamToken);
            return await client.RequestAsync(data);
        }
    }
}
