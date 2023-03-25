using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Skill;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Skill
{
    [CreateAssetMenu(fileName = "New SkillBase", menuName = "Create/Skill", order = 0)]
    public class SkillBase : ScriptableObject {
        /// <summary>
        /// 技能类型，可能会有属性影响
        /// </summary>
        public SkillType Type;
        /// <summary>
        /// 技能总时间
        /// </summary>
        public float TotalTime;

        /// <summary>
        /// 硬直区间
        /// </summary>
        public Range FrozenTime;

        /// <summary>
        /// 事件
        /// </summary>
        [TableList]
        public List<SkillEvent> Events;

    }
}

