using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Utils.Random;

using Pachinko.Model;
using Pachinko.Dict;
using Pachinko.Const;

namespace Pachinko.Controller.NoticeDirection
{
    public class NoticeDirectionController : MonoBehaviour
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------
        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------

        private NoticeDirectionTable _noticeDirectionTable = default;

        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------

        // 初期化
        public void Initialize(NoticeDirectionTable noticeDirectionTable)
        {
            _noticeDirectionTable = noticeDirectionTable;
        }

        // 予告演出を返す
        public NoticeDirectState GetNoticeDirectState(ValueState valueState = ValueState.NONE)
        {
            NoticeDirectState noticeDirectState = NoticeDirectState.NONE;

            NoticeDirectStateTable noticeDirectStateTable = _noticeDirectionTable.GetValue(valueState);

            // 指定スロット状態の予告演出出現確立の分母を算出
            int total = 0;
            foreach (NoticeDirectState state in noticeDirectStateTable.GetKeyList())
            {
                total += noticeDirectStateTable.GetValue(state);
            }

            // ランダムで予告演出を決定
            int value = RandomUtils.GetRandomValue(total);
            int addValue = 0;
            foreach (NoticeDirectState state in noticeDirectStateTable.GetKeyList())
            {
                addValue += noticeDirectStateTable.GetValue(state);
                if (value <= addValue)
                {
                    return state;
                }
            }

            return noticeDirectState;
        }

        // ---------- Private関数 ----------
        // ---------- protected関数 ---------
        // ---------- デバッグ用関数 ---------
    }
}


