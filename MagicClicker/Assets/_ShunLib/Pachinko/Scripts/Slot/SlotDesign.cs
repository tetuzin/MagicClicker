using UnityEngine;
using DG.Tweening;

namespace Pachinko.Slot.Design
{
    public enum SlotAnimState
    {
        Idle = 0,
        Rotate = 1,
        Stop = 2,
        Reach = 3
    }

    public class SlotDesign : MonoBehaviour
    {
        // ---------- 定数宣言 ----------
        // ---------- ゲームオブジェクト参照変数宣言 ----------

        [SerializeField, Tooltip("RectTrans")] protected RectTransform rectTrans = default;
        [SerializeField, Tooltip("CanvasGroup")] protected CanvasGroup canvasGroup = default;
        [SerializeField, Tooltip("図柄値")] protected int value = default;

        // ---------- プレハブ ----------
        // ---------- プロパティ ----------
        // ---------- クラス変数宣言 ----------
        // ---------- インスタンス変数宣言 ----------
        // ---------- Unity組込関数 ----------
        // ---------- Public関数 ----------
        
        // アニメーション再生
        public void PlayAnimation(SlotAnimState animState)
        {
            switch (animState)
            {
                case SlotAnimState.Idle:
                    PlayIdleAnimation();
                    return;
                case SlotAnimState.Rotate:
                    PlayStartAnimation();
                    return;
                case SlotAnimState.Stop:
                    PlayStopAnimation();
                    return;
                case SlotAnimState.Reach:
                    PlayReachAnimation();
                    return;
                default:
                    // Debug.Log("アニメーションなし");
                    return;
            }
        }

        // 透明度の設定
        public void SetAlpha(float alpha)
        {
            canvasGroup.alpha = alpha;
        }

        // フェード
        public void Fade(float alpha, float speed)
        {
            canvasGroup.DOFade(alpha, speed);
        }
        
        // ---------- Private関数 ----------
        // ---------- protected関数 ---------

        // アイドルアニメーション再生
        protected virtual void PlayIdleAnimation()
        {
            // Debug.Log("アイドルアニメーション再生");
        }

        // 開始アニメーション再生
        protected virtual void PlayStartAnimation()
        {
            // Debug.Log("開始アニメーション再生");
        }

        // 停止アニメーション再生
        protected virtual void PlayStopAnimation()
        {
            // Debug.Log("停止アニメーション再生");
        }

        // リーチアニメーション再生
        protected virtual void PlayReachAnimation()
        {
            // Debug.Log("リーチアニメーション再生");
        }
    }
}


