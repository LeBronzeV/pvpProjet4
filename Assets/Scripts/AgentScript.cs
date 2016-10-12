using UnityEngine;
using System.Collections;

public class AgentScript : MonoBehaviour {

    public Transform target;
    public Transform[] targets;
    NavMeshAgent agent;
    private int i = 0;

	// Use this for initialization
	void Start (){
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update(){
        var dist = Vector3.Distance(targets[i].position, transform.position);
        target = targets[i];
        if (dist < 2){
            i++;
            if (i < targets.Length)
                agent.destination = targets[i].position;
            if (i == targets.Length){
                i = 0;
                agent.destination = targets[i].position;
            }
        }
    }
}
