using System.Collections.Generic;

namespace ModernMod.Code
{
    public static class Tech {
        private static void Init()
        {
            CultureTechAsset house6 = new CultureTechAsset {
                id = "house_tier_6",
                path_icon = "tech/icon_tech_house_tier_5",
                required_level = 21,
                requirements = new List<string>{"house_tier_5"}
            };
            AssetManager.culture_tech.add(house6);

            CultureTechAsset house7 = new CultureTechAsset {
                id = "house_tier_7",
                path_icon = "tech/icon_tech_house_tier_5",
                required_level = 22,
                requirements = new List<string>{"house_tier_6"}
            };
            AssetManager.culture_tech.add(house7);

            CultureTechAsset house8 = new CultureTechAsset {
                id = "house_tier_8",
                path_icon = "tech/icon_tech_house_tier_5",
                required_level = 23,
                requirements = new List<string>{"house_tier_7"}
            };
            AssetManager.culture_tech.add(house8);

            CultureTechAsset house9 = new CultureTechAsset {
                id = "house_tier_9",
                path_icon = "tech/icon_tech_house_tier_5",
                required_level = 24,
                requirements = new List<string>{"house_tier_8"}
            };
            AssetManager.culture_tech.add(house9);

            CultureTechAsset house10 = new CultureTechAsset {
                id = "house_tier_10",
                path_icon = "tech/icon_tech_house_tier_5",
                required_level = 25,
                requirements = new List<string>{"house_tier_9"}
            };
            AssetManager.culture_tech.add(house10);

            CultureTechAsset house11 = new CultureTechAsset {
                id = "house_tier_11",
                path_icon = "tech/icon_tech_house_tier_5",
                required_level = 26,
                requirements = new List<string>{"house_tier_10"}
            };
            AssetManager.culture_tech.add(house11);
        }
    }
}
