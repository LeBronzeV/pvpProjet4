using UnityEngine;
using System.Collections;

public class Player1Script : MonoBehaviour {

    public float MaxHP;
    public float Attack;
    public float Speed;

    public Camera mainCamera;
    public GameObject AoE;

    private float HP;
    private Vector3 Direction;
    private bool dashing = false;
    private float dashTime;


    // Use this for initialization
    void Start () {
        HP = MaxHP;
	}
	
	// Update is called once per frame
	void Update () {
        if (dashing == false)
        {
            Direction = Vector3.zero;
            //Forward
            if (Input.GetKey(KeyCode.Z))
            {
                Direction += Vector3.forward;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                Direction += Vector3.left;
            }
            if (Input.GetKey(KeyCode.S))
            {
                Direction += Vector3.back;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Direction += Vector3.right;
            }
            gameObject.transform.position += Speed * Direction * Time.deltaTime;



            var playerPlane = new Plane(Vector3.up, gameObject.transform.position);
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hitdist = 0.0f;
            if (playerPlane.Raycast(ray, out hitdist))
            {
                var targetPoint = ray.GetPoint(hitdist);
                var targetRotation = Quaternion.LookRotation(targetPoint - gameObject.transform.position);
                gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, targetRotation, 100 * Time.deltaTime);
            }


            if (Input.GetMouseButtonDown(0)) // 0 = clic gauche , 1 = clic droit
            {
                AoE.SetActive(true);

            }

            if (Input.GetMouseButtonDown(1)) // 0 = clic gauche , 1 = clic droit
            {
                dashing = true;
                playerPlane = new Plane(Vector3.up, gameObject.transform.position);
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                hitdist = 0.0f;
                if (playerPlane.Raycast(ray, out hitdist))
                {
                    var targetPoint = ray.GetPoint(hitdist);
                    Direction = targetPoint - gameObject.transform.position;
                    Direction = Vector3.Normalize(Direction);
                }
                dashTime = 0.0f;
            }
        }
        else
        {
            dashTime += Time.deltaTime;
            gameObject.transform.position +=  4*Speed * Direction * Time.deltaTime;
            if (dashTime > 0.20f)
            {
                dashing = false;
            }
        }
    }
}
