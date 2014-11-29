using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

	public Rigidbody HandR;
	public Rigidbody HandL;
	public Rigidbody FootR;
	public Rigidbody FootL;

	Vector3 footRDefault;
	Vector3 footLDefault;

	public puppeteer RhandControl;
	public puppeteer LhandControl;

	bool isStep;
	float stepTimer;

	// Use this for initialization
	void Start () {
	
		footLDefault = FootL.transform.position;
		footRDefault = FootR.transform.position;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		this.rigidbody.AddRelativeForce(transform.forward, ForceMode.Impulse);

		//HandL.transform.position = new Vector3(LhandControl.getPointer.x/5 + this.transform.position.x,LhandControl.getPointer.y + this.transform.position.y, 15);
		//HandR.transform.position = new Vector3(RhandControl.getPointer.x/5 + this.transform.position.x,RhandControl.getPointer.y + this.transform.position.y, 15);

		if (isStep) {
			stepTimer += 1 * Time.deltaTime;
		}

		if(stepTimer > 0.5f)
		{
			stepTimer = 0;
			isStep = false;
		}

		if(LhandControl.thumbUp)
		{
			FootL.AddForce(new Vector3(.5f,.5f,0) ,ForceMode.Impulse);

			this.rigidbody.transform.Rotate(Vector3.up);
		}

		if(RhandControl.thumbUp)
		{
			FootR.AddForce(new Vector3(.5f,.5f,0) ,ForceMode.Impulse);

			this.rigidbody.transform.Rotate(Vector3.down);
		}
	}
}
