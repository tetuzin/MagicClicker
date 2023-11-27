using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Dao;

using MagicClicker.Model.Character;
using MagicClicker.Model.Equipment;
using MagicClicker.Model.Magic;
using MagicClicker.Model.Skill;

namespace MagicClicker.Dao
{
    public class MCDao : MonoBehaviour{}

    // キャラクター
    public class CharacterDao : BaseDao<CharacterModel>{}
    public class CharacterDetailsDao : BaseDao<CharacterDetailsModel>{}

    // 装備
    public class EquipmentDao : BaseDao<EquipmentModel>{}
    public class EquipmentGroupDao : BaseDao<EquipmentGroupModel>{}

    // 魔法
    public class MagicDao : BaseDao<MagicModel>{}

    // スキル
    public class SkillDao : BaseDao<SkillModel>{}
    public class SkillEffectGroupDao : BaseDao<SkillEffectGroupModel>{}
    public class SkillEffectDao : BaseDao<SkillEffectModel>{}
}

