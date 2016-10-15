using UnityEngine;
using System.Collections;

public class followPlayerAlly : MonoBehaviour
{
    public NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            agent.SetDestination(other.gameObject.transform.position);
        }
        if (other.gameObject.layer == 8)
        {
            if (other.gameObject.layer == 10)
            {
                agent.SetDestination(other.gameObject.transform.position);
            }
            agent.SetDestination(other.gameObject.transform.position);

        }
    }
}