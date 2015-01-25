using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour, ITargetable {

	private float health;
	public List<GameObject> beacons = new List<GameObject>();
	public Light light;
	public float energy = 1000.0f;
	public Slider energyView;
	public float energyUsePerSecond = 10.0f;
	private float maxEnergyUsePerSecond;
	public List<ShipSection> shipSections = new List<ShipSection>();
	private Radar radar;


	// Use this for initialization
	void Start () {
		energyView.maxValue = energy;
	}
	
	// Update is called once per frame
	void Update () {
		energy -= energyUsePerSecond * Time.deltaTime;
		energyView.value = energy;
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

	public void Refuel(float fuel)
	{
		energy += fuel;
	}
}
