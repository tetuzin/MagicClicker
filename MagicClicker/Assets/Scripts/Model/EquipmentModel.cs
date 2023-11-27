using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicClicker.Model.Equipment
{
    [Serializable]
    public class EquipmentModel
    {
        // 装備ID
        [SerializeField] public int EquipmentId { get; set; }
        // 名前
        [SerializeField] public string Name { get; set; }
        // 装備種
        [SerializeField] public EquipmentType Type { get; set; }
        // 装備グループID
        [SerializeField] public int EquipmentGroupId { get; set; }
        // 説明
        [SerializeField] public string Explanation { get; set; }
        // アイコン用画像
        [SerializeField] public string IconSprite { get; set; }
        // 立ち絵画像
        [SerializeField] public string MainSprite { get; set; }
    }

    [Serializable]
    public class EquipmentGroupModel
    {
        // 装備グループID
        [SerializeField] public int EquipmentGroupId { get; set; }
        // レベル
        [SerializeField] public int Level { get; set; }
        // スキルID
        [SerializeField] public int SkillId { get; set; }
        // 基礎たいりょく増加
        [SerializeField] public int AddBaseHp { get; set; }
        // 基礎きんりょく増加
        [SerializeField] public int AddBasePower { get; set; }
        // 基礎まりょく増加
        [SerializeField] public int AddBaseMagic { get; set; }
        // 基礎しゅんぱつりょく増加
        [SerializeField] public int AddBaseSpeed { get; set; }
        // 基礎ぎじゅつりょく増加
        [SerializeField] public int AddBaseTechnic { get; set; }
        // 基礎ステータス増加
        [SerializeField] public int AddBaseStatus { get; set; }
        // たいりょく強化に必要な消費値がN％減少する
        [SerializeField] public int DecreaseGrowValueRateHp { get; set; }
        // きんりょく強化に必要な消費値がN％減少する
        [SerializeField] public int DecreaseGrowValueRatePower { get; set; }
        // まりょく強化に必要な消費値がN％減少する
        [SerializeField] public int DecreaseGrowValueRateMagic { get; set; }
        // しゅんぱつりょく強化に必要な消費値がN％減少する
        [SerializeField] public int DecreaseGrowValueRateSpeed { get; set; }
        // ぎじゅつりょく強化に必要な消費値がN％減少する
        [SerializeField] public int DecreaseGrowValueRateTechnic { get; set; }
        // ステータス強化に必要な消費値がN％減少する
        [SerializeField] public int DecreaseGrowValueRateStatus { get; set; }
        // クリック時増加値をN％増加
        [SerializeField] public int AddClickValueRate { get; set; }
        // 時間経過増加値をN％増加
        [SerializeField] public int AddTimeValueRate { get; set; }
        // 魔法増加値をN％増加
        [SerializeField] public int AddMagicValueRate { get; set; }
        // 魔法強化時の成長率をN％増加
        [SerializeField] public int MagicNatureGrowRate { get; set; }
        // 魔法強化時の消費値をN％減少
        [SerializeField] public int MagicNatureCostRate { get; set; }
        // 魔法強化時に値消費しなくなる確率N％増加
        [SerializeField] public int MagicNatureNoCostRate { get; set; }
    }

    [Serializable]
    public enum EquipmentType
    {
        NONE = 0,
        NECKLACE = 10,  // ネックレス
        CANE = 20,  // 杖
        RING = 30,  // 指輪
        BANGLE = 40,    // 腕輪
        EARRINGS = 50,  // イヤリング
    }
}

