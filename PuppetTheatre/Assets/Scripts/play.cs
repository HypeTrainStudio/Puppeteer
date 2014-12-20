using UnityEngine;
using System.Collections;

public class play : MonoBehaviour {

	float selectTimer;
	bool selected;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(selected)
		{	
			this.renderer.material.color = Color.Lerp(Color.white,Color.red,10);
			selectTimer = selectTimer += 1 * Time.deltaTime;
		}
		else
			this.renderer.material.color = Color.white;

		if(selectTimer > 2)
		{
			Application.LoadLevel("PuppetTest");
		}
	}

	void OnTriggerEnter(Collider hit)
	{
		if(hit.tag == "cursor")
		{
			selected = true;
		}
	}
	void OnTriggerExit(Collider hit)
	{
		if(hit.tag == "cursor")
		{
			selected = false;
			selectTimer = 0;
		}
	}
}
