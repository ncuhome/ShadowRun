using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DC
{
    public class PlayerPrefsEditor : EditorWindow
    {
        [MenuItem("PlayerPrefs/DeleteAll")]
        public static void DeleteAll()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        [MenuItem("PlayerPrefs/DeleteTarget")]
        public static void DeleteTarget()
        {
            PlayerPrefs.DeleteKey(Selection.activeGameObject.name);
            PlayerPrefs.Save();
        }
    }
}
