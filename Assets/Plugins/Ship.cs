using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour, ITargetable {

	private float health;
	private List<Beacon> beacons = new List<Beacon>();
	private LightSource light;
	private float energy;
	private float energyUsePerSecond;
	private float maxEnergyUsePerSecond;
	private List<ShipSection> shipSections = new List<ShipSection>();
	private Radar radar;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float Health {
		get {
			throw new System.NotImplementedException ();
		}
		set {
			throw new System.NotImplementedException ();
		}
	}

	public void TakeHit (float damage)
	{
		throw new System.NotImplementedException ();
	}
}
