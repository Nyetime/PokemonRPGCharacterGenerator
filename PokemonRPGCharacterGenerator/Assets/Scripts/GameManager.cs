﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;


public static class ListExtensions

{	
	private static System.Random rng = new System.Random();  
	public static void Shuffle<T>(this IList<T> list)  

	{  
		int n = list.Count;  
		while (n > 1) 
		{  
			n--;  
			int k = rng.Next(n + 1);  
			T value = list[k]; 
			list[k] = list[n];  
			list[n] = value;  
		}  
	}
		
	public static List <T> MakeCopy <T> (this List<T> thisList)
	{
		List <T> returnList = new List <T> ();

		for (int i = 0; i < thisList.Count; i++)
		{
			returnList.Add (thisList [i]);
		}
		return returnList;
	}

	public static void Apply <T> (this List<T> thisList,Action<T> action)
	{
		List<T> tempList = thisList.MakeCopy<T>();

		for (int i = 0; i < tempList.Count; i++)
		{
			action(tempList[i]);
		}
	}

}

public enum SelectionState
{
	Select,
	Roll
}


public class GameManager : MonoBehaviour 

{
	public static GameManager instance = null;
	public SkillTreeBlockController _SkillTreeBlockController {
        get { return sceneChanger.GeneratorController.Treeblock; } }
	public SelectionState _SelectionState;
	public Pokemon CurrentPokemon;
	public BadgeLevelGenerator _BadgeLevelGenerator;
	public PokemonSheetDisplay _PokemonSheetDisplay;
	public PokeSheetHistoryManager _PokeSheetHistoryManager;
    public SceneChanger sceneChanger;

    void Awake()
	{
		if (instance == null)
		{instance = this;}
			
		else  if (instance != this)
		{Destroy (gameObject);}
		DontDestroyOnLoad(gameObject);

		_SelectionState = SelectionState.Roll;
		Pokemon.Breed CharmanderBreed = new Pokemon.Breed (ElementTypes.Fire, ElementTypes.Nothing);
		CharmanderBreed.BreedName = "Charmander";
		CharmanderBreed.BreedStatBlock.Endurance.RawValue = 4;
		CharmanderBreed.BreedStatBlock.Attack.RawValue = 5;
		CharmanderBreed.BreedStatBlock.Defense.RawValue = 4;
		CharmanderBreed.BreedStatBlock.SpecialAttack.RawValue = 5;
		CharmanderBreed.BreedStatBlock.SpecialDefense.RawValue = 4;
		CharmanderBreed.BreedStatBlock.Speed.RawValue = 6;


		CurrentPokemon = new Pokemon (CharmanderBreed);
		CurrentPokemon.Maturity = 0;
		CurrentPokemon.Level = 0;
		CurrentPokemon.Rate = 5;
		CurrentPokemon._StatBlock.EnduranceBonuses.SetRawValue (3);
		CurrentPokemon._StatBlock.AttackBonuses.SetRawValue (1);
		CurrentPokemon._StatBlock.DefenseBonuses.SetRawValue (1);
		CurrentPokemon._StatBlock.SpecialAttackBonuses.SetRawValue (0);
		CurrentPokemon._StatBlock.SpecialDefenseBonuses.SetRawValue (2);
		CurrentPokemon._StatBlock.SpeedBonuses.SetRawValue (0);

		CurrentPokemon.CurrentDamage = 0;
		CurrentPokemon.CurrentStrainLost = 0;



		CurrentPokemon._TechniquesKnown.Add (Technique.Fire_Blast ());
		CurrentPokemon._TechniquesKnown.Add (Technique.Dragon_Claw ());
		CurrentPokemon._TechniquesKnown.Add (Technique.Metal_Claw ());
		CurrentPokemon._TechniquesKnown.Add (Technique.Sand_Attack ());
		CurrentPokemon._TechniquesKnown.Add (Technique.Fire_Blast ());

		CurrentPokemon._TechniquesActive.Add (Technique.Fire_Blast ());
		CurrentPokemon._TechniquesActive.Add (Technique.Dragon_Claw ());
		CurrentPokemon._TechniquesActive.Add (Technique.Metal_Claw ());
		CurrentPokemon._TechniquesActive.Add (Technique.Sand_Attack ());
		CurrentPokemon._TechniquesActive.Add (Technique.Fire_Blast ());


		
        sceneChanger.SwitchToTree();
        // TODO add to scene changer
        //_SkillTreeBlockController.ChangeDisplayPokemon(CurrentPokemon);
        sceneChanger._PokemonSheet.ShowNewPokemon(CurrentPokemon, CharmanderBreed);

        for (int i = 0; i < CurrentPokemon._TechniquesKnown.Count; i++)
        {
            sceneChanger._PokemonSheet.TechsList[i].ChangeTechniqueDisplay(CurrentPokemon._TechniquesActive[i]);
        }
        sceneChanger._PokeSheetHistoryManager.ChangeDisplay(CurrentPokemon._HistoryBlock.BonusHistory);
    }

	public void Refresh ()
	{
		_SkillTreeBlockController.Refresh ();
	}

	public void ChangeVisibleTrees ()
	{
		_SkillTreeBlockController.ChangeVisibleTrees ();
	}

	//public void TreeSwap (int TreeToChange, int TreeDataIndex)
	//{
	//	_NewTreeManager.TreeSwap (TreeToChange, TreeDataIndex);
	//}

}