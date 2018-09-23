using Pipliz.Mods.APIProvider.Science;
using Server.Science;

namespace MoreNutrition.Research
{
    [AutoLoadedResearchable]
    public class Nach0Lure : BaseResearchable
    {
        public Nach0Lure()
        {
            key = "Nach0Lure";
            icon = "gamedata/mods/NACH0/MoreNutrition/gamedata/textures/icons/lure.png";
            iterationCount = 35;
            AddIterationRequirement("nach0.types.fishersremastered.fish", 10);
            AddIterationRequirement("nach0.types.fishersremastered.rod", 1);
            AddIterationRequirement("sciencebagadvanced", 2);
            AddDependency("Nach0Fishing");
            AddDependency("pipliz.baseresearch.sciencebagadvanced");
        }

        public override void OnResearchComplete(ScienceManagerPlayer manager, EResearchCompletionReason reason)
        {
            RecipeStorage.GetPlayerStorage(manager.Player).SetRecipeAvailability("nach0.recipes.fishersremastered.pipliz.merchant.lure", true, "pipliz.merchant");
        }
    }
}