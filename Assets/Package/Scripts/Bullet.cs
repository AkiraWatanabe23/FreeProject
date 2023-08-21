using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int _attackValue = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            player.Health.ReceiceDamage(_attackValue);
        }
        else if (collision.gameObject.TryGetComponent(out EnemyController enemy))
        {
            enemy.Health.ReceiceDamage(_attackValue);
        }
    }
}
