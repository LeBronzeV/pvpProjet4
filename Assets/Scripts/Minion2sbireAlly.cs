using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Minion2sbireAlly : MonoBehaviour {

    public float MaxHP;
    public Slider lifeBar;

    public float HP;

    // Use this for initialization
    void Start()
    {

        HP = MaxHP;
    }

    void TakeDamageEnemy(float montant)
    {
        HP -= montant;
        lifeBar.value = (HP / MaxHP);
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
