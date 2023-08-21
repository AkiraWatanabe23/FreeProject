using UnityEngine;

public class AttackRange : MonoBehaviour
{
    private EnemyController _enemy = default;
    private Collider _collider = default;

    private void Start()
    {
        _enemy = GetComponentInParent<EnemyController>();
        TryGetComponent(out _collider);

        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player)) { _enemy.Attack.AttackSwitch(); }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player)) { _enemy.Attack.AttackSwitch(); }
    }
}
