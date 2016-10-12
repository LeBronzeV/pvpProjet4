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
    public float hauteur = 6;
    public float decalage = 4;
    
   

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float milieu = Vector3.Distance(player1.position, player2.position);
        
        var camerabigy = hmin + (milieu * 2 * (hmax - hmin)) / delta2;
        camerabig.transform.position = new Vector3((player1.position.x + player2.position.x) / 2, camerabigy, (player1.position.z + player2.position.z - camerabigy) / 2);
        camerapl1.transform.position = new Vector3(player1.position.x, player1.position.y + hauteur, player1.position.z + decalage);
        camerapl2.transform.position = new Vector3(player2.position.x, player2.position.y + hauteur, player2.position.z + decalage);

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
 