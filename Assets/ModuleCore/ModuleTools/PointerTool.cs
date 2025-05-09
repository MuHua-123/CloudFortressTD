using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerTool : MonoBehaviour {
    /// <summary> 判断指针是否在UI上 </summary>
    public static bool IsPointerOverGameObject;

    private void Update() {
//#if UNITY_EDITOR
//        //编辑器
//        IsPointerOverGameObject = EventSystem.current.IsPointerOverGameObject();
#if UNITY_STANDALONE
        //电脑平台
        IsPointerOverGameObject = EventSystem.current.IsPointerOverGameObject();
#elif UNITY_WEBGL
        //WebGL平台
        IsPointerOverGameObject = EventSystem.current.IsPointerOverGameObject();
#elif UNITY_ANDROID
        //安卓平台
        IsPointerOverGameObject = EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
#elif UNITY_IOS
        //苹果平台
        IsPointerOverGameObject = EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
#endif
    }
}
