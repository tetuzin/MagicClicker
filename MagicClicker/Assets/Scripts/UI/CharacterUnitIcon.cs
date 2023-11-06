using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ShunLib.UI.RadioIcon.Common;

using MagicClicker.Unit.Character;

namespace MagicClicker.UI.Icon.Character.Unit
{
    public class CharacterUnitIcon : MonoBehaviour
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("キャラクター画像")]
        [SerializeField] private Image _characterImage = default;

        [Header("フレーム画像")]
        [SerializeField] private Image _frameImage = default;
        
        [Header("ランクアイコン")]
        [SerializeField] private List<CommonRadioIcon> _rankIcons = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------

        // 初期化
        public void Initialize()
        {
            foreach (CommonRadioIcon icon in _rankIcons)
            {
                icon.Initialize();
            }
        }

        // キャラクターユニットの設定
        public void SetCharacterUnit(CharacterUnit unit)
        {
            // キャラクター画像
            if (unit.Model.CharacterIconSprite != default && unit.Model.CharacterIconSprite != null)
            {
                _characterImage.sprite = unit.Model.CharacterIconSprite;
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


