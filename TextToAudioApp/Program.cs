using Azure.Communication;
using Azure.Communication.Identity;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.Extensions.Azure;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace TextToAudioApp
{
    class Program
    {
        public static string key;
        public static string region;
        public static string customMessage;
        public static string fileName;
        static async Task Main(string[] args)
        {
            Console.WriteLine("enter CognitiveServiceKey ,region and fileName values");
            var userInput = Console.ReadLine().Split();
            key = userInput[0];
            region = userInput[1];
            fileName = userInput[2];
            Console.WriteLine("enter customMessage and press esc to stop");
            bool done = false;
            while (!done)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    done = true;
                }
                customMessage = Console.ReadLine();
                await GenerateCustomAudioMessage(fileName);
            }
            Console.ReadLine();
        }
        private static async Task GenerateCustomAudioMessage(string fileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(region) && !string.IsNullOrEmpty(customMessage))
                {
                    var config = SpeechConfig.FromSubscription(key, region);
                    config.SetSpeechSynthesisOutputFormat(SpeechSynthesisOutputFormat.Riff16Khz16BitMonoPcm);
                    var synthesizer = new SpeechSynthesizer(config, null);
                    var result = await synthesizer.SpeakTextAsync(customMessage);
                    var stream = AudioDataStream.FromResult(result);
                    if (fileName != null && File.Exists($"../../../${fileName}.wav"))
                    {
                       
                        //stream.AppendToWaveFileAsync($"../../../${fileName}.wav");
                    }
                    else
                    {
                        await stream.SaveToWaveFileAsync($"../../../${fileName}.wav");
                    }
                    Console.WriteLine("Converted customMessage into audio successfully!. Give input to continue or press escape to stop ");
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
