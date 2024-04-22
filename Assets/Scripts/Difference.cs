using UnityEngine;

public class Difference : MonoBehaviour
{
    public int differenceID;
    public bool isFound = false; 

    // ����� ��� ������ ��� ������� �� �������
    public void OnDifferenceClicked()
    {
        if (!isFound)
        {
            isFound = true;
            // ���������� LevelManager � ��������� �������
            LevelManager.Instance.OnDifferenceFound(differenceID);
        }
    }
}
