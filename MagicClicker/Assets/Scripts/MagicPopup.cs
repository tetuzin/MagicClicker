using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Popup;
using ShunLib.Btn.Common;
using ShunLib.UI.Scroll;

using MagicClicker.UI.Magic;
using MagicClicker.Model.Magic;

namespace MagicClicker.Popup.Magic
{
    public class MagicPopup : BasePopup
    {
        // ---------- 定数宣言 ----------

        // 戻るボタン
        public const string CANCEL_BUTTON_EVENT = "cancelButtonEvent";

        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("キャンセルボタン")]
        [SerializeField] protected CommonButton _cancelButton = default;

        [Header("スクロールビュー")]
        [SerializeField] protected CommonScrollRect _commonScrollRect = default;

        [Header("MagicIconのPrefab")]
        [SerializeField] protected MagicIcon _magicIconPrefab = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------

        // モデルリスト
        private List<MagicModel> _magicModelList = default;

        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------

        // コンテンツの初期化
        public void SetContent(List<MagicModel> modelList)
        {
            _magicModelList = modelList;
            foreach (MagicModel model in modelList)
            {
                MagicIcon icon = Instantiate(_magicIconPrefab, Vector3.zero, Quaternion.identity);
                icon.Initialize();
                icon.SetMagicModel(model);
                _commonScrollRect.AddContent(icon.gameObject);
            }
        }

        // ---------- Private関数 ----------
        // ---------- protected関数 ---------

        // 初期化
        protected override void Initialize()
        {
            base.Initialize();

            _commonScrollRect.Initialize();
        }

        // ボタンイベントの設定
        protected override void SetButtonEvents()
        {   
            if (_cancelButton != default)
            {
                _cancelButton.SetOnEvent(() => {
                    Action action = GetAction(CANCEL_BUTTON_EVENT);
                    action?.Invoke();
                    Close();
                });
            }
        }

        // ポップアップを閉じるときの処理
        protected override void HidePopup()
        {
            base.HidePopup();

            Action action = GetAction(CANCEL_BUTTON_EVENT);
            action?.Invoke();
        }

        // ---------- デバッグ用関数 ---------
    }
}


