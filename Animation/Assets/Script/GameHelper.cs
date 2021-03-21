using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameHelper : MonoBehaviour
{
	private int _counterApple = 0;
	public Text LblAppleCounter;
	public int TreePrice = 5;
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit raycastHit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit))
			{
				if (raycastHit.collider.gameObject == null)
				{
					return;
				}
				Debug.Log("Hit = " + raycastHit.collider.gameObject.name);

				switch (raycastHit.collider.name)
				{
					case string name when name.Contains("Apple"):
						{
							LblAppleCounter.text = (++_counterApple).ToString();
							Destroy(raycastHit.collider.gameObject);

							break;
						}
					case string name when name.Contains("Floor"):
						{
							if (_counterApple >= TreePrice)
							{
								_counterApple -= TreePrice;
								GameObject tree = Instantiate(Resources.Load("Tree"), raycastHit.point, Quaternion.identity) as GameObject;								
							}
							break;
						}
				}

			}
		}
	}
}
