using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Manager.CommonScene;
using ShunLib.UI.ShowValue;
using ShunLib.Controller.UpdateAction;

using MagicClicker.Unit;
using MagicClicker.Popup.Pause;
using MagicClicker.Popup.Magic;
using MagicClicker.Model.Magic;
using MagicClicker.Unit.Magic;
using MagicClicker.UI.Magic;

namespace MagicClicker.Manager
{
    public class ClickerSceneManager : CommonSceneManager
    {
        // ---------- 定数宣言 ----------
        // クリッカーボタン
        private const string CLICKER_BUTTON = "ClickerButton";
        // ポーズボタン
        private const string PAUSE_BUTTON = "PauseButton";
        // 進化ボタン
        private const string Magic_BUTTON = "MagicButton";
        // ポーズポップアップ
        private const string PAUSE_POPUP = "PausePopup";
        // 進化ポップアップ
        private const string Magic_POPUP = "MagicPopup";
        // ポイント値
        private const string POINT_TEXT = "PointText";
        // 残り時間
        private const string REMAIN_TIME_TEXT = "RemainTimeText";

        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("クリック時の増加値表示テキストオブジェクト")]
        [SerializeField] protected ShowValueObject _showValueObjectPrefab = default;

        [Header("増加値表示テキストオブジェクトの親オブジェクト")]
        [SerializeField] protected Transform _showValueObjectParent = default;

        [Header("MagicIconのPrefab")]
        [SerializeField] protected MagicIcon _magicIconPrefab = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------

        // クリッカーユニット
        private ClickerUnit _clicker = default;
        // UpdateActionController
        private UpdateActionController updateActionCtrl = default;
        // ゲーム時間
        private float _gameTime = 15f;
        // 経過時間
        private float _progressTime = 0f;
        // ゲーム中フラグ
        private bool _isPlay = false;
        // ポーズ中フラグ
        private bool _isPause = false;
        // ポイント値
        private int _point = 0;
        // 魔法一覧
        private List<MagicModel> _magicModelList = default;
        // 魔法ユニット一覧
        private List<MagicUnit> _magicUnitList = default;

        // ---------- Unity組込関数 ----------

        void FixedUpdate()
        {
            // ゲーム中処理
            if (_isPlay)
            {
                // ポーズ中なら処理しない
                if (_isPause) return;

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
            _isPause = false;
        }

        // ゲーム終了
        private void EndGame()
        {
            _isPlay = false;
            _isPause = false;
        }

        // ポイント増減
        private void IncreasePoint(int addPoint)
        {
            _point += addPoint;
            _uiManager.SetText(POINT_TEXT, _point.ToString() + "P");
        }

        // 時間経過処理
        private void ProgressEvent()
        {
            if (_isPause) return;

            // TODO 仮実装
            IncreasePoint(_clicker.TimeValue);

            // その他登録した処理
            updateActionCtrl.UpdateAction();

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
            if (_isPause) return;

            Vector3 mousePosition = Input.mousePosition;
            for (int i = 0; i < _clicker.ClickCount; i++)
            {   
                IncreasePoint(_clicker.ClickValue);
                ShowAddPointValue(_clicker.ClickValue, mousePosition);
            }
        }

        // 自動クリックの処理
        private void AutoClickClickerBtn()
        {
            if (!_isPlay) return;
            if (_isPause) return;

            Vector3 mousePosition = _uiManager.GetButton(CLICKER_BUTTON).transform.position;
            for (int i = 0; i < _clicker.ClickCount; i++)
            {   
                IncreasePoint(_clicker.ClickValue);
                ShowAddPointValue(_clicker.ClickValue, mousePosition);
            }
        }

        // 増加値の表示
        private void ShowAddPointValue(int point, Vector3 mousePosition)
        {
            ShowValueObject showValueObject = Instantiate(
                _showValueObjectPrefab, mousePosition, Quaternion.identity, _showValueObjectParent
            );
            showValueObject.Initialize();
            showValueObject.SetText("+" + point.ToString());
            showValueObject.SetShowTime(2);
            showValueObject.SetAnimation();
            showValueObject.StartShow();
        }

        // ポーズボタン処理
        private void OnClickPauseBtn()
        {
            if (!_isPlay) return;

            OnPause();

            Dictionary<string, Action> actions = new Dictionary<string, Action>();
            actions.Add(PausePopup.CANCEL_BUTTON_EVENT, OffPause);
            _uiManager.CreateOpenPopup(PAUSE_POPUP, actions, null, false);
        }

        // ポーズ開始処理
        private void OnPause()
        {
            _isPause = true;
        }

        // ポーズ解除処理
        private void OffPause()
        {
            _isPause = false;
        }

        // 強化ポップアップ内の取得・強化ボタン設定
        private void OnClickMagicBtn()
        {
            if (!_isPlay) return;

            OnPause();

            Dictionary<string, Action> actions = new Dictionary<string, Action>();
            actions.Add(PausePopup.CANCEL_BUTTON_EVENT, OffPause);
            _uiManager.CreateOpenPopup(Magic_POPUP, actions, (p) => {
                MagicPopup popup = (MagicPopup)p;
                foreach (MagicUnit unit in _magicUnitList)
                {
                    // 魔法強化アイコンの生成
                    MagicIcon icon = Instantiate(_magicIconPrefab, Vector3.zero, Quaternion.identity);
                    icon.Initialize();

                    // 魔法強化アイコンの描画設定
                    icon.SetNameText(unit.MagicModel.MagicName);
                    icon.SetLevelText(unit.Level);
                    icon.SetConsumptionPointText(unit.ConsumptionPoint);
                    icon.SetGetButtonActive(!unit.GetFlag);
                    icon.SetMagicButtonActive(unit.GetFlag);
                    icon.SetGrayOutActive(_point < unit.ConsumptionPoint);

                    // 取得ボタン押下時の処理
                    icon.SetGetButtonEvent(
                        () => {
                            if (_point >= unit.ConsumptionPoint)
                            {
                                // ポイントの消費
                                IncreasePoint(-unit.ConsumptionPoint);

                                // 魔法習得
                                unit.Learn();

                                // 魔法強化アイコンの描画更新
                                UpdateMagicIconView();
                            }
                            else
                            {
                                icon.SetGrayOutActive(true);
                            }
                        }
                    );

                    // 強化ボタン押下時の処理
                    icon.SetMagicButtonEvent(
                        () => {
                            if (_point >= unit.ConsumptionPoint)
                            {
                                // ポイントの消費
                                IncreasePoint(-unit.ConsumptionPoint);

                                // 魔法レベルアップ
                                unit.LevelUp();

                                // 魔法強化アイコンの描画更新
                                UpdateMagicIconView();
                            }
                            else
                            {
                                icon.SetGrayOutActive(true);
                            }
                        }
                    );
                    popup.AddContent(icon.gameObject);
                    unit.MagicIcon = icon;
                }
            }, false);
        }

        // 強化ポップアップ内の魔法強化アイコンの描画更新
        private void UpdateMagicIconView()
        {
            foreach (MagicUnit unit in _magicUnitList)
            {
                if (unit.MagicIcon != default && unit.MagicIcon != null)
                {
                    MagicIcon icon = unit.MagicIcon;
                    icon.SetNameText(unit.MagicModel.MagicName);
                    icon.SetLevelText(unit.Level);
                    icon.SetConsumptionPointText(unit.ConsumptionPoint);
                    icon.SetGetButtonActive(!unit.GetFlag);
                    icon.SetMagicButtonActive(unit.GetFlag);
                    icon.SetGrayOutActive(_point < unit.ConsumptionPoint);
                }
            }
        }

        // クリッカーユニットの初期化
        private void InitializeClickerUnit()
        {
            _clicker = new ClickerUnit();
            _clicker.Initialize();

            updateActionCtrl = new UpdateActionController();
            updateActionCtrl.Initialize();

            // TODO 仮実装
            _clicker.ClickValue = 20;
            _clicker.TimeValue = 1;

            // TODO 仮実装 一定間隔で自動クリック
            updateActionCtrl.AddUpdateAction(
                new UpdateActionData(){
                    progressTime = 0f, actionTime = 1f, action = AutoClickClickerBtn, actionType = UpdateActionType.ROOP, count = 0
                }
            );
        }

        // ---------- protected関数 ---------

        // データ設定
        protected override void InitializeData()
        {
            _isPause = false;

            // TODO 仮実装
            _magicModelList = new List<MagicModel>(){
                new MagicModel(){MagicName = "魔法の聖水", ConsumptionPoint = 50, EffectType = EffectType.ADD_CLICK_VALUE},
                new MagicModel(){MagicName = "精神と時の魔法", ConsumptionPoint = 50, EffectType = EffectType.ADD_TIME_VALUE},
                new MagicModel(){MagicName = "自律型ステッキ", ConsumptionPoint = 100, EffectType = EffectType.ADD_MAGIC_VALUE},
                new MagicModel(){MagicName = "マジカルフィンガー", ConsumptionPoint = 100, EffectType = EffectType.AUTO_CLICK},
            };

            // 魔法ユニットの初期化
            _magicUnitList = new List<MagicUnit>();
            foreach (MagicModel model in _magicModelList)
            {
                MagicUnit unit = new MagicUnit();
                unit.Initialize(model);
                _magicUnitList.Add(unit);
            }

            // クリッカーユニットの初期化
            InitializeClickerUnit();
        }

        // UIボタンの設定
        protected override void InitializeUI()
        {
            // クリッカーボタンの処理設定
            _uiManager.SetButtonEvent(CLICKER_BUTTON, OnClickClickerBtn);

            // ポーズボタンの処理設定
            _uiManager.SetButtonEvent(PAUSE_BUTTON, OnClickPauseBtn);

            // 進化ボタンの処理設定
            _uiManager.SetButtonEvent(Magic_BUTTON, OnClickMagicBtn);
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


