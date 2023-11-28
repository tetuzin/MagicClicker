using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.UI.RadioIcon.Common;
using ShunLib.Utils.Resource;

using MagicClicker.Unit.Character;
using MagicClicker.UI.Icon.CommonInventory;
using MagicClicker.Model.Character;

namespace MagicClicker.UI.Icon.Character.Unit
{
    public class CharacterUnitIcon : CommonInventoryIcon
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------
        
        [Header("ランクアイコン")]
        [SerializeField] private List<CommonRadioIcon> _rankIcons = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------

        // 初期化
        public override void Initialize()
        {
            base.Initialize();
            foreach (CommonRadioIcon icon in _rankIcons)
            {
                icon.Initialize();
            }
        }

        // キャラクターの設定
        public void SetCharacterUnit(CharacterUnit unit, CharacterModel model)
        {
            if (unit == default || unit == null) return;
            if (model == default || model == null) return;

            // キャラクター画像
            if (model.IconSprite != default && model.IconSprite != null)
            {
                SetMainImage(ResourceUtils.GetSprite(model.IconSprite));
            }

            // TODO フレーム画像

            // ランクアイコン
            for (int i = 0; i < unit.Rank; i++)
            {
                if (i < _rankIcons.Count)
                {
                    _rankIcons[i].SetIconState(true);
                }
            }
        }

        // ---------- Private関数 ----------
        // ---------- protected関数 ---------
        // ---------- デバッグ用関数 ---------
    }
}


