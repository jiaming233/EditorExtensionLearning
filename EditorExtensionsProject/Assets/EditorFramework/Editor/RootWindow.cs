using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using EditorExtensions;

namespace EditorFramework
{
    /// <summary>
    /// 自动识别窗口框架
    /// 绘制标记了CustomEditorWindowAttribute的窗口
    /// </summary>
    public class RootWindow : EditorWindow
    {
        [MenuItem("EditorFramework/Open %#e")]
        static void OpenWindow()
        {
            GetWindow<RootWindow>().Show();
        }

        private IEnumerable<Type> mEditorWindowTypes;

        private void OnEnable()
        {
            //获取当前程序集下所有EditorWindow的子类
            //仅显示自定义窗口
            mEditorWindowTypes = typeof(EditorWindow).GetSubTypesWithClassAttributeInAssembly<CustomEditorWindowAttribute>()
                .OrderBy(type => (type.GetCustomAttributes(typeof(CustomEditorWindowAttribute), true)[0] as CustomEditorWindowAttribute).RenderOrder);

            //foreach (var windowType in mEditorWindowTypes)
            //{
            //    Debug.Log($"{windowType.Name} {windowType.GetCustomAttributes(typeof(CustomEditorWindowAttribute), true)?.Length}");
            //}
        }

        private Vector2 mScrollPosition;

        private void OnGUI()
        {
            mScrollPosition = GUILayout.BeginScrollView(mScrollPosition);
            {
                foreach (var windowType in mEditorWindowTypes)
                {
                    GUILayout.BeginHorizontal("box");
                    {
                        GUILayout.Label(windowType.Name);
                        if (GUILayout.Button("Open", GUILayout.Width(80)))
                        {
                            GetWindow(windowType).Show();
                        }
                    }
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndScrollView();
        }
    }
}