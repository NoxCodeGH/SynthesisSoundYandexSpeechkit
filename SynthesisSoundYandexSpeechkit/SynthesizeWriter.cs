using System.Text.Json.Serialization;
using YandexSpeechkit.API.V1;

namespace SynthesisSoundYandexSpeechkit
{
    public class ConnectYandexTTS
    {
        public string AddressYandexSpeechkitTTS { get; set; } = "";
        public string IamToken { get; set; } = "";
        public string FolderId { get; set; } = "";
    }

    public class YandexTTSData
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

    public class ConvertData
    {
        public int RateSourceConvert { get; set; }
        public int BitsSourceConvert { get; set; }
        public int ChannelSourceConvert { get; set; }
        public int RateDestConvert { get; set; }
        public int BitsDestConvert { get; set; }
        public int ChannelDestConvert { get; set; }
        public bool HeaderConvert { get; set; }
    }

    public class WriterData
    {
        public string PathDirWriteSound { get; set; } = Directory.GetCurrentDirectory();
        public string? Extension { get; set; } = "";
    }

    public class SynthesizeWriterData
    {
        public YandexTTSData YandexTTSData { get; set; } = new YandexTTSData();
        public ConvertData? ConvertData { get; set; }
        public WriterData WriterData { get; set; } = new WriterData();
    }

    public class SynthesizeWriter
    {
        private readonly string _addressYandexTTS;

        private readonly string _iamToken;
        private readonly string _folderId;

        public SynthesizeWriter(ConnectYandexTTS сonnectYandexTTS)
        {
            _addressYandexTTS = сonnectYandexTTS.AddressYandexSpeechkitTTS;
            _iamToken = сonnectYandexTTS.IamToken;
            _folderId = сonnectYandexTTS.FolderId;
        }

        public async Task SynthesizeAsync(List<string> texts, SynthesizeWriterData data)
        {
            foreach(string textSound in texts)
                await SynthesizeToFileAsync(textSound, textSound, data);
        }

        public async Task SynthesizeAsync(Dictionary<string, string> texts, SynthesizeWriterData data)
        {
            foreach (var text in texts)
                await SynthesizeToFileAsync(text.Key, text.Value, data);
        }

        private async Task SynthesizeToFileAsync(string nameFile, string textSound, SynthesizeWriterData data)
        {
            ClientYandexSpeechkit client = new(_addressYandexTTS, _iamToken);

            PrepareRequestYandexSpeechkit prepareRequest = new(
                data.YandexTTSData.TextType,
                textSound,
                data.YandexTTSData.Lang,
                data.YandexTTSData.Voice,
                data.YandexTTSData.Emotion,
                data.YandexTTSData.Speed,
                data.YandexTTSData.Format,
                data.YandexTTSData.SampleRateHertz,
                _folderId);
            Stream dataSound = await client.RequestAsync(prepareRequest.DataRequest());

            if (data.ConvertData != null)
            {
                Stream dataSoundConvert = SoundFormatConvert.ConvertWavPcm(
                    dataSound,
                    data.ConvertData.RateSourceConvert,
                    data.ConvertData.BitsSourceConvert,
                    data.ConvertData.ChannelSourceConvert,
                    data.ConvertData.RateDestConvert,
                    data.ConvertData.BitsDestConvert,
                    data.ConvertData.ChannelDestConvert,
                    data.ConvertData.HeaderConvert);

                SoundWriter.Write(dataSoundConvert, data.WriterData.PathDirWriteSound, $"{nameFile}{data.WriterData.Extension}");
            }
            else
            {
                SoundWriter.Write(dataSound, data.WriterData.PathDirWriteSound, $"{nameFile}{data.WriterData.Extension}");
            }
        }
    }
}
