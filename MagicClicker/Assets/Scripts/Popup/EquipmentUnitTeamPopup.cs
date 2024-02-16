using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Popup.Slide;

using MagicClicker.UI.Page.EquipmentUnitTeam;

namespace MagicClicker.Popup.EquipmentUnitTeam
{
    public class EquipmentUnitTeamPopup : SlidePagePopup
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("装備編成ページリスト")]
        [SerializeField] private List<EquipmentUnitTeamPage> _teamPages = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------
        // ---------- Private関数 ----------
        // ---------- protected関数 ---------
        // ---------- デバッグ用関数 ---------
    }
}

