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
        public static Pokemon? CurrentPokemon;

        public static int Round {  get; set; } = 0;

        public static void NewRound()
        {
            Round++;

            foreach (var pokemon in ActivePokemon)
            {
                pokemon.SuccessesNeeded = 1;
            }

            CurrentPokemon = ActivePokemon[0];
        }

        public static void UpdatePokemon(Pokemon pokemon, int initiative, int? dexterity = null)
        {
            pokemon.Initiative = initiative;
            if (dexterity != null) pokemon.Dexterity = dexterity;
        }

        public static Pokemon? GetPokemonByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;

            foreach (var pokemon in ActivePokemon)
            {
                if (pokemon.Name == name) return pokemon;
            }

            return null;
        }

        public static bool TryNextTurn()
        {
            if (CurrentPokemon is null) return false;

            var indexCurrent = ActivePokemon.IndexOf(CurrentPokemon);

            if (indexCurrent == ActivePokemon.Count - 1) return false;

            CurrentPokemon = ActivePokemon[indexCurrent + 1];
            return true;
        }

        public static void AddNewPokemon(string name, int initiative, int dexterity)
        {
            Pokemon pokemon = new(name, initiative, dexterity);
            ActivePokemon.Add(pokemon);
        }

        public static bool TryFaintPokemon()
        {
            Pokemon? pokemonToFaint = CurrentPokemon;
            if (pokemonToFaint == null) return false;

            TryNextTurn();
            ActivePokemon.Remove(pokemonToFaint);
            return true;
        }

        public static void UseAction(Pokemon actingMon)
        {
            actingMon.SuccessesNeeded++;
        }

        public static void Reset()
        {
            ActivePokemon.Clear();
            CurrentPokemon = null;
            Round = 0;
        }
    }
}
