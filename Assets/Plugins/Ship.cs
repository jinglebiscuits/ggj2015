﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour, ITargetable {

	private float health;
	public List<GameObject> beacons = new List<GameObject>();
	public Light light;
	private float energy;
	public Slider energyView;
	private float energyUsePerSecond;
	private float maxEnergyUsePerSecond;
	private List<ShipSection> shipSections = new List<ShipSection>();
	private Radar radar;


	// Use this for initialization
	void Start () {
		energyView.maxValue = energy;
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

	public void Refuel(float fuel)
	{
		energy += fuel;
	}
}
