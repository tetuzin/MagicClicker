using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicClicker.Model.Character
{
    [Serializable]
    public class CharacterModel
    {
        // キャラクターID
        [SerializeField] public int CharacterId { get; set; }
        // 名前
        [SerializeField] public string Name { get; set; }
        // 説明
        [SerializeField] public string Explanation { get; set; }
        // キャラクター詳細ID
        [SerializeField] public int CharacterDetailsId { get; set; }
        // アイコン用画像
        [SerializeField] public string IconSprite { get; set; }
        // 立ち絵画像
        [SerializeField] public string MainSprite { get; set; }
    }

    public class CharacterDetailsModel
    {
        // キャラクター詳細ID
        [SerializeField] public int CharacterDetailsId { get; set; }
        // 二つ名
        [SerializeField] public string DetailsName { get; set; }
        // 説明
        [SerializeField] public string Explanation { get; set; }
        // スキルID
        [SerializeField] public int SkillID { get; set; }
        // 基礎たいりょく値
        [SerializeField] public int BaseHp { get; set; }
        // 基礎きんりょく値
        [SerializeField] public int BasePower { get; set; }
        // 基礎まりょく値
        [SerializeField] public int BaseMagic { get; set; }
        // 基礎しゅんぱつりょく値
        [SerializeField] public int BaseSpeed { get; set; }
        // 基礎ぎじゅつりょく値
        [SerializeField] public int BaseTechnic { get; set; }
    }

    [Serializable]
    public enum StatusType
    {
        // たいりょく
        HP = 10,
        // きんりょく
        POWER = 20,
        // まりょく
        MAGIC = 30,
        // しゅんぱつりょく
        SPEED = 40,
        // ぎじゅつりょく
        TECHNIC = 50,
    }

    [Serializable]
    public enum ElementType
    {
        NONE = 0,
        RED = 1,    // 赤属性
        GREEN = 2,  // 緑属性
        BLUE = 3,   // 青属性
    }
}

