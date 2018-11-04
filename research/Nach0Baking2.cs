using Recipes;
using Science;

namespace MoreNutrition.Research
{
    [AutoLoadedResearchable]
    public class Nach0Baking2 : BaseResearchable
    {
        public Nach0Baking2()
        {
            key = "Nach0Baking2";
            icon = "gamedata/mods/NACH0/MoreNutrition/gamedata/textures/icons/applepie.png";
            iterationCount = 50;
            AddIterationRequirement("Nach0CookedChickenMeat", 3);
            AddIterationRequirement("sciencebagbasic", 1);
            AddDependency("Nach0ChickenFarming");
        }

        public override void OnResearchComplete(ColonyScienceState manager, EResearchCompletionReason reason)
        {
            manager.Colony.RecipeData.UnlockRecipe(new RecipeKey("Nach0ChickenPie-pipliz.baker"));
        }
    }
}