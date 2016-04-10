using UnityEngine;
using MidiJack;
using MIDI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class MidiManager : MonoBehaviour {

    public MidiChannel continousControlChannel = MidiChannel.Ch1;
    public MidiChannel notesChannel = MidiChannel.Ch2;

    private MidiStatusMap statusMap;

    System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();

    GameObject[] recievers;
    float[] sliderValues = new float[127];

	void Start () {
        // BroadcastMessage only broadcasts to children of this object.
        // so, we make every object tagged as Midi Reactive a child of this one
        // TODO: This doesn't take into account objects created at runtime yet.
        recievers = GameObject.FindGameObjectsWithTag("Midi Reactive");
        foreach (var reciever in recievers) {
            reciever.transform.parent = gameObject.transform;
        }
	}

    void handleMidiCC(MidiChannel channel) {
        var active = MidiMaster.GetKnobNumbers(channel);

        foreach (int id in active) 
        {
            var value = MidiMaster.GetKnob(id);

            // we don't want to broadcast if the value remains the same
            if (value != sliderValues[id]) {
                sliderValues[id] = value;
                BroadcastMessage("respondToMidiCC", new MidiCCSource(id, value));
            }
        }
    }

    void handleMidiNotes(MidiChannel channel) {
        for (int i=0; i<127 ; i++) {
            var keyValue = MidiMaster.GetKey(channel, i);
            //Debug.Log("key " + i + " has value: " + keyValue);
            if (keyValue > 0) {
                BroadcastMessage("respondToMidiNote", new MidiNoteSource(i, keyValue));
            }
        }
    }

    void handleMidiClock(MidiChannel channel) {
        var value = MidiMaster.GetKey(channel, 248);
        Debug.Log("clock message value: " + value);
    }
	
	void Update () {

        handleMidiCC(continousControlChannel);

        handleMidiNotes(notesChannel);

        //handleMidiClock(notesChannel);
	}
}

public enum MidiStatusMap {
    Clock = 248                 // F8 in hex
}

