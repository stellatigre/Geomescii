using MIDI;
using UnityStandardAssets.ImageEffects;

public class EdgeDetectionIntensity : MidiCcRecieverBase
{
    public EdgeDetection edge;

    public override void ccResponseHandler (MidiCCSource data) {
        edge.sensitivityDepth = 0 + (data.value * 200);
        edge.edgesOnly = data.value / 10;
    }
}


