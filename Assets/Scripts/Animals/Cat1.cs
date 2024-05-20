using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat1 : Cat
{
    public override void Start()
    {
        GetAnimator();
        Speed();
        LayDown();
        GiveScripts();
    }
}