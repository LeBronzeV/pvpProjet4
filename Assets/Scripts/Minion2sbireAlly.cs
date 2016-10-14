using UnityEngine;
using System.Collections;

public class Minion2sbireAlly : MonoBehaviour {

    public float MaxHP;

    static private float HP;

    // Use this for initialization
    void Start()
    {
        HP = MaxHP;
    }

    void TakeDamageEnemy(float montant)
    {
        HP -= montant;
    }

    // Update is called once per frame


    void Update()
    {
        if (HP < 0 || HP == 0)
        {
            Destroy(this.gameObject);
        }

    }
}
