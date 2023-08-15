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
        _attavkValue = FindObjectOfType<PlayerController>().Attack.AttackValue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out EnemyController enemy))
        {
            enemy.Health.ReceiceDamage(_attavkValue);
        }
    }
}
