using Pipliz.Mods.APIProvider.Science;
using Server.Science;

namespace MoreNutrition.Research
{
    [AutoLoadedResearchable]
    public class Nach0Butchering : BaseResearchable
    {
        public Nach0Butchering()
        {
            key = "Nach0Butchering";
            icon = "gamedata/mods/NACH0/MoreNutrition/gamedata/textures/icons/butcher.png";
            iterationCount = 45;
            AddIterationRequirement("sciencebagbasic", 5);
            AddIterationRequirement("ironsword", 5);
            AddDependency("pipliz.baseresearch.sciencebagbasic");
        }

        public override void OnResearchComplete(ScienceManagerPlayer manager, EResearchCompletionReason reason)
        {
            RecipeStorage.GetPlayerStorage(manager.Player).SetRecipeAvailability("Nach0ButcherBlock-pipliz.crafter", true, "pipliz.crafter");
        }
    }
}