using UnityEngine;
using System.Collections;

public class Alien : MonoBehaviour {

    public enum enAlienBehaviors
    { 
        Attack,
        RunAway
    }

    public enAlienBehaviors Behavior = enAlienBehaviors.RunAway;
    public float fltSpeed = 1.0f;
    public float fltBeaconMinAttackDistance = 1.0f;
    public float fltLightSafeDistance = 5.0f;

    private Neil neil = null;
    private Ship ship = null;
    
    private float fltHealth = 100.0f;
    private float fltSunburn = 0.0f;
    

    private GameObject[] beacons = null;
    private GameObject closestBeacon = null;

	/// <summary>
	/// 
	/// </summary>
	void Start () {
        Behavior = enAlienBehaviors.RunAway;
        neil = GameDirector.instance.neil;
        ship = GameDirector.instance.ship;
	}
	
	/// <summary>
	/// 
	/// </summary>
	void Update () {
        Behave();
	}

    void OnGUI()
    {
        string strDisplay = "";
        if (beacons != null) strDisplay += "beacons : " + beacons.Length;
        if (closestBeacon != null) strDisplay += " closestBeacon : " + closestBeacon.transform.position.ToString();

        //GUI.Label(new Rect(0, 0, Screen.width, Screen.height), strDisplay);
    
    }

    /// <summary>
    /// 
    /// </summary>
    private void Behave()
    {
        if (Behavior == enAlienBehaviors.Attack)
        {
            FindClosestBeacon();
            MoveTowardBeacon();
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
        if (closestBeacon != null && (transform.position - closestBeacon.transform.position).magnitude > fltBeaconMinAttackDistance)
        {
            transform.position = Vector3.Lerp(transform.position, closestBeacon.transform.position, Time.deltaTime * fltSpeed);
        }
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
        foreach (GameObject thisBeacon in GameDirector.instance.beacons)
        {
            fltThisDistance = (thisBeacon.transform.position - gameObject.transform.position).magnitude;
            fltIntensity = GetLightIntensity(thisBeacon);
            fltDamage = fltIntensity / fltThisDistance;
            fltHealth -= fltDamage * Time.deltaTime;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="beacon"></param>
    /// <returns></returns>
    private float GetLightIntensity(GameObject beacon)
    {
        return 0.5f;
    }

}
