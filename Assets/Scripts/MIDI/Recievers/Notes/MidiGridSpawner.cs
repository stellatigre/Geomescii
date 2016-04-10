using UnityEngine;
using MIDI;
using Utilities;
using System.Collections;

public class MidiGridSpawner : MidiNoteRecieverBase
{
    public GameObject prefab;
    public GameObject midiManager;
    public GameObject mainCamera;



    void start () {
        // so we can be sure to assign new objects to be children of midi manager
        midiManager = GameObject.Find("MIDI Manager");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        gameObject.transform.parent = midiManager.transform;
    }


    public override void noteResponseHandler (MidiNoteSource data) {
        Debug.Log(data.value);
        if (data.value > 0) {
            gameObject.transform.position = new Vector3(0, data.key, 0);
        } 
    }


}




