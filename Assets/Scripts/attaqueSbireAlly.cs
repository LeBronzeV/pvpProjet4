using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class attaqueSbireAlly : MonoBehaviour {

    public float hpMax;
    public float HP;
    public Slider lifeBar;

	// Use this for initialization
	void Start () {
        HP = hpMax;
	}
    void TakeDamage(float montant)
    {
        HP -= montant;
        lifeBar.value = (HP / hpMax);
    }
    // Update is called once per frame
    void Update () {
        if (HP <= 0)
            Application.LoadLevel("winPlayer1");
	}
}