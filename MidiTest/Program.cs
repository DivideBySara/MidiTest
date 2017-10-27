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
            /// <summary>
            /// Midi sequence source(s): http://www.kuhmann.com/Yamaha.htm, Tchaikovsky, Pyotr I., last updated 11-May-2016, downloaded 10/25/17
            /// Author: author / sequencer / performer and / or Robert C. Kuhmann 
            /// </summary>
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
