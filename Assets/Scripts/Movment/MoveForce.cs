using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(BaseAnimator))]
public class MoveForce : MonoBehaviour, IMove
{
    [SerializeField]
    private float _speed; //�������� ����

    [SerializeField]
    private float _maxSpeed; // ����������� ��������

    [SerializeField]
    private float _availableDifferenceX = 0.15F; //г����� � ������ �� ������������ ���� �� ��������� �� ����, ���� ��� ��������� ���������

    private Vector2 _position;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private BaseAnimator _baseAnimator;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _baseAnimator = GetComponent<BaseAnimator>();
        _position = new Vector2(transform.position.x, 0);
    }

    private void FixedUpdate()
    {
        //��������� ����������� ������� �� �
        if (_rigidbody2D.velocity.x < 0)
            _spriteRenderer.flipX = true;
        else if (_rigidbody2D.velocity.x > 0)
            _spriteRenderer.flipX = false;

        //���� ������ �� ��������� ����� ��������� ��������
        if (Mathf.Abs(_position.x - transform.position.x) <= _availableDifferenceX)
        {
            _rigidbody2D.AddForce(Vector2.zero);
        }
        else if (Mathf.Abs(_rigidbody2D.velocity.x) <= _maxSpeed) //��������� ���� �������� ��� ���� ���� �������� ����� ���������
        {
            if (_position.x > transform.position.x) //������
                _rigidbody2D.AddForce(Vector2.right * _speed);
            else if (_position.x < transform.position.x)//����
                _rigidbody2D.AddForce(Vector2.left * _speed);
        }

        _baseAnimator.Run(Mathf.Abs(_rigidbody2D.velocity.x));
    }

    public void SetPosition(Vector2 position) //������� �� ��� �������� �������� � CharacterBehavior
    {
        _position = position;
    }
}
