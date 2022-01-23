using System;

namespace UI.Timer
{
    public interface ITimer
    {
        event Action<float> OnTimeChanged;
        event Action OnTimeOver;
        void UpdateTimer();

        /// <summary>
        /// Check is time over
        /// </summary>
        /// <param name="timeRemain"></param>
        void CheckTimeIsOver(float timeRemain);

        /// <summary>
        /// Update timer time
        /// </summary>
        void UpdateTime();

        /// <summary>
        /// Calculate timer time
        /// </summary>
        void CalculateTime();

        /// <summary>
        /// Stop timer
        /// </summary>
        void StopTimer();

        /// <summary>
        /// Get passed time as minutes
        /// </summary>
        /// <returns></returns>
        int GetMinutes();

        /// <summary>
        ///Get passed time as seconds
        /// </summary>
        /// <returns></returns>
        int GetSeconds();

        /// <summary>
        /// Get passed time as miliseconds
        /// </summary>
        /// <returns></returns>
        float GetMilliseconds();

        /// <summary>
        /// Begin timer
        /// </summary>
        void BeginTimer();

        /// <summary>
        /// Set timer on pause
        /// </summary>
        void PauseTimer();

        /// <summary>
        /// Unpause timer
        /// </summary>
        void Unpause();
    }
}