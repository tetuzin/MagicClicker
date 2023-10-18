using UnityEngine;

using ShunLib.Dict;
using ShunLib.Particle;

using Pachinko.Const;
using Pachinko.Model;
using Pachinko.HoldView.Icon;

namespace Pachinko.Dict
{
    public class PachinkoDictionary : MonoBehaviour{}

    /// PachinkoManager ///
    [System.Serializable]
    public class ReachDirectionTable : TableBase<string, ReachDirectionModel, ReachDirectionPair>{}

    [System.Serializable]
    public class ReachDirectionPair : KeyAndValue<string, ReachDirectionModel>{}

    [System.Serializable]
    public class NoticeDirectionTable : TableBase<ValueState, NoticeDirectStateTable, NoticeDirectionPair>{}

    [System.Serializable]
    public class NoticeDirectionPair : KeyAndValue<ValueState, NoticeDirectStateTable>{}

    [System.Serializable]
    public class NoticeDirectStateTable : TableBase<NoticeDirectState, int, NoticeDirectStatePair>{}

    [System.Serializable]
    public class NoticeDirectStatePair : KeyAndValue<NoticeDirectState, int>{}

    [System.Serializable]
    public class ShowerParticleTable : TableBase<ShowerParticleState, ShowerParticleModel, ShowerParticlePair>{}

    [System.Serializable]
    public class ShowerParticlePair : KeyAndValue<ShowerParticleState, ShowerParticleModel>{}

    /// HoldIcon ///
    [System.Serializable]
    public class HoldIconTable : TableBase<HoldIconState, HoldIcon, HoldIconPair>{}

    [System.Serializable]
    public class HoldIconPair : KeyAndValue<HoldIconState, HoldIcon>{}

    /// FinalBattleChargeIcon ///
    [System.Serializable]
    public class FinalBattleChargeIconModelTable : TableBase<FinalBattleChargeIconState, FinalBattleChargeIconModel, FinalBattleChargeIconModelPair>{}

    [System.Serializable]
    public class FinalBattleChargeIconModelPair : KeyAndValue<FinalBattleChargeIconState, FinalBattleChargeIconModel>{}
}


