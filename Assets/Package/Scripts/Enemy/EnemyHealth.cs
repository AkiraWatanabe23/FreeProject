using System;
using UnityEngine;

[Serializable]
public class EnemyHealth : IDamage
{
    [SerializeField]
    private int _hp = 1;

    private GameObject _enemy = default;
    private AnimationPlayer _animation = default;

    public void Init(GameObject enemy, AnimationPlayer animation)
    {
        _enemy = enemy;
        _animation = animation;
    }

    public void ReceiceDamage(int value)
    {
        _hp -= value;
        _animation.ChangeAnimation("Damage");

        if (_hp <= 0)
        {
            _animation.ChangeAnimation("Death");
            _enemy.SetActive(false);
        }
    }
}
