using Pipliz.Mods.APIProvider.Jobs;
using System.IO;

namespace jobentrys
{
    [ModLoader.ModManager]
    public static class jobentrys
    {
        public static string ModGamedataDirectory;

        [ModLoader.ModCallback(ModLoader.EModCallbackType.OnAssemblyLoaded, "nach0.morenutrition.assemblyload")]
        [ModLoader.ModDocumentation("Sets BaseGame gamedata directory")]
        public static void OnAssemblyLoaded(string path)
        {
            ModGamedataDirectory = Path.Combine(Path.GetDirectoryName(path), "gamedata/");
        }

        [ModLoader.ModCallback(ModLoader.EModCallbackType.AfterItemTypesDefined, "nach0.morenutrition.registerjobs")]
        [ModLoader.ModCallbackProvidesFor("pipliz.apiprovider.jobs.resolvetypes")]
        [ModLoader.ModDocumentation("Adds all the job block implementations to BlockJobManagerTracker")]
        public static void AfterDefiningNPCTypes()
        {
            BlockJobManagerTracker.Register<Jobs.Nach0FisherJob>("nach0.types.fishersremastered.rod");
            BlockJobManagerTracker.Register<Jobs.Nach0BetterFisherJob>("nach0.types.fishersremastered.betterrod");
            BlockJobManagerTracker.Register<Jobs.Nach0ChickenCoopJob>("Nach0ChickenCoopJobBlock");
            BlockJobManagerTracker.Register<Jobs.Nach0ButcherJob>("Nach0ButcherBlock");
        }
    }
}
