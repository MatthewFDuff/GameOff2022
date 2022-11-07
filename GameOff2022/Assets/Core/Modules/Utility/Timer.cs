using System;
using System.Collections;
using UnityEngine;


    public class Timer
    {
        // Public events
        public event Action OnCompleted;
        public event Action OnInterrupted;
        public event Action<float> OnTick;

        // Public properties
        public bool IsActive => routine != null;
        public bool Paused
        {
            get { return paused; }
            set { paused = value; }
        }

        public bool IsCompleted
        {
            get { return isCompleted; }
            private set { isCompleted = value; }
        }

        // Internal data 
        private float time, tickRate;
        private bool paused = false;
        private bool isCompleted = false;
        private Coroutine routine;
        private readonly MonoBehaviour behaviour;


        public Timer(MonoBehaviour boundBehaviour, float timerDuration, float tickRate = 0)
        {
            time = timerDuration;
            this.tickRate = tickRate;
            behaviour = boundBehaviour;
        }

        public void Start()
        {
            routine = behaviour.StartCoroutine(coTimer());
            isCompleted = false;
        }

        public void Stop()
        {
            // If the timer is active, stop it and let 
            if (IsActive)
            {
                behaviour.StopCoroutine(routine);
                routine = null;
                OnInterrupted?.Invoke();
            }
        }

        public void Restart()
        {
            Stop();
            Start();
        }

        public void Reset()
        {
            Stop();
            isCompleted = false;
        }

        public void SetTime(float timerDuration)
        {
            // If the timer is running, stop it.
            if (IsActive) Stop();

            time = timerDuration;
        }

        private IEnumerator coTimer()
        {
            float currentElapsedTime = 0;
            float effectiveTickRate = tickRate;

            do
            {
                yield return new WaitForSeconds(effectiveTickRate);

                if (paused) continue;
                
                currentElapsedTime += (tickRate == 0) ? Time.deltaTime : effectiveTickRate;
                OnTick?.Invoke(currentElapsedTime);

                // If our current tick rate would elongate the duration of the timer, set the next tick to land us right at the end
                if (time - currentElapsedTime < effectiveTickRate)
                {
                    effectiveTickRate = time - currentElapsedTime;
                }
                else
                {
                    effectiveTickRate = tickRate;
                }
                
            } while (currentElapsedTime < time);

            OnCompleted?.Invoke();
            isCompleted = true;
            routine = null;
        }
    }
