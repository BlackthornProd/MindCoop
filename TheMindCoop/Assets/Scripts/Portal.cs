using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {


	private GameMaster gm;

	void Start(){
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
	
	}

	void Update(){
		if(gm.fire <= 0){
			SceneManager.LoadScene("Level1");
		}



	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			Debug.Log(gm.fire);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
