using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

	private static GameMaster instance;

	public int fire = 100;

	[Header("References")]
	private FireTracker fireTracker;

	[Header ("Shield Boost")]
	public int shield = 0;
	private float healTime = 5f;
	public float startHealTime = 5f;
	public int healBoost;

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
		Debug.Log("NOA");
	}

	void Update(){


		if(fire <= 0){
			shield = 0;
			fireShield = 0;
			SceneManager.LoadScene("Level1");
			fire = 100;
		}

		if(healTime <= 0 && shield > 0){
			healTime = startHealTime;
			fire += healBoost;
		} else {
			healTime -= Time.deltaTime;
		}

	}

	public void TakeDamage(int damage){
		fireShield -= damage;
		if(shield <= 0){
			fire -= damage;	

		} else {
			shield -= damage;		
		}

	}
}
