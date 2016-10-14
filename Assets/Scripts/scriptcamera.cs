using UnityEngine;
using System.Collections;

public class scriptcamera : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;
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
        float milieu = Vector3.Distance(player1.transform.position, player2.transform.position);
        
        var camerabigy = hmin + (milieu * 2 * (hmax - hmin)) / delta2;
        camerabig.transform.position = new Vector3((player1.transform.position.x + player2.transform.position.x) / 2, camerabigy, (player1.transform.position.z + player2.transform.position.z - camerabigy) / 2);
        camerapl1.transform.position = new Vector3(player1.transform. position.x, player1.transform.position.y + hauteur, player1.transform.position.z + decalage);
        camerapl2.transform.position = new Vector3(player2.transform.position.x, player2.transform.position.y + hauteur, player2.transform.position.z + decalage);

        if (milieu < delta1)
        {
            camerapl1.enabled = false;
            camerapl2.enabled = false;
            camerabig.enabled = true;
            player1.SendMessage("changementCamera", camerabig);
           
        }

        else if (milieu > delta2)
        {
            camerabig.enabled = false;
            camerapl1.enabled = true;
            camerapl2.enabled = true;

            player1.SendMessage("changementCamera", camerapl1);
        }



    }
}
 