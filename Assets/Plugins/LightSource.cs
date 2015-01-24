using UnityEngine;
using System.Collections;

public class LightSource : MonoBehaviour {

	private float radius;
	private float intensity;

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
		}
	}

	public float Intensity {
		get {
			return this.intensity;
		}
		set {
			intensity = value;
		}
	}
}
