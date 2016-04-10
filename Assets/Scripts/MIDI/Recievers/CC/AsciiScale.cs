using MIDI;
using UnityEngine;

public class AsciiScale : MidiCcRecieverBase {

    public AsciiArtFx ascii;

    void start () {
        ascii = gameObject.GetComponent<AsciiArtFx>();
        Debug.Log("ascii " + ascii.ToString());
    }

    public override void ccResponseHandler (MidiCCSource data) {
        ascii.scaleFactor = data.value * 9f + 0.5f;
    }

}

