using UnityEngine;

public class ClickManager : MonoBehaviour
{
    void Update()
    {
        // ��������� ���� �� �������
        if (Input.touchCount > 0)
        {
            // �������� ������ �������
            Touch touch = Input.GetTouch(0);

            // ��������� ���� �������
            if (touch.phase == TouchPhase.Began)
            {
                // ������� ��� �� ������ ����� ����� �������
                Vector2 rayStart = Camera.main.ScreenToWorldPoint(touch.position);

                RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector2.zero);
                if (hit.collider != null)
                {
                    // �������� ������, �� ������� ���� ����������� �������
                    GameObject touchedObject = hit.transform.gameObject;
             
                    Difference difference = touchedObject.GetComponent<Difference>();
                    if (difference != null)
                    {                       
                        difference.OnDifferenceClicked();
                    }
                }
            }
        }
    }
}
