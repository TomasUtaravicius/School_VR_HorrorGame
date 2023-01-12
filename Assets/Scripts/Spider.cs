using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spider : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform Eyes;
    private AudioSource source;
    private float nextTimeToAttack = 0f;
    private float timeForNextAttack = 2f;
    private NavMeshAgent nav;
    private Animator anim;
    public float damage = 25f;
    private string state = "idle";
    private bool alive = true;
    private float distance = 1000f;
    private bool burn = false;
    public SpiderSoundController soundController;
    private bool IsHit = false;
    private SphereCollider sCollider;
    public HealthManagerForSpider hManager;
    public GameObject Effect;
    [SerializeField] GameObject fire;

    private float wait = 0f;



    // Use this for initialization
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        sCollider = GetComponent<SphereCollider>();
        nav.speed = 1.2f;


    }
    public void footsteps()
    {
        if (nav.speed > 0.2)
        {
            soundController.PlayWalk();
        }
    }
    public void checkSight()
    {
        if (alive)
        {
            RaycastHit rayHit;
            Vector3 origing = gameObject.transform.position;
            if (Physics.Raycast(Eyes.position, Eyes.transform.forward, out rayHit))
            {
                Debug.DrawRay(Eyes.position, player.transform.position, Color.green);
                if (rayHit.collider.gameObject.tag == "Player")
                {
                    state = "chase";
                    soundController.PlayChase();
                    Debug.Log(rayHit.collider.gameObject.name);
                    nav.speed = 3.5f;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(nav.speed);
        Debug.Log(state);
        if (alive)
        {
            if (hManager.health <= 0f)
            {
                Debug.Log("DIEE because 0 health");
                state = "dead";
                Die();
                
            }
            if(state=="dead")
            {
               
                anim.SetBool("Hit", true);
            }
            if (state == "idle")
            {
                Vector3 randomPos = Random.insideUnitSphere * 20f;
                NavMeshHit navHit;
                NavMesh.SamplePosition(transform.position + randomPos, out navHit, 20f, NavMesh.AllAreas);
                nav.SetDestination(navHit.position);
                state = "walk";
                if (hManager.health <= 0f)
                {
                    Die();
                }

            }
            if (state == "walk")
            {
                checkSight();
                if (nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending)
                {
                    state = "idle";
                    if(hManager.health<=0f)
                    {
                        Die();
                    }
                }
            }
            if (state == "chase")
            {
                
                if (hManager.health <= 0f)
                {
                    Die();
                }
                nav.destination = player.transform.position;
                distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
                if (distance > 15f)
                {
                    soundController.StopChase();
                    state = "idle";
                }
                if (distance <= 2)
                {
                    soundController.StopChase();
                    state = "attack";
                    anim.Play("attack1");
                }

            }
            if (state == "attack")
            {

                if (hManager.health <= 0f)
                {
                    Die();
                }
                Vector3 targetPostition = new Vector3(player.transform.position.x,
                          this.transform.position.y,
                          player.transform.position.z);
                distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
                gameObject.transform.LookAt(targetPostition);

                if (distance > 15)
                {
                    nav.isStopped = false;
                    state = "idle";
                }
                if (distance > 2 && distance < 15)
                {
                    state = "chase";
                }
                if (Time.time >= nextTimeToAttack)
                {
                    nextTimeToAttack = Time.time + timeForNextAttack;
                    float random = Random.Range(0f, 1f);
                    if (random >= 0.5f)
                    {
                        Debug.Log("Attack1 was called just now");
                        Attack2();
                    }
                    if (random <= 0.5f)
                    {
                        Debug.Log("Attack2 was called just now");
                        Attack1();
                    }
                }
            }

            anim.SetFloat("velocity", nav.velocity.magnitude);
        }
    }
    private void Attack1()
    {
        nav.isStopped = true;
        anim.SetBool("attack", true);
        soundController.PlayAttack1();
        Invoke("GoBack", 0.3f);
    }
    private void Attack2()
    {
        nav.isStopped = true;
        anim.SetBool("attack2", true);
        soundController.PlayAttack2();
        Invoke("GoBack", 0.3f);
    }
    private void GoBack()
    {
        HealthManager healthManagerForPlayer = player.GetComponent<HealthManager>();
        healthManagerForPlayer.GetHit(damage);
        anim.SetBool("attack", false);
        anim.SetBool("attack2", false);
        nav.isStopped = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Slipper")
        {
            if (state != "attack" || state != "chase")
            {
                state = "chase";
            }
            hManager.GetHit(25f);
            soundController.HitSpider();
            
            float random = Random.Range(0f, 1f);
            if (random >= 0.5f)
            {
                anim.Play("hit1");
            }
            if (random <= 0.5f)
            {
                anim.Play("hit2");
            }
        }


    }
    public void Die()
    {
        var currentInstance = Instantiate(Effect) as GameObject;
        var psUpdater = currentInstance.GetComponent<PSMeshRendererUpdater>();
        psUpdater.UpdateMeshEffect(gameObject);
        soundController.StopChase();
        state = "dead";
        alive = false;
        anim.SetBool("Dead", true);
        anim.Play("deaht1");
        soundController.PlayDeath();
        Destroy(sCollider);
        Destroy(nav);
    }
}



