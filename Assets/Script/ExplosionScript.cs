using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

    private float Damages;
    private float lifeSpan;
	// Use this for initialization
	void Start () {
	
	}

    void SetDamages(float montant)
    {
        Damages = montant;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 10 || other.gameObject.layer == 11 ||other.gameObject.layer == 13)
        {

            other.gameObject.SendMessage("TakeDamage", Damages);

        }
    }

    // Update is called once per frame
    void Update () {
	    if(lifeSpan > 0.1f)
        {
            Destroy(this.gameObject);
        }
        lifeSpan += Time.deltaTime;
	}
}
