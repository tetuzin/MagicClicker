using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicClicker.Model.Equipment
{
    [Serializable]
    public class EquipmentModel
    {
        // 名前
        [SerializeField] public string Name { get; set; }
        // 装備種
        [SerializeField] public EquipmentType Type { get; set; }
        // 説明
        [SerializeField] public string Explanation { get; set; }
        // アイコン用画像
        [SerializeField] public string IconSprite { get; set; }
        // 立ち絵画像
        [SerializeField] public string MainSprite { get; set; }
    }

    [Serializable]
    public enum EquipmentType
    {
        NONE = 0,
        NECKLACE = 10,  // ネックレス
        CANE = 20,  // 杖
        RING = 30,  // 指輪
        BANGLE = 40,    // 腕輪
        EARRINGS = 50,  // イヤリング
    }
}

