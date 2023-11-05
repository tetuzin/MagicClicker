using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using ShunLib.UI.Slider;
using ShunLib.Btn.Common;

namespace MagicClicker.Manager.Header
{
    public class HeaderManager : MonoBehaviour
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("所持金テキスト")]
        [SerializeField] private TextMeshProUGUI _moneyText = default;

        [Header("スタミナゲージ")]
        [SerializeField] private CommonSlider _staminaGauge = default;

        [Header("メニューボタン")]
        [SerializeField] private CommonButton _menuBtn = default;

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

        // ---------- Private関数 ----------
        // ---------- protected関数 ---------
        // ---------- デバッグ用関数 ---------
    }
}


