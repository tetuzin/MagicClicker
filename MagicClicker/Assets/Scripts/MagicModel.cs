using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicClicker.Model.Magic
{
    [Serializable]
    public class MagicModel
    {
        // 魔法名
        [SerializeField] public string MagicName { get; set; }
        // 消費ポイント
        [SerializeField] public int ConsumptionPoint { get; set; }
        // 効果
        [SerializeField] public EffectType EffectType { get; set; }
        
    }

    [Serializable]
    public enum EffectType
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
