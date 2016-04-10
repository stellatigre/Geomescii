using UnityEngine;
using System.Linq;
using System.Collections;

namespace MIDI
{

    public class MidiCcRecieverPositional : MidiCcRecieverBase {

        public enum axis {x, y, z};
        public int multiplier = 5;

        public override void ccResponseHandler (MidiCCSource data) {
            var pos = gameObject.transform.position;
            //Debug.Log(axis.x);
            gameObject.transform.position = new Vector3(pos.x, data.value * multiplier, pos.z);
        }

    }

}

