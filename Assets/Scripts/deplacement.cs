using UnityEngine;
using System.Collections;

public class deplacement : MonoBehaviour {
    public Vector3 Direction;
    public float Speed = 10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Direction = Vector3.zero;
        if (Input.GetKey(KeyCode.Z))
        {
            Direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Direction += Vector3.right;
        }
        gameObject.transform.position += Speed * Direction * Time.deltaTime;

    }
}
