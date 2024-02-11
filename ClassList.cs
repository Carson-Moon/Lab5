using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassList : MonoBehaviour
{
    // Classes
    public Class Artificer = new Class("Artificer", 8);
    public Class Barbarian = new Class("Barbarian", 12);
    public Class Bard = new Class("Bard", 8);
    public Class Cleric = new Class("Cleric", 8);
    public Class Druid = new Class("Druid", 8);
    public Class Fighter = new Class("Fighter", 10);
    public Class Monk = new Class("Monk", 8);
    public Class Ranger = new Class("Ranger", 10);
    public Class Rogue = new Class("Rogue", 8);
    public Class Paladin = new Class("Paladin", 10);
    public Class Sorcerer = new Class("Sorcerer", 6);
    public Class Wizard = new Class("Wizard", 6);
    public Class Warlock = new Class("Warlock", 8);

    // Class list
    public List<Class> classes = new List<Class>();


    private void Awake() {
        classes.Add(Artificer);
        classes.Add(Barbarian);
        classes.Add(Bard);
        classes.Add(Cleric);
        classes.Add(Druid);
        classes.Add(Fighter);
        classes.Add(Monk);
        classes.Add(Ranger);
        classes.Add(Rogue);
        classes.Add(Paladin);
        classes.Add(Sorcerer);
        classes.Add(Wizard);
        classes.Add(Warlock);
    }

    // Return the class that has the same name as className.
    public Class SearchForClass(string className){
        for(int i=0; i<classes.Count; i++){
            if(classes[i].className == className)
                return classes[i];
        }

        // Return the first class if we cannot find what class we are searching for.
        return classes[0];
    }
}
