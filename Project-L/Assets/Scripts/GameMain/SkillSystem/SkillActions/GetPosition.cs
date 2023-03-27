using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skill {
    /// <summary>
    /// 根据传入的Transform返回返回位置
    /// </summary>
    public class GetPosition : SkillActionBase
    {
        public GetPositionType Type;
    }

    public enum GetPositionType : byte
    {
        Center
    }

}
