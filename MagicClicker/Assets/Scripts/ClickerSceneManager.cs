using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Manager.CommonScene;

namespace MagicClicker.Manager
{
    public class ClickerSceneManager : CommonSceneManager
    {
        // ---------- 定数宣言 ----------
        private const string CLICKER_BUTTON = "ClickerButton";
        private const string POINT_TEXT = "PointText";

        // ---------- ゲームオブジェクト参照変数宣言 ----------
        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------

        // ポイント値
        private int _point = 0;
        // 1クリックで増える値
        private int _addValue = 1;

        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------
        // ---------- Private関数 ----------

        // クリッカーボタンの処理
        private void OnClickClickerBtn()
        {
            _point += _addValue;
            _uiManager.SetText(POINT_TEXT, _point.ToString());
        }

        // ---------- protected関数 ---------

        // UIボタンの設定
        protected override void InitializeUI()
        {
            // クリッカーボタンの処理設定
            _uiManager.SetButtonEvent(CLICKER_BUTTON, OnClickClickerBtn);
        }

        // ---------- デバッグ用関数 ---------
    }
}


