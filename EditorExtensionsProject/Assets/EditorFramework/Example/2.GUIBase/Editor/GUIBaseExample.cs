using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorFramework
{

    [CustomEditorWindow(2)]
    public class GUIBaseExample : EditorWindow
    {
        public class Label : GUIBase
        {
            private string mText;
            public Label(string text)
            {
                mText = text;
            }

            public override void OnGUI(Rect position)
            {
                GUILayout.Label(mText);
            }

            protected override void OnDisposed()
            {
                mText = null;
            }
        }

        private Label mLable = new Label("123");
        private Label mLable2 = new Label("456");

        private void OnGUI()
        {
            mLable.OnGUI(default);
            mLable2.OnGUI(default);
        } 
    }
}