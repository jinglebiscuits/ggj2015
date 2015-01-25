using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour, ITargetable {

	private float health;
	public List<GameObject> beacons = new List<GameObject>();
	public Light light;
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

	public void Refuel(float fuel)
	{
		energy += fuel;
	}

	void OnTriggerEnter(Collider other) {
		print (other.gameObject.transform.name);
		if(other.gameObject.transform.tag == "Player")
		{
			print ("oh yeah");
			GameObject neil = other.gameObject.transform.parent.gameObject;
			Neil neilScript = neil.GetComponent<Neil>();
			neilScript.neilState = NeilStates.InShip;
			neilScript.neilControlState = NeilControlStates.InShip;
			neil.transform.position = this.transform.position;
		}
		//Destroy(other.gameObject);
	}
}
