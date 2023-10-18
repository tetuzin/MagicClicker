using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Manager.Audio;
using ShunLib.UI.Cutin;
using ShunLib.Adv.Model;
using ShunLib.UI.Message_Window;

namespace Pachinko.Cutin.Message
{
    public class MessageCutin : BaseCutin
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("メッセージウィンドウ1")]
        [SerializeField] protected MessageWindow messageWindow_1 = default;

        [Header("メッセージウィンドウ2")]
        [SerializeField] protected MessageWindow messageWindow_2 = default;

        [Header("メッセージウィンドウ3")]
        [SerializeField] protected MessageWindow messageWindow_3 = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------

        private AdvMessageModel _messageModel_1 = default;
        private AdvMessageModel _messageModel_2 = default;
        private AdvMessageModel _messageModel_3 = default;
        private Action _showMessage1Callback = default;
        private Action _showMessage2Callback = default;
        private Action _showMessage3Callback = default;

        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------

        // 初期化
        public override void Initialize()
        {
            base.Initialize();
            _messageModel_1 = default;
            _messageModel_2 = default;
            _messageModel_3 = default;
            messageWindow_1.Initialize();
            messageWindow_2.Initialize();
            messageWindow_3.Initialize();
        }

        // AudioManagerの設定
        public void SetAudioManager(AudioManager audioManager)
        {
            messageWindow_1.SetAudioManager(audioManager);
            messageWindow_2.SetAudioManager(audioManager);
            messageWindow_3.SetAudioManager(audioManager);
        }

        // カットイン表示
        public override async Task Show(Action callback = null)
        {
            if (!_isShow)
            {
                _isShow = true;
                SetActive(true);

                // メッセージ１を表示
                if (_messageModel_1 != default && _messageModel_1 != default)
                {
                    messageWindow_1.ShowMessageWindow(_showMessage1Callback);
                    await messageWindow_1.SetMessage(_messageModel_1);
                    await messageWindow_1.PlayMessage();

                    // メッセージ２を表示
                    if (_messageModel_2 != default && _messageModel_2 != default)
                    {
                        messageWindow_2.ShowMessageWindow(_showMessage2Callback);
                        await messageWindow_2.SetMessage(_messageModel_2);
                        await messageWindow_2.PlayMessage();

                        // メッセージ３を表示
                        if (_messageModel_3 != default && _messageModel_3 != default)
                        {
                            messageWindow_1.HideMessageWindow();
                            messageWindow_2.HideMessageWindow();

                            await Task.Delay(1000);

                            messageWindow_3.ShowMessageWindow(_showMessage3Callback);
                            await messageWindow_3.SetMessage(_messageModel_3);
                            await messageWindow_3.PlayMessage();
                            await Task.Delay(1000);

                            messageWindow_3.HideMessageWindow(() => {
                                Hide();
                            });
                        }
                        else
                        {
                            messageWindow_1.HideMessageWindow();
                            messageWindow_2.HideMessageWindow(() => {
                                Hide();
                            });
                        }
                    }
                    else
                    {
                        messageWindow_1.HideMessageWindow(() => {
                            Hide();
                        });
                    }
                }
                else
                {
                    Hide();
                }
            }
        }

        // MessageModelの設定
        public void SetAdvModel(AdvModel model)
        {
            if (model.MessageList.Count >= 1) _messageModel_1 = model.MessageList[0];
            if (model.MessageList.Count >= 2) _messageModel_2 = model.MessageList[1];
            if (model.MessageList.Count >= 3) _messageModel_3 = model.MessageList[2];
        }

        // MessageModel_1の設定
        public void SetMessageModel_1(AdvMessageModel model)
        {
            _messageModel_1 = model;
        }

        // MessageModel_2の設定
        public void SetMessageModel_2(AdvMessageModel model)
        {
            _messageModel_2 = model;
        }

        // MessageModel_3の設定
        public void SetMessageModel_3(AdvMessageModel model)
        {
            _messageModel_3 = model;
        }

        // MessageWindow1表示時のコールバック設定
        public void SetShowMessage1Callback(Action callback)
        {
            _showMessage1Callback = callback;
        }

        // MessageWindow2表示時のコールバック設定
        public void SetShowMessage2Callback(Action callback)
        {
            _showMessage2Callback = callback;
        }

        // MessageWindow3表示時のコールバック設定
        public void SetShowMessage3Callback(Action callback)
        {
            _showMessage3Callback = callback;
        }

        // ---------- Private関数 ----------
        // ---------- protected関数 ---------
        // ---------- デバッグ用関数 ---------
    }
}

