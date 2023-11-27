using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using MagicClicker.Model.Skill;

namespace MagicClicker.UI.Icon.Skill
{
    public class SkillIcon : MonoBehaviour
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("スキル名")]
        [SerializeField] private TextMeshProUGUI _nameText = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------

        private SkillModel _model = default;

        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------

        // 初期化
        public void Initialize()
        {

        }

        // 初期化(Skill設定)
        public void Initialize(SkillModel model)
        {
            Initialize();
            SetSkillModel(model);
        }

        // SkillModel設定
        public void SetSkillModel(SkillModel model)
        {
            _model = model;
            SetSkillName(model.Name);
        }

        // スキル名の設定
        public void SetSkillName(string name)
        {
            _nameText.text = name;
        }

        // ---------- Private関数 ----------
        // ---------- protected関数 ---------
        // ---------- デバッグ用関数 ---------
    }
}

