using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using EditorExtensions;
using System;

namespace EditorFramework
{
    [CustomEditorWindow(3)]
    public class TypeExExample : EditorWindow
    {
        public class DescriptionBase
        {
            public virtual string Description { get; set; }
        }

        public class MyDescription : DescriptionBase
        {
            public override string Description { get; set; } = "√Ë ˆ";
        }

        [MyDesc("TypeB")]
        public class MyDescriptionB : DescriptionBase
        {
            public override string Description { get; set; } = "√Ë ˆB";
        }

        public class MyDescAttribute : Attribute
        {
            public string Type;

            public MyDescAttribute(string type = "")
            {
                Type = type;
            }
        }

        private IEnumerable<Type> descriptionTypes;
        private IEnumerable<Type> descriptionTypesWithAttribute;

        private void OnEnable()
        {
            descriptionTypes = typeof(DescriptionBase).GetSubTypesInAssembly();
            descriptionTypesWithAttribute = typeof(DescriptionBase).GetSubTypesWithClassAttributeInAssembly<MyDescAttribute>();
        }

        private void OnGUI()
        {
            GUILayout.Label("Types");
            foreach (var type in descriptionTypes)
            {
                GUILayout.BeginHorizontal("box");
                {
                    GUILayout.Label(type.Name);
                }
                GUILayout.EndHorizontal();
            }

            GUILayout.Label("With Attribute");
            foreach (var type in descriptionTypesWithAttribute)
            {
                //Debug.Log(type.Name);
                GUILayout.BeginHorizontal("box");
                {
                    GUILayout.Label(type.Name);
                    GUILayout.Label((type.GetCustomAttributes(typeof(MyDescAttribute), true)[0] as MyDescAttribute).Type);
                }
                GUILayout.EndHorizontal();
            }
        }
    }
}