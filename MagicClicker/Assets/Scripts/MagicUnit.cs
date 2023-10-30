using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MagicClicker.Model.Magic;
using MagicClicker.UI.Magic;

namespace MagicClicker.Unit.Magic
{
    [Serializable]
    public class MagicUnit
    {
        // 魔法アイコン
        [SerializeField] public MagicIcon MagicIcon { get; set; }
        // 魔法モデル
        [SerializeField] public MagicModel MagicModel { get; set; }
        // 魔法レベル
        [SerializeField] public int Level { get; set; }
        // 消費ポイント
        [SerializeField] public int ConsumptionPoint { get; set; }
        // 習得フラグ
        [SerializeField] public bool GetFlag { get; set; }

        // 初期化
        public void Initialize(MagicModel model)
        {
            MagicIcon = default;
            MagicModel = model;
            Level = 0;
            ConsumptionPoint = model.ConsumptionPoint;
            GetFlag = false;
        }

        // 習得
        public void Learn()
        {
            GetFlag = true;
            Level = 1;
        }

        // レベルアップ
        public void LevelUp()
        {
            Level++;
            ConsumptionPoint*=2;
        }
    }
}

