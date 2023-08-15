using System;
using UnityEngine;

[Serializable]
public class PlayerMove
{
    [SerializeField]
    private float _moveSpeed = 1f;
    [SerializeField]
    private float _rotateSpeed = 1f;

    private Rigidbody _rb = default;
    private PlayerAnimation _animation = default;

    public void Init(Rigidbody rigidbody, PlayerAnimation animation)
    {
        _rb = rigidbody;
        _animation = animation;
    }

    public void Update()
    {
        Move(new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")));
    }

    private void Move(Vector3 input)
    {
        if (input != Vector3.zero)
        {
            var rot = Quaternion.LookRotation(input);
            _rb.rotation = rot;
            //回転を滑らかにしたいなーと思ったら以下をアンコメントしてください
            //_rb.rotation = Quaternion.Lerp(_rb.rotation, rot, _rotateSpeed * Time.deltaTime);

            input.y = _rb.velocity.y;
            _rb.velocity = input * _moveSpeed;

            _animation.ChangeAnimToMove();
        }
        else
        {
            _animation.ChangeAnimToIdle();
        }
    }
}
