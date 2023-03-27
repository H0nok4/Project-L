using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skill {
    public class GetPosition : SkillActionBase
    {
        public GetPositionType Type;
    }

    public enum GetPositionType : byte
    {
        Center
    }

}
