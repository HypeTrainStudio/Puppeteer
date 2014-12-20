using UnityEngine;
using System.Collections;
using Leap;

public class pointerScript : MonoBehaviour {

	public Camera main;
	private Controller leapMotion;
	Frame frame;
	Cursor cursor;

	bool leapOn;

	// Use this for initialization
	void Start () {
		leapMotion = new Controller();
		if (leapMotion.IsConnected)
			leapOn = true;
		else
			leapOn = false;

	}
	
	// Update is called once per frame
	void Update () {

		frame = leapMotion.Frame();

		if (leapOn) {
			this.transform.position = main.ScreenToWorldPoint(new Vector3(frame.Fingers[1].TipPosition.x + UnityEngine.Screen.width/2, frame.Fingers[1].TipPosition.y,10));
		}
		else if(!leapOn)
		{
			this.transform.position = main.ScreenToWorldPoint( new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
		}

	}
}
