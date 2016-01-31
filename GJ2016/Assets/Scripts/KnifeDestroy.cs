using UnityEngine;
using System.Collections;

public class KnifeDestroy : MonoBehaviour {

    void Awake()
    {
        Destroy(gameObject, 2f);
    }
    
	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Map")
        if (col.gameObject.tag == "Enemy1")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Enemy2")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Enemy3")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Map")
        {
            Destroy(gameObject);
        }
    }
}
