using UnityEngine;
using System.Collections;

public class VideoDirector : MonoBehaviour {

    public MovieTexture movieTexture = null;

	// Use this for initialization
	void Start () {
        movieTexture.Play();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
