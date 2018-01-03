using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {


	private string type;								//I Don't Think this is used
	private string curNote;							//I Don't Think this is used
	private bool isChord; //Determines if the pickup is a chord or not
	private string subScaleQuality; //ex: maj, min, dim, maj7, min7

	private List<string> possibleNotes = new List<string>();		//May Not Use This


	private scr_AudioManager audioManager;		//the instance of the audioManager

	public int interval;		//The interval from the chord base

	//To Change Materials
	public Material[] material;
	private Renderer rend;


	// Use this for initialization
	void Start () {

		audioManager = FindObjectOfType<scr_AudioManager>(); //Sets the audioManager

		//For Changing Materials
		rend = this.GetComponent<Renderer>();
		rend.enabled = true;
		//End of changing material stuff



	}

	// Update is called once per frame
	// void Update () {
  //
	// }



	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			string note = audioManager.GetNoteFromSubScale(interval - 1);

			audioManager.Play(note);

			if(isChord){
				FindSubScaleQuality();//finds what kind of chord it would be dep3nding on the current chord and interval
				// Debug.Log(note);
				string third;
				string fifth;
				int i = audioManager.GetNoteIndex(note);
				//Debug.Log("i: " + i);
				// string fifth = audioManager.GetNoteAtIndex(i + 7);
				fifth = audioManager.GetNoteAtIndex(i + 7);
				third = audioManager.GetNoteAtIndex(i + 3); // default to minor chord

				if(subScaleQuality == "ion" || subScaleQuality == "lyd" || subScaleQuality == "mix"){
					third = audioManager.GetNoteAtIndex(i + 4);
					audioManager.Play(third);
				}
				else if(subScaleQuality == "loc"){
					third = audioManager.GetNoteAtIndex(i + 3);
					fifth = audioManager.GetNoteAtIndex(i + 6);
					//subScaleQuality = "min";
				}

				//Debug.Log("base: " + note);
				//Debug.Log("third: " + third);
				//Debug.Log("fifth: " + fifth);

				audioManager.SetScaleBase(note);
				audioManager.SetSubScaleQuality(subScaleQuality);
				audioManager.SetSubScale();
				// audioManager.LogSubScale();
				audioManager.Play(third);
				audioManager.Play(fifth);
			}


			Destroy(this.gameObject);
		}

	}


	string ChooseNote(){
		// for (int i = 0; i < audioManager.)
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

	public void FindSubScaleQuality(){
		string scaleQual = audioManager.GetScaleQuality();
		Debug.Log("FindSubScaleQuality: scaleQual: " + scaleQual);
		if(scaleQual == "aeo"){
			if(interval == 1){
				SetSubScaleQuality("aeo");
			}
			else if(interval == 2){
				SetSubScaleQuality("loc");
			}
			else if(interval == 3){
				SetSubScaleQuality("ion");
			}
			else if(interval == 4){
				SetSubScaleQuality("dor");
			}
			else if(interval == 5){
				SetSubScaleQuality("phr");
			}
			else if(interval == 6){
				SetSubScaleQuality("lyd");
			}
			else if(interval == 7){
				SetSubScaleQuality("mix");
			}
		}
	}


	public void SetSubScaleQuality(string qual){
		subScaleQuality = qual;
		Debug.Log("SetSubScaleQuality:" + qual);
	}



}
