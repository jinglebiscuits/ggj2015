using UnityEngine;
using System.Collections;

public class ColorObjects : MonoBehaviour {
	
	public Material pulseMaterial;
	public Texture2D mainTexture;
	public Texture2D normalMap;
	public Transform player;
	public bool isTarget;
	public Renderer[] rends;
	
	// Use this for initialization
	void Start ()
	{
		if(gameObject.renderer)
		{
			transform.renderer.material = pulseMaterial;
			player = GameObject.FindGameObjectWithTag("Player").transform;
			if(transform.tag == "Grub")
			{
				transform.renderer.material.SetFloat("_RimOn", 1);
				transform.renderer.material.SetColor("_Color", Color.cyan);
			}
			else if(transform.tag == "Cave")
			{
				transform.renderer.material.SetTexture("_MainTex", mainTexture);
				transform.renderer.material.SetFloat("_RimOn", 1);
				transform.renderer.material.SetFloat("_RimPower", 0.6f);
				transform.renderer.material.SetColor("_RimColor", Color.magenta);
				transform.renderer.material.SetColor("_Color", Color.gray);
				transform.renderer.material.SetTexture("_BumpMap", normalMap);
			}
			else if(transform.tag == "Water")
			{
				transform.renderer.material.SetFloat("_RimOn", 0);
				transform.renderer.material.SetColor("_Color", Color.blue);
			}
			else if(transform.tag == "Plant")
			{
				transform.renderer.material.SetFloat("_RimOn", 0);
				transform.renderer.material.SetColor("_Color", Color.green);
				transform.renderer.material.SetTexture("_MainTex", mainTexture);
				transform.renderer.material.SetTexture("_BumpMap", normalMap);
			}			
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
//		if(PulseDistance.target == transform && transform.tag == "Cave")
//		{
//			rends = transform.parent.parent.GetComponentsInChildren<Renderer>();
//			foreach(Renderer rend in rends)
//			{
//				rend.material.SetFloat("_RimOn", 1);
//				if(rend.tag == "Cave")
//					rend.material.SetColor("_RimColor", new Color(0.4f, 0.2f, 0.2f));
//			}
//		}
//		
//		else
//		{
//			rends = gameObject.GetComponentsInChildren<Renderer>();
//			foreach(Renderer rend in rends)
//			{
//				rend.material.SetFloat("_RimOn", 0);	
//			}
//		}
		
		if(gameObject.renderer)
		{
			transform.renderer.material.SetVector("_Origin", new Vector4(0, 0, 0, 0));
			transform.renderer.material.SetFloat("_PDistance", 10.0f);
			transform.renderer.material.SetFloat("_PFadeDistance", 40.0f);
			transform.renderer.material.SetFloat("_PEdgeSoftness", 0.5f);			
		}

	}
	
	public void Glow(bool on)
	{
		if(on)
			transform.renderer.material.SetFloat("_RimOn", 1);
		else
			transform.renderer.material.SetFloat("_RimOn", 0);
	}
}
