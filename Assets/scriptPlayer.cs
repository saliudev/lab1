using UnityEngine;
using System.Collections;

public class scriptPlayer : MonoBehaviour {
	// Player Script

	// Inspector Variables
	public string tagName;			// allow the designer to setup a tag in the inspector;
	public float rayDistance = 0;	// length of the ray for our raycast;
	public int score = 0;
	public float gameTime = 20.0f; 	
	public int numberOfPointsToWin = 10;
	// Private Variables

	
	// Use this for initialization
	void Start () {
		InvokeRepeating("CountDown",1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0)){
    	    RaycastHit hit;
        	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);	// get mouse position

        	if (Physics.Raycast(ray, out hit, 100)){
        		if (hit.transform.tag == tagName){
        			//Vector3 position = new Vector3(Random.Range(-6, 6), Random.Range(-4, 4), 0);	// new random position
        			//hit.transform.position = position;	// move the GO to the new location
        			scriptEnemy enemyScript = hit.transform.GetComponent<scriptEnemy>();
        			enemyScript.numberOfClicks -= 1;	//reduce the click number everytime.
        			// Check the object is 0, and add the points 
        			if(enemyScript.numberOfClicks == 0){
        				score += enemyScript.enemyPoint; // add points to overall score
        			}

        		}
        		else{
        			print ("This is not an enemy");
        		}

            	
            }
    	}
	}

	void CountDown () {
		if(--gameTime == 0) {
			CancelInvoke("CountDown"); //Cancel Countdown
			if (score >= numberOfPointsToWin){
				Application.LoadLevel("sceneScreenWin");
			}
			else{
				Application.LoadLevel("sceneScreenLose");
			}

		}
		
	}

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 20), "score: " + score);
        GUI.Label(new Rect(10, 25, 100, 35), "Time Left: " + gameTime);
    }
}
