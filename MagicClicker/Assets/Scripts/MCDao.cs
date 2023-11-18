using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Dao;

using MagicClicker.Model.Character;
using MagicClicker.Model.Equipment;
using MagicClicker.Model.Magic;

namespace MagicClicker.Dao
{
    public class MCDao : MonoBehaviour{}

    public class CharacterDao : BaseDao<CharacterModel>{}

    public class EquipmentDao : BaseDao<EquipmentModel>{}

    public class MagicDao : BaseDao<MagicModel>{}
}

