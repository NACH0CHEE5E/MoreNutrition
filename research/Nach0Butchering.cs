using Recipes;
using Science;

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
            AddIterationRequirement("sciencebagbasic", 2);
            //AddIterationRequirement("ironsword", 5);
            AddDependency("pipliz.baseresearch.sciencebagbasic");
        }

        public override void OnResearchComplete(ColonyScienceState manager, EResearchCompletionReason reason)
        {
            manager.Colony.RecipeData.UnlockRecipe(new RecipeKey("Nach0ButcherBlock-pipliz.crafter"));
        }
    }
}