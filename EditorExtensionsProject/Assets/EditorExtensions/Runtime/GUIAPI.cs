using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorExtensions
{
    public class GUIAPI
    {
        private Rect mLabelRect = new Rect(20, 60, 200, 20);
        private Rect mTextFieldRect = new Rect(20, 90, 200, 20);
        private Rect mTextAreaRect = new Rect(20, 120, 200, 100);
        private Rect mPasswordFieldRect = new Rect(20, 230, 200, 20);
        private Rect mButtonRect = new Rect(20, 260, 200, 20);
        private Rect mRepeatButtonRect = new Rect(20, 290, 200, 20);
        private Rect mToggleRect = new Rect(20, 320, 200, 20);
        private Rect mToolbarRect = new Rect(20, 350, 400, 20);
        private Rect mBoxRect = new Rect(20, 380, 100, 100);
        private Rect mScrollViewRect = new Rect(20, 60, 500, 400);
        private Rect mHorizontalSliderRect = new Rect(20, 490, 200, 20);
        private Rect mVerticalSliderRect = new Rect(20, 520, 20, 200);
        private Rect mGroupRect = new Rect(20, 730, 200, 20);
        private Rect mWindowRect = new Rect(20, 500, 200, 100);

        private string mTextFieldValue;
        private string mTextAreaValue;
        private string mPasswordFieldValue = string.Empty;

        private bool mToggleValue;
        private int mToolbarIndex;

        private Vector2 mScrollPosition;

        private float mHorizontalSliderValue;
        private float mVerticalSliderValue;

        public void Draw()
        {
            mScrollPosition = GUI.BeginScrollView(mScrollViewRect, mScrollPosition, new Rect(0, 0, 500, 1000));
            {
                GUI.Label(mLabelRect, "Label: Hello GUI API");
                mTextFieldValue = GUI.TextField(mTextFieldRect, mTextFieldValue);
                mTextAreaValue = GUI.TextArea(mTextAreaRect, mTextAreaValue);
                mPasswordFieldValue = GUI.PasswordField(mPasswordFieldRect, mPasswordFieldValue, '*');

                if (GUI.Button(mButtonRect, "Button"))
                {
                    Debug.Log("Button");
                }

                if (GUI.RepeatButton(mRepeatButtonRect, "RepeatButton"))
                {
                    Debug.Log("RepeatButton");
                }

                mToggleValue = GUI.Toggle(mToggleRect, mToggleValue, "Toggle");

                mToolbarIndex = GUI.Toolbar(mToolbarRect, mToolbarIndex, new string[] { "1", "2", "3" });

                GUI.Box(mBoxRect, "Box");

                mHorizontalSliderValue = GUI.HorizontalSlider(mHorizontalSliderRect, mHorizontalSliderValue, 0, 1);
                mVerticalSliderValue = GUI.VerticalSlider(mVerticalSliderRect, mVerticalSliderValue, 0, 1);

                GUI.BeginGroup(mGroupRect, "Group");
                {

                }
                GUI.EndGroup();
            }
            GUI.EndScrollView();


            mWindowRect = GUI.Window(1, mWindowRect, DoMyWindow, "窗口");
        }

        void DoMyWindow(int windowID)
        {
            //参数：可拖拽区域
            GUI.DragWindow(new Rect(0, 0, 10000, 20));

            if (GUI.Button(new Rect(10, 20, 100, 20), "Hello World"))
            {
                Debug.Log("Got a click");
            }
        }
    }
}