using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehavior : MonoBehaviour
{
    //�������� ��������
    private CharacterBehavior _selectedCharacter;

    //������ ���������� ����� ����
    void Update()
    {
        MouseInput();
    }

    private void MouseInput()
    {
        //��� ���� ������� ����
        if (Input.GetMouseButtonDown(0)) //������� ��� ��������
        {
            _selectedCharacter?.SetSelectedVisible(false);
            _selectedCharacter = HitColider().collider?.GetComponent<CharacterBehavior>();
            _selectedCharacter?.SetSelectedVisible(true);
        }

        //��� ������ ������� ����
        if (Input.GetMouseButtonDown(1))//������� �� ������
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

    //���������� �� ������� ������ �� ���� �� ����� ���������� �������,
    //������� �������� ����� � ���� ������� �����
    private RaycastHit2D HitColider()
    {
        Vector2 raycastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return Physics2D.Raycast(raycastPosition, Vector2.zero);
    }
}
