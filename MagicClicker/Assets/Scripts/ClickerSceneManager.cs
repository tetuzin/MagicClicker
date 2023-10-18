using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Manager.CommonScene;
using ShunLib.UI.ShowValue;

namespace MagicClicker.Manager
{
    public class ClickerSceneManager : CommonSceneManager
    {
        // ---------- 定数宣言 ----------
        // クリッカーボタン
        private const string CLICKER_BUTTON = "ClickerButton";
        // ポイント値
        private const string POINT_TEXT = "PointText";
        // 残り時間
        private const string REMAIN_TIME_TEXT = "RemainTimeText";

        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("クリック時の増加値表示テキストオブジェクト")]
        [SerializeField] protected ShowValueObject _showValueObjectPrefab = default;

        [Header("増加値表示テキストオブジェクトの親オブジェクト")]
        [SerializeField] protected Transform _showValueObjectParent = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------

        // ゲーム時間
        private float _gameTime = 15f;
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
            _isPlay = true;
        }

        // ゲーム終了
        private void EndGame()
        {
            _isPlay = false;
        }

        // ポイント増加
        private int AddPoint(int point = 0)
        {
            int addPoint = 0;

            addPoint = point;
            _point += addPoint;
            _uiManager.SetText(POINT_TEXT, _point.ToString());

            return addPoint;
        }

        // 時間経過処理
        private void ProgressEvent()
        {
            // TODO 仮実装
            AddPoint(_addProgressValue);

            // 残り時間表示
            _uiManager.SetText(REMAIN_TIME_TEXT, GetRemainTimeStr());
        }

        // 残り時間文字列を返す
        private string GetRemainTimeStr()
        {   
            float time = _gameTime - _progressTime;
            if (time <= 0) time = 0f;
            int minutes = Mathf.FloorToInt(time / 60F);
            int seconds = Mathf.FloorToInt(time - minutes * 60);
            return string.Format("{0:00}:{1:00}", minutes, seconds);
            // int mseconds = Mathf.FloorToInt((time - minutes * 60 - seconds) * 1000);
            // return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, mseconds);
        }

        // クリッカーボタンの処理
        private void OnClickClickerBtn()
        {
            if (!_isPlay) return;
            int addPoint = AddPoint(_addClickValue);
            ShowAddPointValue(addPoint);
        }

        // 増加値の表示
        private void ShowAddPointValue(int point = 0)
        {
            Vector3 mousePosition = Input.mousePosition;
            ShowValueObject showValueObject = Instantiate(
                _showValueObjectPrefab, mousePosition, Quaternion.identity, _showValueObjectParent
            );
            showValueObject.Initialize();
            showValueObject.SetText("+" + point.ToString());
            showValueObject.SetShowTime(2);
            showValueObject.SetAnimation();
            showValueObject.StartShow();
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
            StartGame();
        }

        // ---------- デバッグ用関数 ---------
    }
}


