using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

namespace Data
{
    //#region PlayerDataJson
    //[SerializeField]
    //public class PlayerData
    //{
    //    public int level;
    //    public int maxHp;
    //    public int attack;
    //    public int totalExp;
    //}

    //[SerializeField]
    //public class PlayerDtaLoader : ILoader<int, PlayerData>
    //{
    //    public List<PlayerData> stats = new List<PlayerData>();

    //    public Dictionary<int, PlayerData> MakeDict()
    //    {
    //        Dictionary<int, PlayerData> dict = new Dictionary<int, PlayerData>();
    //        foreach (PlayerData stat in stats)
    //        {
    //            dict.Add(stat.level, stat);
    //        }

    //        return dict;
    //    }

    //}
    //#endregion

    #region PlayerDataXML
    public class PlayerData
    {
        [XmlAttribute]
        public int level;
        [XmlAttribute]
        public int maxHp;
        [XmlAttribute]
        public int attack;
        [XmlAttribute]
        public int totalExp;
    }

    [Serializable, XmlRoot("PlayerDatas")]
    public class PlayerDataLoader : ILoader<int, PlayerData>
    {
        [XmlElement("PlayerData")]
        public List<PlayerData> stats = new List<PlayerData>();

        public Dictionary<int, PlayerData> MakeDict()
        {
            Dictionary<int, PlayerData> dict = new Dictionary<int, PlayerData>();
            foreach (PlayerData stat in stats)
                dict.Add(stat.level, stat);
            return dict;
        }
    }
    #endregion

    #region MonsterData
    public class MonsterData
    {
        [XmlAttribute]
        public string name;
        [XmlAttribute]
        public string prefab;
        [XmlAttribute]
        public int level;
        [XmlAttribute]
        public int maxHp;
        [XmlAttribute]
        public int attack;
        [XmlAttribute]
        public float speed;
        // DropData
        // - 일정 확률로
        // - 어떤 아이템을 (보석, 스킬 가차, 골드, 고기)
        // - 몇 개 드랍할지?
    }
    #endregion

    #region SkillData
    public class SkillData
    {
        [XmlAttribute]
        public int templateID;

        [XmlAttribute(AttributeName = "type")]
        //public string skillTypeStr;
        public Define.SkillType skillType = Define.SkillType.None;

        [XmlAttribute]
        public int nextID;
        public int prevID = 0;  // TODO

        [XmlAttribute]
        public string prefab;

        // 아주 많이
        [XmlAttribute]
        public int damage;

    }

    [Serializable, XmlRoot("SkillDatas")]
    public class SkillDataLoader : ILoader<int, SkillData>
    {
        [XmlElement("SkillData")]
        public List<SkillData> skills = new List<SkillData>();

        public Dictionary<int, SkillData> MakeDict()
        {
            Dictionary<int, SkillData> dict = new Dictionary<int, SkillData>();
            foreach (SkillData skill in skills)
                dict.Add(skill.templateID, skill);
            return dict;
        }
    }

    #endregion
}