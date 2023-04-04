using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipManager : MonoBehaviour {
    public Transform position;

    public List<Chip> chips;

    private void Start() {
        Rotate(position.position);
    }

    public void Rotate(Vector3 pos) {
        Debug.Log("开始旋转");
        foreach (var chip in chips) {
            chip.CRotateTo(pos);
        }
    }
}
