using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ShunLib.Adv.Model;

namespace Pachinko.Resource.Message
{
    // パチンコ会話演出用のデータクラス
    [CreateAssetMenu(fileName = "PachinkoMessageDirect", menuName = "ScriptableObjects/Pachinko/Message")]
    public class PachinkoMessageScriptableObject : ScriptableObject
    {
        [Header("会話演出")]
        [SerializeField, Tooltip("AdvModel")] public AdvModel advModel = new AdvModel();
    }
}


