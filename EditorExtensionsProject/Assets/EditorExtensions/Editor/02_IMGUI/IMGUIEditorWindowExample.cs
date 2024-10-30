using System;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{

    /// <summary>
    /// IMGUI(Immediately Mode GUI) 即时模式的GUI渲染
    /// 提供4种API
    /// GUILayout 自动布局，支持运行时
    /// GUI
    /// EditorGUILayout
    /// EditorGUI 需要设置坐标、尺寸，仅支持编辑器
    /// </summary>
    public class IMGUIEditorWindowExample : EditorWindow
    {
        [MenuItem("EditorExtensions/02.IMGUI/01.Open IMGUIEditorWindowExample")]
        static void OpenIMGUIEditorWindowExample()
        {
            //API:打开窗口
            GetWindow<IMGUIEditorWindowExample>().Show();
        }

        enum APIMode
        {
            GUILayout,
            GUI,
            EditorGUI,
            EditorGUILayout,
            Other
        }

        enum PageId
        {
            Basic,
            Enabled,
            Rotate,
            Scale,
            Color
        }

        private APIMode mCurrentAPIMode;

        private PageId mCurrentPageId;

        private GUILayoutAPI mGUILayoutAPI = new GUILayoutAPI();

        private GUIAPI mGUIAPI = new GUIAPI();

        private EditorGUIAPI mEditorGUIAPI = new EditorGUIAPI();

        private EditorGUILayoutAPI mEditorGUILayoutAPI = new EditorGUILayoutAPI();

        /// <summary>
        /// 在OnGUI方法中进行绘制
        /// </summary>
        private void OnGUI()
        {
            mCurrentAPIMode = (APIMode)GUILayout.Toolbar((int)mCurrentAPIMode, Enum.GetNames(typeof(APIMode)));

            if(mCurrentAPIMode != APIMode.Other)
            {
                // 简易窗体框架：ToolBar + Enum + 渲染方法
                mCurrentPageId = (PageId)GUILayout.Toolbar((int)mCurrentPageId, Enum.GetNames(typeof(PageId)));

                if (mCurrentPageId == PageId.Basic)
                {
                    Basic();
                }
                else if (mCurrentPageId == PageId.Enabled)
                {
                    Enabled();
                }
                else if (mCurrentPageId == PageId.Rotate)
                {
                    Rotate();
                }
                else if (mCurrentPageId == PageId.Scale)
                {
                    Scale();
                }
                else if (mCurrentPageId == PageId.Color)
                {
                    Color();
                }      
            }
            else
            {
                GUILayout.BeginArea(new Rect(0, 50, 100, 100), "1");
                {

                }
                GUILayout.EndArea();

                BeginWindows();
                GUILayout.Window(1, new Rect(0, 120, 100, 50), id =>
                {
                    if (GUILayout.Button("Hello World"))
                    {
                        Debug.Log("Got a click");
                    }
                }, "2");
                EndWindows();
            }        
        }

        void Basic()
        {
            if (mCurrentAPIMode == APIMode.GUILayout)
            {
                //渲染方法放到类里去实现
                mGUILayoutAPI.Draw();
            }
            else if (mCurrentAPIMode == APIMode.GUI)
            {
                mGUIAPI.Draw();
            }
            else if (mCurrentAPIMode == APIMode.EditorGUI)
            {
                mEditorGUIAPI.Draw();
            }
            else if (mCurrentAPIMode == APIMode.EditorGUILayout)
            {
                mEditorGUILayoutAPI.Draw();
            }
        }

        #region Enabled
        private bool mEnableInteractive = true;

        void Enabled()
        {
            mEnableInteractive = GUILayout.Toggle(mEnableInteractive, "是否可交互");

            if (GUI.enabled != mEnableInteractive)
                GUI.enabled = mEnableInteractive;

            Basic();
        }
        #endregion

        #region Rotate
        private bool mOpenRotateEffect = false;

        void Rotate()
        {
            mOpenRotateEffect = GUILayout.Toggle(mOpenRotateEffect, "是否开启旋转效果");

            if (mOpenRotateEffect)
            {
                //窗口左上角(0,0) 
                GUIUtility.RotateAroundPivot(45, Vector2.zero/*Vector2.one * 200*/);
            }

            Basic();
        }
        #endregion

        #region Scale
        private bool mOpenScaleEffect = false;

        void Scale()
        {
            mOpenScaleEffect = GUILayout.Toggle(mOpenScaleEffect, "是否开启缩放效果");

            if (mOpenScaleEffect)
            {
                GUIUtility.ScaleAroundPivot(Vector2.one * 0.5f, Vector2.one * 200);
            }

            Basic();
        }
        #endregion

        #region Color
        private bool mOpenColorEffect = false;

        void Color()
        {
            mOpenColorEffect = GUILayout.Toggle(mOpenColorEffect, "变换颜色");

            if (mOpenColorEffect)
            {
                //color = backgroundColor 背景颜色 + contentColor 文本颜色
                GUI.color = UnityEngine.Color.yellow;
                //GUI.backgroundColor = UnityEngine.Color.yellow;
                //GUI.contentColor = UnityEngine.Color.green;
            }

            Basic();
        }
        #endregion
    }
}