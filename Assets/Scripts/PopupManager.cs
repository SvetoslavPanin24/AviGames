using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private GameObject winPopup;
    [SerializeField] private GameObject losePopup;
    [SerializeField] private GameObject antiClicker;

    private void OnEnable()
    {
        EventBus.OnWin += ShowWinPopup;
        EventBus.OnLose += ShowLosePopup;
    }

    private void OnDisable()
    {
        EventBus.OnWin -= ShowWinPopup;
        EventBus.OnLose -= ShowLosePopup;
    }

    private void ShowWinPopup()
    {
        antiClicker.SetActive(true);
        winPopup.SetActive(true);
    }

    private void ShowLosePopup()
    {
        antiClicker.SetActive(true);
        losePopup.SetActive(true);
    }

    public void RestartLevel()
    {
        DataManager.Instance.AttemptToIncrement();
        DataManager.Instance.SaveData();

        AppodealManager.instance.ShowRewardedAds();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);        
    }
}