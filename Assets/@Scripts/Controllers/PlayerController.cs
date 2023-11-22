using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : CreatureController
{
    Vector2 _moveDir = Vector2.zero;

    float EnvCollectDist { get; set; } = 1.0f;

    [SerializeField]
    Transform _indicator;
    [SerializeField]
    Transform _fireSocket;

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

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _speed = 5.0f;
        Managers.Game.OnMoveDirChanged -= HandleOnMoveChanged;
        Managers.Game.OnMoveDirChanged += HandleOnMoveChanged;

        StartProjectile();

        return true;
    }

    void HandleOnMoveChanged(Vector2 dir)
    {
        _moveDir = dir;
    }

    void Update()
    {
        //UpdateInput();
        MovePlayer();
        CollectEnv();
    }

    // Simulator ¿¡¼­´Â ¾È¸ÔÈû
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

        if(_moveDir != Vector2.zero)
        {
            _indicator.eulerAngles = new Vector3(0, 0, Mathf.Atan2(-dir.x, dir.y) * 180 / Mathf.PI);
        }

        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    void CollectEnv()
    {
        float sqrCollectDist = EnvCollectDist * EnvCollectDist;

        List<GemController> gems =  Managers.Object.Gems.ToList();
        foreach(GemController gem in gems)
        {
            Vector3 dir = gem.transform.position - transform.position;
            if(dir.sqrMagnitude <= sqrCollectDist)
            {
                Managers.Game.Gem += 1;
                Managers.Object.Despawn(gem);
            }
        }

        var findGems = GameObject.Find("@Grid").GetComponent<GridController>().GatherObject(transform.position, EnvCollectDist + 0.5f);

        Debug.Log($"SearchGems({findGems.Count}, TotalGems({gems.Count})");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MonsterController target = collision.gameObject.GetComponent<MonsterController>();
        if (target == null)
            return;
    }

    public override void OnDamage(BaseController attacker, int damage)
    {
        base.OnDamage(attacker, damage);

        //Debug.Log($"OnDamaged ! {Hp}");

        // Temp
        CreatureController cc = attacker as CreatureController;
        cc?.OnDamage(this, 10000);
    }

    // Temp
    #region FireProjectile
    Coroutine _coFireProjectile;
    
    void StartProjectile()
    {
        if (_coFireProjectile != null)
            StopCoroutine(_coFireProjectile);
        _coFireProjectile = StartCoroutine(CoStartProjectile());
    }

    IEnumerator CoStartProjectile()
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f);

        while(true)
        {
            ProjectileController pc = Managers.Object.Spawn<ProjectileController>(_fireSocket.position, 1);
            pc.SetInfo(1, this, (_fireSocket.position - _indicator.position).normalized);

            yield return wait;
        }
    }

    #endregion
}
