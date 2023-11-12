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
        // スコア
        [SerializeField] public int Score { get; set; }
        // ランク
        [SerializeField] public int Rank { get; set; }
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
        // クリック回数
        [SerializeField] public int ClickCount { get; set; }
        // 稼いだ合計ポイント
        [SerializeField] public int TotalGetPoint { get; set; }

        // 初期化
        public void Initialize()
        {
            Score = 0;
            Rank = 0;
            StatusHp = 0;
            StatusPower = 0;
            StatusMagic = 0;
            StatusSpeed = 0;
            StatusTechnic = 0;
            ClickCount = 0;
            TotalGetPoint = 0;
        }
    }
}

