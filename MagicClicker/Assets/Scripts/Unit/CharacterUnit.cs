using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MagicClicker.Const;
using MagicClicker.Model.Character;
using MagicClicker.Unit.EquipmentTeam;
using MagicClicker.Unit.Clicker;

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
        // 習得スキル
        [SerializeField] public int[] SkillArray { get; set; }
        // 育成時の装備編成
        [SerializeField] public EquipmentTeamUnit EquipmentTeamUnit { get; set; }
        // 育成完了時クリッカー状態
        [SerializeField] public ClickerUnit ClickerUnit { get; set; }

        // 初期化
        public void Initialize()
        {
            Model = null;
            Score = 0;
            Rank = 0;
            StatusHp = 0;
            StatusPower = 0;
            StatusMagic = 0;
            StatusSpeed = 0;
            StatusTechnic = 0;
            EquipmentTeamUnit = null;
            ClickerUnit = null;
            SkillArray = new int[MCConst.CHARACTER_SKILL_COUNT];
        }
    }
}

