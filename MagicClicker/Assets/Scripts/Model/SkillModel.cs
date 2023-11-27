using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MagicClicker.Model.Character;

namespace MagicClicker.Model.Skill
{
    [Serializable]
    public class SkillModel
    {
        // スキルID
        [SerializeField] public int SkillId { get; set; }
        // スキル名
        [SerializeField] public string Name { get; set; }
        // 説明
        [SerializeField] public string Explanation { get; set; }
        // 属性
        [SerializeField] public ElementType ElementType { get; set; }
        // スキル種
        [SerializeField] public SkillType SkillType { get; set; }
        // 対象
        [SerializeField] public TargetType TargetType { get; set; }
        // 攻撃値
        [SerializeField] public int AttackValue { get; set; }
        // スキル効果グループID
        [SerializeField] public int SkillEffectGroupId { get; set; }
    }

    [Serializable]
    public class SkillEffectGroupModel
    {
        // スキル効果グループID
        [SerializeField] public int SkillEffectGroupId { get; set; }
        // 発動条件タイプ
        [SerializeField] public ActivateConditionType ActivateConditionType { get; set; }
        // 値A
        [SerializeField] public int ValueA { get; set; }
        // 値B
        [SerializeField] public int ValueB { get; set; }
        // 値C
        [SerializeField] public int ValueC { get; set; }
        // 発動順番
        [SerializeField] public int ActivateOrder { get; set; }
        // スキル効果ID
        [SerializeField] public int SkillEffectId { get; set; }
    }

    [Serializable]
    public class SkillEffectModel
    {
        // スキル効果ID
        [SerializeField] public int SkillEffectId { get; set; }
        // 説明
        [SerializeField] public string Explanation { get; set; }
        // 効果
        [SerializeField] public EffectType EffectType { get; set; }
        // 値A
        [SerializeField] public int ValueA { get; set; }
        // 値B
        [SerializeField] public int ValueB { get; set; }
        // 値C
        [SerializeField] public int ValueC { get; set; }
        // 発動確率
        [SerializeField] public int Probability { get; set; }
    }

    [Serializable]
    public enum SkillType
    {
        NONE = 0,
        ATTACK = 10,    // 攻撃
        SUPPORT = 20,   // サポート
    }

    [Serializable]
    public enum TargetType
    {
        NONE = 0,
        ONE_ENEMY = 10, // 敵一体
        ALL_ENEMY = 11, // 敵全体
        ONE_ALLY = 20,  // 味方一体
        ALL_ALLY = 21,  // 味方全体
    }

    [Serializable]
    // 発動条件タイプ
    public enum ActivateConditionType
    {
        NONE = 0,

        NO_CONDITION = 9000,    // 無条件で発動
    }

    [Serializable]
    public enum EffectType
    {
        NONE = 0,

        // 攻撃関係 100

        // 回復関係 200
        HP_HEAL = 201,  // たいりょく回復

        // ステータス関係 300
        UP_STATUS_POWER = 311,  // きんりょく増加
        DOWN_STATUS_POWER = 312,  // きんりょく減少
        UP_STATUS_MAGIC = 321,  // まりょく増加
        DOWN_STATUS_MAGIC = 322,  // まりょく減少
        UP_STATUS_SPEED = 331,  // しゅんぱつりょく増加
        DOWN_STATUS_SPEED = 332,  // しゅんぱつりょく減少
        UP_STATUS_TECHNIC = 341,    // ぎじゅつりょく増加
        DOWN_STATUS_TECHNIC = 342,    // ぎじゅつりょく減少
    }
}

