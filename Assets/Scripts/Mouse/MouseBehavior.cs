using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehavior : MonoBehaviour
{
    //вибраний персонаж
    private CharacterBehavior _selectedCharacter;

    //Апдейт визивається кожен кадр
    void Update()
    {
        MouseInput();
    }

    private void MouseInput()
    {
        //Клік лівой кнопкой мишкі
        if (Input.GetMouseButtonDown(0)) //Вибрати або звільнити
        {
            _selectedCharacter?.SetSelectedVisible(false);
            _selectedCharacter = HitColider().collider?.GetComponent<CharacterBehavior>();
            _selectedCharacter?.SetSelectedVisible(true);
        }

        //Клік правой кнопкой мишкі
        if (Input.GetMouseButtonDown(1))//зробити що небуть
        {
            RaycastHit2D hit = HitColider();

            if (hit.collider == null)
            {
                if (_selectedCharacter != null)
                {
                    _selectedCharacter?.MoveTo(Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, 0)));
                }
                else
                {
                    Debug.Log("Character NOT selected"); //Debug.Log(hit.collider.gameObject.name);
                }
            }
        }
    }

    //Взалежності від позиції камери на місце де мишка опускається рейкаст,
    //повертає колайдер обєкта в який рейкаст попав
    private RaycastHit2D HitColider()
    {
        Vector2 raycastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return Physics2D.Raycast(raycastPosition, Vector2.zero);
    }
}
