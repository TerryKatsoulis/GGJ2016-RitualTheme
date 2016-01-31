using UnityEngine;
using System.Collections;

public class Enemy2Shoot : MonoBehaviour {

    public Transform target;
    public float speed = 1f;
    private float range;
    public Rigidbody2D arrow;
    public float starTimer;
    public float RateofStar;
    public bool Throw = false;

    // Use this for initialization
    void Start()
    {
        starTimer = Time.time + RateofStar;

    }


    void Update()
    {
        //this makes the ninja shoot a star at a regular, user selected interval,
        //at the characters location at that instant
        if (Time.time > starTimer)
        {
            Vector2 blueArrow = new Vector2(target.position.x, target.position.y);
            Vector2 ninPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = -(ninPos - blueArrow);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            Rigidbody2D arrowThrow = Instantiate(arrow, new Vector3(transform.position.x, transform.position.y, transform.position.z), rotation) as Rigidbody2D;
            arrowThrow.velocity = transform.TransformDirection(direction);
            arrowThrow.transform.Rotate(0, 0, 90);

            starTimer = Time.time + RateofStar;
            Throw = true;
        }

    }
}
