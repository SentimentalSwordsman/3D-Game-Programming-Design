using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;


public class GameObjects
{
    readonly GameObject Instance;
    readonly Moveable Move;
    readonly ClickGUI clickGUI;
    readonly int type;
    bool onBoat = false;
    CoastSceneController coastScene;

    public GameObjects(int num)
    {
        //  1-p, 0-d
        if (num == 1)
        {
            Instance = Object.Instantiate(Resources.Load<GameObject>("Prefabs/priest"), Vector3.zero, Quaternion.identity);
            type = 1;
        }
        else
        {
            Instance = Object.Instantiate(Resources.Load<GameObject>("Prefabs/devil"), Vector3.zero, Quaternion.identity);
            type = 0;
        }
        Move = Instance.AddComponent(typeof(Moveable)) as Moveable;
        clickGUI = Instance.AddComponent(typeof(ClickGUI)) as ClickGUI;
        clickGUI.setController(this);
    }

    public void setName(int num)
    {
        if(num < 3)
        {
            num++;
            Instance.name = "priest" + num;
        }
        else
        {
            num -= 2;
            Instance.name = "devil" + num;
        }
    }

    public void setPosition(Vector3 pos)
    {
        Instance.transform.position = pos;
    }

    public void moveToPosition(Vector3 dest)
    {
        Move.SetDest(dest);
    }

    public int getType()
    {
        return type;
    }

    public string getName()
    {
        return Instance.name;
    }

    public void getOnBoat(BoatSceneController boat)
    {
        coastScene = null;
        Instance.transform.parent = boat.GetGameobject().transform;
        onBoat = true;
    }

    public void getOnCoast(CoastSceneController coasti)
    {
        coastScene = coasti;
        Instance.transform.parent = null;
        onBoat = false;
    }

    public bool isOnBoat()
    {
        return onBoat;
    }

    public CoastSceneController getCoastSceneController()
    {
        return coastScene;
    }

    public void Reset()
    {
        //  reset后回到岸上
        Move.Reset();
        coastScene = (SSDirector.getInstance().currentScenceController as FirstController).coast1;
        getOnCoast(coastScene);
        setPosition(coastScene.getEmptyPosition());
        coastScene.getOnCoast(this);
    }
}