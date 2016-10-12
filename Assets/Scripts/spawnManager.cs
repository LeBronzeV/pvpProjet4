using UnityEngine;
using System.Collections;

public class spawnManager : MonoBehaviour {

    public GameObject sbireTL;
    public GameObject sbireBL;
    public GameObject sbireTR;
    public GameObject sbireBR;
    public GameObject spawnLT;
    public GameObject spawnLB;
    public GameObject spawnRT;
    public GameObject spawnRB;
    public float spawnDeltaTime = 2f;
    public float spawnDeltaTime2 = 20f;
    private float m_timer = 0.0f;
    private float n_timer = 0.0f;
    public int nombreSbire = 0;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        m_timer += Time.deltaTime;
        n_timer += Time.deltaTime;

        if (n_timer > spawnDeltaTime2)
        {
            nombreSbire = 0;
            n_timer = 0.0f;
            m_timer = 0.0f;
        }
        if (m_timer > spawnDeltaTime){
            m_timer = 0.0f;

            if (nombreSbire < 3){
                nombreSbire++;
                GameObject sbire = (GameObject)Instantiate(sbireTL, spawnLT.transform.position, Quaternion.identity);
                GameObject sbire1 = (GameObject)Instantiate(sbireBL, spawnLB.transform.position, Quaternion.identity);
                GameObject sbire2 = (GameObject)Instantiate(sbireTR, spawnRT.transform.position, Quaternion.identity);
                GameObject sbire3 = (GameObject)Instantiate(sbireBR, spawnRB.transform.position, Quaternion.identity);
            }
        }
    }
}
