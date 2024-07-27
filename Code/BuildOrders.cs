using System;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
// ReSharper disable InconsistentNaming

namespace ModernMod.Code {
  public static class BuildOrders {
    private static readonly string[] BaseGameRaceIDs = { S.human, S.elf, S.orc, S.dwarf };

    internal static void Init() {
      Harmony harmony = new Harmony("com.key.general.harmony_logging");
      MethodInfo original = typeof(BuildOrder).GetMethod(nameof(BuildOrder.getBuildingAsset), BindingFlags.Instance | BindingFlags.Public);
      MethodInfo prefix = typeof(BuildOrders).GetMethod(nameof(getBuildingAsset_Prefix), BindingFlags.Static | BindingFlags.NonPublic);
      harmony.Patch(original, new HarmonyMethod(prefix));
      original = typeof(ai.behaviours.CityBehBuild).GetMethod(nameof(ai.behaviours.CityBehBuild.haveRequiredBuildings), BindingFlags.Static | BindingFlags.NonPublic);
      prefix = typeof(BuildOrders).GetMethod(nameof(haveRequiredBuildings_Prefix), BindingFlags.Static | BindingFlags.NonPublic);
      harmony.Patch(original, new HarmonyMethod(prefix));

      //HUMAN
      RaceBuildOrderAsset kingdomBase = AssetManager.race_build_orders.get("kingdom_base");
      kingdomBase.addUpgrade(SB.order_house_5);
      AddBuildingOrderKeysToCivRaces("order_house_6_modernmod", "6house");
      kingdomBase.addUpgrade("order_house_6_modernmod");
      AddBuildingOrderKeysToCivRaces("order_house_7_modernmod", "7house");
      kingdomBase.addUpgrade("order_house_7_modernmod");
      AddBuildingOrderKeysToCivRaces("order_house_8_modernmod", "8house");
      kingdomBase.addUpgrade("order_house_8_modernmod");
      AddBuildingOrderKeysToCivRaces("order_house_9_modernmod", "9house");
      kingdomBase.addUpgrade("order_house_9_modernmod");
      AddBuildingOrderKeysToCivRaces("order_house_10_modernmod", "10house");
      kingdomBase.addUpgrade("order_house_10_modernmod");
      AddBuildingOrderKeysToCivRaces("order_house_11_modernmod", "11house");

      kingdomBase.addUpgrade(SB.order_hall_2, pPop: 100, pBuildings: 20);
      AddBuildingOrderKeysToCivRaces("order_hall_3_modernmod", "3hall");
      kingdomBase.addUpgrade("order_hall_3_modernmod", pPop: 150, pBuildings: 20);
      AddBuildingOrderKeysToCivRaces("order_hall_4_modernmod", "4hall");
      kingdomBase.addUpgrade("order_hall_4_modernmod", pPop: 200, pBuildings: 20);
      AddBuildingOrderKeysToCivRaces("order_hall_5_modernmod", "5hall");
      kingdomBase.addUpgrade("order_hall_5_modernmod", pPop: 250, pBuildings: 20);
      AddBuildingOrderKeysToCivRaces("order_hall_6_modernmod", "6hall");

      kingdomBase.addUpgrade(SB.order_docks_1, pPop: 150, pBuildings: 30);
      AddBuildingOrderKeysToCivRaces("order_docks_2_modernmod", "2docks");
      kingdomBase.addUpgrade("order_docks_2_modernmod", pPop: 150, pBuildings: 40);
      AddBuildingOrderKeysToCivRaces("order_docks_3_modernmod", "3docks");

      kingdomBase.addUpgrade(SB.order_barracks, pPop: 300, pBuildings: 25);
      AddBuildingOrderKeysToCivRaces("order_barracks_2_modernmod", "2barracks");
      kingdomBase.addUpgrade("order_barracks_2_modernmod", pPop: 350, pBuildings: 30);
      AddBuildingOrderKeysToCivRaces("order_barracks_3_modernmod", "3barracks");

      kingdomBase.addUpgrade(SB.order_temple, pPop: 200, pBuildings: 20);
      AddBuildingOrderKeysToCivRaces("order_temple_2_modernmod", "2temple");
      kingdomBase.addUpgrade("order_temple_2_modernmod", pPop: 400, pBuildings: 30);
      AddBuildingOrderKeysToCivRaces("order_temple_3_modernmod", "3temple");

      kingdomBase.addUpgrade(SB.order_bonfire, pPop: 300);
      AddBuildingOrderKeysToCivRaces("order_bonfire_2_modernmod", "2bonfire", false);

      kingdomBase.addUpgrade(SB.order_well, pPop: 200);
      AddBuildingOrderKeysToCivRaces("order_well_2_modernmod", "2well", false);

      kingdomBase.addUpgrade(SB.order_mine, pPop: 100);
      AddBuildingOrderKeysToCivRaces("order_mine_2_modernmod", "2mine", false);
    }

    private static void AddBuildingOrderKeysToCivRaces(string key, string value, bool raceSpecificBuildings = true) {
      if (raceSpecificBuildings) {
        foreach (string raceID in BaseGameRaceIDs) {
          try {
            if (AssetManager.raceLibrary.get(raceID).building_order_keys.ContainsKey(key)) AssetManager.raceLibrary.get(raceID).building_order_keys.Remove(key);
            AssetManager.raceLibrary.get(raceID).building_order_keys.Add(key, value + "_" + raceID + "_modernmod");
          } catch (Exception e) {
            Debug.LogError("Another mod that loaded before ModernMod has already added the building order key for " + key + " for the " + raceID + " race. This is not a problem, but it means that ModernMod will not be able to add its own building upgrade for " + key + ".\n" + e);
          }
        }

        AddBuildingOrderKeysToModdedCivRaces(key, value + "_human");
      } else {
        foreach (Race race in AssetManager.raceLibrary.list.Where(race => race.civilization)) {
          try {
            if (race.building_order_keys.ContainsKey(key)) race.building_order_keys.Remove(key);
            race.building_order_keys.Add(key, value + "_modernmod");
          } catch (Exception e) {
            Debug.LogError("Another mod that loaded before ModernMod has already added the building order key for " + key + " for the " + race.id + " race. This is not a problem, but it means that ModernMod will not be able to add its own building upgrade for " + key + ".\n" + e);
          }
        }
      }
    }

    private static void AddBuildingOrderKeysToModdedCivRaces(string key, string value) {
      foreach (Race race in AssetManager.raceLibrary.list.Where(race => race.civilization).Where(race => !BaseGameRaceIDs.Contains(race.id))) {
        try {
          if (race.building_order_keys.ContainsKey(key)) race.building_order_keys.Remove(key);
          race.building_order_keys.Add(key, value + "_modernmod");
        } catch (Exception e) {
          Debug.LogError("Another mod that loaded before ModernMod has already added the building order key for " + key + " for the " + race.id + " race. This is not a problem, but it means that ModernMod will not be able to add its own building upgrade for " + key + ".\n" + e);
        }
      }
    }

    private static bool getBuildingAsset_Prefix(Asset __instance, ref BuildingAsset __result, City pCity, string pBuildingID = null) {
      if (string.IsNullOrEmpty(pBuildingID)) pBuildingID = __instance.id;
      try {
        string buildingOrderKey = pCity.race.building_order_keys[pBuildingID];
        __result = AssetManager.buildings.get(buildingOrderKey);
      } catch (Exception e) {
        Debug.Log("Failed to get building order key for " + pBuildingID);
        Debug.Log(e);
      }

      return false;
    }
    
    private static bool haveRequiredBuildings_Prefix(BuildOrder pOrder, City pCity)
    {
      if (pOrder == null) {
        Debug.LogError("Ok sorry what the actual BuildOrder passed to the method is null something is seriously going wrong here ._.");
        throw new NullReferenceException("Ok sorry what the actual BuildOrder passed to the method is null something is seriously going wrong here ._.");
      }
      if (pOrder.requirements_orders == null || pOrder.requirements_orders.Count == 0)
      {
        return true;
      }
      foreach (string requirements_order in pOrder.requirements_orders)
      {
        BuildingAsset buildingAsset = pOrder.getBuildingAsset(pCity, requirements_order);
        if (buildingAsset == null)
        {
          Debug.LogError("(!) Building asset not found: " + requirements_order);
          throw new NullReferenceException("Building asset not found: " + requirements_order);
        }
        if (buildingAsset.id == buildingAsset.upgradeTo)
        {
          Debug.LogError("(!) Building is set to be upgraded to self: " + buildingAsset.id);
          continue;
        }
        while (pCity.countBuildingExact(buildingAsset.id) == 0)
        {
          if (!buildingAsset.canBeUpgraded || string.IsNullOrEmpty(buildingAsset.upgradeTo))
          {
            return false;
          }
          buildingAsset = AssetManager.buildings.get(buildingAsset.upgradeTo);
        }
      }
      return true;
    }
  }
}