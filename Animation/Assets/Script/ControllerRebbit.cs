using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerRebbit : MonoBehaviour
{
	public float Speed = 6.0f;
	public float JumpValue = 8.0f;
	public float Gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	public Text LblAppleCounter;
	bool isdDeath = false;

	private GameObject _target;
	private int _counterApple = 0;
	enum PlayerStatus
	{
		Walk,
		Rake,
		Death
	}
	CharacterController controller;
	// Start is called before the first frame update
	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{
		if (!isdDeath)
		{
			if (controller.isGrounded)
			{
				moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= Speed;
				if (Input.GetButton("Jump"))
				{
					moveDirection.y = JumpValue;
				}
				if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
				{
					GetComponent<Animator>().SetInteger("PlayerStatus", 0);
				}
				else
				{
					GetComponent<Animator>().SetInteger("PlayerStatus", 1);
				}
			}
			moveDirection.y -= Gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);

			if (Input.GetMouseButtonDown(1))
			{
				GetComponent<Animator>().SetInteger("PlayerStatus", 1);
			}
			if (Input.GetKeyDown(KeyCode.Q))
			{
				GetComponent<Animator>().SetInteger("PlayerStatus", 2);
				isdDeath = true;
			}
		}
	}
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		
	}	
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<SphereCollider>())
		{
			LblAppleCounter.text = (++_counterApple).ToString();
			_target = other.gameObject;
			Destroy(_target, 1.0f);
		}
	}
}
