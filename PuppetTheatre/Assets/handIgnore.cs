using UnityEngine;
using System.Collections;

public class handIgnore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision hit){
		if (!hit.collider.GetComponent<Rigidbody> ()) {
			Physics.IgnoreCollision(this.collider, hit.collider);
			Debug.Log("No hit.");
		}
	}
}
