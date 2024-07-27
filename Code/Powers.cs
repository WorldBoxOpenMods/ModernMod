using System.Linq;
using ModernMod.Code.Utils;
using NeoModLoader.General;
using UnityEngine;

namespace ModernMod.Code {
  public static class Powers {
    internal static void Init() {
      CreateGodPowers();
      CreateBuildingUpgradeButton();
      CreateBuildingDowngradeButton();
    }

    private static void CreateBuildingUpgradeButton() {
      Sprite spriteUpgrade = AssetUtils.LoadEmbeddedSprite("images/icon/UpgradeBuilding");
      LM.AddToCurrentLocale("Button_UpgradeBuilding_Keymasterer", "Upgrade Building");
      LM.AddToCurrentLocale("Button_UpgradeBuilding_Keymasterer Description", "Upgrade the building to the next tier.");
      PowerButton buttonUpgradeBuilding = PowerButtonCreator.CreateGodPowerButton("Button_UpgradeBuilding_Keymasterer", spriteUpgrade);
      buttonUpgradeBuilding.godPower = AssetManager.powers.get("upgradeBuilding");
      PowerButtonCreator.AddButtonToTab(buttonUpgradeBuilding, PowerButtonCreator.GetTab("Tab_Drawing"), new Vector2(512f, -18));
    }

    private static void CreateBuildingDowngradeButton() {
      Sprite spriteDowngrade = AssetUtils.LoadEmbeddedSprite("images/icon/DowngradeBuilding");
      LM.AddToCurrentLocale("Button_DowngradeBuilding_Keymasterer", "Upgrade Building");
      LM.AddToCurrentLocale("Button_DowngradeBuilding_Keymasterer Description", "Downgrade the building to the last tier.");
      PowerButton buttonDowngradeBuilding = PowerButtonCreator.CreateGodPowerButton("Button_DowngradeBuilding_Keymasterer", spriteDowngrade);
      buttonDowngradeBuilding.godPower = AssetManager.powers.get("downgradeBuilding");
      PowerButtonCreator.AddButtonToTab(buttonDowngradeBuilding, PowerButtonCreator.GetTab("Tab_Drawing"), new Vector2(512f, 18));
    }


    private static void CreateGodPowers() {
      GodPower upgradeBuildingPower = AssetManager.powers.clone("upgradeBuilding", "_drops");
      upgradeBuildingPower.holdAction = true;
      upgradeBuildingPower.showToolSizes = true;
      upgradeBuildingPower.unselectWhenWindow = true;
      upgradeBuildingPower.name = "Upgrade Building";
      upgradeBuildingPower.dropID = "upgradeBuilding";
      upgradeBuildingPower.fallingChance = 0.01f;
      upgradeBuildingPower.click_power_action = (pTile, pPower) =>  AssetManager.powers.spawnDrops(pTile, pPower);
      upgradeBuildingPower.click_power_brush_action = (pTile, pPower) => AssetManager.powers.loopWithCurrentBrushPower(pTile, pPower);


      DropAsset upgradeBuildingDrop = new DropAsset {
        id = "upgradeBuilding",
        path_texture = "drops/drop_snow",
        animated = true,
        animation_speed = 0.03f,
        default_scale = 0.1f,
        action_landed = UpgradeBuilding
      };
      AssetManager.drops.add(upgradeBuildingDrop);


      GodPower downgradeBuildingPower = AssetManager.powers.clone("downgradeBuilding", "_drops");
      downgradeBuildingPower.holdAction = true;
      downgradeBuildingPower.showToolSizes = true;
      downgradeBuildingPower.unselectWhenWindow = true;
      downgradeBuildingPower.name = "Downgrade Building";
      downgradeBuildingPower.dropID = "downgradeBuilding";
      downgradeBuildingPower.fallingChance = 0.01f;
      downgradeBuildingPower.click_power_action = (pTile, pPower) =>  AssetManager.powers.spawnDrops(pTile, pPower);
      downgradeBuildingPower.click_power_brush_action = (pTile, pPower) => AssetManager.powers.loopWithCurrentBrushPower(pTile, pPower);


      DropAsset downgradeBuildingDrop = new DropAsset {
        id = "downgradeBuilding",
        path_texture = "drops/drop_snow",
        animated = true,
        animation_speed = 0.03f,
        default_scale = 0.1f,
        action_landed = DowngradeBuilding
      };
      AssetManager.drops.add(downgradeBuildingDrop);
    }

    private static void UpgradeBuilding(WorldTile pTile = null, string pDropID = null) {
      if (pTile?.building != null && !string.IsNullOrWhiteSpace(pTile.building.asset.upgradeTo)) {
        Debug.LogWarning("Upgrading building " + pTile.building.asset.id + " to " + pTile.building.asset.upgradeTo + ".");
        BuildingAsset pTemplate = AssetManager.buildings.get(pTile.building.asset.upgradeTo);
        pTile.building.city?.setBuildingDictID(pTile.building, false);
        pTile.building.setTemplate(pTemplate);
        pTile.building.city?.setBuildingDictID(pTile.building, true);
        pTile.building.initAnimationData();
        pTile.building.updateStats();
        pTile.building.data.health = pTile.building.getMaxHealth();
        pTile.building.fillTiles();
      } else if (pTile != null && pTile.building != null) Debug.LogWarning("Failed to upgrade building " + pTile.building.asset.id + " because it has no upgradeTo value.");
    }
    
    private static void DowngradeBuilding(WorldTile pTile = null, string pDropID = null) {
      if (pTile?.building != null) {
        BuildingAsset pTemplate = AssetManager.buildings.list.FirstOrDefault(asset => asset.upgradeTo == pTile.building.asset.id);
        if (pTemplate == null) {
          Debug.LogWarning("Failed to downgrade building " + pTile.building.asset.id + " because it has no predecessor building.");
          return;
        }
        pTile.building.city?.setBuildingDictID(pTile.building, false);
        pTile.building.setTemplate(pTemplate);
        pTile.building.city?.setBuildingDictID(pTile.building, true);
        pTile.building.initAnimationData();
        pTile.building.updateStats();
        pTile.building.data.health = pTile.building.getMaxHealth();
        pTile.building.fillTiles();
        Debug.LogWarning("Downgraded building " + pTemplate.upgradeTo + " to " + pTemplate.id + ".");
      }
    }
  }
}