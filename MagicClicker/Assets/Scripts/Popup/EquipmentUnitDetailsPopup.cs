using System;
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
using ShunLib.Manager.Game;

using MagicClicker.Unit.Equipment;
using MagicClicker.Model.Equipment;
using MagicClicker.Model.Skill;
using MagicClicker.UI.Rank;
using MagicClicker.UI.Icon.Skill;
using MagicClicker.UI.Icon.EquipmentEffect;

namespace MagicClicker.Popup.EquipmentUnitDetails
{
    public class EquipmentUnitDetailsPopup : BasePopup
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("装備画像")]
        [SerializeField] private Image _equipmentImage = default;

        [Header("装備名")]
        [SerializeField] private TextMeshProUGUI _nameText = default;

        [Header("装備種類")]
        [SerializeField] private TextMeshProUGUI _kindText = default;

        [Header("ランク")]
        [SerializeField] private RankView _rankview = default;

        [Header("説明")]
        [SerializeField] private TextMeshProUGUI _explanationText = default;

        [Header("スキルアイコンParent")]
        [SerializeField] private Transform _skillIconParent = default;

        [Header("スキルアイコンPrefab")]
        [SerializeField] private SkillIcon _skillIconPrefab = default;

        [Header("装備効果Parent")]
        [SerializeField] private Transform _equipmentEffectParent = default;

        [Header("装備効果Prefab")]
        [SerializeField] private EquipmentEffectIcon _equipmentEffectPrefab = default;

        [Header("キャンセルボタン")]
        [SerializeField] private CommonButton _cancelButton = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------

        // 装備ユニット設定
        public void SetEquipmentUnit(EquipmentUnit unit)
        {
            if (unit == null || unit == default) return;

            EquipmentModel model = unit.GetEquipmentModel();
            _equipmentImage.sprite = ResourceUtils.GetSprite(model.MainSprite);
            _nameText.text = model.Name;
            _kindText.text = unit.GetEquipmentKindName();
            _rankview.SetRankView(unit.Level);
            _explanationText.text = model.Explanation;
            SetSkill(unit.GetSkillModel());
            SetEffect(unit.GetEquipmentGroupModel());
        }

        // ---------- Private関数 ----------

        // スキルアイコン設定
        private void SetSkill(SkillModel model)
        {
            if (model == null || model == default) return;

            SkillIcon icon = Instantiate(_skillIconPrefab, _skillIconParent);
            icon.gameObject.transform.localPosition = Vector3.zero;
            icon.Initialize(model);
        }

        // 装備効果設定
        private void SetEffect(EquipmentGroupModel model)
        {
            if (model == null || model == default) return;

            if (model.AddBaseHp > 0) CreateEquipmentEffectIcon("育成キャラクターのたいりょくが" + model.AddBaseHp + "増加する。");
            if (model.AddBasePower > 0) CreateEquipmentEffectIcon("育成キャラクターのきんりょくが" + model.AddBasePower + "増加する。");
            if (model.AddBaseMagic > 0) CreateEquipmentEffectIcon("育成キャラクターのまりょくが" + model.AddBaseMagic + "増加する。");
            if (model.AddBaseSpeed > 0) CreateEquipmentEffectIcon("育成キャラクターのしゅんぱつりょくが" + model.AddBaseSpeed + "増加する。");
            if (model.AddBaseTechnic > 0) CreateEquipmentEffectIcon("育成キャラクターのぎじゅつりょくが" + model.AddBaseTechnic + "増加する。");
            if (model.AddBaseStatus > 0) CreateEquipmentEffectIcon("育成キャラクターの全ステータスが" + model.AddBaseStatus + "増加する。");
            if (model.DecreaseGrowValueRateHp > 0) CreateEquipmentEffectIcon(
                "育成キャラクターのたいりょく強化に必要な消費ポイントが" + model.DecreaseGrowValueRateHp + "%減少する。"
            );
            if (model.DecreaseGrowValueRatePower > 0) CreateEquipmentEffectIcon(
                "育成キャラクターのきんりょく強化に必要な消費ポイントが" + model.DecreaseGrowValueRatePower + "%減少する。"
            );
            if (model.DecreaseGrowValueRateMagic > 0) CreateEquipmentEffectIcon(
                "育成キャラクターのまりょく強化に必要な消費ポイントが" + model.DecreaseGrowValueRateMagic + "%減少する。"
            );
            if (model.DecreaseGrowValueRateSpeed > 0) CreateEquipmentEffectIcon(
                "育成キャラクターのしゅんぱつりょく強化に必要な消費ポイントが" + model.DecreaseGrowValueRateSpeed + "%減少する。"
            );
            if (model.DecreaseGrowValueRateTechnic > 0) CreateEquipmentEffectIcon(
                "育成キャラクターのぎじゅつりょく強化に必要な消費ポイントが" + model.DecreaseGrowValueRateTechnic + "%減少する。"
            );
            if (model.DecreaseGrowValueRateStatus > 0) CreateEquipmentEffectIcon(
                "育成キャラクターのステータス強化に必要な消費ポイントが" + model.DecreaseGrowValueRateStatus + "%減少する。"
            );
            if (model.AddClickValueRate > 0) CreateEquipmentEffectIcon(
                "クリックによるポイント増加値が" + model.AddClickValueRate + "%増加する。"
            );
            if (model.AddTimeValueRate > 0) CreateEquipmentEffectIcon(
                "時間経過によるポイント増加値が" + model.AddTimeValueRate + "%増加する。"
            );
            if (model.AddMagicValueRate > 0) CreateEquipmentEffectIcon(
                "魔法によるポイント増加値が" + model.AddClickValueRate + "%増加する。"
            );
            if (model.MagicNatureGrowRate > 0) CreateEquipmentEffectIcon(
                "魔法強化時の魔法成長率が" + model.MagicNatureGrowRate + "%増加する。"
            );
            if (model.MagicNatureCostRate > 0) CreateEquipmentEffectIcon(
                "魔法強化時の消費ポイントが" + model.MagicNatureCostRate + "%減少する。"
            );
        }

        // 装備効果アイコン生成
        private void CreateEquipmentEffectIcon(string text)
        {
            EquipmentEffectIcon icon = Instantiate(_equipmentEffectPrefab, _equipmentEffectParent);
            icon.gameObject.transform.localPosition = Vector3.zero;
            icon.Initialize(text);
        }

        // ---------- protected関数 ---------

        // 初期化
        protected override void Initialize()
        {
            base.Initialize();
            _cancelButton.Initialize();
            _rankview.Initialize();
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

