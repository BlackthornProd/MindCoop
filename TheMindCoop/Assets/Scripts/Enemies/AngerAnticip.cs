using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerAnticip : MonoBehaviour {

	[Header ("Stats")]
	public float timeBeforeDanger;
	public float speed;
	//public float stopMove;

	[Header ("References")]
	public GameObject fireBlast;
	private Anger anger;
	private GameObject[] targets;
	private GameMaster gm;
	public GameObject spawnEffect;
	private CameraShake shake;

	void Start(){
		shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
		anger = GameObject.FindGameObjectWithTag("Boss3").GetComponent<Anger>();
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		if(targets == null){
			targets = GameObject.FindGameObjectsWithTag("Player");
		}
	}

	void Update(){
		if(timeBeforeDanger <= 0){
			shake.Shake(0.2f, 0.2f);
			Instantiate(spawnEffect, transform.position, Quaternion.identity);
			Instantiate(fireBlast, transform.position, Quaternion.identity);
			Destroy(gameObject);
		} else {
			timeBeforeDanger -= Time.deltaTime;
		}

		if(gm.fire > 0){
			if(Vector2.Distance(transform.position, targets[0].transform.position) > Vector2.Distance(transform.position, targets[1].transform.position)){
				transform.position = Vector2.MoveTowards(transform.position, targets[1].transform.position, speed * Time.deltaTime);
			} else {
				transform.position = Vector2.MoveTowards(transform.position, targets[0].transform.position, speed * Time.deltaTime);
			}
		}

	}
}
