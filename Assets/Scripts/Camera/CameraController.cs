using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField]
    public float _panSpeed = 20F;

    [SerializeField]
    public float panBorderThicness = 10F;

    Vector3 _position;

    void Update()
    {
        _position = transform.position;

        if (Input.mousePosition.y >= Screen.height - panBorderThicness)
            _position.y += _panSpeed * Time.deltaTime;

        if (Input.mousePosition.y <= panBorderThicness)
            _position.y -= _panSpeed * Time.deltaTime;

        if (Input.mousePosition.x >= Screen.width - panBorderThicness)
            _position.x += _panSpeed * Time.deltaTime;

        if (Input.mousePosition.x <= panBorderThicness)
            _position.x -= _panSpeed * Time.deltaTime;

        _position.x += Input.GetAxisRaw("Horizontal") * _panSpeed * Time.deltaTime;
        _position.y += Input.GetAxisRaw("Vertical") * _panSpeed * Time.deltaTime;

        transform.position = _position;

    }
}
