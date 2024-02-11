using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionTwo : MonoBehaviour
{
    // Runtime
    private int totalHP = 0;
    private ClassList cList; 

    // Player Stats
    public string playerName;
    public string className;

    public int level;
    public int constitution;

    public bool isHillDwarf;
    public bool isTough;
    public bool isAveraged;

    private int[] constitutionModifiers = new int[]{
        -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0,
        1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7,
        8, 8, 9, 9, 10
    };


    public void Start()
    {
        // Get class list on this object.
        cList = GetComponent<ClassList>();

        // Get the size of the die for this class.
        int dieSize = 0;
        dieSize = cList.SearchForClass(className).classDice;

        string averagedText;
        if(isAveraged){
            totalHP += AveragedHP(dieSize);
            averagedText = "averaged.";
        }else{
            totalHP += RolledHP(dieSize);
            averagedText = "rolled.";
        }
            

        string dwarfText;
        if(isHillDwarf){
            totalHP += level;
            dwarfText = "is";
        }else{
            dwarfText = "is not";
        }
            
        string toughText;
        if(isTough){
            totalHP += (level * 2);
            toughText = "has the";
        }else{
            toughText = "does not have the";
        }
            
        totalHP += constitutionModifiers[(constitution - 1)];

        print("My Character " + playerName + " is a level " + level.ToString() + " " + className +
                " with a CON score of " + constitution + " and " + dwarfText + " a Hill Dwarf and " + 
                toughText + " the Tough feat. I want the HP " +averagedText);
        print("My total HP is " + totalHP.ToString());
    }

    private int AveragedHP(int dieSize){
        // Get the average by adding all sides and dividing by size.
        int dieAverage = 0;
        for(int i=1; i<=dieSize; i++){
            dieAverage += i;
        }
        dieAverage /= dieSize;

        // Add the average multiplied by how many die we need (the players level).
        return dieAverage * level;
    }

    private int RolledHP(int dieSize){
        int totalRolledHP = 0;

        // Roll as many times as what level we are.
        for(int i=0; i<level; i++){
            totalRolledHP += Random.Range(1, dieSize);
        }

        // Return to add to total HP.
        return totalRolledHP;
    }
}
