using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float Speed = 6.0f;
	public float JumpValue = 8.0f;
	public float Gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded)
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= Speed;
			if (Input.GetButton("Jump"))
			{
				moveDirection.y = JumpValue;
			}			
		}
		moveDirection.y -= Gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
