using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.UI.RadioIcon.Common;

namespace MagicClicker.UI.Rank
{   
    public class RankView : MonoBehaviour
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
        public virtual void Initialize()
        {
            foreach (CommonRadioIcon icon in _rankIcons)
            {
                icon.Initialize();
            }
        }

        // 初期化＋ランク設定
        public void Initialize(int rank)
        {
            Initialize();
            SetRankView(rank);
        }

        // ランク設定
        public virtual void SetRankView(int rank)
        {
            // ランクアイコン
            for (int i = 0; i < rank; i++)
            {
                if (i < _rankIcons.Count)
                {
                    _rankIcons[i].SetIconState(true);
                }
            }
        }

        // 表示・非表示
        public void SetActive(bool b)
        {
            this.gameObject.SetActive(b);
        }

        // ---------- Private関数 ----------
        // ---------- protected関数 ---------
        // ---------- デバッグ用関数 ---------
    }
}

