using UnityEngine.Audio;
using System;
using System.Collections.Generic;
using UnityEngine;

public class scr_AudioManager : MonoBehaviour {


	public Sound[] sounds = new Sound[37];
	private List<string> allNotes = new List<string>();
	private List<string> subScale = new List<string>();
	private List<string> chordScale = new List<string>();

	public static scr_AudioManager instance;

	private string curNote;
	private string prevNote;
	private string curChord;
	private string prevChord;
	private string curBase;
	private string scaleBase;
	private string prevKey;
	private bool pentatonicMode;
	private string scaleQuality;
	//private float curTime;



	// Use this for initialization
	void Awake () {
		if(instance == null)
			instance = this;
		else{
			Destroy(gameObject);
			return;
		}

		foreach (Sound s in sounds){
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
		}

		SetAllNotes();
		SetScaleBase("D5");
		SetScaleQuality("min");
		SetSubScale();

	}

	public void SetScaleBase(string b){
		scaleBase = b;
	}

	public void SetChord(string chord){

		curChord = chord;
	}

	public void SetBaseNote(string note){
		curBase = note;

	}

	// public void LoadSounds(){
  //
	// 	//CMajorPent
	// 	//sounds[0].source = "sound/SoftSynthHorn/C4";
	// 	//Debug.Log(sounds[0].name);// = "C4";
	// }

	public void Play(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			Debug.LogWarning("Sound with name: " + name + " is not found!");
			return;
		}

		//Debug.Log(Time.time - curTime);
		s.source.Play();
		//curTime = Time.time;
	}
	public void SetSubScale(){
		int baseIndex = 0;
		for(int i = 0; i < allNotes.Count; i++){
			if(allNotes[i] == scaleBase){
				baseIndex = i;
				break;
			}
		}

		if(scaleQuality == "maj"){
			subScale.Add(allNotes[baseIndex]);//0
			subScale.Add(allNotes[baseIndex + 2]);  //w
			subScale.Add(allNotes[baseIndex + 4]);  //w
			subScale.Add(allNotes[baseIndex + 5]);  //h
			subScale.Add(allNotes[baseIndex + 7]);  //w
			subScale.Add(allNotes[baseIndex + 9]);  //w
			subScale.Add(allNotes[baseIndex + 11]); //w
			// subScale.Add(allNotes[baseIndex + 12]); //h
			// subScale.Add(allNotes[baseIndex + 14]); //w
			// subScale.Add(allNotes[baseIndex + 16]); //w
			// subScale.Add(allNotes[baseIndex + 17]); //h
			// subScale.Add(allNotes[baseIndex + 19]); //w
			// subScale.Add(allNotes[baseIndex + 21]); //w
			// subScale.Add(allNotes[baseIndex + 23]); //w
		}
		else if(scaleQuality == "min"){
			subScale.Add(allNotes[baseIndex]);//0
			subScale.Add(allNotes[baseIndex + 2]);  //w
			subScale.Add(allNotes[baseIndex + 3]);  //h
			subScale.Add(allNotes[baseIndex + 5]);  //w
			subScale.Add(allNotes[baseIndex + 7]);  //w
			subScale.Add(allNotes[baseIndex + 8]);  //h
			subScale.Add(allNotes[baseIndex + 10]); //w
			// subScale.Add(allNotes[baseIndex + 12]); //w
			// subScale.Add(allNotes[baseIndex + 14]); //w
			// subScale.Add(allNotes[baseIndex + 15]); //h
			// subScale.Add(allNotes[baseIndex + 17]); //w
			// subScale.Add(allNotes[baseIndex + 19]); //w
			// subScale.Add(allNotes[baseIndex + 20]); //h
			// subScale.Add(allNotes[baseIndex + 22]); //w
		}
	}
	public void SetScaleQuality(string qual){
		scaleQuality = qual;
	}

	public string GetScaleQuality(){
		return scaleQuality;
	}

	private void SetAllNotes(){

		allNotes.Add("D5");
		allNotes.Add("Ds5");
		allNotes.Add("E5");
		allNotes.Add("F5");
		allNotes.Add("Fs5");
		allNotes.Add("G5");
		allNotes.Add("Gs5");
		allNotes.Add("A5");
		allNotes.Add("As5");
		allNotes.Add("B5");
		allNotes.Add("C6");
		allNotes.Add("Cs6");
		allNotes.Add("D6");
		allNotes.Add("Ds6");
		allNotes.Add("E6");
		allNotes.Add("F6");
		allNotes.Add("Fs6");
		allNotes.Add("G6");
		allNotes.Add("Gs6");
		allNotes.Add("A6");
		allNotes.Add("As6");
		allNotes.Add("B6");


	}

	public int GetNoteIndex(string note){
		if(allNotes.Contains(note)){
			// return allNotes.FindIndex(note);  //IDK WHY THE FUCK THIS DOESN"T WORK???
			for( int i = 0; i < allNotes.Count; i++){
				if(allNotes[i] == note){
					return i;
				}

			}

			return -1;

		}
		else{
			Debug.LogWarning("allNotes does not contain " + note);
			return -1;
		}
	}

	public string GetNoteAtIndex(int i){
		if(i < allNotes.Count){
			return allNotes[i];
		}
		else{
			return "no";
		}
	}











}
