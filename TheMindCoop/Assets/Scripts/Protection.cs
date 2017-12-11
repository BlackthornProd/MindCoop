using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protection : MonoBehaviour {

	private GameObject[] targets;
	public GameObject space;
	public GameObject circle;
	public Collider2D box;
	public GameObject bubble;
	public GameObject destroyEffect;

	void Start(){
		if(targets == null){
			targets = GameObject.FindGameObjectsWithTag("Player");
		}

		box.enabled = false;
		bubble.SetActive(false);
	}

	void Update(){

		if(Vector2.Distance(transform.position, targets[0].transform.position) < 20f || Vector2.Distance(transform.position, targets[1].transform.position) < 20f){
			space.SetActive(true);
		} else {
			space.SetActive(false);
		}

		if(Input.GetKeyDown(KeyCode.Space)){
			box.enabled = true;
			space.SetActive(false);
			circle.SetActive(false);
			bubble.SetActive(true);
			Instantiate(destroyEffect, transform.position, Quaternion.identity);
		} 

	}
}
