using UnityEngine;
using MIDI;
using Utilities;
using System.Collections;

public class MidiCcRecieverGeometrySpawner : MidiCcRecieverBase
{
    public GameObject prefab;
    public GameObject midiManager;
    public GameObject mainCamera;

    void start () {
        // so we can be sure to assign new objects to be children of midi manager
        //midiManager = GameObject.Find("MIDI Manager");
        //mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        gameObject.transform.parent = midiManager.transform;
    }

    /*
    static Vector3 getRandomForce (int limit)
    {
        int x = UnityEngine.Random.Range(-limit, limit);
        int y = UnityEngine.Random.Range(-limit, limit);
        int z = UnityEngine.Random.Range(-limit, limit);
        return new Vector3(x, y, z);
    }
    */

    public override void ccResponseHandler (MidiCCSource data) {
        //Debug.Log(data.value);
        if (data.value == 1) {
            var spawned = (GameObject)GameObject.Instantiate(prefab, gameObject.transform.position, Quaternion.Euler(0,0,0));
            spawned.transform.parent = gameObject.transform;
            //spawned.transform.RotateAround(new Vector3(0,0,0), Vector3.forward, 20 * Time.deltaTime);
            spawned.AddComponent<OrbitCamera>();
        }
    }
}
    


