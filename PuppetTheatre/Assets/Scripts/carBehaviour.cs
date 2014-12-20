using UnityEngine;
using System.Collections;

public class carBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision hit)
	{
		if(hit.collider.GetComponent<Rigidbody>()){
			Debug.Log("Hello");
			this.rigidbody.AddForce(Vector3.left*200, ForceMode.Impulse);
		}
	}
}
