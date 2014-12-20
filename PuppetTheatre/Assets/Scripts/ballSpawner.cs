using UnityEngine;
using System.Collections;

public class ballSpawner : MonoBehaviour {

	public GameObject ballFab;
	Vector3 spawnLoc;
	float randSeedX;
	float randSeedZ;
	float randSeedY;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 200;i++)
		{
			randSeedX = this.transform.position.x + Random.Range(-10,10);
			randSeedY = this.transform.position.y + Random.Range(-2f,2f);
			randSeedZ = this.transform.position.z + Random.Range(-15,15);

			Instantiate(ballFab, new Vector3(randSeedX, randSeedY, randSeedZ), this.gameObject.transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
