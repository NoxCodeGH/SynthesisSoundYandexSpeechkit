using NAudio.Wave;

namespace SynthesisSoundYandexSpeechkit
{
    public class SoundFormatConvert
    {
        public static MemoryStream ConvertWavPcm(Stream dataSource, int rateSource, int bitsSource, int channelsSource,
            int rateDest, int bitsDest, int channelsDest, bool header)
        {
            WaveFormat pcmSource = new(rateSource, bitsSource, channelsSource);
            WaveFormat pcmDest = new(rateDest, bitsDest, channelsDest);

            using WaveStream waveStreamSource = new RawSourceWaveStream(dataSource, pcmSource);
            using WaveFormatConversionStream conversionStream = new(pcmDest, waveStreamSource);

            MemoryStream dataDest = new();
            if (header)                
                WaveFileWriter.WriteWavFileToStream(dataDest, conversionStream);
            else
                conversionStream.CopyTo(dataDest);

            return dataDest;
        }
    }
}
