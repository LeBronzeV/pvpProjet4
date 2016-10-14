using UnityEngine;
using System.Collections;

public class followPlayerAlly : MonoBehaviour
{
    public GameObject sbireParent;
    

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
        
            if (other.gameObject.layer == 10 || other.gameObject.layer == 8)
            {
                sbireParent.SendMessage("searchNavMesh", other.gameObject.transform.position);

            }
    }
}