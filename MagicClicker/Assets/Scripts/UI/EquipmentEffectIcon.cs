using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MagicClicker.UI.Icon.EquipmentEffect
{
    public class EquipmentEffectIcon : MonoBehaviour
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("説明テキスト")]
        [SerializeField] private TextMeshProUGUI _text = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------

        // 初期化
        public void Initialize()
        {

        }

        // 初期化(値設定)
        public void Initialize(string text)
        {
            Initialize();
            SetText(text);
        }

        // テキスト設定
        public void SetText(string text)
        {
            _text.text = text;
        }

        // ---------- Private関数 ----------
        // ---------- protected関数 ---------
        // ---------- デバッグ用関数 ---------
    }
}

