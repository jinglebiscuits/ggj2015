using UnityEngine;
using System.Collections;

public class FuelCan : MonoBehaviour, ICarryable {

	private bool isBeingCarried;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool IsBeingCarried {
		get {
			throw new System.NotImplementedException ();
		}
		set {
			throw new System.NotImplementedException ();
		}
	}
}
