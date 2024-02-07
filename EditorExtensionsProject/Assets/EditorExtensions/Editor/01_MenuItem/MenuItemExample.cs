using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public static class MenuItemExample
    {
        /// <summary>
        /// Ϊ��̬�������MenuItem Attribute
        /// [MenuItem("path")]
        /// </summary>
        [MenuItem("EditorExtensions/01.Menu/01.Hello Editor")]
        static void HelloEditor()
        {
            Debug.Log("Hello Editor");
        }

        [MenuItem("EditorExtensions/01.Menu/02.Open Bing")]
        static void OpenBing()
        {
            Application.OpenURL("https://www.bing.com");
        }

        /// <summary>
        /// API:��Ŀ¼ EditorUtility.RevealInFinder
        /// </summary>
        [MenuItem("EditorExtensions/01.Menu/03.Open PersistentDataPath")]
        static void OpenPersistentDataPath()
        {
            EditorUtility.RevealInFinder(Application.persistentDataPath);
        }


        [MenuItem("EditorExtensions/01.Menu/04.Open Library Folder")]
        static void OpenLibraryFolder()
        {
            EditorUtility.RevealInFinder(Application.dataPath.Replace("Assets", "Library"));
        }

        /// <summary>
        /// �ɹ�ѡ��MenuItem
        /// API:Menu.SetChecked
        /// </summary>
        static bool mOpenShortCut = false;
        [MenuItem("EditorExtensions/01.Menu/05.��ݼ�����")]
        static void ToggleShortCut()
        {
            mOpenShortCut = !mOpenShortCut;
            Menu.SetChecked("EditorExtensions/01.Menu/05.��ݼ�����", mOpenShortCut);
        }

        /// <summary>
        /// MenuItem��ݼ�
        /// ���ã�
        /// % ctrl
        /// # shift
        /// & alt
        /// _a-zA-Z a-zA-Z
        /// </summary>
        [MenuItem("EditorExtensions/01.Menu/06.Hello Editor _c")]
        static void HelloEditorWithShortCut()
        {
            //Debug.Log("Hello Editor");
            //Menu Item����
            //API:EditorApplication.ExecuteMenuItem
            EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/01.Hello Editor");
        }
        /// <summary>
        /// MenuItem������֤����������bool
        /// [MenuItem("path"),validate=true]
        /// </summary>
        [MenuItem("EditorExtensions/01.Menu/06.Hello Editor _c", validate = true)]
        static bool HelloEditorWithShortCutValidate()
        {
            return mOpenShortCut;
        }

        [MenuItem("EditorExtensions/01.Menu/07.Open Bing %e")]
        static void OpenBingWithShortCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/02.Open Bing");
        }
        [MenuItem("EditorExtensions/01.Menu/07.Open Bing %e", validate = true)]
        static bool OpenBingWithShortCutValidate()
        {
            return mOpenShortCut;
        }

        [MenuItem("EditorExtensions/01.Menu/08.Open PersistentDataPath %#t")]
        static void OpenPersistentDataPathWithShortCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/03.Open PersistentDataPath");
        }
        [MenuItem("EditorExtensions/01.Menu/08.Open PersistentDataPath %#t", validate = true)]
        static bool OpenPersistentDataPathWithShortCutValidate()
        {
            return mOpenShortCut;
        }

        [MenuItem("EditorExtensions/01.Menu/09.Open Library Folder &r")]
        static void OpenLibraryFolderWithShortCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtensions/01.Menu/04.Open Library Folder");
        }
        [MenuItem("EditorExtensions/01.Menu/09.Open Library Folder &r", validate = true)]
        static bool OpenLibraryFolderWithShortCutValidate()
        {
            return mOpenShortCut;
        }

        /// <summary>
        /// �ڹ��췽������һЩ��ʼ����У��
        /// ȷ��ÿ�α���֮��״̬��ȷ
        /// </summary>
        static MenuItemExample()
        {
            Menu.SetChecked("EditorExtensions/01.Menu/05.��ݼ�����", mOpenShortCut);
        }

        #region �ٷ��ĵ�ʾ��
        /// <summary>
        /// Inspector��������Ĳ˵�
        /// </summary>
        /// <param name="command"></param>
        // Add a menu item called "Double Mass" to a Rigidbody's context menu.
        [MenuItem("CONTEXT/Rigidbody/Double Mass")]
        static void DoubleMass(MenuCommand command)
        {
            Rigidbody body = (Rigidbody)command.context;
            body.mass = body.mass * 2;
            Debug.Log("Doubled Rigidbody's Mass to " + body.mass + " from Context Menu.");
        }

        // Add a menu item to create custom GameObjects.
        // Priority 1 ensures it is grouped with the other menu items of the same kind
        // and propagated to the hierarchy dropdown and hierarchy context menus.
        [MenuItem("GameObject/MyCategory/Custom Game Object", false, 10)]
        static void CreateCustomGameObject(MenuCommand menuCommand)
        {
            // Create a custom game object
            GameObject go = new GameObject("Custom Game Object");
            // Ensure it gets reparented if this was a context click (otherwise does nothing)
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }
        #endregion
    }
}