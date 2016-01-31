using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player_move : MonoBehaviour {
    //Public Variables
    public int health;
    public int damage = 20;
    public int power = 0;
    public float knifeVelocity;

    //Public Objects
    public Animator anim;
    public Rigidbody2D knife;
    public Text healthText;
    public Slider healthSlider;
    public Enemy1 enemy1Script;
    public Text powerText;
    public Slider powerSlider;
    public Enemy2 enemy2Scipt;
    public Enemy3 enemy3Script;

    //Misc Variables
    float movementSpeed = 1;
    float attackSpeed;
    int maxHealth = 100;
    float attackTimer;
    float hitTimer;
    int maxPower = 140;

    private GameObject[] enemies;
    public Transform bloodTrail;

    static public bool bloody = false;

    void Start()
    {

        //damage = 20;
        health = 100;
        knifeVelocity = 2.5f;
        attackSpeed = .4f;
        healthSlider.minValue = 0;
        healthSlider.maxValue = maxHealth;
        attackTimer = 0.0f;
        powerSlider.minValue = 0;
        powerSlider.maxValue = maxPower;

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        anim = GetComponent<Animator>();

       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetInteger("Movement", 2);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetInteger("Movement", 1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetInteger("Movement", 4);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetInteger("Movement", 3);
        }
        healthText.text = ("HP: " + health);
        healthSlider.value = health;
        powerText.text = ("Power: " + power);
        powerSlider.value = power;
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * movementSpeed, Input.GetAxis("Vertical") * movementSpeed, 0) * Time.deltaTime);
       
        if (Input.GetKeyDown(KeyCode.UpArrow) && Time.time >= attackTimer)
        {
            Rigidbody2D knifeThrow = Instantiate(knife, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), transform.rotation) as Rigidbody2D;
            knifeThrow.velocity = transform.TransformDirection(new Vector3(0, knifeVelocity, 0));
            knifeThrow.transform.Rotate(0f, 0, 315f);
            attackTimer = Time.time + attackSpeed;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && Time.time >= attackTimer)
        {
            Rigidbody2D knifeThrow = Instantiate(knife, new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z), transform.rotation) as Rigidbody2D;
            knifeThrow.velocity = transform.TransformDirection(new Vector3(0, -knifeVelocity, 0));
            knifeThrow.transform.Rotate(0f, 0, 135f);
            attackTimer = Time.time + attackSpeed;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && Time.time >= attackTimer)
        {
            Rigidbody2D knifeThrow = Instantiate(knife, new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
            knifeThrow.velocity = transform.TransformDirection(new Vector3(-knifeVelocity, 0, 0));
            knifeThrow.transform.Rotate(0, 0, 45f);
            attackTimer = Time.time + attackSpeed;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && Time.time >= attackTimer)
        {
            Rigidbody2D knifeThrow = Instantiate(knife, new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
            knifeThrow.velocity = transform.TransformDirection(new Vector3(knifeVelocity, 0, 0));
            knifeThrow.transform.Rotate(0, 0, 225f);
            attackTimer = Time.time + attackSpeed;

        }

        if (power >= 1 && Input.GetKeyDown(KeyCode.E))
        {
            health += power;
            power = 0;
            
        }

        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        if (power >= maxPower)
        {
            power = maxPower;
        }
            GetClosestEnemy(enemies);
    }

    GameObject GetClosestEnemy(GameObject[] enemies)
    {
        GameObject tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        if (!bloody)
        {

            foreach (GameObject t in enemies)
            {
                float dist = Vector3.Distance(t.transform.position, currentPos);
                if (dist < minDist)
                {
                    tMin = t;
                    minDist = dist;

                    //if (power >= 1 && Input.GetKeyDown(KeyCode.L))
                    //{
                        //Instantiate(bloodTrail, tMin.transform.position, tMin.transform.rotation);
                        Destroy(tMin);
                        bloody = true;
                    //}
                }
            }
            return tMin;
        }
        else
        {
            return null;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy1")
        {
            health -= enemy1Script.damage;
          
        }
        if (col.gameObject.tag == "Enemy3")
        {
            health -= enemy3Script.damage;
         
        }

        if (col.gameObject.tag == "Arrow")
        {
            health -= enemy2Scipt.damage;
           
        }
       
    }
}
