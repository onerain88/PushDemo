using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class HelloPush : MonoBehaviour {
    public void OnRequestAuthorizationClicked() {
        PushManager.RequestAuthorization();
    }

    public void OnHelloClicked() {
        try {
            AndroidJavaClass testClazz = new AndroidJavaClass("com.leancloud.push.Test");
            testClazz.CallStatic("Test");
            Debug.Log("++++++++++++++++++++");
        } catch (AndroidJavaException e) {
            Debug.Log($"------------------- {e}");
        }
    }

    public void OnHuaweiClicked() {
        AndroidJavaClass huaweiClazz = new AndroidJavaClass("com.leancloud.push.PushManager");
        huaweiClazz.CallStatic("huawei", new object[] { "100259225" });
    }
}
