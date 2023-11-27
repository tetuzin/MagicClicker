using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Popup;
using ShunLib.Btn.Common;
using ShunLib.UI.Scroll;

namespace MagicClicker.Popup.EquipmentList
{
    public class EquipmentListPopup : BasePopup
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("スクロールビュー")]
        [SerializeField] private CommonScrollRect _scroll = default;

        [Header("キャンセルボタン")]
        [SerializeField] private CommonButton _cancelButton = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------

        // スクロールビューにコンテンツ追加
        public void AddContent(GameObject gameObject)
        {  
            _scroll.AddContent(gameObject);
        }

        // ---------- Private関数 ----------
        // ---------- protected関数 ---------

        // 初期化
        protected override void Initialize()
        {
            base.Initialize();
            
            _scroll.Initialize();
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

