using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Manager.Game;
using ShunLib.Manager.Scene;
using ShunLib.Manager.CommonScene;

using MagicClicker.Manager.Header;
using MagicClicker.Popup.Inventory;
using MagicClicker.Popup.CharacterUnitList;
using MagicClicker.Popup.CharacterUnitDetails;
using MagicClicker.Unit.Character;
using MagicClicker.UI.Icon.Character.Unit;

namespace MagicClicker.Manager.Home
{
    public class HomeSceneManager : CommonSceneManager
    {
        // ---------- 定数宣言 ----------

        // 編成ボタン
        private const string INVENTORY_BUTTON = "InventoryButton";
        // 育成ボタン
        private const string NURTURE_BUTTON = "NurtureButton";
        // 対戦ボタン
        private const string BATTLE_BUTTON = "BattleButton";

        // 編成ポップアップ
        private const string INVENTORY_POPUP = "InventoryPopup";
        // 育成済み魔法少女ポップアップ
        private const string CHARACTER_UNIT_LIST_POPUP = "CharacterUnitListPopup";
        // 魔法少女詳細ポップアップ
        private const string CHARACTER_UNIT_DETAILS_POPUP = "CharacterUnitDetailsPopup";

        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("ヘッダー")]
        [SerializeField] private HeaderManager _header = default;

        [Header("キャラクターユニットアイコンプレハブ")]
        [SerializeField] private CharacterUnitIcon _characterUnitIconPrefab = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------
        // ---------- Private関数 ----------

        // 育成済み魔法少女ポップアップを開く
        private void OpenCharacterUnitListPopup()
        {
            _uiManager.CreateOpenPopup(CHARACTER_UNIT_LIST_POPUP, null, (p) => {
                CharacterUnitListPopup popup = (CharacterUnitListPopup)p;
                List<CharacterUnit> unitList = GameManager.Instance.dataManager.Data.Game.CharacterUnitList;

                // TODO ユニットソート処理実装箇所

                foreach (CharacterUnit unit in unitList)
                {
                    CharacterUnitIcon icon = Instantiate(_characterUnitIconPrefab);
                    icon.Initialize();
                    icon.SetCharacterUnit(unit);
                    icon.SetBaseButtonEvent(() => { OpenCharacterUnitDetailsPopup(unit); });
                    icon.SetBaseButtonDownEvent(() => { OpenCharacterUnitDetailsPopup(unit); });
                    popup.AddContent(icon.gameObject);
                }
            });
        }

        // 魔法少女詳細ポップアップを開く
        private void OpenCharacterUnitDetailsPopup(CharacterUnit unit)
        {
            _uiManager.CreateOpenPopup(CHARACTER_UNIT_DETAILS_POPUP, null, (p) => {
                CharacterUnitDetailsPopup popup = (CharacterUnitDetailsPopup)p;
                popup.SetCharacterUnit(unit);
            });
        }

        // ---------- protected関数 ---------

        // データ設定
        protected override void InitializeData()
        {
            _header.Initialize();
        }

        // UIボタンの設定
        protected override void InitializeUI()
        {
            // 編成ボタン
            _uiManager.SetButtonEvent(INVENTORY_BUTTON, () => {
                _uiManager.CreateOpenPopup(INVENTORY_POPUP, null, (p) => {
                    InventoryPopup popup = (InventoryPopup)p;
                    popup.SetCharacterUnitButton(OpenCharacterUnitListPopup);
                });
            });

            // 育成ボタン
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
