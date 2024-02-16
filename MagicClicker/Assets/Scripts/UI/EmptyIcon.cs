using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Btn.Common;
using System;

namespace MagicClicker.UI.Icon.Empty
{
    public class EmptyIcon : MonoBehaviour
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("選択ボタン")]
        [SerializeField] private CommonButton _selectButton = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------

        // 初期化
        public void Initialize()
        {
            _selectButton.Initialize();
        }

        // 選択ボタン設定
        public void SetSelectButton(Action action)
        {
            _selectButton.SetOnEvent(action);
        }

        // ---------- Private関数 ----------
        // ---------- protected関数 ---------
        // ---------- デバッグ用関数 ---------
    }
}

