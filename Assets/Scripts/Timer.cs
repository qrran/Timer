using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimerLab
{
	public class Timer : MonoBehaviour
	{
		//start time/current time/how much time passed
		public float elapsedTime = 0;
		//time interval fron start to end
		public float duration;
		//check if the timer is running 
		private bool isRunning = false;

		//record the current time
		public float CurrentTime()
		{
			return elapsedTime;
		}
		//set the duration time
		public void SetDuration(float endTime)
		{
			if (endTime <= 0)
			{
				throw new ArgumentException("Ending time should be bigger than 0.");
			}
			else if (endTime <= elapsedTime)
			{
				throw new ArgumentException("Ending time should be bigger than start time.");
			}
			else
			{
				duration = endTime;
			}
		}

		public float GetDuration()
		{
			return duration;
		}
		//start running
		public bool Run()
		{
			// update elapsedTime
			elapsedTime += Time.deltaTime;
			return isRunning = true;
		}
		//reset the timer
		public void Reset()
		{
			isRunning = false;
			elapsedTime = 0;
		}
		//stop runing
		public bool Stop()
		{
			return isRunning = false;
		}

		// Update is called once per frame
		void Update()
		{
			//once timer start running, update timer
			if (isRunning)
			{
				elapsedTime += Time.deltaTime;
				if (elapsedTime >= duration)
				{
					isRunning = false;
				}
			}
		}
	}
}