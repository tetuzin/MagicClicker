using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicClicker.Model.Character
{
    [Serializable]
    public class CharacterModel
    {
        // 名前
        [SerializeField] public string Name { get; set; }
        // 説明
        [SerializeField] public string Explanation { get; set; }
        // アイコン用画像
        [SerializeField] public Sprite CharacterIconSprite { get; set; }
        // 立ち絵画像
        [SerializeField] public Sprite CharacterSprite { get; set; }
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
}

