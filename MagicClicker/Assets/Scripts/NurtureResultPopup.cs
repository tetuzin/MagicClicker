using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using ShunLib.Popup;
using ShunLib.Btn.Common;
using ShunLib.UI.RadioIcon.Common;
using System;

namespace MagicClicker.Popup.NurtureResult
{
    public class NurtureResultPopup : BasePopup
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("画像")]
        [SerializeField] private Image _characterImage = default;

        [Header("ランク")]
        [SerializeField] private List<CommonRadioIcon> _rankIcons = default;

        [Header("キャラクター名")]
        [SerializeField] private TextMeshProUGUI _nameText = default;

        [Header("スコア")]
        [SerializeField] private TextMeshProUGUI _scoreText = default;

        [Header("ホームへもどるボタン")]
        [SerializeField] private CommonButton _returnBtn = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------

        // キャラクター画像の設定
        public void SetCharacterImage(Sprite sprite)
        {
            _characterImage.sprite = sprite;
        }

        // ランクの設定
        public void SetRank(int rank)
        {
            for (int i = 0; i < rank; i++)
            {
                if (rank >= _rankIcons.Count) continue;

                _rankIcons[i].SetIconState(true);
            }
        }

        // キャラクター名の設定
        public void SetCharacterName(string name)
        {
            _nameText.text = name;
        }

        // スコアの設定
        public void SetScore(int score)
        {
            _scoreText.text = score.ToString();
        }

        // ホームへ戻るボタン処理設定
        public void SetReturnBtnEvent(Action action)
        {
            _returnBtn.SetOnEvent(action);
        }

        // ---------- Private関数 ----------
        // ---------- protected関数 ---------

        // 初期化
        protected override void Initialize()
        {
            base.Initialize();
            foreach (CommonRadioIcon icon in _rankIcons)
            {
                icon.Initialize();
            }
        }

        // ボタン設定
        protected override void SetButtonEvents()
        {
            base.SetButtonEvents();
            _returnBtn.Initialize();
        }

        // ---------- デバッグ用関数 ---------
    }
}

