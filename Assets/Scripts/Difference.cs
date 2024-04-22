using UnityEngine;

public class Difference : MonoBehaviour
{
    public int differenceID;
    public bool isFound = false; 

    // Метод для вызова при нажатии на отличие
    public void OnDifferenceClicked()
    {
        if (!isFound)
        {
            isFound = true;
            // Уведомляем LevelManager о найденном отличии
            LevelManager.Instance.OnDifferenceFound(differenceID);
        }
    }
}
