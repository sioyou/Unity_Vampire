using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager 
{
    public PlayerController Player { get; private set; }
    public HashSet<MonsterController> Monsters { get; } = new HashSet<MonsterController>();
    public HashSet<ProjectileController> Projectile { get; } = new HashSet<ProjectileController>();

    public T Spawn<T>(int templateID = 0) where T : BaseController
    {
        System.Type type = typeof(T);

        if(type == typeof(PlayerController))
        {
            // TODO  : Data
            GameObject go = Managers.Resource.Instantiate("Slime_01.prefab", pooing: true);
            go.name = "Player";

            PlayerController pc = go.GetOrAddComponent<PlayerController>();
            Player = pc;
            return pc as T;
        }
        else if(type == typeof(MonsterController))
        {
            // TODO  : Data
            string name = (templateID == 0 ? "Goblin_01" : "Snake_01") ;
            GameObject go = Managers.Resource.Instantiate(name + ".prefab", pooing: true);

            MonsterController mc = go.GetOrAddComponent<MonsterController>();
            Monsters.Add(mc);
            return mc as T;
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

    }
   
}
