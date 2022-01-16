using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(BaseAnimator))]
public class MoveForce : MonoBehaviour, IMove
{
    [SerializeField]
    private float _speed; //Швидкість руху

    [SerializeField]
    private float _maxSpeed; // Максимальна швидкість

    [SerializeField]
    private float _availableDifferenceX = 0.15F; //Різниця у відстані між координатами мишкі та персонажа по іксу, після якої почнеться тормозіння

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
        //Обертання відображення спрайта по х
        if (_rigidbody2D.velocity.x < 0)
            _spriteRenderer.flipX = true;
        else if (_rigidbody2D.velocity.x > 0)
            _spriteRenderer.flipX = false;

        //Якщо різниця між векторами менша допустимої тормозим
        if (Mathf.Abs(_position.x - transform.position.x) <= _availableDifferenceX)
        {
            _rigidbody2D.AddForce(Vector2.zero);
        }
        else if (Mathf.Abs(_rigidbody2D.velocity.x) <= _maxSpeed) //Добавляєм силу поштовху для руху якшо швидкість менша допустимої
        {
            if (_position.x > transform.position.x) //Вправо
                _rigidbody2D.AddForce(Vector2.right * _speed);
            else if (_position.x < transform.position.x)//Вліво
                _rigidbody2D.AddForce(Vector2.left * _speed);
        }

        _baseAnimator.Run(Mathf.Abs(_rigidbody2D.velocity.x));
    }

    public void SetPosition(Vector2 position) //Позиція до якої рухатись задається в CharacterBehavior
    {
        _position = position;
    }
}
