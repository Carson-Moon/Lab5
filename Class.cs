using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public struct Class
{
    // Class Variables
    public string className;
    public int classDice;

    public Class(string name, int dice){
        this.className = name;
        this.classDice = dice;
    }
}