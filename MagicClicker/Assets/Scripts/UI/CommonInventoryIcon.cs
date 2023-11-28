using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ShunLib.UI.RadioIcon.Common;
using ShunLib.Btn.Common;
using ShunLib.Utils.Resource;

namespace MagicClicker.UI.Icon.CommonInventory
{
    public class CommonInventoryIcon : MonoBehaviour
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("メイン画像")]
        [SerializeField] protected Image mainImage = default;

        [Header("フレーム画像")]
        [SerializeField] protected Image frameImage = default;

        [Header("アイコンボタン")]
        [SerializeField] protected CommonButton baseButton = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------

        // 初期化
        public virtual void Initialize()
        {
            if (baseButton != default && baseButton != null)
            {
                baseButton.Initialize();
            }
        }

        // ボタン処理の設定
        public virtual void SetBaseButtonEvent(Action action)
        {
            if (baseButton == default || baseButton == null) return;
            baseButton.SetOnEvent(action);
        }

        // ボタン処理の設定(長押し)
        public virtual void SetBaseButtonDownEvent(Action action)
        {
            if (baseButton == default || baseButton == null) return;
            baseButton.SetOnDownEvent(action);
        }

        // メイン画像の設定
        public virtual void SetMainImage(Sprite mainSprite)
        {
            if (mainSprite == default || mainSprite == null) return;
            if (mainImage == default || mainImage == null) return;

            mainImage.sprite = mainSprite;
        }

        // フレーム画像の設定
        public virtual void SetFrameImage(Sprite frameSprite)
        {
            if (frameSprite == default || frameSprite == null) return;
            if (frameImage == default || frameImage == null) return;

            frameImage.sprite = frameSprite;
        }

        // ---------- Private関数 ----------
        // ---------- protected関数 ---------
        // ---------- デバッグ用関数 ---------
    }
}

