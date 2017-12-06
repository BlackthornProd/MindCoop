using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureHolder : MonoBehaviour {

	[Header ("Death Effects")]
	public GameObject[] bloodSplash;
	public GameObject deathFx;

	[Header("References")]
	public SpriteRenderer currentNumber;
	public Sprite[] numbers;
	public GameObject[] lootDrops;

	public SpriteRenderer head;
	public Sprite[] heads;
	private GameMaster gm;
	private HurtPanel hurtPanel;

	[Header ("Price")]
	private int costInDamage;
	public int priceIncrease;

	void Start(){

		hurtPanel = GameObject.FindGameObjectWithTag("HurtPanel").GetComponent<HurtPanel>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		costInDamage = gm.costInDamage;

		int randNum = Random.Range(0, heads.Length);
		head.sprite = heads[randNum];
	}

	void Update(){
		costInDamage = gm.costInDamage;
		currentNumber.sprite = numbers[gm.numIndex];
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.GetComponent<Projectile>() != null){
			Destroy(other.gameObject);
			DestroyObject();
		} else if(other.CompareTag("Player")){
			DestroyObject();
		}
	}

	void DestroyObject(){
		hurtPanel.Anim();
		int randomSplash = Random.Range(0, bloodSplash.Length);
		//Instantiate(bloodSplash[randomSplash], transform.position, Quaternion.identity);
		GameObject fx = (GameObject)Instantiate(deathFx, transform.position, Quaternion.identity);
		Destroy(fx, 3f);
		
		gm.costInDamage += priceIncrease;
		gm.numIndex++;

		gm.TakeDamage(costInDamage);
		int rand = Random.Range(0, lootDrops.Length);
		Instantiate(lootDrops[rand], transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
