using MIDI;
using UnityStandardAssets.ImageEffects;

public class NoiseCombinedReciever : MidiCcRecieverBase
{
    public NoiseAndGrain noise;

    void Start() {
        noise = gameObject.GetComponent<NoiseAndGrain>();
    }

    public override void ccResponseHandler (MidiCCSource data) {
        noise.generalIntensity = data.value;
        noise.intensityMultiplier = data.value * 5;
    }
}







