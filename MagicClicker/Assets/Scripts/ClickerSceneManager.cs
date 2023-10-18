using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Manager.CommonScene;
using System.Drawing;

namespace MagicClicker.Manager
{
    public class ClickerSceneManager : CommonSceneManager
    {
        // ---------- 定数宣言 ----------
        private const string CLICKER_BUTTON = "ClickerButton";
        private const string POINT_TEXT = "PointText";

        // ---------- ゲームオブジェクト参照変数宣言 ----------
        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------

        // ゲーム時間
        private float _gameTime = 10000f;
        // 経過時間
        private float _progressTime = 0f;
        // ゲーム中フラグ
        private bool _isPlay = false;
        // ポイント値
        private int _point = 0;
        // 1クリックで増える値
        private int _addClickValue = 20;
        // 時間経過で増える値
        private int _addProgressValue = 1;

        // ---------- Unity組込関数 ----------

        void FixedUpdate()
        {
            // ゲーム中処理
            if (_isPlay)
            {
                _progressTime += Time.deltaTime;
                ProgressEvent();
                if (_progressTime >= _gameTime)
                {
                    // ゲーム終了
                    EndGame();
                }
            }
        }

        // ---------- Public関数 ----------
        // ---------- Private関数 ----------

        // ゲーム開始
        private void StartGame()
        {

        }

        // ゲーム終了
        private void EndGame()
        {

        }

        // ポイント増加
        private void AddPoint(int point = 0)
        {
            _point += point;
            _uiManager.SetText(POINT_TEXT, _point.ToString());
        }

        // 時間経過処理
        private void ProgressEvent()
        {
            // TODO 仮実装
            AddPoint(_addProgressValue);
        }

        // クリッカーボタンの処理
        private void OnClickClickerBtn()
        {
            if (!_isPlay) return;
            AddPoint(_addClickValue);
        }

        // ---------- protected関数 ---------

        // UIボタンの設定
        protected override void InitializeUI()
        {
            // クリッカーボタンの処理設定
            _uiManager.SetButtonEvent(CLICKER_BUTTON, OnClickClickerBtn);
        }

        // イベントの設定
        protected override void InitEvent()
        {
            // TODO 仮実装
            // 時間経過でポイント増加
            _isPlay = true;
        }

        // ---------- デバッグ用関数 ---------
    }
}


