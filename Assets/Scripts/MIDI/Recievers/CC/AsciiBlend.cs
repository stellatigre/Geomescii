using MIDI;

public class AsciiBlend : MidiCcRecieverBase {

    public AsciiArtFx ascii;

    void start () {
        ascii = gameObject.GetComponent<AsciiArtFx>();
    }

    public override void ccResponseHandler (MidiCCSource data) {
        ascii.blendRatio = data.value;
    }

}



