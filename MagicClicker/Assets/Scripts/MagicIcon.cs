using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using ShunLib.Btn.Common;

using System;

namespace MagicClicker.UI.Magic
{
    public class MagicIcon : MonoBehaviour
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("強化ボタン")]
        [SerializeField] protected CommonButton _magicButton = default;

        [Header("取得ボタン")]
        [SerializeField] protected CommonButton _getButton = default;

        [Header("名前")]
        [SerializeField] protected TextMeshProUGUI _magicName = default;

        [Header("レベル")]
        [SerializeField] protected TextMeshProUGUI _magicLevel = default;

        [Header("消費ポイント")]
        [SerializeField] protected TextMeshProUGUI _consumptionPointText = default;

        [Header("グレーアウト")]
        [SerializeField] protected GameObject _grayOut = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------

        // 初期化
        public void Initialize()
        {
            SetMagicButtonActive(false);
            SetGetButtonActive(false);
            SetGrayOutActive(false);
        }

        // 名前テキストの設定
        public void SetNameText(string name)
        {
            _magicName.text = name;
        }

        // レベルテキストの設定
        public void SetLevelText(int level)
        {
            _magicLevel.text = "LEVEL:" + level.ToString();
        }

        // 消費ポイントテキストの設定
        public void SetConsumptionPointText(int point)
        {
            _consumptionPointText.text = "消費ポイント:" + point.ToString();
        }

        // 取得ボタンのイベント設定
        public void SetGetButtonEvent(Action action)
        {
            _getButton.RemoveOnEvent();
            _getButton.SetOnEvent(action);
        }

        // 強化ボタンのイベント設定
        public void SetMagicButtonEvent(Action action)
        {
            _magicButton.RemoveOnEvent();
            _magicButton.SetOnEvent(action);
        }

        // 取得ボタンの表示・非表示
        public void SetGetButtonActive(bool isActive)
        {
            _getButton.gameObject.SetActive(isActive);
        }

        // 強化ボタンの表示・非表示
        public void SetMagicButtonActive(bool isActive)
        {
            _magicButton.gameObject.SetActive(isActive);
        }

        // グレーアウトの表示・非表示
        public void SetGrayOutActive(bool isActive)
        {
            _grayOut.SetActive(isActive);
        }

        // ---------- Private関数 ----------
        // ---------- protected関数 ---------
        // ---------- デバッグ用関数 ---------
    }
}

