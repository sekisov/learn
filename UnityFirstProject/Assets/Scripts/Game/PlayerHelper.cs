using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHelper : MonoBehaviour
{
	/// <summary>
	/// Точки куда можем двигаться
	/// </summary>
	public GameObject[] Points;
	/// <summary>
	/// Сохарненная позиция
	/// </summary>
	private Vector3 _target;
	/// <summary>
	/// Точка куда двигаемся
	/// </summary>
	int _index;
	public float Speed;
	// Start is called before the first frame update
	void Start()
	{
		_target = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (_index > 0)
			{
				--_index;
			}
			else
			{
				_index = Points.Length - 1;
			}
			//Перемещаемся к выбранному объекту
			_target = Points[_index].transform.position;
		}
		else
		{
			if (Input.GetMouseButtonDown(1))
			{
				if (_index < Points.Length - 1)
				{
					++_index;
				}
				else
				{
					_index = 0;
				}
				//Перемещаемся к выбранному объекту
				_target = Points[_index].transform.position;
			}
			else
			{
				transform.position = Vector3.MoveTowards(transform.position, _target, Time.deltaTime * Speed);
			}
		}
	}
}
