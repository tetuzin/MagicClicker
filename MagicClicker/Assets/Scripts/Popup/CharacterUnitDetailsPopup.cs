using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using ShunLib.Popup;
using ShunLib.Btn.Common;
using ShunLib.UI.Tab;
using ShunLib.UI.Panel;
using ShunLib.UI.RadioIcon.Common;
using ShunLib.Utils.Resource;

using MagicClicker.Unit.Character;
using System;
using MagicClicker.Model.Character;

namespace MagicClicker.Popup.CharacterUnitDetails
{
    public class CharacterUnitDetailsPopup : BasePopup
    {
        // ---------- 定数宣言 ----------

        // ステータスパネル
        private const string SCORE_VALUE = "ScoreValue";// スコア
        private const string PRAME_HP_VALUE = "PrameHpValue";// たいりょく
        private const string PRAME_POWER_VALUE = "PramePowerValue";// きんりょく
        private const string PRAME_MAGIC_VALUE = "PrameMagicValue";// まりょく
        private const string PRAME_SPEED_VALUE = "PrameSpeedValue";// しゅんぱつりょく
        private const string PRAME_TECHNIC_VALUE = "PrameTechnicValue";// ぎじゅつりょく

        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("キャラクター画像")]
        [SerializeField] private Image _characterImage = default;

        [Header("キャラクター名前")]
        [SerializeField] private TextMeshProUGUI _nameText = default;

        [Header("タブ")]
        [SerializeField] private TabContent _tab = default;

        [Header("ランクアイコン")]
        [SerializeField] private List<CommonRadioIcon> _rankIcons = default;

        [Header("ステータスパネル")]
        [SerializeField] private CommonPanel _statusPanel = default;

        [Header("キャンセルボタン")]
        [SerializeField] private CommonButton _cancelButton = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------

        // キャラクターユニットの設定
        public void SetCharacterUnit(CharacterUnit unit, CharacterModel model)
        {
            _nameText.text = model.Name;
            _characterImage.sprite = ResourceUtils.GetSprite(model.MainSprite);
            SetStatusPanel(unit);
        }

        // ---------- Private関数 ----------

        // ステータスパネルの設定
        private void SetStatusPanel(CharacterUnit unit)
        {
            // スコア
            _statusPanel.SetText(SCORE_VALUE, unit.Score.ToString());

            // ランクアイコン
            for (int i = 0; i < unit.Rank; i++)
            {
                if (i < _rankIcons.Count)
                {
                    _rankIcons[i].SetIconState(true);
                }
            }

            // 各種パラメータ
            _statusPanel.SetText(PRAME_HP_VALUE, unit.StatusHp.ToString());
            _statusPanel.SetText(PRAME_POWER_VALUE, unit.StatusPower.ToString());
            _statusPanel.SetText(PRAME_MAGIC_VALUE, unit.StatusMagic.ToString());
            _statusPanel.SetText(PRAME_SPEED_VALUE, unit.StatusSpeed.ToString());
            _statusPanel.SetText(PRAME_TECHNIC_VALUE, unit.StatusTechnic.ToString());

            // TODO 技
        }

        // ---------- protected関数 ---------

        // 初期化
        protected override void Initialize()
        {
            base.Initialize();
            _tab.Initialize();
            _cancelButton.Initialize();

            foreach (CommonRadioIcon icon in _rankIcons)
            {
                icon.Initialize();
            }
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

