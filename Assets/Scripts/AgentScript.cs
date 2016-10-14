using UnityEngine;
using System.Collections;

public class AgentScript : MonoBehaviour
{

    public Transform target;
    public Transform[] targets;
    public NavMeshAgent agent;
    [SerializeField]private int i = 0;

    // Use this for initialization
    void Start(){
    }

    void searchNavMesh ( Vector3 position)
    {
        agent.SetDestination(position);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        var dist = Vector3.Distance(targets[i].position, transform.position);
        target = targets[i];
        if (dist < 3)
        {
            i++;
            if (i < targets.Length)
                agent.destination = targets[i].position;
        }
    }
}
