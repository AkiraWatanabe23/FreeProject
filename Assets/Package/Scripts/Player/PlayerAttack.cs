using System;
using UnityEngine;

[Serializable]
public class PlayerAttack
{
    [SerializeField]
    private int _attackValue = 1;
    [SerializeField]
    private Transform _muzzle = default;

    private Transform _transform = default;
    private AnimationPlayer _animation = default;

    public int AttackValue => _attackValue;

    public void Init(Transform transform, AnimationPlayer animation)
    {
        _transform = transform;
        _animation = animation;
    }

    public void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //左クリック（遠距離）
            LongDistance();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            //右クリック（近接）
            Proximity();
        }
    }

    /// <summary> 遠距離攻撃 </summary>
    private void LongDistance()
    {
        //エフェクト出すとかはここに書く
        _animation.ChangeAnimToAttackLongDistance();

        if (Physics.Raycast(_muzzle.position, _transform.forward, out RaycastHit hit, 10f))
        {
            if (hit.collider.gameObject.TryGetComponent(out EnemyController enemy))
            {
                enemy.Health.ReceiceDamage(_attackValue);
            }
        }
    }

    /// <summary> 近接攻撃 </summary>
    private void Proximity()
    {
        //ダメージ処理は武器のクラスに一任
        _animation.ChangeAnimToAttackProximity();
    }
}
