using UnityEngine;
using System.Collections;

public class Enemy3 : MonoBehaviour {
    //Follow enemy Variant 1
    public player_move playerScript;
    // public variable
    public int health;
    public int damage = 10;
    public int power = 7;
    public bool isFollowing;
    Animator anim;

    //private variables
    float movementSpeed = .3f;
    GameObject player;
    float maxSpeed = 2.5f;
    // Use this for initialization
    void Start()
    {
        //Initializing stat variables
        health = 60;
        //Finding Player
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        isFollowing = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (movementSpeed >= maxSpeed)
        {
            movementSpeed = maxSpeed;
        }
        float yDifference = player.transform.position.y - transform.position.y;
        float xDifference = player.transform.position.x - transform.position.x;
      
            if (xDifference < 0.0f)
            {
                anim.SetInteger("Movement", 1);
            }
            if (yDifference < 0.0f)
            {
                anim.SetInteger("Movement", 4);
            }
            if (xDifference > 0.0f)
            {
                anim.SetInteger("Movement", 3);
            }        
           
        if (isFollowing == true)
        {
            if (player)
            {
                movementSpeed += 0.015f;
                 yDifference = player.transform.position.y - transform.position.y;
                if (yDifference > .3f)
                {
                    if (yDifference < 0f)
                    {
                        transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);   
                    }
                    if (yDifference > 0f)
                    {
                        transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
                    }
                }
                else
                {
                    transform.Translate((player.transform.position - transform.position).normalized * movementSpeed * Time.deltaTime);
                }
                 xDifference = player.transform.position.x - transform.position.x;
                if (xDifference > .1f)
                {
                    if (xDifference < 0f)
                    {
                        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);

                    } if (xDifference > 0f)
                    {
                        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
                    }
                }
                else
                {
                    transform.Translate((player.transform.position - transform.position).normalized * movementSpeed * Time.deltaTime);

                }

            }
        }

        if (health <= 0)
        {
            playerScript.power += power;
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Knife")
        {
            Debug.Log("Hit3");
            health -= 20;
        }
        if (col.gameObject.tag == "Player")
        {
           
            movementSpeed = .3f;
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            movementSpeed = .3f;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isFollowing = true;
        }


    }
   
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isFollowing = false;
            movementSpeed = 1;
        }
    }
}
