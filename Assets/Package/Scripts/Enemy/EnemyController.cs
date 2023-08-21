using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemyAttack _attack = new();
    [SerializeField]
    private EnemyHealth _health = new();
    [SerializeField]
    private AnimationPlayer _animation = new();

    private GameObject _player = default;
    private Animator _anim = default;

    public EnemyAttack Attack => _attack;
    public EnemyHealth Health => _health;

    private void Start()
    {
        _player = GameObject.Find("Player");
        TryGetComponent(out _anim);

        _attack.Init(_player, transform, _animation);
        _health.Init(gameObject, _animation);
        _animation.Init(_anim);
    }

    private void Update()
    {
        _attack.Update();
    }
}
