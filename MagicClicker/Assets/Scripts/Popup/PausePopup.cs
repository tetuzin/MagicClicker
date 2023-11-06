using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Popup;
using ShunLib.Btn.Common;

namespace MagicClicker.Popup.Pause
{
    public class PausePopup : BasePopup
    {
        // ---------- 定数宣言 ----------

        // 戻るボタン
        public const string CANCEL_BUTTON_EVENT = "cancelButtonEvent";

        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [SerializeField, Tooltip("キャンセルボタン")] protected CommonButton _cancelButton = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------
        // ---------- Private関数 ----------
        // ---------- protected関数 ---------

        // 初期化
        protected override void Initialize()
        {
            base.Initialize();
            _cancelButton.Initialize();
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

