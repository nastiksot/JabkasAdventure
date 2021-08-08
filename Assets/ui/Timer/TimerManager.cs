using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Timer
{
    public class TimerManager : MonoBehaviour
    {
        [SerializeField] private Button pauseButton;

        [SerializeField] private TMP_Text timerTextMeshObject;
        [SerializeField] private float timeLeft = 120;

        private float elapsedRunningTime = 0f;
        private float runningStartTime = 0f;
        private float pauseStartTime = 0f;
        private float elapsedPausedTime = 0f;
        private float totalElapsedPausedTime = 0f;
        private bool isStarted = false;
        private bool isPaused = false;

        float elapsedSeconds;
        float elapsedMinutes;
        float elapsedMilliseconds;

        float milliseconds;
        float seconds;
        float minutes;

        public Button PauseButton
        {
            get => pauseButton;
            set => pauseButton = value;
        }
        
        private void Start()
        {
            BeginTimer();
        }

        void Update()
        {
            if (isStarted)
            {
                elapsedRunningTime = Time.time - runningStartTime - totalElapsedPausedTime;

                UpdateTime();
                CalculateTime();
                if (milliseconds.ToString().Length < 2) return;

                var timeRemaining = timeLeft - seconds;

                timerTextMeshObject.text = timeRemaining.ToString();
            }
            else if (isPaused)
            {
                elapsedPausedTime = Time.time - pauseStartTime;
            }
        }

        private void UpdateTime()
        {
            elapsedMilliseconds = GetMilliseconds();
            elapsedSeconds = GetSeconds();
            elapsedMinutes = GetMinutes();
            milliseconds = elapsedMilliseconds * 1000;
        }

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

        private int GetMinutes()
        {
            return (int) (elapsedRunningTime / 60f);
        }

        private int GetSeconds()
        {
            return (int) (elapsedRunningTime);
        }

        private float GetMilliseconds()
        {
            return (float) (elapsedRunningTime - Math.Truncate(elapsedRunningTime));
        }

        public void BeginTimer()
        {
            if (isStarted || isPaused) return;
            runningStartTime = Time.time;
            isStarted = true;
        }

        public void PauseTimer()
        {
            if (!isStarted || isPaused) return;
            isStarted = false;
            pauseStartTime = Time.time;
            isPaused = true;
        }

        public void Unpause()
        {
            if (isStarted || !isPaused) return;
            totalElapsedPausedTime += elapsedPausedTime;
            isStarted = true;
            isPaused = false;
        }
    }
}