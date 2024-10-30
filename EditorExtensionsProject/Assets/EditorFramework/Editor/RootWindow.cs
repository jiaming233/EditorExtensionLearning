using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using EditorExtensions;

namespace EditorFramework
{
    /// <summary>
    /// �Զ�ʶ�𴰿ڿ��
    /// ���Ʊ����CustomEditorWindowAttribute�Ĵ���
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
            //��ȡ��ǰ����������EditorWindow������
            //����ʾ�Զ��崰��
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