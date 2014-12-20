using UnityEngine;
using System.Collections;

public class toggleSwitch : MonoBehaviour {

	bool isSwitched;
	float switchTimer;
	public Texture altTexture1;
	public Texture altTexture2;
	public Texture altTexture3;
	public Texture altTexture4;

	int textureType;

	public GameObject wall1;
	public GameObject wall2;
	public GameObject wall3;
	public GameObject wall4;

	// Use this for initialization
	void Start () {
		isSwitched = false;
		switchTimer = 0;
		textureType = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(isSwitched)
		{
			switchTimer += 1 * Time.deltaTime;
		}

		if(switchTimer > 2)
		{
			isSwitched = false;
			switchTimer = 0;
			this.transform.Translate(Vector3.forward/2);
		}
	
	}

	void OnTriggerEnter(Collider hit){
		if(!isSwitched && hit.tag == "hand"){
			if(textureType < 3){
				textureType ++;
			}
			else{
				textureType = 0;
			}

			this.transform.Translate(Vector3.back/2);
			isSwitched = true;

			switch(textureType)
			{
				case 0:
					wall1.renderer.material.mainTexture = altTexture1;
					wall2.renderer.material.mainTexture = altTexture1;
					wall3.renderer.material.mainTexture = altTexture1;
					wall4.renderer.material.mainTexture = altTexture1;
					break;
				case 1:
					wall1.renderer.material.mainTexture = altTexture2;
					wall2.renderer.material.mainTexture = altTexture2;
					wall3.renderer.material.mainTexture = altTexture2;
					wall4.renderer.material.mainTexture = altTexture2;
					break;
				case 2:
					wall1.renderer.material.mainTexture = altTexture3;
					wall2.renderer.material.mainTexture = altTexture3;
					wall3.renderer.material.mainTexture = altTexture3;
					wall4.renderer.material.mainTexture = altTexture3;
					break;
				case 3:
					wall1.renderer.material.mainTexture = altTexture4;
					wall2.renderer.material.mainTexture = altTexture4;
					wall3.renderer.material.mainTexture = altTexture4;
					wall4.renderer.material.mainTexture = altTexture4;
					break;
				default:
					break;
			}
		}
	}
}
