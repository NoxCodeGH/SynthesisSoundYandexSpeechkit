using System.Globalization;
using YandexSpeechkit.API.V1;

namespace SynthesisSoundYandexSpeechkit
{
    public class PrepareRequestYandexSpeechkit
    {
        private readonly TextType _textType;
        private readonly string _text;
        private readonly Lang _lang;
        private readonly Voice _voice;
        private readonly Emotion _emotion;
        private readonly double _speed;
        private readonly Format _format;
        private readonly SampleRateHertz _sampleRateHertz;
        private readonly string _folderId;

        public PrepareRequestYandexSpeechkit(TextType textType, string text, Lang lang, Voice voice, 
            Emotion emotion, double speed, Format format, SampleRateHertz sampleRateHertz, string folderId)
        {
            _textType = textType;
            _text = text;
            _lang = lang;
            _voice = voice;
            _emotion = emotion;
            _speed = speed;
            _format = format;
            _sampleRateHertz = sampleRateHertz;
            _folderId = folderId;
        }

        public Dictionary<string, string> DataRequest()
        {
            Dictionary<string, string> dataRequest = new();

            if (_text == "")
                throw new Exception("Пустое текстовое поле.");

            if (_text.Length > 5000)
                throw new Exception("Текст не должен превышать 5000 символов.");

            if (_textType == TextType.text)
                dataRequest.Add("text", _text);
            else
                dataRequest.Add("ssml", _text);

            Dictionary<string, string>? voiceSettings = null;
            switch (_voice)
            {
                case Voice.alena:
                    voiceSettings = VoiceSettingsAleana();
                    break;
                case Voice.john:
                    voiceSettings = VoiceSettingsJohn();
                    break;
                default:
                    throw new Exception("Голос не поддерживается.");
            }

            if (voiceSettings == null)
                throw new Exception("Неверно указаны параметры голоса.");

            dataRequest = dataRequest.Concat(voiceSettings).ToDictionary(d => d.Key, d => d.Value);

            if (_speed < 0.1 || _speed > 3.0)
                throw new Exception("Неверно указана скорость (темп) речи.");

            dataRequest.Add("speed", _speed.ToString(CultureInfo.InvariantCulture));

            switch (_format)
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
            }

            if (_format == Format.lpcm)
            {
                switch (_sampleRateHertz)
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
                }
            }

            if (_folderId.Length > 50)
                throw new Exception("Идентификатор каталога не должен превышать 50 символов.");

            dataRequest.Add("folderId", _folderId);

            return dataRequest;
        }

        private Dictionary<string, string>? VoiceSettingsAleana()
        {
            Dictionary<string, string> voiceSettings = new()
            {
                { "voice", "alena" }
            };

            if (_lang == Lang.ru_RU)
                voiceSettings.Add("lang", "ru-RU");
            else
                return null;

            if (_emotion == Emotion.neutral)
                voiceSettings.Add("emotion", "neutral");
            else if (_emotion == Emotion.good)
                voiceSettings.Add("emotion", "good");
            else
                return null;

            return voiceSettings;
        }

        private Dictionary<string, string>? VoiceSettingsJohn()
        {
            Dictionary<string, string> voiceSettings = new()
            {
                { "voice", "john" }
            };

            if (_lang == Lang.en_US)
                voiceSettings.Add("lang", "en-US");
            else
                return null;

            voiceSettings.Add("emotion", "-");

            return voiceSettings;
        }
    }
}
