﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;


public interface IChoosable
{
    string Name { get; }
    string Description { get; }
    //event EventHandler OnChosen;
    void Choose ();
}

public enum SkillTreeState
{
    Active, Inactive, Locked
}

public enum SkillTreeTier
{
    Tier0, Tier1, Tier2, Tier3
}

public enum BonusAtIndex
{
    Technique, MoveMod, Ability, StatUp, SkillUp, Endurance, Maturity, CrossTree, TreeUp, None
}

public enum BonusState
{
    Remaining,
    Acquired
}

public class SkillTree : IChoosable
{
    #region IChoosable implementation

    public string Name { get { return TreeName; } }
    public string Description { get { return "Skill Tree"; } }
    public void Choose ()
    {

    }

    #endregion

    public SkillTree (string lname, SkillTreeTier _lTier)
    {
        TreeName = lname;
        Tier = _lTier;
        _FavoredStatOnTree = new AttackStat (1);
        _ElementTypesSkillOnTree.Add (new ElementTypesSkill (ElementTypes.Fire));
        Bonuses.Add (new LevelUpBonus.TechniqueGain (this, _TechniquesOnTree [0]));
        Bonuses.Add (new LevelUpBonus.TechniqueGain (this, _TechniquesOnTree [1]));
        Bonuses.Add (new LevelUpBonus.TechniqueGain (this, _TechniquesOnTree [2]));
        Bonuses.Add (new LevelUpBonus.TechniqueGain (this, _TechniquesOnTree [3]));
        Bonuses.Add (new LevelUpBonus.TechniqueModifierGain (this));
        Bonuses.Add (new LevelUpBonus.AbilityGain (this));
        Bonuses.Add (new LevelUpBonus.StatGain (this, _FavoredStatOnTree));
        Bonuses.Add (new LevelUpBonus.ElementTypesSkillGain (this, _ElementTypesSkillOnTree));
        Bonuses.Add (new LevelUpBonus.StatGain (this, new EnduranceStat (1)));
        Bonuses.Add (new LevelUpBonus.MaturityBonusGain (this));
        Bonuses.Add (new LevelUpBonus.CrossTree (this));
        Bonuses.Add (new LevelUpBonus.TreeUp (this));
    }

    public TechniqueModifier _TechniqueModifier;
    public SkillTreeBlock _SkillTreeBlock;
    public Ability _Ability;
    public List <ElementTypesSkill> _ElementTypesSkillOnTree = new List <ElementTypesSkill>();
    public PokemonStat _FavoredStatOnTree = new AttackStat (1);
//    private SkillTreeState _State = SkillTreeState.Locked;
    public List <Technique> _TechniquesOnTree = Technique.ExampleTechniquesOnTree ();

    public List <LevelUpBonus> Bonuses = new List <LevelUpBonus> ();


    private SkillTreeState _State = SkillTreeState.Locked;
    public SkillTree _CrossTree;
    public SkillTree _TreeUp;
    string _Name;
    public Pokemon ThisPokemon { get { return _SkillTreeBlock._Pokemon; }}


    //    public void OnSelectOption (object Caller, EventArgs E)
    //    {
    //        Refresh ();
    //    public event EventHandler OnSelected;
    //    }

    public string TreeName {private set {_Name = value;} get {return _Name;}}

    SkillTreeTier _Tier;

    public SkillTreeTier Tier {private set {_Tier = value;} get {return _Tier;}}

    public SkillTreeState CurrentState 
    {        
        get {return (SkillTreeState) _State;}
    }

    public void SetSkillTreeBlock (SkillTreeBlock treeBlock)
    {
        _SkillTreeBlock = treeBlock;
    }

    public List <LevelUpBonus> GetRemainingBonuses ()
    {
        List <LevelUpBonus> Temp = new List <LevelUpBonus> ();
        for (int i = 0; i < Bonuses.Count; i++)
        {
            if ((BonusState) Bonuses [i].State == BonusState.Remaining) 
            {
                Temp.Add (Bonuses [i]);
            }
        }
        return Temp;
    }

    //    public void OnManualSelectClick (object Caller, EventArgs E)
    //    {
    //        OnManualSelectClick ();
    //    }

    public SkillTree GetTreeIfActive ()
    {
        if (this.CurrentState == SkillTreeState.Active) 
        {return this;} 
        else 
        {return null;}
    }

    public SkillTree GetTreeIfNotLocked ()
    {
        if (this.CurrentState != SkillTreeState.Locked) 
        {return this;} 
        else 
        {return null;}
    }

    public void ChangeTreeState (SkillTreeState NewState)
    {
        _State = NewState;
    }

    public LevelUpBonus GetRandomAvailableBonus ()
    {
        List <LevelUpBonus> Temp = GetRemainingBonuses ();
        Temp.Shuffle ();
        return Temp [0];
    }

    public void OnSelected (ILevelUpOption _Bonus)
    {
        if (Bonuses.Count == 0) 
        {
            return;
        }
        GameManager.instance._SelectionState = SelectionState.Roll;
        GameManager.instance.CurrentPokemon.LevelUp (_Bonus);
    }

    public void OnManualSelectClick (ILevelUpOption _Bonus)
    {
        //        this += OnManualSelectClick;

        if (GameManager.instance._SelectionState == SelectionState.Select)
        {
            OnSelected (_Bonus);
        }
    }
}