using DG.Tweening;
using System;
using UnityEngine;

[Serializable]
public class EnemyAttack
{
    [SerializeField]
    private EnemyType _enemyType = EnemyType.LongDistance;
    [SerializeField]
    private Transform _muzzle = default;
    [SerializeField]
    private int _attackValue = 1;
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
        if (Physics.Raycast(_muzzle.position, _transform.forward, out RaycastHit hit, 10f))
        {
            if (hit.collider.gameObject.TryGetComponent(out PlayerController player))
            {
                player.Health.ReceiceDamage(_attackValue);
                AttackSwitch();
            }
        }
        else
        {
            Debug.Log("当たらなかった");
        }
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
