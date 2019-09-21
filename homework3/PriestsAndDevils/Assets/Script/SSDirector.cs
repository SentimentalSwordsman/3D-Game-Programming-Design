using UnityEngine;
using Interfaces;
using System.Collections;
using System.Collections.Generic;

public class SSDirector : System.Object {
    //  singltion instance
    private static SSDirector _instance;

    public ISceneController currentScenceController { get; set; }
    public bool running { get; set; }
    //  get instance anytime anywhere!
    public static SSDirector getInstance()
    {
        if (_instance == null)
        {
            _instance = new SSDirector();
        }
        return _instance;
    }

    public int getFPS()
    {
        return Application.targetFrameRate;
    }

    public void setFPS(int fps)
    {
        Application.targetFrameRate = fps;
    }
}
