using UnityEngine;
using System.Collections;

public class deplacement1 : MonoBehaviour {
    public Vector3 Direction;
    public float Speed = 10.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Direction = Vector3.zero;
        if (Input.GetKey(KeyCode.O))
        {
            Direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.K))
        {
            Direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.L))
        {
            Direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.M))
        {
            Direction += Vector3.right;
        }
        gameObject.transform.position += Speed * Direction * Time.deltaTime;

    }
}
