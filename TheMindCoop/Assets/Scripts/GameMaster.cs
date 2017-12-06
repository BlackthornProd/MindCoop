using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

	private static GameMaster instance;

	public int fire = 100;
	public int damage = 5;

	[Header ("Bubble")]
	public int numIndex = 0;
	public int costInDamage = 100;

	[Header("References")]
	private FireTracker fireTracker;
	private FadePanel fadePanel;

	[Header ("Fire Boost")]
	public int fireShield;
	public int shieldProtection;

	void Awake(){
		if(instance == null){
			instance = this;
		} else if(instance != null){
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(instance);
	} 

	void Start(){
		fadePanel = GameObject.FindGameObjectWithTag("FadePanel").GetComponent<FadePanel>();
		fireTracker = GameObject.FindGameObjectWithTag("Tracker").GetComponent<FireTracker>();
	}

	void Update(){


		if(fire <= 0){		
			costInDamage = 100;
			numIndex = 0;
			fireShield = 0;
			StartCoroutine(LoadGameOver());
		}

		Debug.Log(shieldProtection);
	}

	public void TakeDamage(int damage){
		if(shieldProtection > 0){
			shieldProtection -= damage;
		} else {
			fireShield -= damage;
			fire -= damage;
		}
	}


	IEnumerator LoadGameOver(){
		
		yield return new WaitForSeconds(2f);
		fadePanel.FadeIn();
		yield return new WaitForSeconds(.5f);
		fire = 100;
		SceneManager.LoadScene("GameOver");
		Destroy(gameObject);
	}

}
