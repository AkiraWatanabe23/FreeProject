using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int _attackValue = 1;

    private float _timer = 0f;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= 5f)
        {
            Destroy(gameObject);
        }
    }

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
