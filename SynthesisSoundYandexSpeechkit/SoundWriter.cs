namespace SynthesisSoundYandexSpeechkit
{
    public class SoundWriter
    {
        public static async void Write(Stream dataSound, string pathDirWriteSound, string nameFile)
        {
            if (!Directory.Exists(pathDirWriteSound)) Directory.CreateDirectory(pathDirWriteSound);

            string path = @$"{pathDirWriteSound}/{nameFile}";
            using FileStream fileStream = File.Open(path, FileMode.OpenOrCreate);
            dataSound.Position = 0;
            await dataSound.CopyToAsync(fileStream);
        }
    }
}
