using Pipliz.Mods.APIProvider.Science;
using Server.Science;

namespace MoreNutrition.Research
{
    [AutoLoadedResearchable]
    public class Nach0ChickenFarming : BaseResearchable
    {
        public Nach0ChickenFarming()
        {
            key = "Nach0ChickenFarming";
            icon = "gamedata/mods/NACH0/MoreNutrition/gamedata/textures/icons/chicken.png";
            iterationCount = 75;
            AddIterationRequirement("sciencebagbasic", 5);
            AddIterationRequirement("sciencebaglife", 5);
            AddDependency("Nach0Butchering");
            AddDependency("pipliz.baseresearch.sciencebaglife");
        }

        public override void OnResearchComplete(ScienceManagerPlayer manager, EResearchCompletionReason reason)
        {
            RecipeStorage.GetPlayerStorage(manager.Player).SetRecipeAvailability("Nach0ChickenCoopJobBlock-pipliz.crafter", true, "pipliz.crafter");
            RecipeStorage.GetPlayerStorage(manager.Player).SetRecipeAvailability("Nach0ChickenFence-pipliz.crafter", true, "pipliz.crafter");
            RecipeStorage.GetPlayerStorage(manager.Player).SetRecipeAvailability("Nach0ChickenFenceCorner-pipliz.crafter", true, "pipliz.crafter");
            RecipeStorage.GetPlayerStorage(manager.Player).SetRecipeAvailability("Nach0ChickenFeed-pipliz.crafter", true, "pipliz.crafter");
            RecipeStorage.GetPlayerStorage(manager.Player).SetRecipeAvailability("Nach0CookedChickenMeat-pipliz.baker", true, "pipliz.baker");
        }
    }
}