namespace ModernMod.Code {
  public static class Buildings {
    public static void Init() {
      SetBaseGameBuildingUpgrades();
      
      CreateHouseUpgrades();

      CreateHallUpgrades();

      CreateDocksUpgrades();

      CreateBarracksUpgrades();

      CreateTemplesUpgrades();

      CreateCommonUpgrades();
    }
    private static void CreateBuildingForEveryCivRace(string id, string baseBuilding, bool shadow, ConstructionCost cost, BuildingFundament fundament, int housing, bool canBeUpgraded, string upgradeTo, int upgradeLevel, float health) {
      string[] baseGameCivRaces = { "human", "elf", "orc", "dwarf" };
      foreach (string race in baseGameCivRaces) {
        BuildingAsset b = AssetManager.buildings.clone(id + "_" + race + "_modernmod", baseBuilding);
        b.race = race;
        b.shadow = shadow;
        b.cost = cost;
        b.fundament = fundament;
        b.housing = housing;
        if (canBeUpgraded) b.upgradeTo = upgradeTo + "_" + race + "_modernmod";
        else b.canBeUpgraded = false;
        b.upgradeLevel = upgradeLevel;
        b.base_stats[S.health] = health;
        AssetManager.buildings.loadSprites(b);
      }
    }

    public static void SetBaseGameBuildingUpgrades() {
      //house 5 HUMANS
      BuildingAsset humanH5 = AssetManager.buildings.get("house_human_5");
      humanH5.canBeUpgraded = true;
      humanH5.upgradeTo = "6house_human_modernmod";

      //house 5 ELVES
      BuildingAsset elfH5 = AssetManager.buildings.get("house_elf_5");
      elfH5.canBeUpgraded = true;
      elfH5.upgradeTo = "6house_elf_modernmod";

      //house 5 ORCS
      BuildingAsset orcH5 = AssetManager.buildings.get("house_orc_5");
      orcH5.canBeUpgraded = true;
      orcH5.upgradeTo = "6house_orc_modernmod";

      //house 5 DWARFES
      BuildingAsset dwarfH5 = AssetManager.buildings.get("house_dwarf_5");
      dwarfH5.canBeUpgraded = true;
      dwarfH5.upgradeTo = "6house_dwarf_modernmod";

      //hall 2 HUMANS
      BuildingAsset humanHall2 = AssetManager.buildings.get("hall_human_2");
      humanHall2.canBeUpgraded = true;
      humanHall2.upgradeTo = "3hall_human_modernmod";

      //hall 2 ELVES
      BuildingAsset elfHall2 = AssetManager.buildings.get("hall_elf_2");
      elfHall2.canBeUpgraded = true;
      elfHall2.upgradeTo = "3hall_elf_modernmod";

      //hall 2 ORCS
      BuildingAsset orcHall2 = AssetManager.buildings.get("hall_orc_2");
      orcHall2.canBeUpgraded = true;
      orcHall2.upgradeTo = "3hall_orc_modernmod";

      //hall 2 DWARFES
      BuildingAsset dwarfHall2 = AssetManager.buildings.get("hall_dwarf_2");
      dwarfHall2.canBeUpgraded = true;
      dwarfHall2.upgradeTo = "3hall_dwarf_modernmod";

      //docks 1 HUMANS
      BuildingAsset docksHuman1 = AssetManager.buildings.get("docks_human");
      docksHuman1.upgradeLevel = 1;
      docksHuman1.canBeUpgraded = true;
      docksHuman1.upgradeTo = "2docks_human_modernmod";

      //docks 1 ELVES
      BuildingAsset docksElf1 = AssetManager.buildings.get("docks_elf");
      docksElf1.upgradeLevel = 1;
      docksElf1.canBeUpgraded = true;
      docksElf1.upgradeTo = "2docks_elf_modernmod";

      //docks 1 ORCS
      BuildingAsset docksOrc1 = AssetManager.buildings.get("docks_orc");
      docksOrc1.upgradeLevel = 1;
      docksOrc1.canBeUpgraded = true;
      docksOrc1.upgradeTo = "2docks_orc_modernmod";

      //docks 1 DWARFES
      BuildingAsset docksDwarf1 = AssetManager.buildings.get("docks_dwarf");
      docksDwarf1.upgradeLevel = 1;
      docksDwarf1.canBeUpgraded = true;
      docksDwarf1.upgradeTo = "2docks_dwarf_modernmod";

      //barracks 1 HUMANS
      BuildingAsset humanBarracks1 = AssetManager.buildings.get("barracks_human");
      humanBarracks1.upgradeLevel = 1;
      humanBarracks1.canBeUpgraded = true;
      humanBarracks1.upgradeTo = "2barracks_human_modernmod";

      //barracks 1 ELVES
      BuildingAsset elfBarracks1 = AssetManager.buildings.get("barracks_elf");
      elfBarracks1.upgradeLevel = 1;
      elfBarracks1.canBeUpgraded = true;
      elfBarracks1.upgradeTo = "2barracks_elf_modernmod";

      //barracks 1 ORCS
      BuildingAsset orcBarracks1 = AssetManager.buildings.get("barracks_orc");
      orcBarracks1.upgradeLevel = 1;
      orcBarracks1.canBeUpgraded = true;
      orcBarracks1.upgradeTo = "2barracks_orc_modernmod";

      //barracks 1 DWARFES
      BuildingAsset dwarfBarracks1 = AssetManager.buildings.get("barracks_dwarf");
      dwarfBarracks1.upgradeLevel = 1;
      dwarfBarracks1.canBeUpgraded = true;
      dwarfBarracks1.upgradeTo = "2barracks_dwarf_modernmod";

      //temple 1 HUMANS
      BuildingAsset humanTemple1 = AssetManager.buildings.get("temple_human");
      humanTemple1.upgradeLevel = 1;
      humanTemple1.canBeUpgraded = true;
      humanTemple1.upgradeTo = "2temple_human_modernmod";

      //temple 1 ELVES
      BuildingAsset elfTemple1 = AssetManager.buildings.get("temple_elf");
      elfTemple1.upgradeLevel = 1;
      elfTemple1.canBeUpgraded = true;
      elfTemple1.upgradeTo = "2temple_elf_modernmod";

      //temple 1 ORCS
      BuildingAsset orcTemple1 = AssetManager.buildings.get("temple_orc");
      orcTemple1.upgradeLevel = 1;
      orcTemple1.canBeUpgraded = true;
      orcTemple1.upgradeTo = "2temple_orc_modernmod";

      //temple 1 DWARFES
      BuildingAsset dwarfTemple1 = AssetManager.buildings.get("temple_dwarf");
      dwarfTemple1.upgradeLevel = 1;
      dwarfTemple1.canBeUpgraded = true;
      dwarfTemple1.upgradeTo = "2temple_dwarf_modernmod";

      //bonfire 1 ALL
      BuildingAsset bonfire1 = AssetManager.buildings.get("bonfire");
      bonfire1.upgradeLevel = 1;
      bonfire1.canBeUpgraded = true;
      bonfire1.upgradeTo = "2bonfire_modernmod";

      //well 1 ALL
      BuildingAsset well1 = AssetManager.buildings.get("well");
      well1.upgradeLevel = 1;
      well1.canBeUpgraded = true;
      well1.upgradeTo = "2well_modernmod";

      //mine 1 ALL
      BuildingAsset mine1 = AssetManager.buildings.get("mine");
      mine1.upgradeLevel = 1;
      mine1.canBeUpgraded = true;
      mine1.upgradeTo = "2mine_modernmod";
    }

    private static void CreateCommonUpgrades() {
      BuildingAsset bonfire2 = AssetManager.buildings.clone("2bonfire_modernmod", "bonfire");
      bonfire2.cost = new ConstructionCost(0, 5, 5, 5);
      bonfire2.upgradeLevel = 2;
      bonfire2.smoke = false;
      bonfire2.base_stats[S.health] = 500f;
      bonfire2.canBeUpgraded = false;
      AssetManager.buildings.loadSprites(bonfire2);

      BuildingAsset well2 = AssetManager.buildings.clone("2well_modernmod", "well");
      well2.cost = new ConstructionCost(0, 20, 20, 10);
      well2.upgradeLevel = 2;
      well2.base_stats[S.health] = 250f;
      well2.canBeUpgraded = false;
      AssetManager.buildings.loadSprites(well2);

      BuildingAsset mine2 = AssetManager.buildings.clone("2mine_modernmod", "mine");
      mine2.cost = new ConstructionCost(0, 10, 25, 15);
      mine2.upgradeLevel = 2;
      mine2.base_stats[S.health] = 250f;
      mine2.canBeUpgraded = false;
      AssetManager.buildings.loadSprites(mine2);
    }
    private static void CreateTemplesUpgrades() {
      CreateBuildingForEveryCivRace(
        "2temple",
        "temple_human",
        true,
        new ConstructionCost(0, 20, 4, 60),
        new BuildingFundament(1, 1, 2, 0),
        0,
        true,
        "3temple",
        2,
        400f
      );
      CreateBuildingForEveryCivRace(
        "3temple",
        "2temple_human_modernmod",
        true,
        new ConstructionCost(0, 20, 4, 60),
        new BuildingFundament(1, 1, 2, 0),
        0,
        false,
        "",
        3,
        500f
      );
    }
    private static void CreateBarracksUpgrades() {
      CreateBuildingForEveryCivRace(
        "2barracks",
        "barracks_human",
        true,
        new ConstructionCost(0, 40, 40, 40),
        new BuildingFundament(1, 1, 2, 0),
        0,
        true,
        "3barracks",
        2,
        400f
      );
      CreateBuildingForEveryCivRace(
        "3barracks",
        "2barracks_human_modernmod",
        true,
        new ConstructionCost(0, 40, 40, 40),
        new BuildingFundament(1, 1, 2, 0),
        0,
        false,
        "",
        3,
        500f
      );
    }
    private static void CreateDocksUpgrades() {
      CreateBuildingForEveryCivRace(
        "2docks",
        "docks_human",
        true,
        new ConstructionCost(0, 10, 10, 10),
        new BuildingFundament(1, 1, 2, 0),
        0,
        true,
        "3docks",
        2,
        300f
      );
      CreateBuildingForEveryCivRace(
        "3docks",
        "2docks_human_modernmod",
        true,
        new ConstructionCost(0, 10, 20, 20),
        new BuildingFundament(1, 1, 2, 0),
        0,
        false,
        "",
        3,
        400f
      );
    }
    private static void CreateHallUpgrades() {
      CreateBuildingForEveryCivRace(
        "3hall",
        "hall_human_2",
        false,
        new ConstructionCost(0, 20, 1, 150),
        new BuildingFundament(1, 1, 2, 0),
        15,
        true,
        "4hall",
        3,
        800f
      );
      CreateBuildingForEveryCivRace(
        "4hall",
        "3hall_human_modernmod",
        false,
        new ConstructionCost(0, 30, 1, 200),
        new BuildingFundament(1, 1, 2, 0),
        20,
        true,
        "5hall",
        4,
        1000f
      );
      CreateBuildingForEveryCivRace(
        "5hall",
        "4hall_human_modernmod",
        false,
        new ConstructionCost(0, 60, 1, 250),
        new BuildingFundament(1, 1, 2, 0),
        25,
        true,
        "6hall",
        5,
        1200f
      );
      CreateBuildingForEveryCivRace(
        "6hall",
        "5hall_human_modernmod",
        false,
        new ConstructionCost(0, 80, 20, 300),
        new BuildingFundament(1, 1, 2, 0),
        30,
        false,
        "",
        6,
        1500f
      );
    }
    private static void CreateHouseUpgrades() {
      CreateBuildingForEveryCivRace(
        "6house",
        "house_human_5",
        false,
        new ConstructionCost(0, 10, 10, 10),
        new BuildingFundament(1, 1, 2, 0),
        1,
        true,
        "7house",
        6,
        425f
      );
      CreateBuildingForEveryCivRace(
        "7house",
        "6house_human_modernmod",
        false,
        new ConstructionCost(1, 1, 1, 1),
        new BuildingFundament(1, 1, 2, 0),
        9,
        true,
        "8house",
        7,
        450f
      );
      CreateBuildingForEveryCivRace(
        "8house",
        "7house_human_modernmod",
        false,
        new ConstructionCost(0, 15, 10, 15),
        new BuildingFundament(1, 1, 2, 0),
        11,
        true,
        "9house",
        8,
        500f
      );
      CreateBuildingForEveryCivRace(
        "9house",
        "8house_human_modernmod",
        false,
        new ConstructionCost(0, 15, 15, 20),
        new BuildingFundament(1, 1, 2, 0),
        13,
        true,
        "10house",
        9,
        550f
      );
      CreateBuildingForEveryCivRace(
        "10house",
        "9house_human_modernmod",
        false,
        new ConstructionCost(0, 20, 20, 25),
        new BuildingFundament(1, 1, 2, 0),
        15,
        true,
        "11house",
        10,
        600f
      );
      CreateBuildingForEveryCivRace(
        "11house",
        "10house_human_modernmod",
        false,
        new ConstructionCost(0, 25, 25, 25),
        new BuildingFundament(1, 1, 2, 0),
        17,
        false,
        "",
        11,
        650f
      );
    }
  }
}