using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ShunLib.Manager.Initialize;

namespace MagicClicker.Manager
{
    [DefaultExecutionOrder(-1)]
    public class MagicClickerInitializeManager : InitializeManager
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------
        [Header("画面タッチ判定用ボタン")] 
        [SerializeField] protected Button _windowBtn = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------
        // ---------- Private関数 ----------
        // ---------- protected関数 ---------

        // 起動時の初期設定
        protected override void Initialize()
        {
            _windowBtn.onClick.RemoveAllListeners();
            _windowBtn.onClick.AddListener(() => {
                base.Initialize();
            });
        }

        // ---------- デバッグ用関数 ---------
    }
}


