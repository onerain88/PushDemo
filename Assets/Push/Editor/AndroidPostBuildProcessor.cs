using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor.Android;
using UnityEditor.Build;

public class AndroidPostBuildProcessor : IPostGenerateGradleAndroidProject {
    int IOrderedCallback.callbackOrder => 0;

    void IPostGenerateGradleAndroidProject.OnPostGenerateGradleAndroidProject(string path) {
        Debug.Log($"jsonPath: {Application.dataPath}/Push/Android/huawei/agconnect-services.json");
        Debug.Log($"unityLibrary: {path}");
        File.Copy($"{Application.dataPath}/Push/Android/huawei/agconnect-services.json", $"{path}/../launcher/agconnect-services.json");
    }
}
