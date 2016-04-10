using UnityEngine;
using Utilities;
using System.Collections;

public class OrbitCamera : MonoBehaviour {

    GameObject mainCamera;

	// Use this for initialization
	void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.RotateAround(mainCamera.transform.position, Utils.getRandomRotation(3), 20 * Time.deltaTime);
	}
}
