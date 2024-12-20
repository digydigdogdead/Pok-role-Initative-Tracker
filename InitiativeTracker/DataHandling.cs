﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    internal static class DataHandling
    {
        public static List<Pokemon> ActivePokemon = new List<Pokemon>();
        public static Pokemon CurrentPokemon;

        public static int Round {  get; set; } = 0;

        public static Pokemon? TrackedPokemon { get; set; }
        public static void NewRound()
        {
            Round++;

            if (Round != 1)
            {
                // This block will update all the pokemon
            }

            CurrentPokemon = ActivePokemon[0];
        }

        public static void NextTurn()
        {

        }

        public static void GetNewPokemon(string name, int initiative)
        {
            Pokemon pokemon = new(name, initiative);
            ActivePokemon.Add(pokemon);
        }

        public static void FaintPokemon()
        {
            Pokemon pokemonToFaint = TrackedPokemon;
            NextTurn();
            ActivePokemon.Remove(pokemonToFaint);
        }

        public static void UseAction()
        {
            CurrentPokemon.SuccessesNeeded++;
        }
    }
}
