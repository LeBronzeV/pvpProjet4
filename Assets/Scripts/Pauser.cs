using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour {
	private bool paused = false;
    [SerializeField]
    public GameObject myObject;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
		{
          
            paused = !paused;
            
		}

        if (paused)
        {
            myObject.SetActive(true);

            Time.timeScale = 0;

        }
        else {
            Time.timeScale = 1;

            myObject.SetActive(false);
        }

    }

    
    
}
