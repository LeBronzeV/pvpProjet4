using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy_sbire_Attack : MonoBehaviour {

    public Animator animator;
    public float degat;
    List<GameObject> inRangeAlly = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (inRangeAlly.Count >= 1)
        {
            StartCoroutine(attacking());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 10)
        {
            inRangeAlly.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        inRangeAlly.Remove(other.gameObject);
    }

    IEnumerator attacking()
    {
        animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(1.02f);
        if (Physics.Raycast(transform.position, transform.forward, 1))
        {
            inRangeAlly[0].SendMessage("TakeDamageEnemy", degat);
        }
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("isAttacking", false);
    }
}