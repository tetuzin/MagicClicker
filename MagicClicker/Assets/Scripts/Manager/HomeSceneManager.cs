using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Manager.Game;
using ShunLib.Manager.Scene;
using ShunLib.Manager.CommonScene;

using MagicClicker.Dao;
using MagicClicker.Const;
using MagicClicker.Manager.Header;
using MagicClicker.Popup.Inventory;
using MagicClicker.Popup.CharacterUnitList;
using MagicClicker.Popup.CharacterUnitDetails;
using MagicClicker.Popup.EquipmentUnitList;
using MagicClicker.Popup.EquipmentUnitDetails;
using MagicClicker.Unit.Character;
using MagicClicker.UI.Icon.Character.Unit;
using MagicClicker.UI.Icon.Equipment.Unit;
using MagicClicker.Model.Character;
using MagicClicker.Unit.Equipment;
using MagicClicker.Model.Equipment;

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
        // 所持装備一覧ポップアップ
        private const string EQUIPMENT_UNIT_LIST_POPUP = "EquipmentUnitListPopup";
        // 装備詳細ポップアップ
        private const string EQUIPMENT_UNIT_DETAILS_POPUP = "EquipmentUnitDetailsPopup";

        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("ヘッダー")]
        [SerializeField] private HeaderManager _header = default;

        [Header("キャラクターユニットアイコンプレハブ")]
        [SerializeField] private CharacterUnitIcon _characterUnitIconPrefab = default;

        [Header("装備ユニットアイコンプレハブ")]
        [SerializeField] private EquipmentUnitIcon _equipmentUnitIconPrefab = default;

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

                // データ取得しアイコン生成
                CharacterDao dao = (CharacterDao)GameManager.Instance.masterManager.GetDao(MCConst.DAO_NAME_CHARACTER);
                foreach (CharacterUnit unit in unitList)
                {
                    CharacterModel model = dao.GetModelById(unit.CharacterId);
                    CharacterUnitIcon icon = Instantiate(_characterUnitIconPrefab);
                    icon.Initialize();
                    icon.SetCharacterUnit(unit, model);
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
                CharacterDao dao = (CharacterDao)GameManager.Instance.masterManager.GetDao(MCConst.DAO_NAME_CHARACTER);
                CharacterModel model = dao.GetModelById(unit.CharacterId);
                popup.SetCharacterUnit(unit, model);
            });
        }

        // 所持装備一覧ポップアップを開く
        private void OpenEquipmentUnitListPopup()
        {
            _uiManager.CreateOpenPopup(EQUIPMENT_UNIT_LIST_POPUP, null, (p) => {
                EquipmentUnitListPopup popup = (EquipmentUnitListPopup)p;
                List<EquipmentUnit> unitList = GameManager.Instance.dataManager.Data.Game.EquipmentUnitList;

                // TODO ユニットソート処理実装箇所

                // データ取得しアイコン生成
                EquipmentDao dao = (EquipmentDao)GameManager.Instance.masterManager.GetDao(MCConst.DAO_NAME_EQUIPMENT);
                foreach (EquipmentUnit unit in unitList)
                {
                    EquipmentModel model = dao.GetModelById(unit.EquipmentId);
                    EquipmentUnitIcon icon = Instantiate(_equipmentUnitIconPrefab);
                    icon.Initialize();
                    icon.SetEquipmentUnit(unit, model);
                    icon.SetBaseButtonEvent(() => { OpenEquipmentUnitDetailsPopup(unit); });
                    icon.SetBaseButtonDownEvent(() => { OpenEquipmentUnitDetailsPopup(unit); });
                    popup.AddContent(icon.gameObject);
                }
            });
        }

        // 装備詳細ポップアップを開く
        private void OpenEquipmentUnitDetailsPopup(EquipmentUnit unit)
        {
            _uiManager.CreateOpenPopup(EQUIPMENT_UNIT_DETAILS_POPUP, null, (p) => {
                EquipmentUnitDetailsPopup popup = (EquipmentUnitDetailsPopup)p;
                EquipmentDao dao = (EquipmentDao)GameManager.Instance.masterManager.GetDao(MCConst.DAO_NAME_EQUIPMENT);
                EquipmentModel model = dao.GetModelById(unit.EquipmentId);
                popup.SetEquipmentUnit(unit);
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
                    popup.SetBattleTeamButton(ShowDevelopText);
                    popup.SetCharacterUnitButton(OpenCharacterUnitListPopup);
                    popup.SetEquipmentTeamButton(ShowDevelopText);
                    popup.SetEquipmentListButton(OpenEquipmentUnitListPopup);
                });
            });

            // 育成ボタン
            _uiManager.SetButtonEvent(NURTURE_BUTTON, () => {
                // TODO 仮実装
                SceneLoadManager.Instance.TransitionScene("ClickerScene");
            });

            // 対戦ボタン
            _uiManager.SetButtonEvent(BATTLE_BUTTON, () => {
                // TODO 仮実装
                ShowDevelopText();
            });
        }

        // イベントの設定
        protected override void InitEvent()
        {
            // TODO おしらせ　ログボ

            // TODO 仮　装備ユニット付与
            GameManager.Instance.dataManager.Data.Game.EquipmentUnitList.Add(
                new EquipmentUnit(){
                    EquipmentId = 100001,
                    Level = 1,
                    FavoriteFlag = false,
                }
            );
            GameManager.Instance.dataManager.Save();
        }

        // ---------- デバッグ用関数 ---------
    }
}
