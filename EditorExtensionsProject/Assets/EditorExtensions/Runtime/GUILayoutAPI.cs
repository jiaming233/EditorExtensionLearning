using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorExtensions
{
    public class GUILayoutAPI
    {
        private string mTextFieldValue;
        private string mTextAreaValue;
        private string mPasswordFieldValue = string.Empty;
        private Vector2 mScrollPosition;
        private bool mToggleValue;
        private float mSliderValue;
        private int mToolbarIndex;
        private int mSelectionGridIndex;

        /// <summary>
        /// GUILayout常用组件
        /// </summary>
        public void Draw()
        {
            GUILayout.Label("Label: Hello IMGUI");

            GUILayout.Space(10);

            //使用样式
            GUILayout.BeginVertical("box");
            {
                mScrollPosition = GUILayout.BeginScrollView(mScrollPosition);
                {
                    // {}代码块使层级结构更清晰
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
                        // mPasswordFieldValue没有默认值会报空指针异常
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
                        if (GUILayout.RepeatButton("Repeat Button", GUILayout.Width(100), GUILayout.Height(100)))
                        {
                            Debug.Log("Repeat Button");
                        }
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("Toggle");
                        //使label左对齐 toggle右对齐
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
                        mSliderValue = GUILayout.VerticalSlider(mSliderValue, 0, 1, GUILayout.MinHeight(200));
                        GUILayout.FlexibleSpace();
                    }
                    GUILayout.EndHorizontal();

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
    }
}