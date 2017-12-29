using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {


	private string type;
	private string curNote;
	private bool isChord;
	private string chordQuality; //ex: maj, min, dim, maj7, min7

	private List<string> possibleNotes = new List<string>();


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

		//setIsChord(true);
		// SetChordQuality("min");
		FindChordQuality();

	}

	// Update is called once per frame
	void Update () {

	}



	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			string note = ChooseNote();

			audioManager.Play(note);

			if(isChord){
				// Debug.Log(note);
				string third;
				string fifth;
				int i = audioManager.GetNoteIndex(note);
				//Debug.Log("i: " + i);
				// string fifth = audioManager.GetNoteAtIndex(i + 7);
				fifth = audioManager.GetNoteAtIndex(i + 7);
				third = audioManager.GetNoteAtIndex(i + 3); // default to minor chord

				if(chordQuality == "maj"){
					third = audioManager.GetNoteAtIndex(i + 4);
					audioManager.Play(third);
				}
				else if(chordQuality == "dim"){
					third = audioManager.GetNoteAtIndex(i + 3);
					fifth = audioManager.GetNoteAtIndex(i + 6);
				}

				//Debug.Log("base: " + note);
				//Debug.Log("third: " + third);
				//Debug.Log("fifth: " + fifth);
				audioManager.Play(third);
				audioManager.Play(fifth);

			}


			Destroy(this.gameObject);
		}

	}


	string ChooseNote(){
		//string[] notes = {"A5", "B5", "C6", "D6", "E6", "F6", "G6"};

		// notes = new Array["A5", "B5", "C6", "D6", "E6", "F6", "G6"];
    //
		for (int i = 0; i < audioManager.)
		possibleNotes.Add("D5");
		possibleNotes.Add("E5");
		possibleNotes.Add("F5");
		possibleNotes.Add("G5");
		possibleNotes.Add("A5");
		possibleNotes.Add("As5");
		possibleNotes.Add("C6");


		 return possibleNotes[interval - 1];
	}

	public void SetMaterial(){

		rend = this.GetComponent<Renderer>();
		rend.enabled = true;
		rend.sharedMaterial = material[interval - 1];
		// Debug.Log(interval);
	}

	public void SetInterval(int note){
		interval = note;
		// Debug.Log("setInterval");
		this.SetMaterial();
	}

	public void setIsChord(bool chord){
		isChord = chord;
		// Debug.Log("setIsChord");
		// this.SetMaterial();
	}

	public void FindChordQuality(){
		string scaleQual = audioManager.GetScaleQuality();

		if(scaleQual == "min"){
			if(interval == 1){
				SetChordQuality("min");
			}
			else if(interval == 2){
				SetChordQuality("dim");
			}
			else if(interval == 3){
				SetChordQuality("maj");
			}
			else if(interval == 4){
				SetChordQuality("min");
			}
			else if(interval == 5){
				SetChordQuality("min");
			}
			else if(interval == 6){
				SetChordQuality("maj");
			}
			else if(interval == 7){
				SetChordQuality("maj");
			}
		}
	}


	public void SetChordQuality(string qual){
		chordQuality = qual;
	}



}
