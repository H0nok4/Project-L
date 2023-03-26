using System.Collections;
using System.Collections.Generic;
using Skill;
using UnityEngine;

namespace Skill
{
    public class DamageTarget : SkillActionBase
    {
        public int DamageValue;

        public enum DamageType
        {
            Normal,
            Fire,
            Ice
        }
    }


}
