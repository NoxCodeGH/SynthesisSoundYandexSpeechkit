using System.Runtime.Serialization;

namespace YandexSpeechkit.API.V1
{
    public enum TextType
    {
        [EnumMember(Value = "text")]
        text,
        [EnumMember(Value = "ssml")]
        ssml
    }

    public enum Lang
    {
        [EnumMember(Value = "ru_RU")]
        ru_RU,
        [EnumMember(Value = "en_US")]
        en_US,
        [EnumMember(Value = "kk_KK")]
        kk_KK
    }

    public enum Voice
    {
        [EnumMember(Value = "alena")]
        alena,
        [EnumMember(Value = "filipp")]
        filipp,
        [EnumMember(Value = "jane")]
        jane,
        [EnumMember(Value = "omazh")]
        omazh,
        [EnumMember(Value = "zahar")]
        zahar,
        [EnumMember(Value = "ermil")]
        ermil
    }

    public enum Emotion
    {
        [EnumMember(Value = "neutral")]
        neutral,
        [EnumMember(Value = "good")]
        good,
        [EnumMember(Value = "evil")]
        evil
    }

    public enum Format
    {
        [EnumMember(Value = "lpcm")]
        lpcm,
        [EnumMember(Value = "oggopus")]
        oggopus,
        [EnumMember(Value = "mp3")]
        mp3
    }

    public enum SampleRateHertz
    {
        [EnumMember(Value = "none")]
        none,
        [EnumMember(Value = "sr8000")]
        sr8000 = 8000,
        [EnumMember(Value = "sr16000")]
        sr16000 = 16000,
        [EnumMember(Value = "sr48000")]
        sr48000 = 48000
    }
}
