using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    void Start()
    {
        //Resources.Load<GameObject>("Prefabs/Snake_01");

        Managers.Resource.LoadAllAsync<GameObject>("Prefabs", (key, count, totalCount) =>
        {
            //Debug.Log($"{key}, {count}/{totalCount}");
            if(count == totalCount)
            {
                StartLoaded();
            }
        });

    }
    SpawningPool _spawningPool;
    
    void StartLoaded()
    {
        _spawningPool = gameObject.AddComponent<SpawningPool>();

        var player = Managers.Object.Spawn<PlayerController>();

        for (int i = 0; i < 10; i++)
        {
            var mc = Managers.Object.Spawn<MonsterController>(Random.Range(0, 2));
            mc.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        }

        var joystick = Managers.Resource.Instantiate("UI_Joystick.prefab");
        joystick.name = "@UI_Joystick";

        var map = Managers.Resource.Instantiate("Map.prefab");
        map.name = "@Map";
        Camera.main.GetComponent<CameraController>().target = player.gameObject;
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
