using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour {

	public static bool isStop = false;
	public int spawnInterval;
	public GameObject enemy;
	
	private int frames;
	private int count;
	
	// Use this for initialization
	void Start () {
		frames = Mathf.RoundToInt(1.0f / Time.fixedDeltaTime);
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
		if (!isStop)
			count++;
		else
			count = 0;
		if (count > frames * spawnInterval)
		{
			count = 0;
			InstantiateEnemy("normal");
		}
	}

	private void InstantiateEnemy(string type)
	{
		if (type.Equals("normal"))
			Instantiate(enemy, this.transform.position, this.transform.rotation);
	}
}
