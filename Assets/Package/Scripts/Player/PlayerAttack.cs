using System;
using UnityEngine;

[Serializable]
public class PlayerAttack
{
    [SerializeField]
    private int _attackValue = 1;
    [SerializeField]
    private Transform _raycastPos = default;

    private Transform _transform = default;

    public void Init(Transform transform)
    {
        _transform = transform;
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

    private void LongDistance()
    {
        //エフェクト出すとかはここに書く

        if (Physics.Raycast(_raycastPos.position, _transform.forward, out RaycastHit hit, 10f))
        {
            if (hit.collider.gameObject.TryGetComponent(out EnemyController enemy))
            {
                enemy.Health.ReceiceDamage(_attackValue);
            }
        }
    }

    private void Proximity()
    {

    }
}
