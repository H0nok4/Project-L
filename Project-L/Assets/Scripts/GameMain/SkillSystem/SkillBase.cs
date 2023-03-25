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
        /// �������ͣ����ܻ�������Ӱ��
        /// </summary>
        public SkillType Type;
        /// <summary>
        /// ������ʱ��
        /// </summary>
        public float TotalTime;

        /// <summary>
        /// Ӳֱ����
        /// </summary>
        public Range FrozenTime;

        /// <summary>
        /// �¼�
        /// </summary>
        [TableList]
        public List<SkillEvent> Events;

    }
}

