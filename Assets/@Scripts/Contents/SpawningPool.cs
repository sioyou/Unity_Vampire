using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
    // ������ �ֱ��?
    // ���� �ִ� ������?
    // ����?
    float _spawnInterval = 0.1f;
    int _maxMonsterCount = 100;
    Coroutine _coUpdateSpawningPool;

    public bool Stopped { get; set; } = false;

    void Start()
    {
        _coUpdateSpawningPool = StartCoroutine(CoUpdateSpwaningPool());
    }

    IEnumerator CoUpdateSpwaningPool()
    {
        while(true)
        {
            TrySpawn();
            yield return new WaitForSeconds(_spawnInterval);
        }

    }

    void TrySpawn()
    {
        if (Stopped)
            return;
        int monsterCount = Managers.Object.Monsters.Count;
        if (monsterCount >= _maxMonsterCount)
            return;

        // TEMP : DataID?
        Vector3 randPos = Utils.GenerateMonsterSpawnPosition(Managers.Game.Player.transform.position, 10, 15);
        MonsterController mc = Managers.Object.Spawn<MonsterController>(randPos, 1 + Random.Range(0, 2));
    }

    void Update()
    {
        
    }
}
