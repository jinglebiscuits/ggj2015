using UnityEngine;
using System.Collections;

public class Alien : MonoBehaviour {

    public enum enAlienBehaviors
    { 
        Attack,
        RunAway,
        Wander
    }

    public enAlienBehaviors Behavior = enAlienBehaviors.Attack;

    /// <summary>
    /// running speed
    /// </summary>
    public float fltSpeed = 1.0f;
    /// <summary>
    /// When the alien gets to this distance from the beacon, it attacks
    /// </summary>
    public float fltBeaconAttackDistance = 1.0f;
    /// <summary>
    /// this is the minimum distance an alien will run from a light when in RunAway mode
    /// </summary>
    public float fltLightSafeDistance = 5.0f;
    /// <summary>
    /// The current health
    /// </summary>
    public float fltHealth = 100.0f;
    /// <summary>
    /// The alien will change from attack mode to RunAway mode when his health falls below this point
    /// </summary>
    public float fltHealthRunAwayThreshold = 50.0f;
    /// <summary>
    /// The rate the alien does damage to a beacon during an attack
    /// </summary>
    public float fltBeaconDamageRate = 0.01f;

    private Neil neil = null;
    private Ship ship = null;

    string strDisplay = "";

    private GameObject[] beacons = null;
    private GameObject closestBeacon = null;

	/// <summary>
	/// 
	/// </summary>
	void Start () {
        neil = GameDirector.instance.neil;
        ship = GameDirector.instance.ship;
        StartWave();
	}
	
	/// <summary>
	/// 
	/// </summary>
	void Update () {
        strDisplay = "";
        Behave();
	}

    void OnGUI()
    {
        
        if (beacons != null) strDisplay += "beacons : " + beacons.Length;
        if (closestBeacon != null) strDisplay += " closestBeacon : " + closestBeacon.transform.position.ToString();

        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), strDisplay);
    
    }

    /// <summary>
    /// 
    /// </summary>
    public void StartWave()
    {
        GetBeaconList();
        fltHealth = 100.0f;
        Behavior = enAlienBehaviors.Attack;
    }

    /// <summary>
    /// 
    /// </summary>
    private void Behave()
    {
        GetDamageFromLight();
        if (Behavior == enAlienBehaviors.Attack)
        {
            FindClosestBeacon();
            MoveTowardBeacon();
            CheckHealth();
        }
        else if (Behavior == enAlienBehaviors.RunAway)
        {
            FindClosestBeacon();
            RunAwayFromBeacon();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void FindClosestBeacon()
    {
        float fltBestDistance = float.MaxValue;
        float fltThisDistance = 0.0f;

        if (beacons == null) GetBeaconList();
        foreach (GameObject thisBeacon in beacons)
        {
            fltThisDistance = (thisBeacon.transform.position - gameObject.transform.position).magnitude;
            if (fltThisDistance < fltBestDistance)
            {
                fltBestDistance = fltThisDistance;
                closestBeacon = thisBeacon;
            }
        }
    
    }

    /// <summary>
    /// 
    /// </summary>
    private void GetBeaconList()
    {
        beacons = GameObject.FindGameObjectsWithTag(Common.Tags.Beacon);
    }

    /// <summary>
    /// 
    /// </summary>
    private void MoveTowardBeacon()
    {
        if (closestBeacon != null )
        {
            if ((transform.position - closestBeacon.transform.position).magnitude > fltBeaconAttackDistance)
            {
                //we are not close enough to do damage
                transform.position = Vector3.Lerp(transform.position, closestBeacon.transform.position, Time.deltaTime * fltSpeed);
            }
            else
            { 
                //we are close enough to do damage
                AttackBeaconClosestBeacon();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void AttackBeaconClosestBeacon()
    {
        //get a ref to the beacon script
        Beacon beaconScript = closestBeacon.GetComponent<Beacon>();
        //damage the beacon
        beaconScript.TakeHit(fltBeaconDamageRate);
    }

    /// <summary>
    /// 
    /// </summary>
    private void RunAwayFromBeacon()
    {
        //get the direction of the closest light
        Vector3 vctRunDirection = (transform.position - closestBeacon.transform.position);
        //are we a save distance from it?
        if (vctRunDirection.magnitude < fltLightSafeDistance)
        {
            //we are too close.  run away! run away!
            vctRunDirection = vctRunDirection.normalized;
            transform.position += vctRunDirection * Time.deltaTime * fltSpeed;
        }
        else
        { 
            //we should be safe now. i will just piddle around out here in outter darkness.
            Behavior = enAlienBehaviors.Wander;
        }
        
    }

    /// <summary>
    /// 
    /// </summary>
    private void GetDamageFromLight()
    { 
        //iterate through each light source
        float fltThisDistance = 0.0f;
        float fltIntensity = 0.0f;
        float fltDamage = 0.0f;
        if (beacons != null)
        {
            foreach (GameObject thisBeacon in beacons)
            {
                fltThisDistance = (thisBeacon.transform.position - gameObject.transform.position).magnitude;
                fltIntensity = GetLightIntensity(thisBeacon);
                fltDamage = fltIntensity / Mathf.Pow(fltThisDistance, 2.0f);
                if (fltDamage < 0.1f) fltDamage = 0.0f;
                fltHealth -= fltDamage * Time.deltaTime;
            }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    private void CheckHealth()
    {
        //Debug.Log(string.Format("health {0:000.000}  thresh {1:000.000} ", fltHealth, fltHealthRunAwayThreshold));
        //check to see if i am well enough to keep attacking
        if (fltHealth < fltHealthRunAwayThreshold)
        {
            
            //run away!  run away!
            Behavior = enAlienBehaviors.RunAway;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="beacon"></param>
    /// <returns></returns>
    private float GetLightIntensity(GameObject beacon)
    {
        //get a ref to the beacon script
        Beacon beaconScript = beacon.GetComponent<Beacon>();
        Light light = beaconScript.light;
        LightSource ls = light.GetComponent<LightSource>();
        float fltIntensity = ls.intensity;
        return fltIntensity;
    }

}
