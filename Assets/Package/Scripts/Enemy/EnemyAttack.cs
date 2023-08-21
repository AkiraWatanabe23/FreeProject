using DG.Tweening;
using UnityEngine;

[System.Serializable]
public class EnemyAttack
{
    [SerializeField]
    private EnemyType _enemyType = EnemyType.LongDistance;
    [SerializeField]
    private int _attackValue = 1;
    [SerializeField]
    private Transform _muzzle = default;
    [SerializeField]
    private GameObject _bulletPrefab = default;
    [Tooltip("弾速")]
    [SerializeField]
    private float _bulletSpeed = 1f;
    [Tooltip("何秒かけて特定の位置に移動するか")]
    [SerializeField]
    private float _moveSecond = 1f;

    private GameObject _player = default;
    private Transform _transform = default;
    private AnimationPlayer _animation = default;
    private bool _isAttack = false;

    public int AttackValue => _attackValue;

    public void Init(GameObject player, Transform transform, AnimationPlayer animation)
    {
        _player = player;
        _transform = transform;
        _animation = animation;
    }

    public void Update()
    {
        if (_isAttack) { Attack(); }
    }

    public void Attack()
    {
        if (_enemyType == EnemyType.LongDistance) { LongDistance(); }
        else if (_enemyType == EnemyType.Proximity) { Proximity(); }

        _isAttack = false;
    }

    private void LongDistance()
    {
        var lookDirection = _player.transform.position - _transform.position;
        _transform.rotation = Quaternion.LookRotation(lookDirection);

        _animation.ChangeAnimToAttackLongDistance();

        var bullet = Object.Instantiate(_bulletPrefab, _muzzle.position, _muzzle.rotation);
        var rb =  bullet.AddComponent<Rigidbody>();

        rb.useGravity = false;
        rb.velocity = bullet.transform.forward * _bulletSpeed;
    }

    private void Proximity()
    {
        var movePosition = _player.transform.position;

        _transform.DOMove(movePosition, _moveSecond);

        //ここで攻撃Animation
        _animation.ChangeAnimToAttackProximity();
    }

    public void AttackSwitch()
    {
        _isAttack = !_isAttack;
    }
}

public enum EnemyType
{
    /// <summary> 遠距離 </summary>
    LongDistance,
    /// <summary> 近接 </summary>
    Proximity,
}
