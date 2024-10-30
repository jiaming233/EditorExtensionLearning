using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class GUIContentAndGUIStyleExample : EditorWindow
{
    [MenuItem("EditorExtensions/02.IMGUI/02.Open GUIContentAndGUIStyleExample")]
    static void OpenGUIContentAndGUIStyleExample()
    {
        GetWindow<GUIContentAndGUIStyleExample>().Show();
    }

    enum Mode
    {
       GUIContent,
       GUIStyle
    }

    private Mode mMode;

    private GUIStyle mBoxStype = "box";
    private Lazy<GUIStyle> mFontStype = new Lazy<GUIStyle>(()=>
    {
        return new GUIStyle("label");
    });

    private void OnEnable()
    {
        mFontStype.Value.fontSize = 30;
        mFontStype.Value.fontStyle = FontStyle.BoldAndItalic;
    }

    private void OnGUI()
    {
        mMode = (Mode)GUILayout.Toolbar((int)mMode, Enum.GetNames(typeof(Mode)));

        if (mMode == Mode.GUIContent)
        {
            GUILayout.Label("Label");
            GUILayout.Label(new GUIContent("Label"));
            GUILayout.Label(new GUIContent("Label", Texture2D.grayTexture));
            GUILayout.Label(new GUIContent("Label", Texture2D.whiteTexture, "Label Tooltip"));
        }
        else if (mMode == Mode.GUIStyle)
        {
            GUILayout.Label("Style of default");
            GUILayout.Label("Style of box", mBoxStype);
            GUILayout.Label("Style font", mFontStype.Value);
        }
    }
}
