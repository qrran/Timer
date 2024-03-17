
using UnityEngine;
using TimerLab;

public class TimerTest : MonoBehaviour
{
	Timer timer;

	// Start is called before the first frame update
	void Start()
	{
		timer = gameObject.AddComponent<Timer>();
		timer.SetDuration(3);
		timer.Run();
		Debug.Log("The timer starts at: " + timer.CurrentTime());

	}

	// Update is called once per frame
	void Update()
	{
		if (timer.CurrentTime() >= timer.duration)
		{
			timer.Stop();
			UnityEditor.EditorApplication.isPlaying = false;
			Debug.Log("Timer finished at: " + timer.CurrentTime());
		}
	}

}
