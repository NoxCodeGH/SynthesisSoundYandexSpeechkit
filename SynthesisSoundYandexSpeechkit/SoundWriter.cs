namespace SynthesisSoundYandexSpeechkit
{
    public class SoundWriter
    {
        public static async void Write(Stream data, string dir, string name)
        {
            if (!Directory.Exists(dir)) 
                Directory.CreateDirectory(dir);

            string path = @$"{dir}/{name}";
            using FileStream file = File.Open(path, FileMode.OpenOrCreate);
            await data.CopyToAsync(file);
        }
    }
}
