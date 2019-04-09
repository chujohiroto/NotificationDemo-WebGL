﻿/*
 * Unity標準のFPSはあまり当てにならないので自作
 * 
 * 下記のリンクより一部利用
 * https://wiki.unity3d.com/index.php/FramesPerSecond
 */

using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    [SerializeField]
    Color m_TextColor;
    float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = m_TextColor;
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}