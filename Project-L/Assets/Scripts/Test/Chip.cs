using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Chip : MonoBehaviour {
    public int Index;

    public Vector3 targetPosition;

    private void Update() {
        if (targetPosition != Vector3.zero) {
            this.transform.Rotate(new Vector3(3,0,0), 90f * Time.deltaTime,Space.World);
        }
    }

    public void CRotateTo(Vector3 center) {
        targetPosition = center;

    }
}
