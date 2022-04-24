using System; 
using UnityEngine; 

namespace UI.Timer
{
    public class Timer : ITimer
    {
        private float timeRemaining;
        private float timeLeft = 240; 

        private float elapsedRunningTime = 0f;
        private float runningStartTime = 0f;
        private float pauseStartTime = 0f;
        private float elapsedPausedTime = 0f;
        private float totalElapsedPausedTime = 0f;
        private bool isStarted = false;
        private bool isPaused = false;

        private float elapsedSeconds;
        private float elapsedMinutes;
        private float elapsedMilliseconds;

        private float milliseconds;
        private float seconds;
        private float minutes;
        
        private Action<float> onTimeChanged;
        private Action onTimeOver;
        public event Action<float> OnTimeChanged
        {
            add => onTimeChanged += value;
            remove => onTimeChanged -= value;
        }
    
        public event Action OnTimeOver
        {
            add => onTimeOver += value;
            remove => onTimeOver -= value;
        }
        public void UpdateTimer()
        {
            if (isStarted)
            {
                elapsedRunningTime = Time.time - runningStartTime - totalElapsedPausedTime;

                UpdateTime();
                CalculateTime();
                timeRemaining = timeLeft - elapsedSeconds;
                CheckTimeIsOver(timeRemaining);
                onTimeChanged?.Invoke(timeRemaining);
            }
            else if (isPaused)
            {
                elapsedPausedTime = Time.time - pauseStartTime;
            }
        }

        /// <summary>
        /// Check is time over
        /// </summary>
        /// <param name="timeRemain"></param>
        public void CheckTimeIsOver(float timeRemain)
        {
            if (timeRemain > 0) return;
            onTimeOver?.Invoke();
            PauseTimer();
        }

        /// <summary>
        /// Update timer time
        /// </summary>
        public void UpdateTime()
        {
            elapsedMilliseconds = GetMilliseconds();
            elapsedSeconds = GetSeconds();
            elapsedMinutes = GetMinutes();
            milliseconds = elapsedMilliseconds * 1000;
        }

        /// <summary>
        /// Calculate timer time
        /// </summary>
        public void CalculateTime()
        {
            if (elapsedSeconds >= 60)
            {
                seconds = elapsedSeconds % 60;
            }
            else
            {
                seconds = elapsedSeconds;
            }

            if (elapsedMinutes >= 3600)
            {
                minutes = elapsedMinutes % 3600;
            }
            else
            {
                minutes = elapsedMinutes;
            }
        }

        /// <summary>
        /// Stop timer
        /// </summary>
        public void StopTimer()
        {
            elapsedRunningTime = 0f;
            runningStartTime = 0f;
            pauseStartTime = 0f;
            elapsedPausedTime = 0f;
            totalElapsedPausedTime = 0f;
            isStarted = false;
            isPaused = false;
        }

        /// <summary>
        /// Get passed time as minutes
        /// </summary>
        /// <returns></returns>
        public int GetMinutes()
        {
            return (int) (elapsedRunningTime / 60f);
        }

        /// <summary>
        ///Get passed time as seconds
        /// </summary>
        /// <returns></returns>
        public int GetSeconds()
        {
            return (int) (elapsedRunningTime);
        }

        /// <summary>
        /// Get passed time as miliseconds
        /// </summary>
        /// <returns></returns>
        public float GetMilliseconds()
        {
            return (float) (elapsedRunningTime - Math.Truncate(elapsedRunningTime));
        }

        /// <summary>
        /// Begin timer
        /// </summary>
        public void BeginTimer()
        {
            if (isStarted || isPaused) return;
            runningStartTime = Time.time;
            isStarted = true;
        }

        /// <summary>
        /// Set timer on pause
        /// </summary>
        public void PauseTimer()
        {
            if (!isStarted || isPaused) return;
            isStarted = false;
            pauseStartTime = Time.time;
            isPaused = true;
        }

        /// <summary>
        /// Unpause timer
        /// </summary>
        public void Unpause()
        {
            if (isStarted || !isPaused) return;
            totalElapsedPausedTime += elapsedPausedTime;
            isStarted = true;
            isPaused = false;
        }
    }
}