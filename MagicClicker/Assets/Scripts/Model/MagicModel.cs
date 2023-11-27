using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicClicker.Model.Magic
{
    [Serializable]
    public class MagicModel
    {
        // 魔法ID
        [SerializeField] public int MagicId { get; set; }
        // 魔法名
        [SerializeField] public string MagicName { get; set; }
        // 消費ポイント
        [SerializeField] public int ConsumptionPoint { get; set; }
        // 魔法タイプ
        [SerializeField] public MagicType MagicType { get; set; }
        // 基本効果値
        [SerializeField] public int EffectValue { get; set; }
        // 発動時間
        [SerializeField] public float ActivateTime { get; set; }
    }

    [Serializable]
    // 魔法タイプ
    public enum MagicType
    {
        NONE = 0,

        // クリック時の値増加
        ADD_CLICK_VALUE = 10,

        // 時間経過での値増加
        ADD_TIME_VALUE = 20,

        // 魔法による値増加
        ADD_MAGIC_VALUE = 30,

        // 自動クリック
        AUTO_CLICK = 40,
    }
}
