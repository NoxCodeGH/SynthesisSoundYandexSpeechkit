namespace SynthesisSoundYandexSpeechkit
{
    public class OptionsSynthesize
    {
        public OptionsYandexTTS OptionsYandexTTS { get; set; } = new OptionsYandexTTS();
        public OptionsConvert? OptionsConvert { get; set; }
        public OptionsWriter OptionsWriter { get; set; } = new OptionsWriter();
    }
}
