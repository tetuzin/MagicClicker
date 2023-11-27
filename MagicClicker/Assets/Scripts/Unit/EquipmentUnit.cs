using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MagicClicker.Model.Equipment;

namespace MagicClicker.Unit.Equipment
{
    [Serializable]
    public class EquipmentUnit
    {   
        // 装備ID
        [SerializeField] public int EquipmentId { get; set; }
        // 装備レベル
        [SerializeField] public int Level { get; set; }
        // お気に入りフラグ
        [SerializeField] public bool FavoriteFlag { get; set; }
    }
}

