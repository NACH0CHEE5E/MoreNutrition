using Recipes;
using Science;

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

        public override void OnResearchComplete(ColonyScienceState manager, EResearchCompletionReason reason)
        {
            manager.Colony.RecipeData.UnlockRecipe(new RecipeKey("Nach0ChickenCoopJobBlock-pipliz.crafter"));
            manager.Colony.RecipeData.UnlockRecipe(new RecipeKey("Nach0ChickenFence-pipliz.crafter"));
            manager.Colony.RecipeData.UnlockRecipe(new RecipeKey("Nach0ChickenFenceCorner-pipliz.crafter"));
            manager.Colony.RecipeData.UnlockRecipe(new RecipeKey("Nach0ChickenFeed-pipliz.crafter"));
            manager.Colony.RecipeData.UnlockRecipe(new RecipeKey("Nach0CookedChickenMeat-pipliz.baker"));
        }
    }
}