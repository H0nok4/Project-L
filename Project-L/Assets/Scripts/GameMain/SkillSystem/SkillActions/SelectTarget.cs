using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Skill
{
    public class SelectTarget : SkillActionBase
    {
        public Type SelectType;

        public SelectTargetEntityType EntityType;

        [ShowIf("@this.SelectType != Type.Self")]
        public SelectRangeOffsetType SelectRangeType;

        [ShowIf("@this.SelectType != Type.Self")]
        public Vector3 OffsetCenterPosition;

        [ShowIf("@this.SelectType != Type.Self && this.SelectType != Type.SquareRange")]
        public float RangeLength;

        [ShowIf("@this.SelectType != Type.Self && this.SelectType == Type.SquareRange")]
        public Vector3 SquareSize;

        public enum Type {
            Self,
            SquareRange,
            CubeRange,
            SphereRange,
        }

        public enum SelectRangeOffsetType {
            /// <summary>
            /// ������Ϊ�����ڵ㿪ʼ
            /// </summary>
            FromSelf,
            /// <summary>
            /// ��������ǰ��Ϊ��׼��ƫ�Ƶ�Ϊ���ĵ�
            /// </summary>
            ForwardSelf,
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
        
        public enum SelectTargetEntityType
        {
            Enemy,
            Friendly,
            Same,
            Diff,
            All
        }

    }



}
