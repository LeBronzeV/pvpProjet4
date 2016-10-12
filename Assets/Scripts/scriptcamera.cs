using UnityEngine;
using System.Collections;

public class scriptcamera : MonoBehaviour {
    public Transform player1;
    public Transform player2;
    public Camera camerabig;
    public Camera camerapl1;
    public Camera camerapl2;
    public float delta1 = 10;
    public float delta2 = 20;
    public float hmax = 20;
    public float hmin = 5;
    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float milieu = Vector3.Distance(player1.position, player2.position);
        var camerabigy = hmin + (milieu * 2 * (hmax - hmin)) / delta2;
        camerabig.transform.position = new Vector3((player1.position.x + player2.position.x) / 2, camerabigy, (player1.position.z + player2.position.z) / 2);

        if (milieu < delta1)
        {
            camerapl1.enabled = false;
            camerapl2.enabled = false;
            camerabig.enabled = true;
           
        }

        else if (milieu > delta2)
        {
            camerabig.enabled = false;
            camerapl1.enabled = true;
            camerapl2.enabled = true;
        }



    }
}
 