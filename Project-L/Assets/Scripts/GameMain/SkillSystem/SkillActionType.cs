using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skill {
    public enum SkillActionType {
        /// <summary>
        /// ���Ŷ���
        /// </summary>
        PlayAnimation,
        /// <summary>
        /// ��ͣ����
        /// </summary>
        StopAnimation,
        /// <summary>
        /// ѡ��Ŀ��
        /// </summary>
        SelectTarget,
        /// <summary>
        /// ����BUFF
        /// </summary>
        AddBuff,
        /// <summary>
        /// �Ƴ�BUFF
        /// </summary>
        RemoveBuff,
        /// <summary>
        /// ����˺�
        /// </summary>
        CauseDamage,
        /// <summary>
        /// ����
        /// </summary>
        Heal,
        /// <summary>
        /// ���һ����־��������
        /// </summary>
        Log
    }

}