using MIDI;
using UnityStandardAssets.ImageEffects;

public class SaturationReciever : MidiCcRecieverBase
{
    public ColorCorrectionCurves curves;

    void Start() {
        curves = gameObject.GetComponent<ColorCorrectionCurves>();
    }

    public override void ccResponseHandler (MidiCCSource data) {
        // control is from 0 to 1.0, sat value is from 0 to 5
        curves.saturation = 0.5f + data.value * 4.5f;
    }
}





