using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class WanderingRange : MonoBehaviour
{
    [SerializeField]
    private GameObject _player = default;
    [SerializeField]
    private EnemyController[] _enemies = default;
    [Tooltip("徘徊地点生成円の半径")]
    [Range(1f, 50f)]
    [SerializeField]
    private float _radius = 10f;

    private void Awake()
    {
        ColliderSetting();
        foreach (var enemy in _enemies) { enemy.Init(_player); }
    }

    private void ColliderSetting()
    {
        var posCollider = GetComponent<SphereCollider>();

        posCollider.radius = _radius;
        posCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            foreach (var enemy in _enemies) { enemy.Attack.AttackSwitch(); }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            foreach (var enemy in _enemies) { enemy.Attack.AttackSwitch(); }
        }
    }
}