using UnityEngine;
using System.Collections;

public class ShipSection : MonoBehaviour {

	private bool isHookedUp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool IsHookedUp {
		get {
			return this.isHookedUp;
		}
		set {
			isHookedUp = value;
		}
	}
}
