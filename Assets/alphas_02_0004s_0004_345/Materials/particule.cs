using UnityEngine;
using System.Collections;

public class particule : MonoBehaviour {
    [SerializeField]
    private ParticleSystem particule1;
    [SerializeField]
    private ParticleSystem particule2;
    [SerializeField]
    private ParticleSystem particule3;
    // Use this for initialization
    void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Z))
        {
            particule1.Play();
            particule2.Play();
            particule3.Play();


        }
    }
   

   
}
