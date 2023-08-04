using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemyHealth _health = new();

    public EnemyHealth Health => _health;
}
