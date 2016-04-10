using MIDI;
using Kino;

public class DigitalGlitchIntensityReciever : MidiCcRecieverBase
{
    public DigitalGlitch glitch;
    public override void ccResponseHandler (MidiCCSource data) {
        glitch.intensity = data.value;
    }
}



