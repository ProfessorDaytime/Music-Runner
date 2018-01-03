using UnityEngine.Audio;
using System;
using System.Collections.Generic;
using UnityEngine;

public class scr_AudioManager : MonoBehaviour {


	public Sound[] sounds = new Sound[37];								//Array of sounds linked in Unity Editor
	private List<string> allNotes = new List<string>();   //List of sound names set below
	private List<string> subScale = new List<string>();		//List of current scale set below
	private List<string> chordScale = new List<string>(); //--++Haven't actually used yet++--
		//IDK if I should use that or just write in all of the modes to easier figure out the arps

	public static scr_AudioManager instance; // for making sure there is only one instance of this.

	private string curNote;																// I don't think I use This
	private string prevNote; 															// I don't think I use this
	private string curChord; 															// I don't think I use this
	private string prevChord; 														// I don't think I use this
	private string curBase; 															// I don't think I use this
	private string scaleBase;								//This is to determine the base note of a scale
	private string prevKey; 															// I don't think I use this
	private bool pentatonicMode;						// Use this later to turn on Pentatonic Mode
	private string subScaleQuality;					//This is to determine what notes go in a subScale
	private string scaleQuality; 						//This is to determine the way subscales are determined




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
		SetScaleQuality("aeo");
		SetSubScaleQuality("aeo");
		SetSubScale();

	}


	//_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_
	//-------------------------------------------------------------------
	//-----------SETTERS-------------------------------------------------
	//-------------------------------------------------------------------
	//_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_

	//-------------------------------
	//Sets the base note of the scale
	//-------------------------------
	public void SetScaleBase(string b){
		scaleBase = b;
		SetSubScale();
	}

	//I don't think this is used
	public void SetChord(string chord){

		curChord = chord;
	}

	//I don't think this is used
	public void SetBaseNote(string note){
		curBase = note;

	}

	public void SetScaleQuality(string qual){
		scaleQuality = qual;
	}

	//-------------------------------
	//Sets the Quality of the scale from the string you give
	//-------------------------------
	public void SetSubScaleQuality(string qual){
		subScaleQuality = qual;
		SetSubScale();
	}

	//-------------------------------
	//Sets the subScale list according to what the scaleBase and subScaleQuality are
	//-------------------------------
	// ion, dor, phr, lyd, mix, aeo, loc
	public void SetSubScale(){
		Debug.Log("SetSubScale");
		if(subScale != null){
			subScale.Clear();
		}

		int baseIndex = 0;
		for(int i = 0; i < allNotes.Count; i++){
			if(allNotes[i] == scaleBase){
				baseIndex = i;
				break;
			}
		}
		Debug.Log("SCALEBASE: " + scaleBase + ", " + baseIndex + " qual: " + subScaleQuality);
		if(subScaleQuality == "ion"){
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
			Debug.Log("Major Scale");
		}
		else if(subScaleQuality == "dor"){
			subScale.Add(allNotes[baseIndex]);//0
			subScale.Add(allNotes[baseIndex + 2]);  //w
			subScale.Add(allNotes[baseIndex + 3]);  //h
			subScale.Add(allNotes[baseIndex + 5]);  //w
			subScale.Add(allNotes[baseIndex + 7]);  //w
			subScale.Add(allNotes[baseIndex + 9]);  //w
			subScale.Add(allNotes[baseIndex + 10]); //h
			Debug.Log(" Scale");
		}
		else if(subScaleQuality == "phr"){
			subScale.Add(allNotes[baseIndex]);//0
			subScale.Add(allNotes[baseIndex + 1]);  //h
			subScale.Add(allNotes[baseIndex + 3]);  //w
			subScale.Add(allNotes[baseIndex + 5]);  //w
			subScale.Add(allNotes[baseIndex + 7]);  //w
			subScale.Add(allNotes[baseIndex + 8]);  //h
			subScale.Add(allNotes[baseIndex + 10]); //w
			Debug.Log(" Scale");
		}
		else if(subScaleQuality == "lyd"){
			subScale.Add(allNotes[baseIndex]);//0
			subScale.Add(allNotes[baseIndex + 2]);  //w
			subScale.Add(allNotes[baseIndex + 4]);  //w
			subScale.Add(allNotes[baseIndex + 6]);  //w
			subScale.Add(allNotes[baseIndex + 7]);  //h
			subScale.Add(allNotes[baseIndex + 9]);  //w
			subScale.Add(allNotes[baseIndex + 11]); //w
			Debug.Log(" Scale");
		}
		else if(subScaleQuality == "mix"){
			subScale.Add(allNotes[baseIndex]);//0
			subScale.Add(allNotes[baseIndex + 2]);  //w
			subScale.Add(allNotes[baseIndex + 4]);  //w
			subScale.Add(allNotes[baseIndex + 5]);  //h
			subScale.Add(allNotes[baseIndex + 7]);  //w
			subScale.Add(allNotes[baseIndex + 9]);  //w
			subScale.Add(allNotes[baseIndex + 10]); //h
			Debug.Log(" Scale");
		}
		else if(subScaleQuality == "aeo"){
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
			Debug.Log("Minor Scale");
		}
		else if(subScaleQuality == "loc"){
			subScale.Add(allNotes[baseIndex]);//0
			subScale.Add(allNotes[baseIndex + 1]);  //h
			subScale.Add(allNotes[baseIndex + 3]);  //w
			subScale.Add(allNotes[baseIndex + 5]);  //w
			subScale.Add(allNotes[baseIndex + 6]);  //h
			subScale.Add(allNotes[baseIndex + 8]);  //w
			subScale.Add(allNotes[baseIndex + 10]); //w
			Debug.Log(" Scale");
		}
	}

	//-------------------------------
	//Sets all of the possible notes that you have files for
	//-------------------------------
	private void SetAllNotes(){

		if(allNotes != null){
			allNotes.Clear();
		}

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



	//-------------------------------------------------------------------
	//----END-OF-SETTERS-------------------------------------------------
	//-------------------------------------------------------------------


	//_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_
	//-------------------------------------------------------------------
	//-----------GETTERS-------------------------------------------------
	//-------------------------------------------------------------------
	//_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_


	//-------------------------------
	//Returns the index of a note that you send in from the list of all allNotes
	//-------------------------------
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

	//-------------------------------
	//Returns the string name of a note that you give the index for from allNotes
	//-------------------------------
	public string GetNoteAtIndex(int i){

		if(i < allNotes.Count){
			return allNotes[i];
		}
		else{
			Debug.Log("GetNoteAtIndex: " + i + "Count: " + allNotes.Count);
			return "no";
		}
	}

	//-------------------------------
	//Returns the string name of a note that you give the index for from subScale
	//-------------------------------
	public string GetNoteFromSubScale(int i){

		if(i < subScale.Count){
			return subScale[i];
		}
		else{
			Debug.Log("GetNoteFromSubScale: " + i + "Count: " + subScale.Count);
			return "no";
		}
	}

	//-------------------------------
	//Returns the subScaleQuality
	//-------------------------------
	public string GetSubScaleQuality(){
		return subScaleQuality;
	}

	public string GetScaleQuality(){
		return scaleQuality;
	}


	//-------------------------------------------------------------------
	//----END-OF-GETTERS-------------------------------------------------
	//-------------------------------------------------------------------


	//_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_
	//-------------------------------------------------------------------
	//-----------ACTIONS-------------------------------------------------
	//-------------------------------------------------------------------
	//_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_



	public void Play(string name){
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if(s == null){
			Debug.LogWarning("Sound with name: " + name + " is not found!");
			return;
		}

		//Debug.Log(Time.time - curTime);
		s.source.Play();
		Debug.Log(name);
		//curTime = Time.time;
	}

	//-------------------------------------------------------------------
	//----END-OF-ACTIONS-------------------------------------------------
	//-------------------------------------------------------------------

	//_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_
	//-------------------------------------------------------------------
	//-----------DEBUG---------------------------------------------------
	//-------------------------------------------------------------------
	//_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_-+*+-_




	//-------------------------------
	//Prints the notes
	//-------------------------------
	public void LogSubScale(){
		Debug.Log("-=-=-=-=-=-=-=-=-=-=-");
		for(int i = 0; i < subScale.Count; i++){
			Debug.Log(subScale[i]);
		}
		Debug.Log("-=-=-=-=-=-=-=-=-=-=-");
	}


	//-------------------------------------------------------------------
	//----END-OF-DEBUG---------------------------------------------------
	//-------------------------------------------------------------------


}
