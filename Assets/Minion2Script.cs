using UnityEngine;
using System.Collections;

public class Minion2Script : MonoBehaviour {

    public float MaxHP;
    public Player1Script joueurEnnemi;

    private float HP;

	// Use this for initialization
	void Start () {
        HP = MaxHP;
	}
	
	// Update is called once per frame
    void OnCollisionEnter (Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            HP -= joueurEnnemi.Attack;
        }
    }

	void Update () {
        if (HP < 0)
        {
            Destroy(this.gameObject);
        }

    }
}
