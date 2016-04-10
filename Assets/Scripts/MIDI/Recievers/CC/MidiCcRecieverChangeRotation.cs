using UnityEngine;
using MIDI;
using System.Collections;

public class MidiCcRecieverChangeRotation : MidiCcRecieverBase
{
    public float RotationDuration = 0.5f;
    public int multiplier = 2;

    private bool _isRotating = false;

    IEnumerator RotateObject(Quaternion start, Quaternion end, float duration)
    {
        float endTime = Time.time + duration;
        _isRotating = true;
        while (Time.time <= endTime) {
            // normalized progress from 0 - 1
            float t = 1f - (endTime - Time.time) / duration;
            transform.rotation = Quaternion.Lerp(start, end, t);
            yield return 0;
        }
        transform.rotation = end;
        _isRotating = false;
    }

    public override void ccResponseHandler (MidiCCSource data) {
 
        Debug.Log("doing sharp rotation");
        StartCoroutine(RotateObject(
            transform.rotation, 
            transform.rotation * Quaternion.Euler(90, 0, 0), 
            RotationDuration
        ));
    }
}

    