using UnityEngine;
using System.Collections;

public class LoserDirector : MonoBehaviour {

	public string playableScene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Replay()
	{
		Application.LoadLevel(playableScene);
	}
}
