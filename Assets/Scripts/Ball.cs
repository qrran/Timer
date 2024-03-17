using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimerLab;

public class Ball : MonoBehaviour
{
    Timer destroyTimer;
    // Start is called before the first frame update
    void Start()
    {
		destroyTimer = gameObject.AddComponent<Timer>();

		// destroy ball after 10 sec
		destroyTimer.SetDuration(10f);
		destroyTimer.Run();
	}

	// Update is called once per frame
	void Update()
    {
		if (destroyTimer.CurrentTime() >= destroyTimer.GetDuration())
		{
			Destroy(gameObject);
			Debug.Log("destroy at: " + destroyTimer.CurrentTime());
			Debug.Log("Ball destroyed");
			destroyTimer.Reset();
		}

	}
}
