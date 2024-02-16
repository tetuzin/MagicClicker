using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.UI.Input;

using MagicClicker.UI.Icon.Empty;

namespace MagicClicker.UI.Page.EquipmentUnitTeam
{
    public class EquipmentUnitTeamPage : MonoBehaviour
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("編成名InputField")]
        [SerializeField] private CommonInputField _teamNameInputField = default;

        [Header("装備選択アイコン")]
        [SerializeField] private List<EmptyIcon> _equipmentSelectIcons = default;

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

