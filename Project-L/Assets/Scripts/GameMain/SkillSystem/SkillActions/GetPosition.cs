using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skill {
    /// <summary>
    /// ���ݴ����Transform���ط���λ��
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
