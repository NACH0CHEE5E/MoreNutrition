using Pipliz.Mods.APIProvider.Science;
using Server.Science;

namespace MoreNutrition.Research
{
    [AutoLoadedResearchable]
    public class Nach0Baking : BaseResearchable
    {
        public Nach0Baking()
        {
            key = "Nach0Baking";
            icon = "gamedata/mods/NACH0/MoreNutrition/gamedata/textures/icons/bread.png";
            iterationCount = 15;
            AddIterationRequirement("bread", 3);
            AddDependency("pipliz.baseresearch.wheatfarming");
        }

        public override void OnResearchComplete(ScienceManagerPlayer manager, EResearchCompletionReason reason)
        {
            RecipeStorage.GetPlayerStorage(manager.Player).SetRecipeAvailability("Nach0Bread-pipliz.baker", true, "pipliz.baker");
            RecipeStorage.GetPlayerStorage(manager.Player).SetRecipeAvailability("Nach0ApplePie-pipliz.baker", true, "pipliz.baker");
            RecipeStorage.GetPlayerStorage(manager.Player).SetRecipeAvailability("Nach0BerryPie-pipliz.baker", true, "pipliz.baker");
        }
    }
}