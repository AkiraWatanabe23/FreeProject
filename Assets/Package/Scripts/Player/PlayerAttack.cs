using UnityEngine;

[System.Serializable]
public class PlayerAttack
{
    [SerializeField]
    private int _attackValue = 1;
    [SerializeField]
    private Transform _muzzle = default;
    [SerializeField]
    private GameObject _bulletPrefab = default;
    [Tooltip("弾速")]
    [SerializeField]
    private float _bulletSpeed = 1f;

    private AnimationPlayer _animation = default;

    public int AttackValue => _attackValue;

    public void Init(AnimationPlayer animation)
    {
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
        _animation.ChangeAnimation("LongDistance");

        Debug.Log("遠距離攻撃");
        var bullet = Object.Instantiate(_bulletPrefab, _muzzle.position, _muzzle.rotation);
        var rb = bullet.AddComponent<Rigidbody>();

        rb.useGravity = false;
        rb.velocity = bullet.transform.forward * _bulletSpeed;
    }

    /// <summary> 近接攻撃 </summary>
    private void Proximity()
    {
        //ダメージ処理は武器のクラスに一任
        _animation.ChangeAnimation("Proximity");
    }
}
