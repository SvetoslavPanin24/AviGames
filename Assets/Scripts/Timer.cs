using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeRemaining; // ����� � ��������
    private bool timerIsRunning;

    [SerializeField] private TMP_Text timeText; // ������ �� ��������� ��������� ��� ����������� �������

    private void OnEnable()
    {
        EventBus.OnWin += StopTimer;
        EventBus.OnLose += StopTimer;
    }

    private void OnDisable()
    {
        EventBus.OnWin -= StopTimer;
        EventBus.OnLose -= StopTimer;
    }

    // ������������� �������
    private void Start()
    {
        StartTimer();
    }

    // ���������� �������
    private void Update()
    {
        if (!timerIsRunning) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeDisplay(timeRemaining);
        }
        else
        {
            EventBus.OnLose?.Invoke();
            StopTimer();
        }
    }

    // ����������� �������
    private void UpdateTimeDisplay(float timeToDisplay)
    {
        timeToDisplay += 1;
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = $"{minutes:00}:{seconds:00}";
    }

    // ���������� ��������
    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }

    // ���������� ������� � �������
    public void AddTime(float secondsToAdd)
    {
        if (timerIsRunning)
        {
            timeRemaining += secondsToAdd;
        }
    }
}
 
