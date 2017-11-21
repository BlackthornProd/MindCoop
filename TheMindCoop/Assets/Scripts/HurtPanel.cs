using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtPanel : MonoBehaviour {

	private Animator hurtPanel;
	public bool on = false;
	public float timeOn = 0f;

	void Start(){
		hurtPanel = GetComponent<Animator>();
	}


	public void Anim(){

		hurtPanel.SetTrigger("Hurt");
	}
}
