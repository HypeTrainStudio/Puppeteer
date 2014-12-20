using UnityEngine;
using System.Collections;

public class keyBoard : MonoBehaviour {

	bool pianoIsDown;
	public AudioSource pianoSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(pianoIsDown)
		{
			if(!pianoSound.isPlaying){
				pianoSound.Play();
			}
		}

	}

	void OnCollisionEnter(Collision hit)
	{
		if(!pianoIsDown)
		{
			pianoIsDown = true;
		}
	}

	void OnCollisionExit(Collision hit)
	{
		if(pianoIsDown)
		{
			pianoIsDown = false;
		}
	}
}
