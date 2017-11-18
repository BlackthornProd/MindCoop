using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

	public int fire = 100;

	[Header("References")]
	public TextMeshProUGUI fireDisplay;
	public TextMeshProUGUI bossDisplay;
	public Animator hurtPanel;
	private FireTracker fireTracker;
	public TextMeshProUGUI buyPrompt;

	[Header ("Shield Boost")]
	public float shield = 0;
	private float healTime = 5f;
	public float startHealTime = 5f;
	public int healBoost;
	public TextMeshProUGUI shieldDisplay;

	[Header ("Fire Boost")]
	public int fireShield;
	public TextMeshProUGUI fireBoostDisplay;

	void Start(){
		fireTracker = GameObject.FindGameObjectWithTag("Tracker").GetComponent<FireTracker>();
		fire = fireTracker.fire;
	}

	void Update(){

		fireDisplay.text = "FIRE : " + fire;
		fireBoostDisplay.text = "FB : " + fireShield;
		shieldDisplay.text = "Shield : " + shield;
		if(fireShield <= 0){
			fireBoostDisplay.text = "FB : " + 0;
		}
		if(shield <= 0){
			shieldDisplay.text = "Shield : " + 0;
		}


		if(fire <= 0){
			fireTracker.fire = 100;
			SceneManager.LoadScene("Level1");
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
			hurtPanel.SetTrigger("Hurt");
			fire -= damage;	
		} else {
			shield -= damage;		
		}
	}
}
