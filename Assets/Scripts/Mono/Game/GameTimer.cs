using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public event Action OnTimerCompleted;

    [SerializeField] private TMP_Text _timerText;

    private Coroutine _timerCoroutine;
    private float _remainingTime;

    public void StartTimer(float duration)
    {
        if (_timerCoroutine != null)
        {
            StopTimer();
        }

        _remainingTime = duration;
        _timerCoroutine = StartCoroutine(TimerCoroutine(duration));
    }

    public void StopTimer()
    {
        StopCoroutine(_timerCoroutine);
        _timerCoroutine = null;
    }

    private IEnumerator TimerCoroutine(float duration)
    {
        _remainingTime = duration;
        
        while (_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;
            UpdateTimerText(_remainingTime);
            yield return null;
        }

        _remainingTime = 0;
        _timerCoroutine = null;

        UpdateTimerText(_remainingTime);
        OnTimerCompleted?.Invoke();
    }

    private void UpdateTimerText(float time)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        _timerText.text = $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
    }

    public bool IsTimerRunning()
    {
        return _timerCoroutine != null;
    }

    public float GetTimeRemaining()
    {
        return _remainingTime;
    }
}
