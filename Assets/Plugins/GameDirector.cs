﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDirector : MonoBehaviour {

    public static GameDirector instance = null;

    public Neil neil = null;
    public Ship ship = null;
    public List<GameObject> beacons = null;
   

    void Awake()
    {
        instance = this;
    }

	void Update()
	{
		if(Input.GetButton("Fire1"))
		{
			print ("ball");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100))
			{
				print ("sack");
				print (hit.point);
				Debug.DrawLine(ray.origin, hit.point);
				neil.WalkToSpot(hit.point);
			}
				
		}
			
	}

}