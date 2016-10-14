using UnityEngine;
using System.Collections;

public class attaqueDuSbire : MonoBehaviour {

    public Animator animator;
    public float degat;
    private float temps;

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
        temps += Time.deltaTime;
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9 || other.gameObject.layer == 11)
        {
            animator.SetBool("isAttacking", true);
            yield return new WaitForSeconds(1.02f);
            if (Physics.Raycast(transform.position, transform.forward, 1))
            {
                other.gameObject.SendMessage("TakeDamage", degat);
            }
            yield return new WaitForSeconds(0.1f);
            animator.SetBool("isAttacking", false);
            other.gameObject.SetActive(false);
            other.gameObject.SetActive(true);
        }
    }
}
