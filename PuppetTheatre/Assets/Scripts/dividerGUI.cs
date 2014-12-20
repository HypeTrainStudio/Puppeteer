using UnityEngine;
using System.Collections;

public class dividerGUI : MonoBehaviour {

	public Texture divider;
	public Texture divider2;

	public puppeteer leapHand;

	void OnGUI(){
		GUI.DrawTexture(new Rect(-100, Screen.height/4, Screen.width+200, 20), divider2, ScaleMode.ScaleAndCrop);
		if(leapHand.leapOn)
			GUI.Label (new Rect (10, 10, 150, 100), "Leap Motion is ON");
		else
			GUI.Label (new Rect (10, 10, 150, 100), "Leap Motion is OFF");

		GUI.DrawTexture(new Rect((Screen.width/2)-170, (Screen.height/4)-85, 340, 200), divider);
	}
}
