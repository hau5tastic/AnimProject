using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

    public Vector3 rotationSpeed = new Vector3(0, 0, 200);

    public enum Type
    {
        Damage,
        MoveSpeed
    };

    int damageBoost = 20;
    float moveSpeedBoost = 1.5f;

    Type type;

	// Use this for initialization
	void Start () {
        int typeSelect = Random.Range(1, 2);

        switch (typeSelect)
            {
            case 1:
                type = Type.Damage;
                break;
            case 2:
                type = Type.MoveSpeed;
                break;
            }
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotationSpeed);
        Debug.Log("rotating");
    }
}
