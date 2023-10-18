using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pachinko.Machine;
using ShunLib.Controller.InputKey;

namespace ShunLib.Demo.Pachinko
{
    public class DemoPachinkoScene : MonoBehaviour
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [Header("デモ用パチンコ")]
        [SerializeField] public PachinkoMachine pachinkoPrefab = default;

        [Header("操作用キーコントローラ")]
        [SerializeField] public InputKeyController keyController = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------

        void Start()
        {
            Initialize();
        }

        // ---------- Public関数 ----------
        // ---------- Private関数 ----------

        // 初期化
        private void Initialize()
        {
            InitKeyController();
            CreatePachinko();
        }

        // キーコントローラの初期化
        private void InitKeyController()
        {
            keyController.Initialize();
            keyController.EnableKeyCtrl = true;
        }

        // パチンコ生成
        private void CreatePachinko()
        {
            PachinkoMachine pachinko = Instantiate(pachinkoPrefab);
            if (pachinko.resource == default) return;
            pachinko.InitializeEndCallback = () => {
                pachinko.SetKeyController(keyController);
                pachinko.StartGame(2000);
            };
        }

        // ---------- protected関数 ---------
        // ---------- デバッグ用関数 ---------
    }
}

