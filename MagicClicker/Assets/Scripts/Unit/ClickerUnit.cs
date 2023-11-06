using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicClicker.Unit
{
    public class ClickerUnit : MonoBehaviour
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------
        // ---------- プレハブ ----------
        // ---------- プロパティ ----------

        // クリック時の値増加量
        public int ClickValue { get; set; }

        // 時間経過による値増加量
        public int TimeValue { get; set; }

        // クリック回数
        public int ClickCount { get; set; }


        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------

        // 初期化
        public void Initialize()
        {
            ClickValue = 1;
            TimeValue = 0;
            ClickCount = 1;
        }
        // ---------- Private関数 ----------
        // ---------- protected関数 ---------
        // ---------- デバッグ用関数 ---------
    }
}

