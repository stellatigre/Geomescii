using UnityEngine;
using MIDI;

public class MidiCcRecieverAxis : MidiCcRecieverBase {

    public enum AxisEnum {x, y, z};
    public AxisEnum axis;
    public int multiplier = 5;

    public override void ccResponseHandler (MidiCCSource data) {
        var pos = gameObject.transform.position;
        pos[(int)axis] = data.value * multiplier;
        
        gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

}

