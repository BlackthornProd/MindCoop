using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootPatrolPoint : MonoBehaviour {

	public float speed;

	private Transform midPoint;

	void Start(){

		midPoint = GameObject.FindGameObjectWithTag("Mid").GetComponent<Transform>();
	}

	void Update(){

		transform.position = Vector2.MoveTowards(transform.position, midPoint.position, speed * Time.deltaTime);
	}
}
