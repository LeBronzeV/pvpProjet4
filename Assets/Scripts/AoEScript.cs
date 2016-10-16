using UnityEngine;
using System.Collections;

public class AoEScript : MonoBehaviour {

    private bool Existence;
    private float Timer;

	// Use this for initialization
	void Start () {
        Existence = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (Existence == true)
        {
            Existence = false;
            gameObject.SetActive(false);
        }
        else
        {
            Timer += Time.deltaTime;
            if (Timer > 0.01f)
            {
                Existence = true;
                Timer = 0.0f;
            }
        }
	}
}
