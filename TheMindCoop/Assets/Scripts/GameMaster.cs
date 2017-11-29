using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

	private static GameMaster instance;

	public int fire = 100;
	public int damage = 5;
	public int costInDamage = 100;

	[Header("References")]
	private FireTracker fireTracker;


	[Header ("Fire Boost")]
	public int fireShield;


	void Awake(){
		if(instance == null){
			instance = this;
		} else if(instance != null){
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(instance);
	} 

	void Start(){
		fireTracker = GameObject.FindGameObjectWithTag("Tracker").GetComponent<FireTracker>();
	}

	void Update(){


		if(fire <= 0){
			fireShield = 0;
			SceneManager.LoadScene("Level1");
			fire = 100;
		}


	}

	public void TakeDamage(int damage){
		fireShield -= damage;
		fire -= damage;
	}
}
