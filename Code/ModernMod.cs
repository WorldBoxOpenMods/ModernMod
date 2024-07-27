using System.Threading.Tasks;
using NeoModLoader.api;

namespace ModernMod.Code {
  public class ModernMod : BasicMod<ModernMod> {
    private static async Task LateInit() {
      while (true) {
        await Task.Delay(500);
        if (Instance.enabled == false) break;
        Buildings.SetBaseGameBuildingUpgrades();
      }
    }
    protected override void OnModLoad() {
      Buildings.Init();
      Powers.Init();
      BuildOrders.Init();
      Task.Run(LateInit);
    }
  }
}