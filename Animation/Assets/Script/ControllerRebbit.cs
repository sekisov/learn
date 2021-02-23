using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRebbit : MonoBehaviour
{
	enum PlayerStatus
	{
		Walk, 
		Rake,
		Death
	}
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			GetComponent<Animator>().SetInteger("PlayerStatus", 0);
			//GetComponent<Animator>().SetBool("Rake", true);
		}
		if (Input.GetMouseButtonDown(1))
		{
			GetComponent<Animator>().SetInteger("PlayerStatus", 1);
			//GetComponent<Animator>().SetBool("Rake", false);
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GetComponent<Animator>().SetInteger("PlayerStatus", 2);
		}
	}
}
