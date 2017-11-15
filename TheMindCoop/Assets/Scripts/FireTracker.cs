using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTracker : MonoBehaviour {

	private static FireTracker instance;
	private GameMaster gm;
	public int fire;

	void Awake(){

		if(instance == null){
			instance = this;
		} else if(instance != null){
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(instance);
	} 

	void Start(){
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
	}

	void Update(){
		fire = gm.fire;
	}
}
