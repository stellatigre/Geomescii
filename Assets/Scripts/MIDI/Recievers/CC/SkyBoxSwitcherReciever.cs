using MIDI;
using UnityEngine;

public class SkyBoxSwitcherReciever : MidiCcRecieverBase
{
    public Material skybox;

    public override void ccResponseHandler (MidiCCSource data) {
        RenderSettings.skybox = skybox;
    }
}

