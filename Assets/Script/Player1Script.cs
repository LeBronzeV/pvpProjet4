using UnityEngine;
using System.Collections;

public class Player1Script : MonoBehaviour {

    public float MaxHP;
    public float Attack;
    public float Speed;
    public float throwForce;
    public float MunitionCooldown;

    public Camera mainCamera;
    public GameObject AoE;
    public GameObject Attack1;
    public GameObject Special1;

    private int Munition;
    private float HP;
    private Vector3 Direction;
    private bool dashing = false;
    private float dashTime;
    private float MunitionCooldownTimer;
    


    // Use this for initialization
    void Start () {
        HP = MaxHP;
        Munition = 1;
	}

    void TakeDamage(float montant)
    {
        HP -= montant;
    }

    // Update is called once per frame
    void Update () {
        
        if(HP < 0)
        {
            Destroy(this.gameObject);
        }
        if (Munition < 2)
        {
            if(MunitionCooldownTimer > MunitionCooldown)
            {
                Munition += 1;
                MunitionCooldownTimer=0.0f;
            }
            MunitionCooldownTimer += Time.deltaTime;
        }

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


            if (Input.GetMouseButtonDown(0)) // 0 = clic gauche , tir
            {
                AoE.SetActive(true);
                playerPlane = new Plane(Vector3.up, gameObject.transform.position);
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                hitdist = 0.0f;
                if (playerPlane.Raycast(ray, out hitdist))
                {
                    var targetPoint = ray.GetPoint(hitdist);
                    Direction = targetPoint - gameObject.transform.position;
                    Direction = Vector3.Normalize(Direction);

                    GameObject attack = (GameObject)Instantiate(Attack1, this.gameObject.transform.position, Quaternion.identity);
                    attack.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(Direction) * throwForce);
                    attack.GetComponent("Attaque1Script").SendMessage("SetDamages",Attack);
                }

            }

            if (Input.GetMouseButtonDown(1)) // 1 = clic droit , dash
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

            if (Input.GetKeyDown("space") && Munition > 0) // Barre espace, attaque spéciale (grenade)
            {
                Munition -= 1;

                playerPlane = new Plane(Vector3.up, gameObject.transform.position);
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                hitdist = 0.0f;
                if (playerPlane.Raycast(ray, out hitdist))
                {
                    var targetPoint = ray.GetPoint(hitdist);
                    Direction = targetPoint - gameObject.transform.position;
                    Direction = Vector3.Normalize(Direction);
                    Direction.y += 0.7f;

                    GameObject specialAttack = (GameObject)Instantiate(Special1, this.gameObject.transform.position, Quaternion.identity);
                    specialAttack.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(Direction) * throwForce *30);
                    specialAttack.GetComponent("grenadeScript").SendMessage("SetDamages", Attack);
                }
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
