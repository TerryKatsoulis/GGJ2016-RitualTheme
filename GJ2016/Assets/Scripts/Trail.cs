using UnityEngine;
using System.Collections;

public class Trail : MonoBehaviour
{

    public Transform target;
    public float speed = 5f;
    private float range;
    public Rigidbody2D arrow;

    // Use this for initialization
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Vector2 playerPos = new Vector2(target.position.x, target.position.y);
            Vector2 bloodSource = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = -(bloodSource - playerPos);
            //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            Rigidbody2D bloodThrow = Instantiate(arrow, new Vector3(transform.position.x, transform.position.y, transform.position.z), rotation) as Rigidbody2D;
            bloodThrow.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            bloodThrow.velocity = direction * speed;
        }
    }
}