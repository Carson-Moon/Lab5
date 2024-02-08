using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SolutionOne : MonoBehaviour
{
    // Runtime
    private int totalHP = 0;

    // Player Stats
    public string playerName;
    public string className;

    public int level;
    public int constitution;

    public bool isHillDwarf;
    public bool isTough;
    public bool isAveraged;

    // Dice Dictionary
    private Dictionary<string, int> diceDictionary = new Dictionary<string, int>{
        {"Artificer", 8},
        {"Barbarian", 12},
        {"Bard", 8},
        {"Cleric", 8},
        {"Druid", 8},
        {"Fighter", 10},
        {"Monk", 8},
        {"Ranger", 10},
        {"Rogue", 8},
        {"Paladin", 10},
        {"Sorcerer", 6},
        {"Wizard", 6},
        {"Warlock", 8},
    };

    private int[] constitutionModifiers = new int[]{
        -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0,
        1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7,
        8, 8, 9, 9, 10
    };

    public void Start()
    {
        // Get the size of the die for this class.
        int dieSize = 0;
        diceDictionary.TryGetValue(className, out dieSize);

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
