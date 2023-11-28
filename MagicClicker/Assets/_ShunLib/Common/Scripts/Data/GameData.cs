using System;
using UnityEngine;
using System.Collections.Generic;

using MagicClicker.Unit.Character;
using MagicClicker.Unit.Equipment;

namespace ShunLib.Data.Game
{
    [Serializable]
    public class GameData : BaseData
    {
        // キャラクターユニットリスト
        [SerializeField] public List<CharacterUnit> CharacterUnitList { get; set; }
        // 装備ユニットリスト
        [SerializeField] public List<EquipmentUnit> EquipmentUnitList { get; set; }
        
        public void Initialize()
        {
            CharacterUnitList = new List<CharacterUnit>();
            EquipmentUnitList = new List<EquipmentUnit>();
        }
    }
}