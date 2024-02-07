using System;
using UnityEditor;
using UnityEngine;

/// <summary>
/// IMGUI(Immediately Mode GUI) ��ʱģʽ��GUI��Ⱦ
/// �ṩ4��API
/// GUILayout �Զ����֣�֧������ʱ
/// GUI
/// EditorGUILayout
/// EditorGUI ��Ҫ�������ꡢ�ߴ磬��֧�ֱ༭��
/// </summary>
public class GUILayoutExample : EditorWindow
{
    [MenuItem("EditorExtensions/02.IMGUI/01.Open GUILayoutExample")]
    static void OpenGUILayoutExample()
    {
        //API:�򿪴���
        GetWindow<GUILayoutExample>().Show();
    }

    enum PageId
    {
        Basic,
        Other
    }

    private PageId mCurrentPageId;

    /// <summary>
    /// ��OnGUI�����н��л���
    /// </summary>
    private void OnGUI()
    {
        // ���״����ܣ�ToolBar + Enum + ��Ⱦ����
        mCurrentPageId = (PageId)GUILayout.Toolbar((int)mCurrentPageId, Enum.GetNames(typeof(PageId)));

        if (mCurrentPageId == PageId.Basic)
        {
            Basic();
        }
        else if (mCurrentPageId == PageId.Other)
        {

        }
    }

    #region Basic
    private string mTextFieldValue;
    private string mTextAreaValue;
    private string mPasswordFieldValue = string.Empty;
    private Vector2 mScrollPosition;
    private bool mToggleValue;
    private float mSliderValue;
    private int mToolbarIndex;
    private int mSelectionGridIndex;

    /// <summary>
    /// GUILayout�������
    /// </summary>
    void Basic()
    {
        GUILayout.Label("Label: Hello IMGUI");

        GUILayout.Space(10);

        //ʹ����ʽ
        GUILayout.BeginVertical("box");
        {
            mScrollPosition = GUILayout.BeginScrollView(mScrollPosition);
            {
                // {}�����ʹ�㼶�ṹ������
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("TextField");
                    mTextFieldValue = GUILayout.TextField(mTextFieldValue);
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("TextArea");
                    mTextAreaValue = GUILayout.TextArea(mTextAreaValue);
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("PasswordField");
                    // mPasswordFieldValueû��Ĭ��ֵ�ᱨ��ָ���쳣
                    mPasswordFieldValue = GUILayout.PasswordField(mPasswordFieldValue, '*');
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Button");
                    if (GUILayout.Button("Button", GUILayout.MinWidth(50), GUILayout.MinHeight(50), GUILayout.MaxWidth(150), GUILayout.MaxHeight(150)))
                    {
                        Debug.Log("Button");
                    }
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Repeat Button");
                    if (GUILayout.RepeatButton("Repeat Button", GUILayout.Width(150), GUILayout.Height(150)))
                    {
                        Debug.Log("Repeat Button");
                    }
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Toggle");
                    //ʹlabel����� toggle�Ҷ���
                    GUILayout.FlexibleSpace();
                    mToggleValue = GUILayout.Toggle(mToggleValue, "Toggle");
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Box");
                    GUILayout.Box("AutoLayout Box");
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("HorizontalSlider");
                    mSliderValue = GUILayout.HorizontalSlider(mSliderValue, 0, 1);
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("VerticalSlider");
                    mSliderValue = GUILayout.VerticalSlider(mSliderValue, 0, 1);
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginArea(new Rect(0, 0, 100, 100), "1");
                {

                }
                GUILayout.EndArea();

                GUILayout.Window(1, new Rect(0, 0, 100, 100), id =>
                {
                }, "2");

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Toolbar");
                    mToolbarIndex = GUILayout.Toolbar(mToolbarIndex, new[] { "1", "2", "3" });
                }
                GUILayout.EndHorizontal();

                GUILayout.Space(20);

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("SelectionGrid");
                    mSelectionGridIndex = GUILayout.SelectionGrid(mSelectionGridIndex, new[] { "1", "2", "3", "4", "5" }, 3);
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndScrollView();
        }
        GUILayout.EndVertical();
    }
    #endregion
}