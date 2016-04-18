using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour {

    Vector3 rotationSpeed = new Vector3(0, 1, 0);

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotationSpeed);
    }
}
