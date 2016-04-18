using UnityEngine;
using System.Collections;

public class Prop : MonoBehaviour {
    private Collider m_Collider;

	// Use this for initialization
	void Start () {
        m_Collider = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Character player = col.gameObject.GetComponent<Character>();
            if (player.attacking)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
