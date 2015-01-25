using UnityEngine;
using System.Collections;

public class LightSource : MonoBehaviour {

	public float radius;
	public float intensity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float Radius {
		get {
			return this.radius;
		}
		set {
			radius = value;
			this.GetComponent<Light>().range = radius;
		}
	}

	public float Intensity {
		get {
			return this.intensity;
		}
		set {
			intensity = value;
			print (value + " " + this.GetComponent<Light>().intensity);
			this.GetComponent<Light>().intensity = intensity;
		}
	}
}
