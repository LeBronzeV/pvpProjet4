using UnityEngine;
using System.Collections;

public class grenadeScript : MonoBehaviour {

    public GameObject Explosion;
    public float detonationTime;

    private float Damages;
    private float Timer;

	// Use this for initialization
	void Start () {
        Timer = 0.0f;
	}

    void SetDamages(float montant)
    {
        Damages = 10*montant;
    }

    void Explode()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion, this.gameObject.transform.position, Quaternion.identity);
        explosion.SendMessage("SetDamages", Damages);
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 11 || other.gameObject.layer == 13)
        {

            Explode();
        }
    }

    // Update is called once per frame
    void Update () {
	    if(Timer > detonationTime)
        {
            Explode();
        }
        if (Timer > 0.1f && this.gameObject.GetComponent<Collider>().enabled == false)
        {
            this.gameObject.GetComponent<Collider>().enabled=true;
        }
        Timer += Time.deltaTime;
	}
}
