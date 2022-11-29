using System.Globalization;
using YandexSpeechkit.API.V1;

namespace SynthesisSoundYandexSpeechkit
{
    public class RequestPreparationApiV1 : RequestPreparation
    {
        private readonly DataApiV1 _dataApiV1;

        public RequestPreparationApiV1(DataApiV1 dataApiV1) => _dataApiV1 = dataApiV1;

        public override Dictionary<string, string> Prepare()
        {
            Dictionary<string, string> dataRequest = new();

            if (_dataApiV1.Text == "")
                throw new Exception("Пустое текстовое поле.");

            if (_dataApiV1.Text.Length > 5000)
                throw new Exception("Текст не должен превышать 5000 символов.");

            if (_dataApiV1.TextType == TextType.text)
                dataRequest.Add("text", _dataApiV1.Text);
            else if (_dataApiV1.TextType == TextType.ssml)
                dataRequest.Add("ssml", _dataApiV1.Text);
            else
                throw new Exception("Неизвестный тип текстового поля.");

            Dictionary<string, string> voiceSettings = _dataApiV1.Voice switch
            {
                Voice.alena => VoiceSettingsAleana(),
                Voice.john => VoiceSettingsJohn(),
                _ => throw new Exception("Неизвестный тип голоса."),
            };

            dataRequest = dataRequest
                .Concat(voiceSettings)
                .ToDictionary(d => d.Key, d => d.Value);

            if (_dataApiV1.Speed < 0.1 || _dataApiV1.Speed > 3.0)
                throw new Exception("Указанная скорость (темп) речи вышла за диапазон.");

            dataRequest.Add("speed", _dataApiV1.Speed.ToString(CultureInfo.InvariantCulture));

            switch (_dataApiV1.Format)
            {
                case Format.lpcm:
                    dataRequest.Add("format", "lpcm");
                    break;
                case Format.oggopus:
                    dataRequest.Add("format", "oggopus");
                    break;
                case Format.mp3:
                    dataRequest.Add("format", "mp3");
                    break;
                default:
                    throw new Exception("Неверно указан формат возвращаемого аудио файла.");
            }

            if (_dataApiV1.Format == Format.lpcm)
            {
                switch (_dataApiV1.SampleRateHertz)
                {
                    case SampleRateHertz.sr8000:
                        dataRequest.Add("sampleRateHertz", "8000");
                        break;
                    case SampleRateHertz.sr16000:
                        dataRequest.Add("sampleRateHertz", "16000");
                        break;
                    case SampleRateHertz.sr48000:
                        dataRequest.Add("sampleRateHertz", "48000");
                        break;
                    case SampleRateHertz.none:
                        throw new Exception("Не указана частота дискретизации для формата lpcm.");
                    default: 
                        throw new Exception("Неверно указана частота дискретизации.");
                }
            }

            if (_dataApiV1.FolderId.Length <= 0 || _dataApiV1.FolderId.Length > 50)
                throw new Exception("Идентификатор каталога имеет неверный формат.");

            dataRequest.Add("folderId", _dataApiV1.FolderId);

            return dataRequest;
        }

        private Dictionary<string, string> VoiceSettingsAleana()
        {
            Dictionary<string, string> voiceSettings = new()
            {
                { "voice", "alena" }
            };

            if (_dataApiV1.Lang == Lang.ru_RU)
                voiceSettings.Add("lang", "ru-RU");
            else
                throw new Exception("Голос не поддерживает указанный язык.");

            if (_dataApiV1.Emotion == Emotion.neutral)
                voiceSettings.Add("emotion", "neutral");
            else if (_dataApiV1.Emotion == Emotion.good)
                voiceSettings.Add("emotion", "good");
            else
                throw new Exception("Голос не поддерживает указанную языковую окраску.");

            return voiceSettings;
        }

        private Dictionary<string, string> VoiceSettingsJohn()
        {
            Dictionary<string, string> voiceSettings = new()
            {
                { "voice", "john" }
            };

            if (_dataApiV1.Lang == Lang.en_US)
                voiceSettings.Add("lang", "en-US");
            else
                throw new Exception("Голос не поддерживает указанный язык.");

            if (_dataApiV1.Emotion == Emotion.none)
                voiceSettings.Add("emotion", "-");
            else
                throw new Exception("Голос не поддерживает указанную языковую окраску.");

            return voiceSettings;
        }
    }
}
