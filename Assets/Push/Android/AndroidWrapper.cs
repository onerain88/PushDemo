using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidWrapper {
    public static void RequestAuthorization() {
        AndroidJavaClass pushManagerClazz = new AndroidJavaClass("com.leancloud.push.PushManager");
        pushManagerClazz.CallStatic("requestAuthorization");
    }

    public static void HuaWei() {
        AndroidJavaClass pushManagerClazz = new AndroidJavaClass("com.leancloud.push.PushManager");
        pushManagerClazz.CallStatic("huawei");
    }
}
