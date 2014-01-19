using UnityEngine;
using System.Collections;

public class scriptEnemy : MonoBehaviour {
	// Enemy Script

	// Inspector Variables
	public int numberOfClicks = 2;
	public Color[] shapeColor ;		// Color of object
	public float respWaitTime = 8F;	// How many time to wait
	public Transform explosion;		// Load explosion
	public int enemyPoint = 1;			// Enemy points

	// Private Variables
	private int storeClicks = 0;

	
	// Use this for initialization
	void Start () {
		storeClicks = numberOfClicks;  
		Vector3 position = new Vector3(Random.Range(-6, 6), Random.Range(-4, 4), 0);	// new random position
       	transform.position = position;	// move the GO to the new location

		RandomColor();
    }
	
	
	// Update is called once per frame
	void Update () {
		if(numberOfClicks <= 0){
			if (explosion) {
				Instantiate (explosion, transform.position, transform.rotation); // create an explosion;
			}
			if (audio.clip) {
				audio.Play();
			}
			Vector3 position = new Vector3(Random.Range(-6, 6), Random.Range(-4, 4), 0);	// new random position
			//print("Starting in Update" + Time.time);

			renderer.enabled = false;
			RandomColor();
			StartCoroutine(RespWaitTime(respWaitTime));
			//print("Afterwait " + Time.time);
        	transform.position = position;	// move the GO to the new location
        	numberOfClicks = storeClicks;
    	}
	}

	// RespWaitTime is used to hide a GO for a set amount of time and then unhid it
	IEnumerator RespWaitTime(float waitTime) {
         //print("beforewait"+Time.time);
        yield return new WaitForSeconds(waitTime);
     	 
     	renderer.enabled = true;
         //print(Time.time);
    }

	// Random color is used to change out the color of a GO
	void RandomColor () {
		if(shapeColor.Length >0){
			int newColor = Random.Range(0,shapeColor.Length);
			renderer.material.color = shapeColor[newColor];
		}
	}
}
