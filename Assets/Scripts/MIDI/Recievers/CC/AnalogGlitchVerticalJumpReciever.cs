using MIDI;

public class AnalogGlitchVerticalJumpReciever : AnalogGlitchBase
{
    public override void ccResponseHandler (MidiCCSource data) {
        analog.verticalJump = data.value;
    }
}







