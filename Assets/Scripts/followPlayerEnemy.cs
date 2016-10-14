using UnityEngine;
using System.Collections;

public class followPlayerEnemy : MonoBehaviour {

    public NavMeshAgent agent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay (Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            agent.SetDestination(other.gameObject.transform.position);
        }
        if (other.gameObject.layer == 9)
        {
            if (other.gameObject.layer == 11)
            {
                agent.SetDestination(other.gameObject.transform.position);
            }
            agent.SetDestination(other.gameObject.transform.position);

        }
    }
}