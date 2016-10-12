using UnityEngine;
using System.Collections;

public class Player1Script : MonoBehaviour {

    public float MaxHP;
    public float Attack;
    public float Speed;
    private float HP;
    private Vector3 Direction;


    // Use this for initialization
    void Start () {
        HP = MaxHP;
	}
	
	// Update is called once per frame
	void Update () {
        Direction = Vector3.zero;
        //Forward
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
