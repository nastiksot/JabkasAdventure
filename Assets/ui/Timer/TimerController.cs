using System;
using DI;
using TMPro;
using UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Timer
{
    public class TimerController
    {
        private float timeRemaining;
        private float timeLeft = 120;
        private Action<float> onTimeChanged;

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

        public float TimeRemaining => timeRemaining;

        public event Action<float> OnTimeChanged
        {
            add => onTimeChanged += value;
            remove => onTimeChanged -= value;
        }

        public void StartTimer()
        {
            if (isStarted)
            {
                elapsedRunningTime = Time.time - runningStartTime - totalElapsedPausedTime;

                UpdateTime();
                CalculateTime();
                timeRemaining = timeLeft - seconds;
                onTimeChanged?.Invoke(timeRemaining);
            }
            else if (isPaused)
            {
                elapsedPausedTime = Time.time - pauseStartTime;
            }
        }

        /// <summary>
        /// Update timer time
        /// </summary>
        private void UpdateTime()
        {
            elapsedMilliseconds = GetMilliseconds();
            elapsedSeconds = GetSeconds();
            elapsedMinutes = GetMinutes();
            milliseconds = elapsedMilliseconds * 1000;
        }

        /// <summary>
        /// Calculate timer time
        /// </summary>
        private void CalculateTime()
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
        private int GetMinutes()
        {
            return (int) (elapsedRunningTime / 60f);
        }

        /// <summary>
        ///Get passed time as seconds
        /// </summary>
        /// <returns></returns>
        private int GetSeconds()
        {
            return (int) (elapsedRunningTime);
        }

        /// <summary>
        /// Get passed time as miliseconds
        /// </summary>
        /// <returns></returns>
        private float GetMilliseconds()
        {
            return (float) (elapsedRunningTime - Math.Truncate(elapsedRunningTime));
        }

        /// <summary>
        /// Begin timer
        /// </summary>
        public void BeginTimer()
        {
            if (isStarted || isPaused) return;
            Time.timeScale = 1f;
            runningStartTime = Time.time;
            isStarted = true;
        }

        /// <summary>
        /// Set timer on pause
        /// </summary>
        public void PauseTimer()
        {
            Time.timeScale = 0;
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
            Time.timeScale = 1f;
            if (isStarted || !isPaused) return;
            totalElapsedPausedTime += elapsedPausedTime;
            isStarted = true;
            isPaused = false;
        }
    }
}