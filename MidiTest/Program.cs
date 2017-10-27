using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace MidiTest
{
    class Program
    {        
        static void Main(string[] args)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "002TCHAIKOVSKYPyotrIlyichRachmaninovSleepingWaltzseqYogore.mid");
            string openCommand = "open " + filePath + " alias music";

            MidiOutCaps.Mci(openCommand);
            MidiOutCaps.Mci("play music");
            Console.ReadKey();
            MidiOutCaps.Mci("close music");
            Console.ReadKey();
        }        
    }
}
