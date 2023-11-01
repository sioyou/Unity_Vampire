using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    GameObject _snake;
    GameObject _slime;
    GameObject _goblin;
    GameObject _joystick;

    void Start()
    {
        //Resources.Load<GameObject>("Prefabs/Snake_01");

        Managers.Resource.LoadAllAsync<GameObject>("Prefabs", (key, count, totalCount) =>
        {
            Debug.Log($"{key}, {count}/{totalCount}");
            if(count == totalCount)
            {
                StartLoaded();
            }
        });

    }
    
    void StartLoaded()
    {
        GameObject prefab = Managers.Resource.Load<GameObject>("Slime_01.prefab");
        GameObject go = new GameObject() { name = "@Monsters" };
        _slime = Managers.Resource.Instantiate("Slime_01.prefab", go.transform);
        Camera.main.GetComponent<CameraController>().target = _slime;

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
