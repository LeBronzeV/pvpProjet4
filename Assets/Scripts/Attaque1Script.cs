﻿using UnityEngine;
using System.Collections;

public class Attaque1Script : MonoBehaviour {

    public Player1Script Source;
    public GameObject Attack1;
    private float Damages;
    private float lifeSpan;
    

    // Use this for initialization
    void Start () {

        lifeSpan = 0;

    }

    void SetDamages(float montant)
    {
        Damages = montant;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.layer == 9 || other.gameObject.layer == 11 || other.gameObject.layer == 14)
        {

            Destroy(this.gameObject);
            other.gameObject.SendMessage("TakeDamage",Damages);

        }

        if (other.gameObject.layer == 12)
            Destroy(this.gameObject);
    }

    void Update()
    {
        if (lifeSpan > 2.0f)
        {
            Destroy(this.gameObject);
        }
        lifeSpan += Time.deltaTime;
        Damages -= Time.deltaTime * 9.0f;
    }
}
