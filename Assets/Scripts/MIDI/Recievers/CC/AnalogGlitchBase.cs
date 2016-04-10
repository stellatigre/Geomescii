using Kino;
using MIDI;

public class AnalogGlitchBase : MidiCcRecieverBase
{
    public AnalogGlitch analog;

    public void Start() {
        analog = gameObject.GetComponent<AnalogGlitch>();
    }
}









