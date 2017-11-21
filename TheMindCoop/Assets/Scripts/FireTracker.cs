using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FireTracker : MonoBehaviour {

	private GameMaster gm;	


	public TextMeshProUGUI bossDisplay;
	public TextMeshProUGUI fireDisplay;
	public TextMeshProUGUI buyPrompt;
	//public TextMeshProUGUI shieldDisplay;
	public TextMeshProUGUI fireBoostDisplay;

	void Start(){
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
	}

	void Update(){


		fireDisplay.text = "" + gm.fire;
		fireBoostDisplay.text = "+";
		//shieldDisplay.text = "" + gm.shield;
		if(gm.fireShield <= 0){
			fireBoostDisplay.text = "";
		}
		/*if(gm.shield <= 0){
			shieldDisplay.text = "" + 0;
		}*/

	}
}
