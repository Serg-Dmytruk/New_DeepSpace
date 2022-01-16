using UnityEngine;
public class CharacterBehavior : MonoBehaviour
{
    private GameObject _selected;

    //���������� ���� ��� �� ���� ���  ���� ���� �� �� ������ ������ ������������
    private void Awake()
    {
        _selected = transform.Find("Selected").gameObject;
        _selected.SetActive(false);
    }

    //������ ���� �� ���������� ������� ���� ���� ������, ����������� � MouseBehavior
    public void SetSelectedVisible(bool visible)
    {
        _selected.SetActive(visible);
    }

    // ������ ����������� � MouseBehavior � ������ ��� ������������� �� ����������� �� IMove (MoveForce ���������), � ���� ����� �� GameObject
    public void MoveTo(Vector2 position)
    {
        GetComponent<IMove>().SetPosition(position);
    }
}
