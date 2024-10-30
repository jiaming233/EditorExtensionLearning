using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

namespace EditorExtensions
{
    public class EditorGUILayoutAPI
    {
        private bool mToggleGroupEnabledValue;
        private bool[] mToggleValues = new bool[3] { true, true, true };

        private BuildTargetGroup mBuildTargetGroup;

        private AnimBool mFadeGroupValue = new AnimBool();

        private AnimationCurve mCurveValue = new AnimationCurve();

        private float mMinValue;
        private float mMaxValue;

        public void Draw()
        {
            mToggleGroupEnabledValue = EditorGUILayout.BeginToggleGroup("ToggleGroup", mToggleGroupEnabledValue);
            {
                mToggleValues[0] = EditorGUILayout.Toggle("0", mToggleValues[0]);
                mToggleValues[1] = EditorGUILayout.Toggle("1", mToggleValues[1]);
                mToggleValues[2] = EditorGUILayout.Toggle("2", mToggleValues[2]);
            }
            EditorGUILayout.EndToggleGroup();

            mBuildTargetGroup = EditorGUILayout.BeginBuildTargetSelectionGrouping();
            {
                if(mBuildTargetGroup == BuildTargetGroup.Standalone)
                {
                    EditorGUILayout.HelpBox("Standalone", MessageType.Info);
                }
            }
            EditorGUILayout.EndBuildTargetSelectionGrouping();


            mFadeGroupValue.target = EditorGUILayout.Toggle("Fade", mFadeGroupValue.target);
            if(EditorGUILayout.BeginFadeGroup(mFadeGroupValue.faded))
            {
                EditorGUILayout.LabelField("Fade Label");
            }
            EditorGUILayout.EndFadeGroup();


            mCurveValue = EditorGUILayout.CurveField("Curve", mCurveValue);

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField(mMinValue.ToString(), GUILayout.Width(100));
                EditorGUILayout.MinMaxSlider(ref mMinValue, ref mMaxValue, 0, 10);
                EditorGUILayout.LabelField(mMaxValue.ToString(), GUILayout.Width(100));
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}