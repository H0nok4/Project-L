using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skill {
    public enum SkillActionType {
        /// <summary>
        /// 播放动画
        /// </summary>
        PlayAnimation,
        /// <summary>
        /// 暂停动画
        /// </summary>
        StopAnimation,
        /// <summary>
        /// 选择目标
        /// </summary>
        SelectTarget,
        /// <summary>
        /// 附加BUFF
        /// </summary>
        AddBuff,
        /// <summary>
        /// 移除BUFF
        /// </summary>
        RemoveBuff,
        /// <summary>
        /// 造成伤害
        /// </summary>
        CauseDamage,
        /// <summary>
        /// 治疗
        /// </summary>
        Heal,
        /// <summary>
        /// 输出一条日志，测试用
        /// </summary>
        Log
    }

}