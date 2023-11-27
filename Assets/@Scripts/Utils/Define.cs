using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define 
{
   public enum Scene
    {
        Unknown,
        DevScene,
        GameScene,
    }

    public enum Sound
    {
        Bgm,
        Effect,
    }

    public enum ObejctType
    {
        Player,
        Monster,
        Projectile,
        Env,
    }

    public enum SkillType
    {
        None,
        Melee,
        Projectile,
        Etc,
    }

    public enum StageType
    {
        Normal,
        Boss,
    }

    public enum CreatureState
    {
        Idle,
        Moving,
        Skill,
        Death,
    }

    public const int GOBLIN_ID = 1;
    public const int SNAKE_ID = 2;
    public const int BOSS_ID = 3;

    public const int PLAYER_DATA_IO = 1;
    public const string EXP_GEM_PREFAB = "EXPGem.prefab";

    public const int EGO_SWORD_ID = 10;
}
