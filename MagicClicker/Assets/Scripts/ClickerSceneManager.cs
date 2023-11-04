using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Manager.Game;
using ShunLib.Manager.CommonScene;
using ShunLib.UI.ShowValue;
using ShunLib.Controller.UpdateAction;
using ShunLib.Popup.Simple;

using MagicClicker.Unit;
using MagicClicker.Popup.Pause;
using MagicClicker.Popup.Magic;
using MagicClicker.Popup.NurtureResult;
using MagicClicker.Popup.Nurture;
using MagicClicker.Model.Magic;
using MagicClicker.Model.Character;
using MagicClicker.Unit.Magic;
using MagicClicker.Unit.Character;
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
        // 育成ポップアップ
        private const string NURTURE_POPUP = "NurturePopup";
        // スタートテキストポップアップ
        private const string START_TEXT_POPUP = "StartTextPopup";
        // 魔力充填完了テキストポップアップ
        private const string MAGIC_POWER_TEXT_POPUP = "MagicPowerTextPopup";
        // 育成完了ポップアップ
        private const string NURTURE_RESULT_POPUP = "NurtureResultPopup";
        // ポイント値
        private const string POINT_TEXT = "PointText";
        // 残り時間
        private const string REMAIN_TIME_TEXT = "RemainTimeText";

        // クリック時増加値の基礎値
        private const int BASIC_ADD_CLICK_VALUE = 20;
        // 時間経過による増加値の基礎値
        private const int BASIC_ADD_TIME_VALUE = 0;
        // 一定時間で増加する用定数
        private const string MAGIC_CLICK_KEY = "MagicClickKey";
        // 自動クリック用定数
        private const string AUTO_CLICK_KEY = "AutoClickKey";

        // ステータス1増加させるのに必要なポイント
        private const int STATUS_UP_COST_POINT = 100;

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

        // 育成キャラクターモデル
        private CharacterModel _characterModel = default;
        // 育成キャラクターユニット
        private CharacterUnit _characterUnit = default;
        // クリッカーユニット
        private ClickerUnit _clicker = default;
        // UpdateActionController
        private UpdateActionController updateActionCtrl = default;
        // ゲーム時間
        private float _gameTime = 10f;
        // 経過時間
        private float _progressTime = 0f;
        // ゲーム中フラグ
        private bool _isPlay = false;
        // ポーズ中フラグ
        private bool _isPause = false;
        // ポイント値
        private long _point = 0;
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
        private async void StartGame()
        {
            _uiManager.CreateOpenPopup(START_TEXT_POPUP, isModal:false);
            await Task.Delay(1500);

            _isPlay = true;
            _isPause = false;
        }

        // ゲーム終了
        private async void EndGame()
        {
            _isPlay = false;
            _isPause = false;

            _uiManager.CreateOpenPopup(MAGIC_POWER_TEXT_POPUP, isModal:false);
            await Task.Delay(1500);

            // 育成ポップアップ表示
            _uiManager.CreateOpenPopup(NURTURE_POPUP, isModal:false, popupAction:(p) => {
                NurturePopup popup = (NurturePopup)p;
                popup.SetPointText(_point);

                // たいりょく
                popup.FrameHp.Initialize();
                popup.FrameHp.SetUpButtonEvent(() => {
                    if (_point < STATUS_UP_COST_POINT) return;
                    UpStatusByPoint(StatusType.HP, 1, STATUS_UP_COST_POINT);
                    popup.FrameHp.SetValue(_characterUnit.StatusHp);
                    popup.SetPointText(_point);
                });
                popup.FrameHp.SetDownButtonEvent(() => {
                    if (_characterUnit.StatusHp <= 0) return;
                    UpStatusByPoint(StatusType.HP, -1, -STATUS_UP_COST_POINT);
                    popup.FrameHp.SetValue(_characterUnit.StatusHp);
                    popup.SetPointText(_point);
                });

                // きんりょく
                popup.FramePower.Initialize();
                popup.FramePower.SetUpButtonEvent(() => {
                    if (_point < STATUS_UP_COST_POINT) return;
                    UpStatusByPoint(StatusType.POWER, 1, STATUS_UP_COST_POINT);
                    popup.FramePower.SetValue(_characterUnit.StatusPower);
                    popup.SetPointText(_point);
                });
                popup.FramePower.SetDownButtonEvent(() => {
                    if (_characterUnit.StatusPower <= 0) return;
                    UpStatusByPoint(StatusType.POWER, -1, -STATUS_UP_COST_POINT);
                    popup.FramePower.SetValue(_characterUnit.StatusPower);
                    popup.SetPointText(_point);
                });

                // まりょく
                popup.FrameMagic.Initialize();
                popup.FrameMagic.SetUpButtonEvent(() => {
                    if (_point < STATUS_UP_COST_POINT) return;
                    UpStatusByPoint(StatusType.MAGIC, 1, STATUS_UP_COST_POINT);
                    popup.FrameMagic.SetValue(_characterUnit.StatusMagic);
                    popup.SetPointText(_point);
                });
                popup.FrameMagic.SetDownButtonEvent(() => {
                    if (_characterUnit.StatusMagic <= 0) return;
                    UpStatusByPoint(StatusType.MAGIC, -1, -STATUS_UP_COST_POINT);
                    popup.FrameMagic.SetValue(_characterUnit.StatusMagic);
                    popup.SetPointText(_point);
                });

                // しゅんぱつりょく
                popup.FrameSpeed.Initialize();
                popup.FrameSpeed.SetUpButtonEvent(() => {
                    if (_point < STATUS_UP_COST_POINT) return;
                    UpStatusByPoint(StatusType.SPEED, 1, STATUS_UP_COST_POINT);
                    popup.FrameSpeed.SetValue(_characterUnit.StatusSpeed);
                    popup.SetPointText(_point);
                });
                popup.FrameSpeed.SetDownButtonEvent(() => {
                    if (_characterUnit.StatusSpeed <= 0) return;
                    UpStatusByPoint(StatusType.SPEED, -1, -STATUS_UP_COST_POINT);
                    popup.FrameSpeed.SetValue(_characterUnit.StatusSpeed);
                    popup.SetPointText(_point);
                });

                // ぎじゅつりょく
                popup.FrameTechnic.Initialize();
                popup.FrameTechnic.SetUpButtonEvent(() => {
                    if (_point < STATUS_UP_COST_POINT) return;
                    UpStatusByPoint(StatusType.TECHNIC, 1, STATUS_UP_COST_POINT);
                    popup.FrameTechnic.SetValue(_characterUnit.StatusTechnic);
                    popup.SetPointText(_point);
                });
                popup.FrameTechnic.SetDownButtonEvent(() => {
                    if (_characterUnit.StatusTechnic <= 0) return;
                    UpStatusByPoint(StatusType.TECHNIC, -1, -STATUS_UP_COST_POINT);
                    popup.FrameTechnic.SetValue(_characterUnit.StatusTechnic);
                    popup.SetPointText(_point);
                });

                popup.SetNurtureCompleteBtnEvent(async () => {
                    GameManager.Instance.dataManager.Data.Game.CharacterUnitList.Add(_characterUnit);
                    await GameManager.Instance.dataManager.Save();
                    _uiManager.CreateOpenPopup(NURTURE_RESULT_POPUP, null, (p) => {
                        NurtureResultPopup resultPopup = (NurtureResultPopup)p;
                        resultPopup.SetCharacterName(_characterUnit.Model.Name);
                        resultPopup.SetRank(3);
                        resultPopup.SetScore(12345);
                        resultPopup.SetReturnBtnEvent(() => {
                            // TODO 仮実装
                            Debug.Log("ホームへ戻る");
                        });
                    });
                });
            });
        }

        // ポイント増減
        private void IncreasePoint(long addPoint)
        {
            _point += addPoint;
            _uiManager.SetText(POINT_TEXT, _point.ToString() + "P");
        }

        // ポイントを消費してステータスアップ
        private void UpStatusByPoint(StatusType status, int upValue, long costPoint)
        {
            switch(status)
            {
                case StatusType.HP:
                    _characterUnit.StatusHp += upValue;
                    break;
                case StatusType.POWER:
                    _characterUnit.StatusPower += upValue;
                    break;
                case StatusType.MAGIC:
                    _characterUnit.StatusMagic += upValue;
                    break;
                case StatusType.SPEED:
                    _characterUnit.StatusSpeed += upValue;
                    break;
                case StatusType.TECHNIC:
                    _characterUnit.StatusTechnic += upValue;
                    break;
            }
            IncreasePoint(-costPoint);
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
            // for (int i = 0; i < _clicker.ClickCount; i++)
            // {   
            //     IncreasePoint(_clicker.ClickValue);
            //     ShowAddPointValue(_clicker.ClickValue, mousePosition);
            // }
            IncreasePoint(_clicker.ClickValue);
            ShowAddPointValue(_clicker.ClickValue, mousePosition);
        }

        // 一定時間で値増加の処理
        private void MagicClickClickerBtn(MagicUnit unit)
        {
            if (!_isPlay) return;
            if (_isPause) return;

            Vector3 mousePosition = _uiManager.GetButton(CLICKER_BUTTON).transform.position;
            IncreasePoint(unit.EffectValue);
            ShowAddPointValue(unit.EffectValue, mousePosition);
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

        // 指定魔法効果の効果値合計を取得
        private int GetTotalEffectValue(EffectType type)
        {  
            int value = 0;
            foreach (MagicUnit unit in _magicUnitList)
            {
                if (unit.MagicModel.EffectType == type)
                {
                    value += unit.EffectValue;
                }
            }
            return value;
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
                                UpdateClickerUnit();
                                if (unit.MagicModel.EffectType == EffectType.AUTO_CLICK)
                                {
                                    updateActionCtrl.AddUpdateAction(
                                        AUTO_CLICK_KEY,
                                        new UpdateActionData(){
                                            progressTime = 0f, 
                                            actionTime = GetTotalEffectValue(EffectType.AUTO_CLICK), 
                                            action = AutoClickClickerBtn, 
                                            actionType = UpdateActionType.ROOP, 
                                            count = 0
                                        }
                                    );
                                }

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
                                UpdateClickerUnit();

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

            _clicker.ClickValue = BASIC_ADD_CLICK_VALUE;
            _clicker.TimeValue = BASIC_ADD_TIME_VALUE;
            _clicker.ClickCount = 1;
        }

        private void UpdateClickerUnit()
        {
            _clicker.ClickValue = BASIC_ADD_CLICK_VALUE + GetTotalEffectValue(EffectType.ADD_CLICK_VALUE);
            _clicker.TimeValue = BASIC_ADD_TIME_VALUE + GetTotalEffectValue(EffectType.ADD_TIME_VALUE);
            _clicker.ClickCount = GetTotalEffectValue(EffectType.AUTO_CLICK);
            
            foreach (MagicUnit unit in _magicUnitList)
            {
                if (!unit.GetFlag)
                {
                    continue;
                }
                if (unit.MagicModel.EffectType == EffectType.ADD_MAGIC_VALUE)
                {
                    // 一定時間で値増加
                    updateActionCtrl.AddUpdateAction(
                        unit.MagicModel.MagicName,
                        new UpdateActionData(){
                            progressTime = 0f, 
                            actionTime = unit.ActivateTime, 
                            action = () => {MagicClickClickerBtn(unit);}, 
                            actionType = UpdateActionType.ROOP, 
                            count = 0
                        }
                    );
                }

                if (unit.MagicModel.EffectType == EffectType.AUTO_CLICK)
                {
                    // 自動クリック
                    updateActionCtrl.AddUpdateAction(
                        AUTO_CLICK_KEY,
                        new UpdateActionData(){
                            progressTime = 0f, 
                            actionTime = unit.ActivateTime,  
                            action = AutoClickClickerBtn, 
                            actionType = UpdateActionType.ROOP, 
                            count = 0
                        }
                    );
                }
            }
        }

        // ---------- protected関数 ---------

        // データ設定
        protected override void InitializeData()
        {
            _isPause = false;

            // TODO 仮実装 魔法モデルリストの用意
            _magicModelList = new List<MagicModel>(){
                new MagicModel(){MagicName = "魔法の聖水", ConsumptionPoint = 50, EffectType = EffectType.ADD_CLICK_VALUE, EffectValue = 10},
                new MagicModel(){MagicName = "精神と時の魔法", ConsumptionPoint = 50, EffectType = EffectType.ADD_TIME_VALUE, EffectValue = 1},
                new MagicModel(){MagicName = "自律型ステッキ", ConsumptionPoint = 100, EffectType = EffectType.ADD_MAGIC_VALUE, EffectValue = 10, ActivateTime = 3f},
                new MagicModel(){MagicName = "マジカルフィンガー", ConsumptionPoint = 100, EffectType = EffectType.AUTO_CLICK, EffectValue = 1, ActivateTime = 1f},
            };

            // TODO 仮実装 キャラクターモデルの用意
            _characterModel = new CharacterModel(){
                Name = "テス子",
                Explanation = "開発用キャラクター。",
            };

            // 育成キャラクターユニットの初期化
            _characterUnit = new CharacterUnit();
            _characterUnit.Initialize();
            _characterUnit.Model = _characterModel;

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


