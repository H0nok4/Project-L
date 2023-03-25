using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Skill
{
    [Serializable]
    public class PlayAnimationSkillAction : SkillActionBase
    {
        /// <summary>
        /// 播放的动画名称
        /// </summary>
        public string AnimationName;
    }

}