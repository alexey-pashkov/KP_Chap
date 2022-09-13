using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using NAudio.Midi;

namespace MIDI
{
    public class ReadMidi
    {
        MidiIn midiIn;


        public void SelectDevice()
        {
            int devNum;
            for (int i = 0; i < MidiIn.NumberOfDevices; i++)
                Console.WriteLine(MidiIn.DeviceInfo(i).ProductName + " " +MidiIn.DeviceInfo(i).ProductId);
            Console.WriteLine("Select device:");
            devNum = int.Parse(Console.ReadLine());
            midiIn = new MidiIn(devNum);
            midiIn.MessageReceived += MessageRecived;
            midiIn.Start();
            Console.ReadLine();
        }

        private void MessageRecived(object sender, MidiInMessageEventArgs e) 
        { 
            Console.WriteLine(e.MidiEvent.CommandCode.ToString() + " " + e.Timestamp + " " + e.RawMessage + e.MidiEvent);
        }

    }


}
