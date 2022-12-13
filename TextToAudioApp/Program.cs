using Azure.Communication;
using Azure.Communication.Identity;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace TextToAudioApp
{
    class Program
    {
        public static string key;
        public static string region;
        public static string customMessage;
        static async Task Main(string[] args)
        {
            Console.WriteLine("enter CognitiveServiceKey");
            key = Console.ReadLine();
            Console.WriteLine("enter CognitiveServiceRegion");
            region = Console.ReadLine();
            Console.WriteLine("enter customMessage");
            customMessage = Console.ReadLine();
            await GenerateCustomAudioMessage();
            Console.ReadLine();
        }
        private static async Task GenerateCustomAudioMessage()
        {
            try
            {
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(region) && !string.IsNullOrEmpty(customMessage))
                {
                    var config = SpeechConfig.FromSubscription(key, region);
                    config.SetSpeechSynthesisOutputFormat(SpeechSynthesisOutputFormat.Riff16Khz16BitMonoPcm);

                    var audioConfig = AudioConfig.FromWavFileOutput($"../../../custom-message.wav");
                    var synthesizer = new SpeechSynthesizer(config, audioConfig);

                    Console.WriteLine("Converting customMessage to audio...");
                    await synthesizer.SpeakTextAsync(customMessage);
                    Console.WriteLine("Converter customMessage into audio successfully!");
                }
                else
                {
                    Console.WriteLine("CognitiveKey or CognitiveRegion or custom messsage value is null");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception while generating text to speech. Exception: {ex.Message}");
            }
        }
    }
}
