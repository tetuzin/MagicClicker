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
    public class CharacterDao : BaseDao<CharacterModel>
    {
        // ID検索
        public CharacterModel GetModelById(int id)
        {
            foreach (CharacterModel model in Get())
            {
                if (model.CharacterId == id) return model;
            }
            return null;
        }
    }
    public class CharacterDetailsDao : BaseDao<CharacterDetailsModel>{}

    // 装備
    public class EquipmentDao : BaseDao<EquipmentModel>
    {
        // ID検索
        public EquipmentModel GetModelById(int id)
        {
            foreach (EquipmentModel model in Get())
            {
                if (model.EquipmentId == id) return model;
            }
            return null;
        }
    }
    public class EquipmentGroupDao : BaseDao<EquipmentGroupModel>
    {
        // ID検索
        public EquipmentGroupModel GetModelById(int id)
        {
            foreach (EquipmentGroupModel model in Get())
            {
                if (model.EquipmentGroupId == id) return model;
            }
            return null;
        }
    }

    // 魔法
    public class MagicDao : BaseDao<MagicModel>{}

    // スキル
    public class SkillDao : BaseDao<SkillModel>
    {
        // ID検索
        public SkillModel GetModelById(int id)
        {
            foreach (SkillModel model in Get())
            {
                if (model.SkillId == id) return model;
            }
            return null;
        }
    }
    public class SkillEffectGroupDao : BaseDao<SkillEffectGroupModel>{}
    public class SkillEffectDao : BaseDao<SkillEffectModel>{}
}

