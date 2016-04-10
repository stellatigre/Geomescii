using UnityEngine;
using MIDI;
using System.Collections;

public class MidiCCScaler : MidiCcRecieverBase {
    
    public override void ccResponseHandler (MidiCCSource data) {
        var transform = gameObject.transform;
        var pos = transform.position;
        float scale = 1f + data.value * 2;
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
