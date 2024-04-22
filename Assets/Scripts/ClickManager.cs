using UnityEngine;

public class ClickManager : MonoBehaviour
{
    void Update()
    {
        // Проверяем есть ли касания
        if (Input.touchCount > 0)
        {
            // Получаем первое касание
            Touch touch = Input.GetTouch(0);

            // Проверяем фазу касания
            if (touch.phase == TouchPhase.Began)
            {
                // Создаем луч из камеры через точку касания
                Vector2 rayStart = Camera.main.ScreenToWorldPoint(touch.position);

                RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector2.zero);
                if (hit.collider != null)
                {
                    // Получаем объект, на который было произведено касание
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
