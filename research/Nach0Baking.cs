/*using Recipes;
using Science;

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

        public override void OnResearchComplete (ColonyScienceState manager, EResearchCompletionReason reason)
        {
            manager.Colony.RecipeData.UnlockRecipe(new RecipeKey("Nach0Bread-pipliz.baker"));
            manager.Colony.RecipeData.UnlockRecipe(new RecipeKey("Nach0ApplePie-pipliz.baker"));
            manager.Colony.RecipeData.UnlockRecipe(new RecipeKey("Nach0BerryPie-pipliz.baker"));
        }
    }
}
*/
using Recipes;
using Science;


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

        public override void OnResearchComplete(ColonyScienceState manager, EResearchCompletionReason reason)
        {
            manager.Colony.RecipeData.UnlockRecipe(new RecipeKey("Nach0Bread-pipliz.baker"));
            manager.Colony.RecipeData.UnlockRecipe(new RecipeKey("Nach0ApplePie-pipliz.baker"));
            manager.Colony.RecipeData.UnlockRecipe(new RecipeKey("Nach0BerryPie-pipliz.baker"));
        }
    }
}