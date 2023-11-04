using System;
using UnityEngine;

using MagicClicker.Unit.Character;
using System.Collections.Generic;

namespace ShunLib.Data.Game
{
    [Serializable]
    public class GameData : BaseData
    {
        // キャラクターユニットリスト
        [SerializeField] private List<CharacterUnit> _characterUnitList = default;

        public List<CharacterUnit> CharacterUnitList
        {
            get { return _characterUnitList; }
            set { _characterUnitList = value; }
        }
        
        public void Initialize()
        {
            _characterUnitList = new List<CharacterUnit>();
        }
    }
}