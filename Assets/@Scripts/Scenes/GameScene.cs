using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    void Start()
    {

        Managers.Resource.LoadAllAsync<Object>("PreLoad", (key, count, totalCount) =>
        {
            Debug.Log($"{key}, {count}/{totalCount}");
            if(count == totalCount)
            {
                StartLoaded();
            }
        });

    }
    SpawningPool _spawningPool;
    
    void StartLoaded()
    {
        Managers.Data.Init();
        Managers.UI.ShowSceneUI<UI_GameScene>();

        _spawningPool = gameObject.AddComponent<SpawningPool>();

        var player = Managers.Object.Spawn<PlayerController>(Vector3.zero);

        for (int i = 0; i < 10; i++)
        {
            Vector3 randPos = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
            var mc = Managers.Object.Spawn<MonsterController>(randPos, Random.Range(0, 2));
        }

        var joystick = Managers.Resource.Instantiate("UI_Joystick.prefab");
        joystick.name = "@UI_Joystick";

        var map = Managers.Resource.Instantiate("Map.prefab");
        map.name = "@Map";
        Camera.main.GetComponent<CameraController>().target = player.gameObject;

        // Data Test
        foreach(var playerData in Managers.Data.PlayerDic.Values)
        {
            Debug.Log($"Lv : {playerData.level}, Hp : {playerData.maxHp}");
        }

        Managers.Game.OnGemCountChanged -= HandleOnGemCountChanged;
        Managers.Game.OnGemCountChanged += HandleOnGemCountChanged;
        Managers.Game.OnKillCountChanged += HandleOnKillCountChanged;
        Managers.Game.OnKillCountChanged += HandleOnKillCountChanged;
    }

    public void HandleOnKillCountChanged(int killCount)
    {
        Managers.UI.GetSceneUI<UI_GameScene>().SetKillCount(killCount);

        if(killCount == 5)
        {
            // Boss
        }

    }

    int _collectedGemCount = 0;
    int _remainingTotalGemCount = 10;
    public void HandleOnGemCountChanged(int gemCount)
    {
        _collectedGemCount++;

        if (_collectedGemCount == _remainingTotalGemCount)
        {
            Managers.UI.ShowPopup<UI_SkillSelectPopup>();
            _collectedGemCount = 0;
            _remainingTotalGemCount *= 2;
        }

        Managers.UI.GetSceneUI<UI_GameScene>().SetGemCountRatio((float)_collectedGemCount / _remainingTotalGemCount);
    }

    private void OnDestroy()
    {
        if (Managers.Game != null)
            Managers.Game.OnGemCountChanged -= HandleOnGemCountChanged;
    }

    void StartLoaded2()
    {
        var player = Managers.Resource.Instantiate("Slime_01.prefab");
        player.AddComponent<PlayerController>();

        var snake = Managers.Resource.Instantiate("Snake_01.prefab");
        var goblin = Managers.Resource.Instantiate("Gobline_01.prefab");
        var joystick = Managers.Resource.Instantiate("UI_Joystick.prefab");
        joystick.name = "@UI_Joystick";

        var map = Managers.Resource.Instantiate("Map.prefab");
        map.name = "@Map";
        Camera.main.GetComponent<CameraController>().target = player;

        //Managers.Resource.LoadAsync<GameObject>("Snake_01", (go) =>
        //{
        //    // TODO
        //});

        //_snake = GameObject.Instantiate(_snakePrefab);
        //_slime = GameObject.Instantiate(_slimePrefab);
        //_goblin = GameObject.Instantiate(_goblinPrefab);
        //_joystick = GameObject.Instantiate(_joystickPrefab);

        //GameObject go = new GameObject() { name = "@Monsters" };

        //_snake.transform.parent = go.transform;
        ////_slime.transform.parent = go.transform;
        //_goblin.transform.parent = go.transform;

        //_snake.name = _snakePrefab.name;
        //_slime.name = _slimePrefab.name;
        //_goblin.name = _goblinPrefab.name;
        //_joystick.name = "@UI_JoyStick";
        //_slime.AddComponent<PlayerController>();

        //Camera.main.GetComponent<CameraController>().target = _slime;
    }

    void Update()
    {
        
    }
}
