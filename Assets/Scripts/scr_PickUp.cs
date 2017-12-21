using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_PickUp : MonoBehaviour {


	private string type;
	private string interval;
	private string color;
	private string curNote;
	private string prevNote;

	private scr_AudioManager audioManager;

	// Use this for initialization
	void Start () {
		type = "TEST";

		audioManager = FindObjectOfType<scr_AudioManager>();
	}

	// Update is called once per frame
	void Update () {

	}



	void OnTriggerEnter(Collider other){
		//Debug.Log("Destroy!!!");



		if(other.gameObject.tag == "Player"){
			string note = ChooseNote();
			audioManager.Play(note);
			Destroy(this.gameObject);
		}
		//Debug.Log(other.gameObject);


	}

	string ChooseNote(){
		string[] notes = {"C4", "D4", "F4", "G4", "A4", "C5", "D5", "F5", "G5", "A5"};

		return notes[Random.Range(0,notes.Length - 1)];
	}

	// void OnTriggerEnter(Collider other){
  //
	// 	if(other.tag == "Player"){
	// 		Debug.LogWarning("Ping");
	// 		audioManager.Play("C4");
  //
	// 		//Destroy(collisionInfo.collider.gameObject);
	// 	}
  //
  //
	// }
}
