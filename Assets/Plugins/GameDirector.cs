using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDirector : MonoBehaviour {

    public static GameDirector instance = null;

    public Neil neil = null;
    public Ship ship = null;
    public List<GameObject> beacons = new List<GameObject>();
   

    void Awake()
    {
        instance = this;
    }

	void Update()
	{
		if(Input.GetButton("Fire1"))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100))
			{
				if(hit.collider.transform.tag == "Terrain")
				{
					if(neil.neilControlState == NeilControlStates.InShip)
					{
						neil.PlaceBeacon(GetNearestBeaconLocation(hit.point), hit.point);
					}
					else if(neil.neilControlState == NeilControlStates.FreeMove)
					{
						neil.WalkToSpot(hit.point);
					}
				}
				else if(hit.collider.transform.name == "Ship")
				{
					if(neil.neilControlState == NeilControlStates.FreeMove)
					{
						neil.WalkToSpot(hit.collider.transform.position);
					}
				}
			}
		}
			
	}

	public Vector3 GetNearestBeaconLocation(Vector3 beaconPlacement)
	{
		Vector3 teleportLocation = ship.transform.position;
		float distanceToPlacement = (beaconPlacement - ship.transform.position).magnitude;
		if(beacons.Count > 0)
		{
			foreach(GameObject beacon in beacons)
			{
				float tempDistance = (beacon.transform.position - beaconPlacement).magnitude;
				if (tempDistance < distanceToPlacement)
				{
					distanceToPlacement = tempDistance;
					teleportLocation = beacon.transform.position;
				}
			}
		}
		teleportLocation.y = 1.583f;
		return teleportLocation;
	}

}
