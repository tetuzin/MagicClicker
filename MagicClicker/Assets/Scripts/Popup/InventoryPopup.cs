using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Popup;
using ShunLib.Btn.Common;

namespace MagicClicker.Popup.Inventory
{
    public class InventoryPopup : BasePopup
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("バトルチーム編成ボタン")]
        [SerializeField] private CommonButton _battleTeamButton = default;
        [Header("育成済み魔法少女ボタン")]
        [SerializeField] private CommonButton _characterUnitButton = default;
        [Header("装備編成ボタン")]
        [SerializeField] private CommonButton _equipmentUnitTeamButton = default;
        [Header("所持装備一覧ボタン")]
        [SerializeField] private CommonButton _equipmentUnitListButton = default;

        [Header("キャンセルボタン")]
        [SerializeField] private CommonButton _cancelButton = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------

        // バトルチーム編成ボタンの処理設定
        public void SetBattleTeamButton(Action action)
        {
            _battleTeamButton.SetOnEvent(action);
        }

        // 育成済み魔法少女ボタンの処理設定
        public void SetCharacterUnitButton(Action action)
        {
            _characterUnitButton.SetOnEvent(action);
        }

        // 装備編成ボタンの処理設定
        public void SetEquipmentTeamButton(Action action)
        {
            _equipmentUnitTeamButton.SetOnEvent(action);
        }

        // 所持装備一覧ボタンの処理設定
        public void SetEquipmentListButton(Action action)
        {
            _equipmentUnitListButton.SetOnEvent(action);
        }

        // ---------- Private関数 ----------
        // ---------- protected関数 ---------

        // 初期化
        protected override void Initialize()
        {
            base.Initialize();
            _battleTeamButton.Initialize();
            _characterUnitButton.Initialize();
            _equipmentUnitTeamButton.Initialize();
            _equipmentUnitListButton.Initialize();
            _cancelButton.Initialize();
        }

        // ボタンイベントの設定
        protected override void SetButtonEvents()
        {   
            if (_cancelButton != default)
            {
                _cancelButton.SetOnEvent(Close);
            }
        }

        // ---------- デバッグ用関数 ---------
    }
}

