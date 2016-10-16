using UnityEngine;
using System.Collections;

public class LoadScene1 : MonoBehaviour {

    [SerializeField]
    private string Destination;

	// Use this for initialization
	void Start () {
            Application.LoadLevel(Destination);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
