using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Manager.Game;
using ShunLib.Manager.Scene;
using ShunLib.Manager.CommonScene;

using MagicClicker.Manager.Header;

namespace MagicClicker.Manager.Home
{
    public class HomeSceneManager : CommonSceneManager
    {
        // ---------- 定数宣言 ----------

        // 編成ボタン
        private const string CHARACTER_BUTTON = "CharacterButton";
        // 育成ボタン
        private const string NURTURE_BUTTON = "NurtureButton";
        // 対戦ボタン
        private const string BATTLE_BUTTON = "BattleButton";

        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("ヘッダー")]
        [SerializeField] private HeaderManager _header = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------
        // ---------- Private関数 ----------
        // ---------- protected関数 ---------

        // データ設定
        protected override void InitializeData()
        {
            _header.Initialize();
        }

        // UIボタンの設定
        protected override void InitializeUI()
        {
            _uiManager.SetButtonEvent(NURTURE_BUTTON, () => {
                // TODO 仮実装
                SceneLoadManager.Instance.TransitionScene("ClickerScene");
            });
        }

        // イベントの設定
        protected override void InitEvent()
        {
            // TODO おしらせ　ログボ
        }

        // ---------- デバッグ用関数 ---------
    }
}
