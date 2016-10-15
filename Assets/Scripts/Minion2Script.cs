using UnityEngine;
using System.Collections;

public class Minion2Script : MonoBehaviour {

    public float MaxHP;

    public float HP;

	// Use this for initialization
	void Start () {
        HP = MaxHP;
	}

    void TakeDamage(float montant)
    {
        HP -= montant;
    }
    
    // Update is called once per frame
   

	void Update () {
        if (HP < 0 || HP== 0)
        {
            Destroy(this.gameObject);
        }

    }
}
