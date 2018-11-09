
using UnityEngine;
using System.Runtime.InteropServices;

public class DynamicSoundAssignmentWrapper : MonoBehaviour {

    const string DLL_NAME = "DynamicSoundAssignment";

    [DllImport(DLL_NAME)]
    private static extern bool Init();

    [DllImport(DLL_NAME)]
    private static extern void CleanUp();
    [DllImport(DLL_NAME)]
    private static extern void initializeSound();
    [DllImport(DLL_NAME)]
    private static extern void loadSound(int key);

    [DllImport(DLL_NAME)]
    private static extern void playSound();


    // Update is called once per frame
    void Update () {

        initializeSound();
        loadSound(13);
        playSound();
    }
}
