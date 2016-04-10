using MIDI;

public class AnalogGlitchScanLinesReciever : AnalogGlitchBase
{
    public override void ccResponseHandler (MidiCCSource data) {
        analog.scanLineJitter = data.value;
    }
}

