using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MagicClicker.Model.Character;

namespace MagicClicker.Unit.Character
{
    [Serializable]
    public class CharacterUnit
    {
        // キャラクター
        [SerializeField] public CharacterModel Model { get; set; }
        // たいりょく
        [SerializeField] public int StatusHp { get; set; }
        // きんりょく
        [SerializeField] public int StatusPower { get; set; }
        // まりょく
        [SerializeField] public int StatusMagic { get; set; }
        // しゅんぱつりょく
        [SerializeField] public int StatusSpeed { get; set; }
        // ぎじゅつりょく
        [SerializeField] public int StatusTechnic { get; set; }

        // 初期化
        public void Initialize()
        {
            StatusHp = 0;
            StatusPower = 0;
            StatusMagic = 0;
            StatusSpeed = 0;
            StatusTechnic = 0;
        }
    }
}

