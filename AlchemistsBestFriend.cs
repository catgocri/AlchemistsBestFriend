using System;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace catgocri.AlchemistsBestFriend.PotionCraft
{  
    // Reflection function is from RoboPhred https://github.com/RoboPhred
    public static class Reflection
    {
        public static void SetPrivateField<T>(object instance, string fieldName, T value)
        {
            var prop = instance.GetType().GetField(fieldName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop.SetValue(instance, value);
        }
    }   

    [BepInPlugin("net.catgocri.PotionCraft.AlchemistsBestFriend", "Alchemists Best Friend PotionCraft", "1.0")]
    public class AlchemistsBestFriendPlugin : BaseUnityPlugin
    {   
      void Awake()
      {
        Debug.Log($"[AlchemistsBestFriend]: Loaded");
        var harmony = new Harmony("net.catgocri.PotionCraft.AlchemistsBestFriend");
        harmony.PatchAll();
      }
      void Update()
      {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
          foreach (InventoryItem ingredient in Managers.Ingredient.ingredients)
          {
            if (!ingredient.name.Equals("Default"))
            {
              Managers.Player.inventory.AddItem(ingredient, 1000, true, true);
            }
          }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
          foreach (InventoryItem allSalt in Salt.allSalts)
            Managers.Player.inventory.AddItem(allSalt, 1000, true, true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
          Managers.Player.inventory.Clear();
          foreach (InventoryItem ingredient in Managers.Ingredient.ingredients)
          {
            if (!ingredient.name.Equals("Default"))
            {
              Managers.Player.inventory.AddItem(ingredient, 1, true, true);
            }
          }
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
          Managers.Player.inventory.Clear();
        }
      }
    }
}