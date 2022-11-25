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
        kk_KK,
        [EnumMember(Value = "de_DE")]
        de_DE,
        [EnumMember(Value = "uz_UZ")]
        uz_UZ
    }

    public enum Voice
    {
        [EnumMember(Value = "lea")]
        lea,
        [EnumMember(Value = "john")]
        john,
        [EnumMember(Value = "amira")]
        amira,
        [EnumMember(Value = "madi")]
        madi,
        [EnumMember(Value = "alena")]
        alena,
        [EnumMember(Value = "filipp")]
        filipp,
        [EnumMember(Value = "jane")]
        jane,
        [EnumMember(Value = "madirus")]
        madirus,
        [EnumMember(Value = "omazh")]
        omazh,
        [EnumMember(Value = "zahar")]
        zahar,
        [EnumMember(Value = "nigora")]
        nigora,
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
