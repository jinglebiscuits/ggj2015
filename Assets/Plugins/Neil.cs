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

	public GameObject body;

	public GameDirector gameDirector;

	public delegate void MyEventHandler();
	public event MyEventHandler radarEvent;
	//public event MyEventHandler moveEvent;

	// Use this for initialization
	void Start () {
		gameDirector = GameDirector.instance;
		movementSpeed = 1.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GroundNeil();
		if(neilControlState == NeilControlStates.PlantingBeacon)
		{
			float step = movementSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, wayPoint, step);
			if((transform.position - wayPoint).magnitude <= 0.5f)
			{
				GameObject clone = (GameObject) Instantiate(beacon, wayPoint, Quaternion.identity);
				gameDirector.beacons.Add(clone);
				gameDirector.UpdateShipEnergyUse();
				neilState = NeilStates.InLight;
				neilControlState = NeilControlStates.FreeMoveStanding;
			}
		}

		if(neilControlState == NeilControlStates.FreeMoveMoving)
		{
			float step = movementSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, wayPoint, step);
			if((transform.position - wayPoint).magnitude <= 0.5f)
			{
				neilControlState = NeilControlStates.FreeMoveStanding;
			}
		}
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

	public void GroundNeil()
	{
		int layerMask = 1 << 9;
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -Vector3.up, out hit, layerMask))
		{
			float distanceToGround = hit.distance;
			this.transform.position = new Vector3(this.transform.position.x, hit.point.y + 0.0f, this.transform.position.z);
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

	private void OnCollisionEnter(Collision col)
	{
		print ("collided with something");
		if(col.transform.CompareTag("Section"))
		{
			print ("collided with Section");
			if(neilControlState == NeilControlStates.PlantingBeacon)
			{
				wayPoint = transform.position;
			}
		}
		else if(col.transform.CompareTag("Ship"))
		{
			print ("collided with ship");
			neilState = NeilStates.InShip;
			neilControlState = NeilControlStates.InShip;
			this.transform.position = col.transform.position;
		}
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
	FreeMoveMoving,
	FreeMoveStanding
}
