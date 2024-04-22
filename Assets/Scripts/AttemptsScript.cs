using TMPro;
using UnityEngine;

public class AttemptsScript : MonoBehaviour
{
    [SerializeField] private TMP_Text attemptsText;

    private void OnEnable()
    {
        EventBus.OnDataLoaded += UpdateAttempsText;
    }

    private void OnDisable()
    {
        EventBus.OnDataLoaded -= UpdateAttempsText;
    }

    private void UpdateAttempsText()
    {
        attemptsText.text = "Attempts: " + DataManager.Instance.GetAttemptsCount().ToString();
    }
}
