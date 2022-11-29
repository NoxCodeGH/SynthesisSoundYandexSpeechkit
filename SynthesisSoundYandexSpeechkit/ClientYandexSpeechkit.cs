using System.Net;

namespace SynthesisSoundYandexSpeechkit
{
    public class ClientYandexSpeechkit
    {
        private readonly string _address;
        private readonly string _iamToken;

        public ClientYandexSpeechkit(string address, string iamToken)
        {
            _address = address;
            _iamToken = iamToken;            
        }

        public async Task<Stream> RequestAsync(Dictionary<string, string> dataRequest)
        {
            var content = new FormUrlEncodedContent(dataRequest);

            using HttpClient client = new();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _iamToken);
            
            var respone = await client.PostAsync(_address, content);
            if (!respone.IsSuccessStatusCode)
                throw new Exception($"Не удалось выполнить запрос. Код: {respone.StatusCode} Ошибка: ?");
            
            return await respone.Content.ReadAsStreamAsync();
        }
    }
}
