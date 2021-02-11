using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject EnemyPrefab;
	public float SpawnTime = 0.5f;
	// Start is called before the first frame update
	void Start()
	{
		InvokeRepeating("SpawnTimer", SpawnTime, SpawnTime);
	}
	private void SpawnTimer()
	{
		GameObject Enemy = Instantiate(EnemyPrefab, transform.position, transform.rotation);
		
	}
	// Update is called once per frame
	private void Update()
	{

	}
}
