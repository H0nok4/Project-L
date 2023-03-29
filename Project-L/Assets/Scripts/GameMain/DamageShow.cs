using System.Collections;
using System.Collections.Generic;
using System.Net;
using DG.Tweening;
using UnityEngine;


public class DamageShow : MonoBehaviour
{
    public Vector3 WorldPosition;

    public Vector3 ScreenPosition;

    public bool Active;

    public Vector2 GUIPosition;

    //文本宽度
    public float ContentWidth = 100;
    //文本高度
    public float ContentHeight = 50;

    public float Value ;

    void Start()
    {
        Active = true;
        CaculatePosition();
        transform.DOMove(new Vector3(0, 0.5f, 0), 0.7f);
        StartCoroutine(LifeTime());
    }

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(0.7f);
        Active = false;
        Destroy(this.gameObject);//后面要弄对象池
    }

    void CaculatePosition()
    {
        WorldPosition = transform.position;
        ScreenPosition = Camera.main.WorldToScreenPoint(WorldPosition);
        GUIPosition = new Vector2(ScreenPosition.x, Screen.height - ScreenPosition.y);
    }

    void Update() {
        CaculatePosition();
    }

    public void OnGUI()
    {
        if (!Active && ScreenPosition.z > 0)
        {
            
         return;   
        }

        GUI.color = Color.red;
        GUI.Label(new Rect(GUIPosition.x, GUIPosition.y, ContentWidth, ContentHeight), Value.ToString());
    }
}
