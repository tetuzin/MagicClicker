using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using ShunLib.Popup;
using ShunLib.Btn.Common;
using ShunLib.UI.ParameterSettingFrame;
using System;

namespace MagicClicker.Popup.Nurture
{
    public class NurturePopup : BasePopup
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("獲得ポイント")]
        [SerializeField] private TextMeshProUGUI _pointText = default;

        [Header("たいりょくフレーム")]
        [SerializeField] public CommonParameterSettingFrame FrameHp = default;
        [Header("きんりょくフレーム")]
        [SerializeField] public CommonParameterSettingFrame FramePower = default;
        [Header("まりょくフレーム")]
        [SerializeField] public CommonParameterSettingFrame FrameMagic = default;
        [Header("しゅんぱつりょくフレーム")]
        [SerializeField] public CommonParameterSettingFrame FrameSpeed = default;
        [Header("ぎじゅつりょくフレーム")]
        [SerializeField] public CommonParameterSettingFrame FrameTechnic = default;

        [Header("育成完了ボタン")]
        [SerializeField] private CommonButton _nurtureCompleteBtn = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------

        // 獲得ポイントテキスト設定
        public void SetPointText(long point)
        {
            _pointText.text = point.ToString();
        }

        // 育成完了ボタンの処理設定
        public void SetNurtureCompleteBtnEvent(Action action)
        {
            _nurtureCompleteBtn.SetOnEvent(action);
        }

        // ---------- Private関数 ----------
        // ---------- protected関数 ---------

        // 初期化
        protected override void Initialize()
        {
            base.Initialize();
            _nurtureCompleteBtn.Initialize();
        }

        // ボタンイベントの設定
        protected override void SetButtonEvents()
        {   
            if (_nurtureCompleteBtn != default)
            {
                _nurtureCompleteBtn.SetOnEvent(Close);
            }
        }

        // ---------- デバッグ用関数 ---------
    }
}


