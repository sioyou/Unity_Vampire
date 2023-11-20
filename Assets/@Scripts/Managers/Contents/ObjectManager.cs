using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager 
{
    public PlayerController Player { get; private set; }
    public HashSet<MonsterController> Monsters { get; } = new HashSet<MonsterController>();
    public HashSet<ProjectileController> Projectile { get; } = new HashSet<ProjectileController>();
    public HashSet<GemController> Gems { get; } = new HashSet<GemController>();

    public T Spawn<T>(Vector3 position, int templateID = 0) where T : BaseController
    {
        System.Type type = typeof(T);

        if(type == typeof(PlayerController))
        {
            // TODO  : Data
            GameObject go = Managers.Resource.Instantiate("Slime_01.prefab", pooling: true);
            go.name = "Player";
            go.transform.position = position;

            PlayerController pc = go.GetOrAddComponent<PlayerController>();
            Player = pc;
            pc.Init();

            return pc as T;
        }
        else if(type == typeof(MonsterController))
        {
            // TODO  : Data
            string name = (templateID == 0 ? "Goblin_01" : "Snake_01") ;
            GameObject go = Managers.Resource.Instantiate(name + ".prefab", pooling: true);

            go.transform.position = position;
            MonsterController mc = go.GetOrAddComponent<MonsterController>();
            Monsters.Add(mc);
            mc.Init();

            return mc as T;
        }
        else if(type == typeof(GemController))
        {
            GameObject go = Managers.Resource.Instantiate(Define.EXP_GEM_PREFAB, pooling: true);
            go.transform.position = position;

            GemController gc = go.GetOrAddComponent<GemController>();
            Gems.Add(gc);
            gc.Init();

            string key = Random.Range(0, 2) == 0 ? "EXPGem_01.sprite" : "EXPGem_02.sprite";
            Sprite sprite = Managers.Resource.Load<Sprite>(key);
            go.GetComponent<SpriteRenderer>().sprite = sprite;

            // Temp
            GameObject.Find("@Grid").GetComponent<GridController>().Add(go);

            return gc as T;
        }

        return null;
    }

    public void Despanw<T>(T obj) where T : BaseController
    {
        System.Type type = typeof(T);

        if(type == typeof(PlayerController))
        {

        }
        else if(type == typeof(MonsterController))
        {
            Monsters.Remove(obj as MonsterController);
            Managers.Resource.Destroy(obj.gameObject);
        }
        else if(type == typeof(ProjectileController))
        {
            Projectile.Remove(obj as ProjectileController);
            Managers.Resource.Destroy(obj.gameObject);
        }
        else if(type == typeof(GemController))
        {
            Gems.Remove(obj as GemController);
            Managers.Resource.Destroy(obj.gameObject);

            // Temp
            GameObject.Find("@Grid").GetComponent<GridController>().Remove(obj.gameObject);
        }
    }
   
}
