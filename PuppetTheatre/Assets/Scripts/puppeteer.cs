using UnityEngine;
using System.Collections;
using Leap;

public class puppeteer : MonoBehaviour {

	public bool isLeft;

	public GameObject pinky;
	public GameObject ring;
	public GameObject middle;
	public GameObject index;
	public GameObject thumb;
	public GameObject palm;

	Vector3 pinDef;
	Vector3 rinDef;
	Vector3 midDef;
	Vector3 indDef;
	Vector3 thuDef;

	Vector indexLeap;
	Vector thumbLeap;
	Vector ringLeap;
	Vector pinkyLeap;
	Vector middleLeap;
	Vector palmLeap;

	Hand currentHand = null;

	public bool thumbUp;
	public bool leapOn;

	Vector3 pointerLoc;
	public Vector3 getPointer;

	private Controller leapMotion;
	Frame frame;

	// Use this for initialization
	void Start () {
	
		leapMotion = new Controller();
		pinDef = pinky.transform.position;
		rinDef = ring.transform.position;
		midDef = middle.transform.position;
		indDef = index.transform.position;
		thuDef = thumb.transform.position;

		if (leapMotion.IsConnected)
			leapOn = true;
		else
			leapOn = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		getHandPositions ();

		if((thumb.transform.position.y-palm.transform.position.y) > 0)
		{
			thumbUp = true;
		}
		else
			thumbUp = false;

		pointerLoc = index.transform.position + palm.transform.position;
		getPointer = pointerLoc;


	}

	void getHandPositions()
	{
		frame = leapMotion.Frame();

		if(frame.Hands.Count > 0)
		{
			if(isLeft)
				currentHand = frame.Hands.Leftmost;
			else if(!isLeft)
				currentHand = frame.Hands.Rightmost;
		}
		else
		{
			currentHand = null;
			resetPositions();
		}

		if(currentHand != null)
		{
			if(currentHand.IsLeft && isLeft)
			{
				palmLeap = currentHand.PalmPosition;
				palm.transform.eulerAngles = new Vector3(currentHand.PalmNormal.x*90, currentHand.PalmNormal.y*90, -currentHand.PalmNormal.z*90);
				
				indexLeap = currentHand.Fingers[1].TipPosition - palmLeap;
				index.transform.position = palm.transform.position + new Vector3(indexLeap.x, indexLeap.y, -indexLeap.z)/10;
				
				middleLeap = currentHand.Fingers[2].TipPosition - palmLeap;
				middle.transform.position = palm.transform.position + new Vector3(middleLeap.x, middleLeap.y , -middleLeap.z)/10;
				
				ringLeap = currentHand.Fingers[3].TipPosition - palmLeap;
				ring.transform.position = palm.transform.position + new Vector3(ringLeap.x, ringLeap.y, -ringLeap.z)/10;
				
				pinkyLeap = currentHand.Fingers[4].TipPosition - palmLeap;
				pinky.transform.position = palm.transform.position + new Vector3(pinkyLeap.x ,pinkyLeap.y ,-pinkyLeap.z)/10;
				
				thumbLeap = currentHand.Fingers[0].TipPosition - palmLeap;
				thumb.transform.position = palm.transform.position + new Vector3(thumbLeap.x ,thumbLeap.y ,-thumbLeap.z)/10;
			}
			else if(currentHand.IsRight && !isLeft)
			{
				palmLeap = currentHand.PalmPosition;
				palm.transform.eulerAngles = new Vector3(currentHand.PalmNormal.x*90, currentHand.PalmNormal.y*90, -currentHand.PalmNormal.z*90);

				indexLeap = currentHand.Fingers[1].TipPosition - palmLeap;
				index.transform.position = palm.transform.position + new Vector3(indexLeap.x, indexLeap.y, -indexLeap.z)/10;
				
				middleLeap = currentHand.Fingers[2].TipPosition - palmLeap;
				middle.transform.position = palm.transform.position + new Vector3(middleLeap.x, middleLeap.y , -middleLeap.z)/10;
				
				ringLeap = currentHand.Fingers[3].TipPosition - palmLeap;
				ring.transform.position = palm.transform.position + new Vector3(ringLeap.x, ringLeap.y, -ringLeap.z)/10;
				
				pinkyLeap = currentHand.Fingers[4].TipPosition - palmLeap;
				pinky.transform.position = palm.transform.position + new Vector3(pinkyLeap.x ,pinkyLeap.y ,-pinkyLeap.z)/10;
				
				thumbLeap = currentHand.Fingers[0].TipPosition - palmLeap;
				thumb.transform.position = palm.transform.position + new Vector3(thumbLeap.x ,thumbLeap.y ,-thumbLeap.z)/10;
			}
			else
			{
				currentHand = null;
				resetPositions();
			}
		}
	}

	void resetPositions()
	{
		index.transform.position = indDef;
		middle.transform.position = midDef;
		ring.transform.position = rinDef;
		pinky.transform.position = pinDef;
		thumb.transform.position = thuDef;
		palm.transform.eulerAngles = Vector3.zero;
	}
}
