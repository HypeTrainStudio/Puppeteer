using UnityEngine;
using System.Collections;

public class horse : MonoBehaviour {

	public AudioSource neigh;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision hit)
	{
		if(hit.collider.tag != "ground")
		{
			if(!neigh.isPlaying)
			{
				neigh.Play();
			}
		}
	}
}
