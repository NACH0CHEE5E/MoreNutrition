using Recipes;
using Science;

namespace MoreNutrition.Research
{
    [AutoLoadedResearchable]
    public class Nach0Fishing2 : BaseResearchable
    {
        public Nach0Fishing2()
        {
            key = "Nach0Fishing2";
            icon = "gamedata/mods/NACH0/MoreNutrition/gamedata/textures/icons/fish.png";
            iterationCount = 50;
            AddIterationRequirement("nach0.types.fishersremastered.lure", 1);
            AddIterationRequirement("nach0.types.fishersremastered.fish", 15);
            AddIterationRequirement("sciencebagadvanced", 2);
            AddDependency("Nach0Lure");
        }

        public override void OnResearchComplete(ColonyScienceState manager, EResearchCompletionReason reason)
        {
            manager.Colony.RecipeData.UnlockRecipe(new RecipeKey("nach0.recipes.fishersremastered.pipliz.crafter.betterrod"));
        }
    }
}