namespace SynthesisSoundYandexSpeechkit
{
    internal class SynthesizeManager
    {
        private readonly ConnectYandexTTS _connectYandexTTS;

        public SynthesizeManager(ConnectYandexTTS сonnectYandexTTS) => _connectYandexTTS = сonnectYandexTTS;

        public async Task SynthesizeListAsync(List<string> texts, OptionsSynthesize data)
        {
            foreach (string textSound in texts)
                await SynthesizeAsync(textSound, textSound, data);
        }

        public async Task SynthesizeDictionaryAsync(Dictionary<string, string> texts, OptionsSynthesize data)
        {
            foreach (var text in texts)
                await SynthesizeAsync(text.Key, text.Value, data);
        }

        private async Task SynthesizeAsync(string nameFile, string textSound, OptionsSynthesize data)
        {
            Synthesizer synthesizer = new(_connectYandexTTS);

            DataApiV1 dataApiV1 = new(
                data.OptionsYandexTTS.TextType,
                textSound,
                data.OptionsYandexTTS.Lang,
                data.OptionsYandexTTS.Voice,
                data.OptionsYandexTTS.Emotion,
                data.OptionsYandexTTS.Speed,
                data.OptionsYandexTTS.Format,
                data.OptionsYandexTTS.SampleRateHertz,
                _connectYandexTTS.FolderId);

            RequestPreparation preparation = new RequestPreparationApiV1(dataApiV1);            
            Stream dataSound = await synthesizer.Synthesize(preparation.Prepare());

            if (data.OptionsConvert != null)
            {
                Stream dataSoundConvert = ConvertSound(dataSound, data.OptionsConvert);
                SoundWriter.Write(dataSoundConvert, data.OptionsWriter.Path, $"{nameFile}{data.OptionsWriter.Extension}");
            }
            else
            {
                SoundWriter.Write(dataSound, data.OptionsWriter.Path, $"{nameFile}{data.OptionsWriter.Extension}");
            }
        }

        private Stream ConvertSound(Stream dataSound, OptionsConvert convertData)
        {
            return SoundFormatConvert.ConvertWavPcm(
                dataSound,
                convertData.RateSourceConvert,
                convertData.BitsSourceConvert,
                convertData.ChannelSourceConvert,
                convertData.RateDestConvert,
                convertData.BitsDestConvert,
                convertData.ChannelDestConvert,
                convertData.HeaderConvert);
        }
    }
}
