using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace MidiTest
{
    class Program
    {
        // for midis
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string command,
   StringBuilder returnValue, int returnLength, IntPtr winHandle);

        [DllImport("winmm.dll")]
        private static extern int midiOutGetNumDevs();

        [DllImport("winmm.dll")]
        private static extern int midiOutGetDevCaps(Int32 uDeviceID,
           ref MidiOutCaps lpMidiOutCaps, UInt32 cbMidiOutCaps);

        [DllImport("winmm.dll")]
        private static extern int midiOutOpen(ref int handle,
           int deviceID, MidiCallBack proc, int instance, int flags);

        [DllImport("winmm.dll")]
        protected static extern int midiOutShortMsg(int handle,
           int message);

        [DllImport("winmm.dll")]
        protected static extern int midiOutClose(int handle);

        static void Main(string[] args)
        {
            string res = String.Empty;
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "002TCHAIKOVSKYPyotrIlyichRachmaninovSleepingWaltzseqYogore.mid");
            string openCommand = "open " + filePath + " alias music";

            res = Mci(openCommand);
            res = Mci("play music");
            Console.ReadLine();    // Pause until return is pressed
            res = Mci("close music");

            Console.ReadKey();
        }

        static string Mci(string command)
        {
            int returnLength = 256;
            StringBuilder reply = new StringBuilder(returnLength);
            mciSendString(command, reply, returnLength, IntPtr.Zero);
            return reply.ToString();
        }

        private delegate void MidiCallBack(int handle, int msg, int instance, int param1, int param2);
    }
}
