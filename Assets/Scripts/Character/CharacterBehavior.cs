using UnityEngine;
public class CharacterBehavior : MonoBehaviour
{
    private GameObject _selected;

    //Визивається один раз за весь час  після того як всі обєктии будуть інінціалізовані
    private void Awake()
    {
        _selected = transform.Find("Selected").gameObject;
        _selected.SetActive(false);
    }

    //Робить коло під персонажем видимим якщо його обрали, викликається в MouseBehavior
    public void SetSelectedVisible(bool visible)
    {
        _selected.SetActive(visible);
    }

    // отримує коокрдинати в MouseBehavior і передає тим компоненентам які наслідуються від IMove (MoveForce наприклад), і вони додані до GameObject
    public void MoveTo(Vector2 position)
    {
        GetComponent<IMove>().SetPosition(position);
    }
}
