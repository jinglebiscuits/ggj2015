using UnityEngine;
using System.Collections;

public class Radar : MonoBehaviour {

	private float energyUse;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	float EnergyUse {
		get {
			return this.energyUse;
		}
	}

	public void Pulse()
	{
		//send out visible area

		//drain energy from ship
	}
}
