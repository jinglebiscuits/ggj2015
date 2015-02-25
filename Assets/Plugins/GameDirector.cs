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
    public Light MainLight = null;
    public bool blnFoundArmory = false;
    public bool blnFoundMedStation = false;
    public bool blnWin = false;
    public Material matArmoryMaterial = null;
    public Material matMedSectionMaterial = null;
   
    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        matArmoryMaterial.SetColor("_Color", Color.black);
        matMedSectionMaterial.SetColor("_Color", Color.black);
    }

    public void FoundShipPart(string strName)
    {
        Debug.Log("found ship part " + strName);
        if (strName == "ArmorySection")
        {
            blnFoundArmory = true;
            matArmoryMaterial.SetColor("_Color", Color.white);
            Debug.Log(matArmoryMaterial.GetColor("_Color").ToString());
        }

        if (strName == "MedicalSection")
        {
			print ("jedi");
            blnFoundMedStation = true;
            matMedSectionMaterial.SetColor("_Color", Color.white);
            Debug.Log(matMedSectionMaterial.GetColor("_Color").ToString());
        }

        if (blnFoundArmory == true && blnFoundMedStation == true)
        {
            Debug.Log("you win");
            blnWin = true;
            StartCoroutine(LoadWinScene());
        }
    }

    private IEnumerator LoadWinScene()
    {
        yield return new WaitForSeconds(3.0f);
        Application.LoadLevel("Win");
    }

    /// <summary>
    /// 
    /// </summary>
	void Update()
	{
        try
        {
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) return;

		    if(Input.GetButton("Fire1"))
		    {
			    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			    RaycastHit hit;
			    if (Physics.Raycast(ray, out hit, 100, ~(1 << 10)))
			    {
				    if(hit.collider.transform.tag == "Terrain")
				    {
					    if(neil.neilControlState == NeilControlStates.InShip)
					    {
							neil.transform.position = GetNearestBeaconLocation(hit.point);
							neil.wayPoint = hit.point;
							neil.neilControlState = NeilControlStates.PlantingBeacon;
						    //neil.PlaceBeacon(GetNearestBeaconLocation(hit.point), hit.point);
					    }
					    else if(neil.neilControlState == NeilControlStates.FreeMoveStanding)
					    {
							neil.wayPoint = hit.point;
							neil.neilControlState = NeilControlStates.FreeMoveMoving;
//						    neil.WalkToSpot(hit.point);
					    }
				    }
				    else if(hit.collider.transform.name == "Ship")
				    {
					    if(neil.neilControlState == NeilControlStates.FreeMoveStanding)
					    {
							neil.wayPoint = hit.collider.transform.position;
							neil.neilControlState = NeilControlStates.FreeMoveMoving;
//						    neil.WalkToSpot(hit.collider.transform.position);
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

    /// <summary>
    /// 
    /// </summary>
    public void SendPulse()
    {
        Debug.Log("Send Pulse");
        StartCoroutine(StartPulseWave());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartPulseWave()
    {
        Debug.Log("turning light up");
        int intTotal = 10;
        for (int i = 0; i < intTotal; i++)
        {
            MainLight.intensity = (float)i / (float)intTotal;
            yield return new WaitForSeconds(0.003f);
        }

        for (int i = intTotal; i > 0; i--)
        {
            MainLight.intensity = (float)i / (float)intTotal;
            yield return new WaitForSeconds(0.003f);
        }
        
        MainLight.intensity = 0.0f;
        Debug.Log("turning light down");
        yield return 0;
        
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
