namespace SynthesisSoundYandexSpeechkit
{
    public class RequestPreparationApiV1 : RequestPreparation<DataApiV1>
    {
        private readonly DataApiV1 _dataApiV1;

        public RequestPreparationApiV1(DataApiV1 dataApiV1)
        {
            _dataApiV1 = dataApiV1;
        }

        public override void Prepare()
        {

        }
    }
}
