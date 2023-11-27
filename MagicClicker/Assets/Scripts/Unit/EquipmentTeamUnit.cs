using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MagicClicker.Unit.Equipment;

namespace MagicClicker.Unit.EquipmentTeam
{
    [Serializable]
    public class EquipmentTeamUnit
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------
        // ---------- プレハブ ----------
        // ---------- プロパティ ----------

        // ネックレス
        [SerializeField] public EquipmentUnit NecklaceUnit { get; set; }
        // 杖
        [SerializeField] public EquipmentUnit CaneUnit { get; set; }
        // 指輪
        [SerializeField] public EquipmentUnit RingUnit { get; set; }
        // 腕輪
        [SerializeField] public EquipmentUnit BangleUnit { get; set; }
        // イヤリング
        [SerializeField] public EquipmentUnit EarringsUnit { get; set; }

        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------

        // 初期化
        public void Initialize()
        {
            NecklaceUnit = null;
            CaneUnit = null;
            RingUnit = null;
            BangleUnit = null;
            EarringsUnit = null;
        }

        // ---------- Private関数 ----------
        // ---------- protected関数 ---------
        // ---------- デバッグ用関数 ---------
    }
}

