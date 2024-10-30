using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorExtensions
{
    public class EditorGUIAPI
    {
        private Rect mLabelFieldRect = new Rect(20, 60, 200, 20);
        private Rect mToggleRect = new Rect(20, 90, 200, 20);
        private Rect mIntFieldRect = new Rect(20, 120, 200, 20);

        private Rect mTextFieldRect = new Rect(20, 150, 300, 20);
        private Rect mTextAreaRect = new Rect(20, 180, 300, 50);
        private Rect mPasswordFieldRect = new Rect(20, 240, 300, 20);

        private Rect mDropdownButtonRect = new Rect(20, 270, 200, 20);
        private Rect mToggleLeftRect = new Rect(20, 300, 200, 20);

        private Rect mHelpBoxRect = new Rect(20, 330, 200, 20);

        private Rect mColorRect = new Rect(20, 360, 200, 20);
        private Rect mBoundsRect = new Rect(20, 390, 200, 40);

        private Rect mFoldoutGroupRect = new Rect(20, 440, 300, 20);
        private Rect mMaskRect = new Rect(40, 470, 280, 20);
        private Rect mEnumRect = new Rect(20, 500, 300, 20);

        private Rect mMultiIntRect = new Rect(20, 530, 300, 20);
        private Rect mGradientRect = new Rect(400, 60, 300, 20);

        private Rect mHandleTotalRect = new Rect(400, 90, 300, 20);
        private Rect mHandleLabelRect = new Rect(400, 90, 200, 20);

        private bool mDisabledGroupValue;

        private int mIntFieldValue;
        private string mTextFieldValue;
        private string mTextAreaValue;
        private string mPasswordFieldValue;

        private Color mColorValue;
        private Bounds mBoundsValue;
        private Gradient mGradientValue = new Gradient();

        private int mMaskIndex;

        private bool mFoldoutValue;

        private OPTIONS mEnumValue;

        public enum OPTIONS
        {
            Position = 0,
            Rotation = 1,
            Scale = 2,
        }


        public void Draw()
        {
            EditorGUI.LabelField(mLabelFieldRect, "LabelField: EditorGUI API");

            mDisabledGroupValue = EditorGUI.Toggle(mToggleRect, "Disable Group", mDisabledGroupValue);

            EditorGUI.BeginDisabledGroup(mDisabledGroupValue);
            {
                mIntFieldValue = EditorGUI.IntField(mIntFieldRect, mIntFieldValue);
            }
            EditorGUI.EndDisabledGroup();

            mTextFieldValue = EditorGUI.TextField(mTextFieldRect, "Text Field", mTextFieldValue);

            mTextAreaValue = EditorGUI.TextArea(mTextAreaRect, mTextAreaValue);

            mPasswordFieldValue = EditorGUI.PasswordField(mPasswordFieldRect, "Password", mPasswordFieldValue);

            //鼠标按下时返回true
            if(EditorGUI.DropdownButton(mDropdownButtonRect, new GUIContent("DropdownButton"), FocusType.Native))
            {
                Debug.Log("DropdownButton");
            }

            mDisabledGroupValue = EditorGUI.ToggleLeft(mToggleLeftRect, "Disable Group", mDisabledGroupValue);

            EditorGUI.HelpBox(mHelpBoxRect, "Message", MessageType.Error);

            mColorValue = EditorGUI.ColorField(mColorRect, Color.white);

            mBoundsValue = EditorGUI.BoundsField(mBoundsRect, mBoundsValue);

            mFoldoutValue = EditorGUI.BeginFoldoutHeaderGroup(mFoldoutGroupRect, mFoldoutValue, "Foldout");
            {
                if (mFoldoutValue)
                {
                    mMaskIndex = EditorGUI.MaskField(mMaskRect, "Mask", mMaskIndex, new string[] { "1", "2", "3" });
                }           
            }
            EditorGUI.EndFoldoutHeaderGroup();

            mEnumValue = (OPTIONS)EditorGUI.EnumPopup(mEnumRect, "Enum", mEnumValue);

            EditorGUI.MultiIntField(mMultiIntRect, new GUIContent[] { new GUIContent("1"), new GUIContent("2"), new GUIContent("3") }, new int[] { 1, 2, 3 });

            mGradientValue = EditorGUI.GradientField(mGradientRect, mGradientValue);

            EditorGUI.HandlePrefixLabel(mHandleTotalRect, mHandleLabelRect, new GUIContent("LabelLabelLabelLabelLabelLabelLabelLabel"));
            mIntFieldValue = EditorGUI.IntField(new Rect(420, 120, 200, 20), mIntFieldValue);

        }
    }
}