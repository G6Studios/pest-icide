
using UnityEngine;
using System.Runtime.InteropServices;

public class DynamicSoundassignmentWrapper : MonoBehaviour {

    const string DLL_NAME = "DynamicSoundassignment";

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

    [DllImport(DLL_NAME)]
    private static extern void destroySound();

    // Use this for initialization 
    void Start()
    {
        Init();
        initializeSound();
        loadSound(11);
        // print("playingsound");
        playSound();
        // print("playedsound");
        destroySound();

    }


        // Update is called once per frame
    void Update () {
       // print("playingsound");
       // playSound();
    }
}
