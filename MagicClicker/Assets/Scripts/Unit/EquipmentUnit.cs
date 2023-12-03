using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Manager.Game;

using MagicClicker.Dao;
using MagicClicker.Const;
using MagicClicker.Model.Equipment;
using MagicClicker.Model.Skill;

namespace MagicClicker.Unit.Equipment
{
    [Serializable]
    public class EquipmentUnit
    {   
        // 装備ID
        [SerializeField] public int EquipmentId { get; set; }
        // 装備レベル
        [SerializeField] public int Level { get; set; }
        // お気に入りフラグ
        [SerializeField] public bool FavoriteFlag { get; set; }

        // EquipmentModelを取得
        public EquipmentModel GetEquipmentModel()
        {
            EquipmentDao dao = (EquipmentDao)GameManager.Instance.masterManager.GetDao(MCConst.DAO_NAME_EQUIPMENT);
            return dao.GetModelById(EquipmentId);
        }

        // EquipmentGroupModelを取得
        public EquipmentGroupModel GetEquipmentGroupModel()
        {
            EquipmentGroupDao dao = (EquipmentGroupDao)GameManager.Instance.masterManager.GetDao(MCConst.DAO_NAME_EQUIPMENT_GROUP);
            return dao.GetModelById(GetEquipmentModel().EquipmentGroupId);
        }

        // SkillModelを取得
        public SkillModel GetSkillModel()
        {
            SkillDao dao = (SkillDao)GameManager.Instance.masterManager.GetDao(MCConst.DAO_NAME_SKILL);
            return dao.GetModelById(GetEquipmentGroupModel().SkillId);
        }

        // 装備種名を取得
        public string GetEquipmentKindName()
        {
            switch(GetEquipmentModel().Type)
            {
                case EquipmentType.NECKLACE:
                    return MCConst.EQUIPMENT_KIND_NECKLACE;
                case EquipmentType.CANE:
                    return MCConst.EQUIPMENT_KIND_CANE;
                case EquipmentType.BANGLE:
                    return MCConst.EQUIPMENT_KIND_BANGLE;
                case EquipmentType.EARRINGS:
                    return MCConst.EQUIPMENT_KIND_EARRINGS;
                case EquipmentType.RING:
                    return MCConst.EQUIPMENT_KIND_RING;
                case EquipmentType.NONE:
                default:
                    return "";
            }
        }
    }
}

