using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

	public int fire = 100;

	public TextMeshProUGUI fireDisplay;
	public TextMeshProUGUI bossDisplay;
	public Animator hurtPanel;
	private FireTracker fireTracker;

	void Start(){
		fireTracker = GameObject.FindGameObjectWithTag("Tracker").GetComponent<FireTracker>();
		fire = fireTracker.fire;
	}

	void Update(){

		if(Input.GetKeyDown(KeyCode.Space)){
			SceneManager.LoadScene("Level2");
		}
		fireDisplay.text = "FIRE : " + fire;

		if(fire <= 0){
			fireTracker.fire = 100;
			SceneManager.LoadScene("Level1");
		}
	}

	public void TakeDamage(int damage){
		hurtPanel.SetTrigger("Hurt");
		fire -= damage;	
	}
}
