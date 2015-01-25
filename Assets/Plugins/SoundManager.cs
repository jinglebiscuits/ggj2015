using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

	public GameObject audioSource;
	private List<GameObject> audioSources = new List<GameObject>();
	public List<AudioClip> audioClips = new List<AudioClip>();
	public AudioClip gameOver;
	public AudioClip actionBass;
	public Ship ship;
	private int tension = 0;

	// Use this for initialization
	void Start () {

		//ship = GameObject.Find("Ship").GetComponent<Ship>();

		for(int i = 0; i < 9; i++)
		{
			GameObject clone = (GameObject) Instantiate(audioSource, transform.position, Quaternion.identity);
			clone.transform.parent = this.transform;
			audioSources.Add(clone);
		}
		audioSources[0].GetComponent<AudioSource>().clip = audioClips[0];
		audioSources[0].GetComponent<AudioSource>().Play();
		
		audioSources[1].GetComponent<AudioSource>().clip = audioClips[1];
		audioSources[1].GetComponent<AudioSource>().Play();
		
		audioSources[2].GetComponent<AudioSource>().clip = audioClips[2];
		audioSources[2].GetComponent<AudioSource>().Play();
		
		audioSources[3].GetComponent<AudioSource>().clip = audioClips[3];
		audioSources[3].GetComponent<AudioSource>().Play();
		
		audioSources[4].GetComponent<AudioSource>().clip = audioClips[4];
		audioSources[4].GetComponent<AudioSource>().Play();
		
		audioSources[5].GetComponent<AudioSource>().clip = audioClips[5];
		audioSources[5].GetComponent<AudioSource>().Play();
		
		audioSources[6].GetComponent<AudioSource>().clip = audioClips[6];
		audioSources[6].GetComponent<AudioSource>().Play();
		
		audioSources[7].GetComponent<AudioSource>().clip = audioClips[7];
		audioSources[7].GetComponent<AudioSource>().Play();

		Tension0 ();
	}
	
	// Update is called once per frame
	void Update () {
		if(ship.energy < 970 && ship.energy >= 800)
		{
			if(tension != 1)
			{
				tension = 1;
				Tension1();
			}
		}
		else if(ship.energy < 800 && ship.energy >= 600)
		{
			if(tension != 2)
			{
				tension = 2;
				Tension2();
			}
		}
		else if(ship.energy < 600 && ship.energy >= 500)
		{
			if(tension != 3)
			{
				tension = 3;
				Tension3();
			}
		}
		else if(ship.energy < 500 && ship.energy >= 400)
		{
			if(tension != 4)
			{
				tension = 4;
				Tension4();
			}
		}
		else if(ship.energy < 400 && ship.energy >= 300)
		{
			if(tension != 5)
			{
				tension = 5;
				Tension5();
			}
		}
		else if(ship.energy < 300 && ship.energy >= 200)
		{
			if(tension != 6)
			{
				tension = 6;
				Tension6();
			}
		}
		else if(ship.energy < 200 && ship.energy >= 100)
		{
			if(tension != 7)
			{
				tension = 7;
				Tension7();
			}
		}
	}

	public void Tension0()
	{
		audioSources[0].GetComponent<AudioSource>().volume = 1;
		audioSources[1].GetComponent<AudioSource>().volume = 0;
		audioSources[2].GetComponent<AudioSource>().volume = 0;
		audioSources[3].GetComponent<AudioSource>().volume = 0;
		audioSources[4].GetComponent<AudioSource>().volume = 0;
		audioSources[5].GetComponent<AudioSource>().volume = 0;
		audioSources[6].GetComponent<AudioSource>().volume = 0;
		audioSources[7].GetComponent<AudioSource>().volume = 0;
	}

	public void Tension1()
	{
		StartCoroutine(FadeIn(audioSources[1].GetComponent<AudioSource>()));
//		audioSources[1].GetComponent<AudioSource>().volume = 1;
//		audioSources[2].GetComponent<AudioSource>().volume = 0;
//		audioSources[3].GetComponent<AudioSource>().volume = 0;
//		audioSources[4].GetComponent<AudioSource>().volume = 0;
//		audioSources[5].GetComponent<AudioSource>().volume = 0;
//		audioSources[6].GetComponent<AudioSource>().volume = 0;
//		audioSources[7].GetComponent<AudioSource>().volume = 0;
	}

	public void Tension2()
	{
		StartCoroutine(FadeIn(audioSources[2].GetComponent<AudioSource>()));
//		audioSources[1].GetComponent<AudioSource>().volume = 1;
//		audioSources[2].GetComponent<AudioSource>().volume = 1;
//		audioSources[3].GetComponent<AudioSource>().volume = 0;
//		audioSources[4].GetComponent<AudioSource>().volume = 0;
//		audioSources[5].GetComponent<AudioSource>().volume = 0;
//		audioSources[6].GetComponent<AudioSource>().volume = 0;
//		audioSources[7].GetComponent<AudioSource>().volume = 0;
	}

	public void Tension3()
	{
		StartCoroutine(FadeIn(audioSources[3].GetComponent<AudioSource>()));
//		audioSources[1].GetComponent<AudioSource>().volume = 1;
//		audioSources[2].GetComponent<AudioSource>().volume = 1;
//		audioSources[3].GetComponent<AudioSource>().volume = 1;
//		audioSources[4].GetComponent<AudioSource>().volume = 0;
//		audioSources[5].GetComponent<AudioSource>().volume = 0;
//		audioSources[6].GetComponent<AudioSource>().volume = 0;
//		audioSources[7].GetComponent<AudioSource>().volume = 0;
	}

	public void Tension4()
	{
		StartCoroutine(FadeIn(audioSources[4].GetComponent<AudioSource>()));
//		audioSources[1].GetComponent<AudioSource>().volume = 1;
//		audioSources[2].GetComponent<AudioSource>().volume = 1;
//		audioSources[3].GetComponent<AudioSource>().volume = 1;
//		audioSources[4].GetComponent<AudioSource>().volume = 1;
//		audioSources[5].GetComponent<AudioSource>().volume = 0;
//		audioSources[6].GetComponent<AudioSource>().volume = 0;
//		audioSources[7].GetComponent<AudioSource>().volume = 0;
	}

	public void Tension5()
	{
		StartCoroutine(FadeIn(audioSources[5].GetComponent<AudioSource>()));
//		audioSources[1].GetComponent<AudioSource>().volume = 1;
//		audioSources[2].GetComponent<AudioSource>().volume = 1;
//		audioSources[3].GetComponent<AudioSource>().volume = 1;
//		audioSources[4].GetComponent<AudioSource>().volume = 1;
//		audioSources[5].GetComponent<AudioSource>().volume = 1;
//		audioSources[6].GetComponent<AudioSource>().volume = 0;
//		audioSources[7].GetComponent<AudioSource>().volume = 0;
	}

	public void Tension6()
	{
		StartCoroutine(FadeIn(audioSources[6].GetComponent<AudioSource>()));
//		audioSources[1].GetComponent<AudioSource>().volume = 1;
//		audioSources[2].GetComponent<AudioSource>().volume = 1;
//		audioSources[3].GetComponent<AudioSource>().volume = 1;
//		audioSources[4].GetComponent<AudioSource>().volume = 1;
//		audioSources[5].GetComponent<AudioSource>().volume = 1;
//		audioSources[6].GetComponent<AudioSource>().volume = 1;
//		audioSources[7].GetComponent<AudioSource>().volume = 0;
	}

	public void Tension7()
	{
		StartCoroutine(FadeIn(audioSources[7].GetComponent<AudioSource>()));
//		audioSources[1].GetComponent<AudioSource>().volume = 1;
//		audioSources[2].GetComponent<AudioSource>().volume = 1;
//		audioSources[3].GetComponent<AudioSource>().volume = 1;
//		audioSources[4].GetComponent<AudioSource>().volume = 1;
//		audioSources[5].GetComponent<AudioSource>().volume = 1;
//		audioSources[6].GetComponent<AudioSource>().volume = 1;
//		audioSources[7].GetComponent<AudioSource>().volume = 1;
	}

	public IEnumerator FadeIn(AudioSource audioSource)
	{
		while(audioSource.volume < 1.0f)
		{
			audioSource.volume += 0.1f;
			yield return new WaitForSeconds(0.4f);
		}
	}

	public IEnumerator FadeOut(AudioSource audioSource)
	{
		while(audioSource.volume > 0.0f)
		{
			audioSource.volume -= 0.1f;
			yield return new WaitForSeconds(0.4f);
		}
	}
}
