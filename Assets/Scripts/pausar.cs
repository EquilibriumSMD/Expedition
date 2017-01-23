using UnityEngine;
using System.Collections;

public class pausar : MonoBehaviour 
{

	public bool jgPausado;

	public GameObject campoPausar;

	// Use this for initialization
	void Start () 
	{
		jgPausado = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyUp (KeyCode.Escape)) 
		{
			jgPausado = !jgPausado;
			campoPausar.SetActive (jgPausado);
			if (jgPausado) 
			{
				Debug.Log ("Pausou");
				Time.timeScale = 0;
			}
			else 
			{
				Debug.Log ("Resumiu");
				Time.timeScale = 1;
			}
		}
	}
}
