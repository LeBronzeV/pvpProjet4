using UnityEngine;
using System.Collections;

public class Player2Script : MonoBehaviour
{
    public float MaxHP;
    static private float HP;
    public float Speed;
    private Vector3 Direction;

    // Use this for initialization
    void Start()
    {
        HP = MaxHP;
    }

    void TakeDamage(float montant)
    {
        HP -= montant;
    }
    // Update is called once per frame
    void Update()
    {
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

        if (HP < 0)
        {
            Destroy(this.gameObject);
        }
    }
}