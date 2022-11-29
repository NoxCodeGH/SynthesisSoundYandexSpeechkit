using SynthesisSoundYandexSpeechkit;
using System.Text;
using System.Text.Json;

namespace SynthesisSoundYandexSpeechkitConsole
{
    class Program
    {
        private static readonly string _pathTexts = Path.Combine(Directory.GetCurrentDirectory(), "Texts.txt");
        private static readonly string _pathConfigSynthesis = Path.Combine(Directory.GetCurrentDirectory(), "ConfigSynthesis.json");
        private static readonly string _pathConfig = Path.Combine(Directory.GetCurrentDirectory(), "Config.json");

        private static Config? _config;
        private static OptionsSynthesize? _synthesizeWriterData;

        public static async Task Main()
        {
            Console.WriteLine("--- start ---");
            try
            {
                await InitDefaultFilesAsync();
                if (_config == null) throw new Exception("Файл конфигурации приложения прочитан с ошибкой.");
                if (_synthesizeWriterData == null) throw new Exception("Файл параметров синтезатора прочитан с ошибкой.");

                if (!Directory.Exists(_synthesizeWriterData.OptionsWriter.Path))
                    Directory.CreateDirectory(_synthesizeWriterData.OptionsWriter.Path);

                List<string> texts = File.ReadLines(_pathTexts).ToList();

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
            if (!File.Exists(_pathConfig))
            {
                using FileStream configStreamDef = File.Open(_pathConfig, FileMode.OpenOrCreate);
                await JsonSerializer.SerializeAsync(
                    configStreamDef,
                    new Config() { ConnectYandexTTS = new() }, new JsonSerializerOptions { WriteIndented = true });
            }

            using FileStream configStream = File.OpenRead(_pathConfig);
            _config = await JsonSerializer.DeserializeAsync<Config>(configStream);
        }

        private static async Task InitSynthesizeWriterData()
        {
            if (!File.Exists(_pathConfigSynthesis))
            {
                using FileStream configStreamDef = File.Open(_pathConfigSynthesis, FileMode.OpenOrCreate);
                await JsonSerializer.SerializeAsync(
                    configStreamDef,
                    new OptionsSynthesize(), new JsonSerializerOptions { WriteIndented = true });
            }

            using FileStream configStream = File.OpenRead(_pathConfigSynthesis);
            _synthesizeWriterData = await JsonSerializer.DeserializeAsync<OptionsSynthesize>(configStream);
        }

        private static async Task InitTexts()
        {
            if (!File.Exists(_pathTexts))
            {
                using FileStream textsStream = File.OpenWrite(_pathTexts);

                string value = "Пример - \"Текст для синтеза.\"";
                await textsStream.WriteAsync(Encoding.UTF8.GetBytes(value));
            }
        }
    }
}