using UnityEngine;
using System.Collections;

public class DestroyArrow : MonoBehaviour {

	void Awake () {

        Destroy(gameObject, 1f);
	
	}
}
