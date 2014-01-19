using UnityEngine;
using System.Collections;

public class scriptScreenWin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUI.Label(new Rect(180,180,100,40), "YOU WIN!!!");
		if(GUI.Button(new Rect(10,30,90,50),"Start Game")){

			print("Start Game");
			Application.LoadLevel("sceneLevel1");

		}
		if(GUI.Button(new Rect(10,90,90,50), "Exit Game")){
			print("Exit Game");
			Application.Quit();
		}
	}
}
