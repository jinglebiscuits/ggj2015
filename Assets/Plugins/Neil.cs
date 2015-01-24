using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Neil : MonoBehaviour, ITargetable {

	private float health;
	private float movementSpeed;
	public Vector3 wayPoint;
	private string state;
	private List<ICarryable> inventory = new List<ICarryable>();
	public GameObject beacon;
	public GameObject nearestBeacon;
	public NeilStates neilState = NeilStates.InShip;
	public NeilControlStates neilControlState = NeilControlStates.InShip;


	public delegate void MyEventHandler();
	public event MyEventHandler radarEvent;

	// Use this for initialization
	void Start () {
		movementSpeed = 0.25f;
	}
	
	// Update is called once per frame
	void Update () {

	}

	#region Accessor Methods
	public float Health {
		get {
			return this.health;
		}
		set {
			health = value;
		}
	}

	public float MovementSpeed {
		get {
			return this.movementSpeed;
		}
		set {
			movementSpeed = value;
		}
	}

	public string State {
		get {
			return this.state;
		}
		set {
			state = value;
		}
	}

	public List<ICarryable> Inventory {
		get {
			return this.inventory;
		}
		set {
			inventory = value;
		}
	}
	#endregion

	public void TakeHit(float damage)
	{
		//subtract damage from Neil's hp
	}

	public void PulseRadar()
	{
		if(radarEvent != null)
		{
			radarEvent();
		}
	}

	public void PlaceBeacon(Vector3 teleportLocation, Vector3 beaconLocation)
	{
		beaconLocation += new Vector3(0, transform.position.y, 0);
		//teleport to nearest beacon
		transform.position = teleportLocation;
		neilControlState = NeilControlStates.PlantingBeacon;
		//auto walk to beacon spot
		StopAllCoroutines();
		StartCoroutine(WalkToWayPoint(beaconLocation));
		//plant beacon
		GameObject clone = (GameObject) Instantiate(beacon);

		//change states
		neilControlState = NeilControlStates.FreeMove;
	}

	public void WalkToSpot(Vector3 spot)
	{
		spot += new Vector3(0, transform.position.y, 0);
		//move to spot
		if(neilControlState == NeilControlStates.FreeMove)
		{
			StopAllCoroutines();
			StartCoroutine(WalkToWayPoint(spot));
		}
	}

	public IEnumerator WalkToWayPoint(Vector3 wayPoint)
	{
		while((transform.position - wayPoint).magnitude >= 0.01f)
		{
			this.transform.position = Vector3.Lerp(this.transform.position, wayPoint, Time.deltaTime * movementSpeed);
			yield return new WaitForSeconds(0.01f);
		}
	}

	public void ToggleBeacon(Beacon beacon)
	{
		beacon.LightOn = !beacon.LightOn;
	}

	public void ConnectSection(ShipSection section)
	{
		section.IsHookedUp = true;
	}

	public void PickUpFuelCan(FuelCan fuelCan)
	{
		fuelCan.IsBeingCarried = true;
	}

	public void RefuelShip(Ship ship, FuelCan fuelCan)
	{
		ship.Refuel(fuelCan.Fuel);
	}
}

public enum NeilStates
{
	InShip,
	InLight,
	InDarkness
}

public enum NeilControlStates
{
	InShip,
	PlantingBeacon,
	FreeMove
}
