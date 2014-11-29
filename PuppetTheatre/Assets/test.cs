using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	
	public Rigidbody HandR;
	public Rigidbody HandL;
	public Rigidbody FootR;
	public Rigidbody FootL;
	
	public puppeteer puppetL;
	public puppeteer puppetR;

	Vector3 footRDefault;
	Vector3 footLDefault;


	// Use this for initialization
	void Start () {
		
		footLDefault = FootL.transform.position;
		footRDefault = FootR.transform.position;

	}

	// Update is called once per frame
	void Update () {

		Vector3 xyLVector = puppetL.index.transform.localPosition;
		Vector3 xyRVector = puppetR.index.transform.localPosition;

		HandL.transform.localPosition = new Vector3 (xyLVector.x * 2 - 10, xyLVector.y, 4);

		HandR.transform.localPosition = new Vector3 (xyRVector.x * 2 + 5, xyRVector.y, 4);

		if(puppetL.thumbUp)
	   	{
			this.transform.Rotate(Vector3.up);
		}

		if(puppetR.thumbUp)
		{
			this.transform.Rotate(Vector3.down);
			FootR.AddForce(Vector3.up);
		}

		if(puppetL.thumbUp || puppetR.thumbUp)
		{
			//this.transform.Translate(Vector3.forward/20, this.transform);
			this.rigidbody.AddRelativeForce(Vector3.forward, ForceMode.Impulse);
		}
	}
}
