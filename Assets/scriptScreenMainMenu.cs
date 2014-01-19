using UnityEngine;
using System.Collections;

public class scriptScreenMainMenu : MonoBehaviour {

	public float buttonSize = 100.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		if(GUI.Button(new Rect(10,10,buttonSize,50),"Start Game")){
			print("Start Game");
			Application.LoadLevel("sceneLevel1");

		}
		if(GUI.Button(new Rect(10,70,buttonSize,50), "Exit Game")){
			print("Exit Game");
			Application.Quit();
		}
	}
}
