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
    public Material BeaconLineRendererMaterial;

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
                PlaceLineRenderer();
				//gameDirector.UpdateShipEnergyUse();
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

    private void PlaceLineRenderer()
    {
        GameObject pt1 = null;
        GameObject pt2 = null;
        if (gameDirector.beacons.Count > 1)
        {
            //we have at least 2 beacons
             pt1 = gameDirector.beacons[gameDirector.beacons.Count - 1];
             pt2 = gameDirector.beacons[gameDirector.beacons.Count - 2];
        }
        else
        { 
            //the firest point is the ship
            pt1 = gameDirector.beacons[gameDirector.beacons.Count - 1];
            pt2 = gameDirector.shipLocation;
        }
        CreateLR(pt1, pt2, BeaconLineRendererMaterial);

    }

    private void CreateLR(GameObject p1, GameObject p2, Material mat)
    {
        LineRenderer lr = p1.AddComponent<LineRenderer>();

        lr.material = mat;
        lr.SetColors(Color.red, Color.green);
        lr.SetWidth(0.2f, 0.2f);
        lr.SetVertexCount(2);
        lr.SetPosition(0, p1.transform.position);
        lr.SetPosition(1, p2.transform.position);
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
