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
    private AnimationPlayer _animation = new();

    private Rigidbody _rb = default;
    private Animator _anim = default;

    public PlayerAttack Attack => _attack;
    public PlayerHealth Health => _health;

    private void Start()
    {
        TryGetComponent(out _rb);
        TryGetComponent(out _anim);

        _movement.Init(_rb, _animation);
        _attack.Init(_animation);
        _health.Init(gameObject, _animation);
        _animation.Init(_anim);
    }

    private void Update()
    {
        _movement.Update();
        _attack.Update();
    }
}
