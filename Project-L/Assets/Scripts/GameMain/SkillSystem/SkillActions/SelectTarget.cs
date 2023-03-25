using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Skill
{
    public class SelectTarget : SkillActionBase
    {
        public SelectTargetType SelectType;

        [ShowIf("SelectType", SelectTargetType.Square)]
        public SelectRangeOffsetType SquareSelectRangeType;
        [ShowIf("SelectType", SelectTargetType.CubeRange)]
        public SelectRangeOffsetType CubeSelectRangeType;
        [ShowIf("SelectType", SelectTargetType.SphereRange)]
        public SelectRangeOffsetType SphereRangeType;
        public enum SelectTargetType {
            self,
            Square,
            CubeRange,
            SphereRange,
        }

        public enum SelectRangeOffsetType {
            /// <summary>
            /// ������Ϊ�����ڵ㿪ʼ
            /// </summary>
            FromSelf,
            /// <summary>
            /// ����������ƫ��λ��Ϊ���ĵ㿪ʼ
            /// </summary>
            FromOffsetSelf,
            /// <summary>
            /// ��һ����������ѡȡ�㿪ʼ
            /// </summary>
            FromMouseSelectPosition,
            /// <summary>
            /// ���浱ǰ���ѡ��λ�ÿ�ʼ
            /// </summary>
            FromMouseInputPosition
        }

    }



}
