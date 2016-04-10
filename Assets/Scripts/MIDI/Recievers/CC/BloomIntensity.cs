using MIDI;
using UnityStandardAssets.ImageEffects;

public class BloomIntensity : MidiCcRecieverBase
{
    public Bloom bloom;
   
    public override void ccResponseHandler (MidiCCSource data) {
        bloom.bloomIntensity = data.value * 3;
    }
}

