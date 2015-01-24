using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartButton : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
		
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}

		public void StartButtonClick ()
		{
				Application.LoadLevel ("Main");
		}

		public void MadeIt ()
		{
				Application.LoadLevel ("TitleMenu");
		}

		public void Done ()
		{
				Application.Quit ();
		}

}
