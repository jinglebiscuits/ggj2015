using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public class GameDirector : MonoBehaviour {

    public static GameDirector instance = null;

    public Neil neil = null;
    public Ship ship = null;
    public List<GameObject> beacons = new List<GameObject>();
    public GameObject[] Aliens = null;
    public float fltWaveTime = 15.0f;
    public float fltNextWave = 0;
   
    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// 
    /// </summary>
	void Update()
	{
        try
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
				    else if(hit.collider.transform.parent.transform.tag == "Beacon")
				    {
					    Beacon beacon = hit.collider.transform.parent.GetComponent<Beacon>();
					    beacon.LightOn = !beacon.LightOn;
				    }
			    }
		    }

            ComputeWave();

		    CheckForLoseCondition();
		    if(CheckForWinCondition())
		    {
			    print ("you win");
			    Time.timeScale = 0.0f;
		    }
        }
        catch (System.Exception ex)
        {


        }
			
	}

	public void UpdateShipEnergyUse()
	{
		ship.energyUsePerSecond += 5.0f;
	}

    /// <summary>
    /// 
    /// </summary>
    private void ComputeWave()
    {
        //Debug.Log(string.Format("time {0}  next wave {1}", Time.realtimeSinceStartup, fltNextWave));
        if (Time.realtimeSinceStartup > fltNextWave)
        { 
            //trigger a wave
            StartWave();
            //set time to next wave
            fltNextWave = Time.realtimeSinceStartup + fltWaveTime;
        }
    
    }

    /// <summary>
    /// 
    /// </summary>
    private void StartWave()
    {
        foreach (GameObject alien in Aliens)
        {
            Alien alienScript = alien.GetComponent<Alien>();
            alienScript.StartWave();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="beaconPlacement"></param>
    /// <returns></returns>
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

	public void CheckForLoseCondition()
	{
		if(ship.energy <= 0.0f)
		{
			print ("you lost buddy");
			Time.timeScale = 0;
		}
	}

	public bool CheckForWinCondition()
	{
		foreach(ShipSection shipSection in ship.shipSections)
		{
			if(!shipSection.IsHookedUp)
				return false;
		}
		return true;
	}
}
