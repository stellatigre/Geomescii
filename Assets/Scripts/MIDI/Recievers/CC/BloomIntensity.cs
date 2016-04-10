using MIDI;
using UnityStandardAssets.ImageEffects;

public class BloomIntensity : MidiCcRecieverBase
{
    //public Bloom bloom;
    public BloomOptimized bloom;
   
    public override void ccResponseHandler (MidiCCSource data) {
        bloom.intensity = data.value * 3;
    }
}

