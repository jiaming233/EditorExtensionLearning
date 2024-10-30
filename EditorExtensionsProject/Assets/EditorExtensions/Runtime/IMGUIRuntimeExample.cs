using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorExtensions
{
    public class IMGUIRuntimeExample : MonoBehaviour
    {
        //�༭��������������ʱ�ű�
        private GUILayoutAPI mGUILayoutAPI = new GUILayoutAPI();
        private GUIAPI mGUIAPI = new GUIAPI();

        private int mIndex;

        /// <summary>
        /// ����ʱ����
        /// </summary>
        private void OnGUI()
        {
            mIndex = GUILayout.Toolbar(mIndex, new string[] { "GUILayout", "GUI"});

            if(mIndex == 0)
            {
                mGUILayoutAPI.Draw();
            }
            else if(mIndex == 1)
            {
                mGUIAPI.Draw();
            }
        }
    }

}