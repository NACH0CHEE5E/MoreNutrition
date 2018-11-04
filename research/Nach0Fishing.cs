using Recipes;
using Science;

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

        public override void OnResearchComplete(ColonyScienceState manager, EResearchCompletionReason reason)
        {
            manager.Colony.RecipeData.UnlockRecipe(new RecipeKey("nach0.recipes.fishersremastered.pipliz.crafter.rod"));
            manager.Colony.RecipeData.UnlockRecipe(new RecipeKey("nach0.recipes.fishersremastered.pipliz.baker.cookedfish"));
        }
    }
}