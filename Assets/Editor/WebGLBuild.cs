using UnityEditor;

public class WebGLBuild
{
    [InitializeOnLoadMethod]
    public static void WebGLBuildSetting()
    {
        if(EditorApplication.isPlayingOrWillChangePlaymode) return;
        //Unity's support for multithreading is highly unstable and will cause crash, build errors randomly!
        //Forum: https://forum.unity.com/threads/state-of-supporting-multithreading-for-webgl-builds.1396450/
        PlayerSettings.WebGL.emscriptenArgs = "";// "-s ALLOW_MEMORY_GROWTH=1 -s PTHREAD_POOL_SIZE=navigator.hardwareConcurrency -s PTHREAD_POOL_SIZE_STRICT=0";
        PlayerSettings.WebGL.threadsSupport = false;// true;
        UnityEngine.Debug.Log("WebGL threads enabled: " + PlayerSettings.WebGL.threadsSupport + "\nems arg: " + PlayerSettings.WebGL.emscriptenArgs);
    }
}
