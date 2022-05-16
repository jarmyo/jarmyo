using Microsoft.CognitiveServices.Speech;

namespace Personal.Helpers
{
    public static class AzureServiceHelper
    {
        public static string SpeechKey { get; set; }
        public class TextoAVoz
        {
            public async Task Generar(string s)
            {
                var config = SpeechConfig.FromSubscription(SpeechKey, "southcentralus");
                config.SpeechSynthesisLanguage = "es-MX";
                config.SpeechRecognitionLanguage = "es-MX";
                config.SpeechSynthesisVoiceName = "es-MX-DaliaNeural";
                using var synthesizer = new SpeechSynthesizer(config, null);

                var result = await synthesizer.SpeakTextAsync(s);
                using var stream = AudioDataStream.FromResult(result);
                await stream.SaveToWaveFileAsync(@"c:\repos\file+" + DateTime.Now.ToFileTimeUtc() + ".wav");
            }
        }
    }
}