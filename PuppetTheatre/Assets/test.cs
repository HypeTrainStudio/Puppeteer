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
	}

	// Update is called once per frame
	void FixedUpdate () {

		if(puppetL.leapOn || puppetR.leapOn)
		{
			Vector3 xyLVector = puppetL.index.transform.localPosition;
			Vector3 xyRVector = puppetR.index.transform.localPosition;

			HandL.transform.localPosition = new Vector3 (xyLVector.x * 2 - 5, xyLVector.y/2, 3);

			HandR.transform.localPosition = new Vector3 (xyRVector.x * 2 + 5, xyRVector.y/2, 3);

			if (puppetL.thumbUp) {
					this.rigidbody.AddRelativeForce (Vector3.forward/4, ForceMode.VelocityChange);
					this.transform.Rotate (Vector3.up);
			}

			if (puppetR.thumbUp) {
					this.rigidbody.AddRelativeForce (Vector3.forward/4, ForceMode.VelocityChange);
					this.transform.Rotate (Vector3.down);
			}

			if (puppetL.thumbUp && puppetR.thumbUp) {
					//this.transform.Translate(Vector3.forward/20, this.transform);
					//this.rigidbody.AddRelativeForce (Vector3.forward/2, ForceMode.VelocityChange);
					this.GetComponent<Animator>().SetBool("isWalking", true);
			}
			else{
				this.GetComponent<Animator>().SetBool("isWalking", false);
			}
		}
		else if(!puppetL.leapOn || !puppetR.leapOn)
		{
			if(Input.GetAxis("Vertical") > 0)
			{
				this.rigidbody.AddRelativeForce(Vector3.forward/2, ForceMode.VelocityChange);
				this.GetComponent<Animator>().SetBool("isWalking", true);
			}
			else{
				this.GetComponent<Animator>().SetBool("isWalking", false);
			}

			if(Input.GetAxis("Horizontal") < 0)
			{
				this.transform.Rotate(Vector3.down);
			}
			else if(Input.GetAxis("Horizontal") > 0)
			{
				this.transform.Rotate(Vector3.up);
			}

			HandL.transform.localPosition = new Vector3 (((Input.mousePosition.x  - Screen.width/2)/75) - .1f, (Input.mousePosition.y - Screen.height/2)/100, 3);
			HandR.transform.localPosition = new Vector3 (((Input.mousePosition.x - Screen.width/2)/75) + .1f, (Input.mousePosition.y - Screen.height/2)/100, 3);
		}
	}
}
