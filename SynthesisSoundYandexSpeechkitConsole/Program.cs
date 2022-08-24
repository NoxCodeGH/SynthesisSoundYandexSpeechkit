using SynthesisSoundYandexSpeechkit;
using System.Text;
using System.Text.Json;

namespace SynthesisSoundYandexSpeechkitConsole
{
    class Program
    {
        private const string NAME_FILE_TEXTS = @"Texts.txt";
        private static readonly string _pathFileTexts = Directory.GetCurrentDirectory() + @$"\{NAME_FILE_TEXTS}";

        private static Config? _config;
        private static SynthesizeWriterData? _synthesizeWriterData;

        public static async Task Main()
        {
            Console.WriteLine("--- start ---");
            try
            {
                await InitDefaultFilesAsync();
                if (_config == null) throw new Exception("Файл конфигурации приложения прочитан с ошибкой.");
                if (_synthesizeWriterData == null) throw new Exception("Файл параметров синтезатора прочитан с ошибкой.");

                if (!Directory.Exists(_synthesizeWriterData.WriterData.PathDirWriteSound))
                    Directory.CreateDirectory(_synthesizeWriterData.WriterData.PathDirWriteSound);

                List<string> texts = File.ReadLines(_pathFileTexts).ToList();

                Console.WriteLine($"Будет синтезировано звуковых файлов: {texts.Count}");
                while (true)
                {
                    Console.Write("Для продолжения введите (Y): ");
                    string? keyConsole = Console.ReadLine();
                    if (keyConsole?.ToUpper() == "Y")
                        break;
                }

                SynthesizeWriter synthesisControl = new(_config.ConnectYandexTTS);
                await synthesisControl.SynthesizeAsync(texts, _synthesizeWriterData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("--- end ---");
                Console.ReadKey();
            }
        }

        private static async Task InitDefaultFilesAsync()
        {
            await InitConfig();
            await InitSynthesizeWriterData();
            await InitTexts();
        }

        private static async Task InitConfig()
        {
            string path = Directory.GetCurrentDirectory() + @"/Config.json";
            if (!File.Exists(path))
            {
                using FileStream configStreamDef = File.Open(path, FileMode.OpenOrCreate);
                await JsonSerializer.SerializeAsync(
                    configStreamDef,
                    new Config() { ConnectYandexTTS = new() }, new JsonSerializerOptions { WriteIndented = true });
            }

            using FileStream configStream = File.OpenRead(path);
            _config = await JsonSerializer.DeserializeAsync<Config>(configStream);
        }

        private static async Task InitSynthesizeWriterData()
        {
            string path = Directory.GetCurrentDirectory() + @"/ConfigSynthesis.json";
            if (!File.Exists(path))
            {
                using FileStream configStreamDef = File.Open(path, FileMode.OpenOrCreate);
                await JsonSerializer.SerializeAsync(
                    configStreamDef,
                    new SynthesizeWriterData(), new JsonSerializerOptions { WriteIndented = true });
            }

            using FileStream configStream = File.OpenRead(path);
            _synthesizeWriterData = await JsonSerializer.DeserializeAsync<SynthesizeWriterData>(configStream);
        }

        private static async Task InitTexts()
        {
            string path = Directory.GetCurrentDirectory() + @"/Texts.txt";
            if (!File.Exists(path))
            {
                using FileStream textsStream = File.OpenWrite(path);

                string value = "Пример - \"Текст для синтеза.\"";
                await textsStream.WriteAsync(Encoding.UTF8.GetBytes(value));
            }
        }
    }
}