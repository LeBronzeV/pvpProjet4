using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour {
	private bool paused = false;
    [SerializeField]
    private GameObject menupause;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.P))
		{
			paused = !paused;
            
		}

        if (paused)
        {
            Time.timeScale = 0;
            menupause.SetActive(true);
        }
        else
            Time.timeScale = 1;
            menupause.SetActive(false);

    }

    
    
}
