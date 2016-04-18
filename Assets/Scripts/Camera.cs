using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    const float r3 = 1.7320508f;
    public float max = 0;
    public GameObject[] targets;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 avg = new Vector3(0,0,0);
        int iter = 0;
        max = 0;
        Vector3 cameraXY = new Vector3(transform.position.x, 0, transform.position.z);
	    foreach(GameObject obj in targets)
        {
            avg += obj.transform.position;
            iter++;
            Vector3 objXY = new Vector3(obj.transform.position.x, 0, obj.transform.position.z);
            float dist = (cameraXY - objXY).magnitude;
            if(dist > max)
                max = dist;
        }
        avg /= iter;
        transform.position = new Vector3(avg.x, max * r3, avg.z);
	}
}
