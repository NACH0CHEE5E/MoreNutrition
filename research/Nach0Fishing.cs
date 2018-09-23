using Pipliz.Mods.APIProvider.Science;
using Server.Science;

namespace MoreNutrition.Research
{
    [AutoLoadedResearchable]
    public class Nach0Fishing : BaseResearchable
    {
        public Nach0Fishing()
        {
            key = "Nach0Fishing";
            icon = "gamedata/mods/NACH0/MoreNutrition/gamedata/textures/icons/fish.png";
            iterationCount = 25;
            AddIterationRequirement("sciencebagbasic", 2);
            AddDependency("pipliz.baseresearch.sciencebagbasic");
        }

        public override void OnResearchComplete(ScienceManagerPlayer manager, EResearchCompletionReason reason)
        {
            RecipeStorage.GetPlayerStorage(manager.Player).SetRecipeAvailability("nach0.recipes.fishersremastered.pipliz.crafter.rod", true, "pipliz.crafter");
            RecipeStorage.GetPlayerStorage(manager.Player).SetRecipeAvailability("nach0.recipes.fishersremastered.pipliz.baker.cookedfish", true, "pipliz.baker");
        }
    }
}