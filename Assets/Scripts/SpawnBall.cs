using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimerLab;
using System;

public class SpawnBall : MonoBehaviour
{
	[SerializeField] GameObject prefabBall;
	Timer spawnTimer;

	[SerializeField] float minSpawnX = -5, maxSpawnX = 5, minSpawnY = -5, maxSpawnY = 5;

	// Start is called before the first frame update
	void Start()
	{

		//spawnTimer objects
		spawnTimer = gameObject.AddComponent<Timer>();

		//spawn a ball at the beginning
		spawnBall();
		//set random time interval between 2f and 4f for next ball to spawn
		spawnTimer.SetDuration(UnityEngine.Random.Range(2f, 4f));
		//start spawnTimer
		spawnTimer.Run();
	}

	// Update is called once per frame
	void Update()
	{
		//once it reaches the random time for next ball to spawn
		if (spawnTimer.CurrentTime() >= spawnTimer.GetDuration())
		{
			//spawn the ball
			spawnBall();
			//test
			Debug.Log("spawn time: " + spawnTimer.CurrentTime());
			//reset the spawnTimer
			spawnTimer.Reset();
			//continue start another timer for next ball to spawn at a random time
			spawnTimer.SetDuration(UnityEngine.Random.Range(2f, 4f));
			//start spawnTimer
			spawnTimer.Run();
		}
	}

	void spawnBall()
	{
		//instantiate the ball
		GameObject ball = Instantiate(
			prefabBall,
			new Vector3(
				UnityEngine.Random.Range(minSpawnX, maxSpawnX),
				UnityEngine.Random.Range(minSpawnY, maxSpawnY),
				-Camera.main.transform.position.z),
			transform.rotation);
		//assign random color for each ball spawned
		Color color = new Color(
			UnityEngine.Random.Range(0, 1f),
			UnityEngine.Random.Range(0, 1f),
			UnityEngine.Random.Range(0, 1f),
			UnityEngine.Random.Range(0.5f, 1f) //transparency
			);
		SpriteRenderer spriteRenderer = ball.GetComponent<SpriteRenderer>();
		spriteRenderer.color = color;

	}

}
