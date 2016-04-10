using UnityEngine;
using System.Linq;
using MidiJack;
using System.Collections.Generic;
using System.Reflection;

namespace MIDI {

    public class MidiCCSource {
        public int controlID;
        public float value;
        public MidiCCSource (int id, float value) {
            this.controlID = id;
            this.value = value;
        }
    }

    public class MidiNoteSource {
        public int key;
        public float value;
        public MidiNoteSource (int key, float value) {
            this.key = key;
            this.value = value;
        }
    }       

    public class MidiCcRecieverBase : MonoBehaviour {

        public NanoKontrol2 nanoKontrol;
        public Component component;

        void respondToMidiCC (MidiCCSource data) {
            //Debug.Log(data.controlID + "  " + data.value);

            if ((int)nanoKontrol == data.controlID) {
                ccResponseHandler(data);
            }
        }

        public virtual void ccResponseHandler (MidiCCSource data) {
            Debug.Log("please override this ccResponseHandler method");        
        }

    }


    public class MidiNoteRecieverBase : MonoBehaviour {

        public MidiChannel channel;

        void respondToMidiNote (MidiNoteSource data) {
            noteResponseHandler(data);
        }

        public virtual void noteResponseHandler (MidiNoteSource data) {
            Debug.Log("please override this noteResponseHandler method");        
        }

    }

}
