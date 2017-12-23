using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {


	private string type;
	private string curNote;
	private bool isChord;
	private string chordQuality; //ex: maj, min, dim, maj7, min7

	private scr_AudioManager audioManager;

	public int interval;
	//To Change Materials
	public Material[] material;
	private Renderer rend;


	// Use this for initialization
	void Start () {
		type = "TEST";

		audioManager = FindObjectOfType<scr_AudioManager>();

		//For Changing Materials
		rend = this.GetComponent<Renderer>();
		rend.enabled = true;
		//rend.sharedMaterial = material[3];
		//End of changing material stuff
		//Debug.Log("Start" + this.gameObject);
		//interval = 1;


	}

	// Update is called once per frame
	void Update () {

	}



	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			string note = ChooseNote();
			audioManager.Play(note);
			Destroy(this.gameObject);
		}

	}


	string ChooseNote(){
		string[] notes = {"A5", "B5", "C6", "D6", "E6", "F6", "G6"};

		return notes[interval - 1];
	}

	public void SetMaterial(){
		Debug.Log("SetMat" + this.gameObject);
		rend = this.GetComponent<Renderer>();
		rend.enabled = true;
		rend.sharedMaterial = material[interval];
	}

	public void SetInterval(int note){
		interval = note;
		Debug.Log("setInterval");
		this.SetMaterial();
	}

	public void setIsChord(bool chord){
		isChord = chord;
	}



}
