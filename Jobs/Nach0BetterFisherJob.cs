using BlockTypes.Builtin;
using Pipliz.Mods.APIProvider.Jobs;
using Server.NPCs;
using Pipliz;
using NPC;


namespace Jobs
{
    public class Nach0BetterFisherJob : CraftingJobBase, IBlockJobBase, INPCTypeDefiner
    {
        public static float StaticCraftingCooldown = 5f;

        public override string NPCTypeKey { get { return "Nach0BetterFisherJob"; } }

        public override float CraftingCooldown
        {
            get { return StaticCraftingCooldown; }
            set { StaticCraftingCooldown = value; }
        }

        private static ushort waterType = ItemTypes.IndexLookup.GetIndex("water");
        private Vector3Int waterPosition = Vector3Int.maximum;
        private static float waitForWater = 8f;

        private void calculateWaterPosition()
        {
            if (!World.TryGetTypeAt(position, out ushort type))
                return;

            string rodDirection = ItemTypes.IndexLookup.GetName(type);
            rodDirection = rodDirection.Substring(rodDirection.Length - 2); //Will save x+, x-, z+, z-

            switch (rodDirection)
            {
                case "x+":
                    waterPosition = position + Vector3Int.down + new Vector3Int(1, 0, 0);
                    break;
                case "x-":
                    waterPosition = position + Vector3Int.down + new Vector3Int(-1, 0, 0);
                    break;
                case "z+":
                    waterPosition = position + Vector3Int.down + new Vector3Int(0, 0, 1);
                    break;
                case "z-":
                    waterPosition = position + Vector3Int.down + new Vector3Int(0, 0, -1);
                    break;

                default:
                    waterPosition = position;
                    Log.Write("<color=red>PROBLEM WITH WATERPOSITION</color>");
                    break;
            }
        }

        public override int MaxRecipeCraftsPerHaul { get { return 4; } }

        NPCTypeStandardSettings INPCTypeDefiner.GetNPCTypeDefinition()
        {
            return new NPCTypeStandardSettings()
            {
                keyName = NPCTypeKey,
                printName = "Better Fisher",
                maskColor1 = new UnityEngine.Color32(84, 2, 2, 1),
                type = NPCTypeID.GetNextID()
            };
        }

        public override void OnNPCAtJob(ref NPCBase.NPCState state)
        {
            //Initialize waterPosition if is not initialized
            if (waterPosition == Vector3Int.maximum)
                calculateWaterPosition();

            if (!World.TryGetTypeAt(waterPosition, out ushort type) || type != waterType)
            {
                state.SetIndicator(new Shared.IndicatorState(waitForWater, "water"));    //Wait X time saying that he doesn't have water
            }
            else
                base.OnNPCAtJob(ref state); //Normal work
        }
    }
}