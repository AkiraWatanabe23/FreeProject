using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerMove _movement = new();
    [SerializeField]
    private PlayerAttack _attack = new();
    [SerializeField]
    private PlayerHealth _health = new();
    [SerializeField]
    private PlayerAnimation _animation = new();

    private Rigidbody _rb = default;
    private Animator _anim = default;

    public PlayerMove Movement => _movement;
    public PlayerAttack Attack => _attack;
    public PlayerHealth Health => _health;
    public PlayerAnimation Animation => _animation;
    public Rigidbody Rigidbody => _rb;

    private void Start()
    {
        TryGetComponent(out _rb);
        TryGetComponent(out _anim);

        _movement.Init(_rb);
        _attack.Init(transform);
        _health.Init(gameObject);
        _animation.Init(_anim);
    }

    private void Update()
    {
        _movement.Update();
        _attack.Update();
    }
}
