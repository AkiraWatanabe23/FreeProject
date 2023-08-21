using UnityEngine;

/// <summary> 近接用のオブジェクトにつけるクラス </summary>
public class Weapon : MonoBehaviour
{
    //想定としてはAnimationで近接武器のCollider切り替えを行う
    private Collider _collider = default;
    private int _attavkValue = 0;

    private void Start()
    {
        TryGetComponent(out _collider);
        _collider.isTrigger = true;
        _collider.enabled = false;

        if (gameObject.transform.parent.gameObject.TryGetComponent(out PlayerController player))
        {
            _attavkValue = player.Attack.AttackValue;
        }
        else if (gameObject.transform.parent.gameObject.TryGetComponent(out EnemyController enemy))
        {
            _attavkValue = enemy.Attack.AttackValue;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out EnemyController enemy) &&
            gameObject.transform.parent.gameObject.TryGetComponent(out PlayerController playerObj))
        {
            enemy.Health.ReceiceDamage(_attavkValue);
        }
        else if (other.gameObject.TryGetComponent(out PlayerController player) &&
            gameObject.transform.parent.gameObject.TryGetComponent(out EnemyController enemyObj))
        {
            player.Health.ReceiceDamage(_attavkValue);
        }
    }
}
