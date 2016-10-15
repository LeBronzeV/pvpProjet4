using UnityEngine;
using System.Collections;

public class Player1Script : MonoBehaviour {

    public float MaxHP;
    public float Attack;
    public float Speed;
    public float throwForce;
    public float MunitionCooldown;

    public Camera mainCamera;
    public GameObject Explosion;
    public GameObject Attack1;
    public GameObject Special1;

    private int Munition;
    public float HP;
    private Vector3 Direction;
    private bool dashing = false;
    private float dashTime;
    private float MunitionCooldownTimer;

    public Transform respawnPlayerAlly;
    public Collider monCol;
    public Rigidbody monRigid;

    [SerializeField]
    private ParticleSystem particule1;
    [SerializeField]
    private ParticleSystem particule2;
    [SerializeField]
    private ParticleSystem particule3;
    
    // Use this for initialization
    void Start () {
        HP = MaxHP;
        Munition = 1;
	}

    void changementCamera(Camera cam)
    {
        mainCamera = cam;
    }

    void TakeDamageEnemy(float montant)
    {
        HP -= montant;
    }

    

    // Update is called once per frame
    void Update () {
        

        if (HP <= 0)
        {
            StartCoroutine(respawnTime());
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
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            var hitdist = 0.0f;
            if (playerPlane.Raycast(ray, out hitdist))
            {
                var targetPoint = ray.GetPoint(hitdist);
                var targetRotation = Quaternion.LookRotation(targetPoint - gameObject.transform.position);
                gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, targetRotation, 100 * Time.deltaTime);
            }


            if (Input.GetMouseButtonDown(0)) // 0 = clic gauche , tir
            {
                Explosion.SetActive(true);
                playerPlane = new Plane(Vector3.up, gameObject.transform.position);
                ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                hitdist = 0.0f;
                if (playerPlane.Raycast(ray, out hitdist))
                {
                    var targetPoint = ray.GetPoint(hitdist);
                    Direction = targetPoint - gameObject.transform.position;
                    Direction = Vector3.Normalize(Direction);
                    var ballPosition = this.gameObject.transform.position;
                    ballPosition.y += 0.5f;

                    GameObject attack = (GameObject)Instantiate(Attack1, ballPosition, Quaternion.identity);
                    attack.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(Direction) * throwForce);
                    attack.GetComponent("Attaque1Script").SendMessage("SetDamages",Attack);
                }

            }

            if (Input.GetMouseButtonDown(1)) // 1 = clic droit , dash
            {
                dashing = true;
                playerPlane = new Plane(Vector3.up, gameObject.transform.position);
                ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                hitdist = 0.0f;
                if (playerPlane.Raycast(ray, out hitdist))
                {
                    var targetPoint = ray.GetPoint(hitdist);
                    Direction = targetPoint - gameObject.transform.position;
                    Direction = Vector3.Normalize(Direction);
                }
                dashTime = 0.0f;
            }

            if (Input.GetKeyUp("space") && Munition > 0) // Barre espace, attaque spéciale (grenade)
            {
                Munition -= 1;

                playerPlane = new Plane(Vector3.up, gameObject.transform.position);
                ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                hitdist = 0.0f;
                if (playerPlane.Raycast(ray, out hitdist))
                {
                    var targetPoint = ray.GetPoint(hitdist);
                    Direction = targetPoint - gameObject.transform.position;
                    Direction = Vector3.Normalize(Direction);
                    Direction.y += 3.0f;

                    GameObject specialAttack = (GameObject)Instantiate(Special1, this.gameObject.transform.position, Quaternion.identity);
                    specialAttack.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(Direction) * throwForce *60);
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

    IEnumerator respawnTime()
    {
        monCol.enabled = false;
        monRigid.isKinematic = true;
        yield return new WaitForSeconds(5.0f);
        monCol.enabled = true;
        monRigid.isKinematic = false;
        this.gameObject.transform.position = respawnPlayerAlly.position;
        particule1.Play();
        particule2.Play();
        particule3.Play();
        HP = MaxHP;
    }
}
