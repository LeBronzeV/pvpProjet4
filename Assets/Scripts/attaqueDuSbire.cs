using UnityEngine;
using System.Collections;

public class attaqueDuSbire : MonoBehaviour
{

    public Animator animator;
    public float degat;
    private float temps;
    private bool attackLaunching = false;
    private bool detection = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (detection == true)
        {
            animator.SetBool("isAttacking", true);
            temps += Time.deltaTime;
            if (temps > 1.02f)
            {
                temps = 0.0f;
                attackLaunching = true;
            }
        }
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9 || other.gameObject.layer == 11)
        {
            detection = true;
            if (attackLaunching == true)
            {
                attackLaunching = false;
                detection = false;
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

    /*IEnumerator OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9 || other.gameObject.layer == 11)
        {
            detection = true;
            if (attackLaunching == true)
            {
                attackLaunching = false;
                detection = false;
                if (Physics.Raycast(transform.position, transform.forward, 1))
                {
                    other.gameObject.SendMessage("TakeDamage", degat);
                }
                yield return new WaitForSeconds(0.1f);
                animator.SetBool("isAttacking", false);
                //other.gameObject.SetActive(false);
                //other.gameObject.SetActive(true);
            }
        }
    }*/
}