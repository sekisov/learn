using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLight : MonoBehaviour
{
	public float Speed = 10.0f;
	public int Signum = 1;
	private bool _lookAt;
	GameObject _target;
	// Start is called before the first frame update
	private void Start()
	{

	}

	// Update is called once per frame
	private void Update()
	{
		if (_target == null)
		{
			transform.Rotate(Vector3.right * Signum * Time.deltaTime * Speed);
		}
		else
		{
			transform.LookAt(_target.transform);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<PlayerController>())
		{
			_target = other.gameObject;
		}
	}
	private void OnTriggerStay(Collider other)
	{
		if (other.GetComponent<PlayerController>())
		{ }
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<PlayerController>())
		{
			_target = null;
		}
	}

}
