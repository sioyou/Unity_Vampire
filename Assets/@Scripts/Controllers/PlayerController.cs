using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 _moveDir = Vector2.zero;
    float _speed = 5f;

    public Vector2 MoveDir
    {
        get { return _moveDir; }
        set { _moveDir = value.normalized; }
    }

    void OnDestroy()
    {
        if(Managers.Game != null)
            Managers.Game.OnMoveDirChanged -= HandleOnMoveChanged;
    }

    void Start()
    {
        Managers.Game.OnMoveDirChanged -= HandleOnMoveChanged;
        Managers.Game.OnMoveDirChanged += HandleOnMoveChanged;
    }

    void HandleOnMoveChanged(Vector2 dir)
    {
        _moveDir = dir;
    }

    void Update()
    {
        //UpdateInput();
        MovePlayer();

    }

    // Simulator ������ �ȸ���
    void UpdateInput()
    {
        Vector2 moveDir = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            moveDir.y += 1;
        if (Input.GetKey(KeyCode.S))
            moveDir.y -= 1;
        if (Input.GetKey(KeyCode.A))
            moveDir.x -= 1;
        if (Input.GetKey(KeyCode.D))
            moveDir.x += 1;

        _moveDir = moveDir.normalized;
    }

    void MovePlayer()
    {
        //_moveDir = Managers.Game.MoveDir;
        Vector3 dir = _moveDir * _speed * Time.deltaTime;
        transform.position += dir;
    }

}
