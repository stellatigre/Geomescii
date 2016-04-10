using UnityEngine;
using System;
using System.Collections;

public class ResponsiveRandomRotate : MonoBehaviour {

    int direction = 1;
    int rotationsDone = 0;

    public float RotationDuration = 0.5f;
    public int rotationsToChange = 4;
    private bool _isRotating = false;

    private Vector3 lastAngles;
    private Vector3 force;

	// Use this for initialization
	void Start () {
        force = getRandomForce(1);
	}

    static Vector3 getRandomForce (int limit)
    {
        int x = UnityEngine.Random.Range(-limit, limit);
        int y = UnityEngine.Random.Range(-limit, limit);
        int z = UnityEngine.Random.Range(-limit, limit);
        return new Vector3(x, y, z);
    }

    int msFromBPM (int bpm) 
    {
        return 60000 / bpm;
    }

    void handleRandomRotation () 
    {
        if (Math.Abs(lastAngles.x - gameObject.transform.eulerAngles.x) > 350)
        {
            //Debug.Log("x rotation crossed?");
            rotationsDone += 1;

            if (rotationsDone % rotationsToChange == 0)
            {
                //Debug.Log("changing force");
                //Debug.Log(DateTime.Now);
                force = getRandomForce(1);
            }
        }

        lastAngles = gameObject.transform.eulerAngles;
    }

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

    int rndDirection ()
    {
        return UnityEngine.Random.value < 0.5 ? 1 : -1;
    }

    Quaternion randomDegreeRotation ()
    {
        int x = 90 * rndDirection();
        int y = 90 * rndDirection();
        int z = 90 * rndDirection();
        return Quaternion.Euler(x, y ,z);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 vector = force * direction;
        gameObject.transform.Rotate(vector);

        handleRandomRotation();

        if (Input.GetKeyDown(KeyCode.R) && !_isRotating)
        {
            Debug.Log("r pressed");
            StartCoroutine(RotateObject(
                transform.rotation, 
                transform.rotation * Quaternion.Euler(90, 0, 0), 
                RotationDuration
            ));

            //force = getRandomForce();
            //rotationsDone = 0;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = direction * -1;
        }


	}
}
