using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicClicker.Const
{
    public class MCConst
    {
        public const string DAO_NAME_CHARACTER = "CharacterDao";
        public const string DAO_NAME_CHARACTER_DETAILS = "CharacterDetailsDao";
        public const string DAO_NAME_EQUIPMENT = "EquipmentDao";
        public const string DAO_NAME_EQUIPMENT_GROUP = "EquipmentGroupDao";
        public const string DAO_NAME_MAGIC = "MagicDao";
        public const string DAO_NAME_SKILL = "SkillDao";
        public const string DAO_NAME_SKILL_EFFECT = "SkillEffectDao";
        public const string DAO_NAME_SKILL_EFFECT_GROUP = "SkillEffectGroupDao";

        // キャラクターが習得できるスキルの数
        public const int CHARACTER_SKILL_COUNT = 3;

        // 装備種名
        public const string EQUIPMENT_KIND_NECKLACE = "ネックレス";
        public const string EQUIPMENT_KIND_CANE = "杖";
        public const string EQUIPMENT_KIND_RING = "指輪";
        public const string EQUIPMENT_KIND_BANGLE = "腕輪";
        public const string EQUIPMENT_KIND_EARRINGS = "イヤリング";
    }
}

