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
        // 効果値
        [SerializeField] public int EffectValue { get; set; }
        // 発動時間
        [SerializeField] public float ActivateTime { get; set; }
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
            ActivateTime = model.ActivateTime;
            ConsumptionPoint = model.ConsumptionPoint;
            GetFlag = false;
        }

        // 習得
        public void Learn()
        {
            GetFlag = true;
            Level = 1;
            EffectValue = MagicModel.EffectValue;
            ConsumptionPoint*=2;
        }

        // レベルアップ
        public void LevelUp()
        {
            Level++;
            switch (MagicModel.MagicType)
            {
                case MagicType.ADD_CLICK_VALUE:
                    EffectValue += MagicModel.EffectValue;
                    break;

                case MagicType.ADD_TIME_VALUE:
                    EffectValue *= 2;
                    break;

                case MagicType.ADD_MAGIC_VALUE:
                    EffectValue *= 3;
                    break;

                case MagicType.AUTO_CLICK:
                    EffectValue++;
                    break;

                default:
                    break;
            }
            ConsumptionPoint*=2;
        }
    }
}

