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

//	public GameObject shieldProtection;

	void Start(){
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		gm.shieldProtection = 0;
	}

	void Update(){


		fireDisplay.text = "" + gm.fire;
		fireBoostDisplay.enabled = true;
		//shieldDisplay.text = "" + gm.shield;
		if(gm.fireShield <= 0){
			fireBoostDisplay.enabled = false;
		}

	}
}
