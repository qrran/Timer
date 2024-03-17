using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimerLab;
using System;

public class SpawnBall : MonoBehaviour
{
	[SerializeField] GameObject prefabBall;
	Timer spawnTimer;

	[SerializeField]float minSpawnX = -5, maxSpawnX = 5, minSpawnY = -5, maxSpawnY = 5;

	// Start is called before the first frame update
	void Start()
	{
		//string path = "Assets/Resources/ball.prefab";
		//prefabBall = Instantiate(Resources.Load(path, typeof(GameObject))) as GameObject;

		//spawnTimer objects
		spawnTimer = gameObject.AddComponent<Timer>();

		//spawn a ball at the beginning
		spawnBall();
		spawnTimer.SetDuration(UnityEngine.Random.Range(2f, 4f));
		spawnTimer.Run();
	}

	// Update is called once per frame
	void Update()
	{
		//spawnTimer.GetDuration
		if (spawnTimer.CurrentTime() >= spawnTimer.GetDuration())
		{
			//when reach random time between 2f and 4f, spawn a ball
			spawnBall();
			Debug.Log("spawn time: " + spawnTimer.CurrentTime());
			spawnTimer.Reset();
			spawnTimer.SetDuration(UnityEngine.Random.Range(2f, 4f));
			spawnTimer.Run();
		}
	}

	void spawnBall()
	{
		//instantiate ball
		GameObject ball = Instantiate(
			prefabBall,
			new Vector3(
				UnityEngine.Random.Range(minSpawnX, maxSpawnX),
				UnityEngine.Random.Range(minSpawnY, maxSpawnY),
				-Camera.main.transform.position.z),
			transform.rotation);

		Color color = new Color(
			UnityEngine.Random.Range(0, 1f),
			UnityEngine.Random.Range(0, 1f),
			UnityEngine.Random.Range(0, 1f),
			UnityEngine.Random.Range(0.5f,1f) //transparency
			);
		SpriteRenderer spriteRenderer = ball.GetComponent<SpriteRenderer>();
		spriteRenderer.color = color;

	}

}
