using BlockTypes.Builtin;
using Pipliz.Mods.APIProvider.Jobs;
using Server.NPCs;
using Pipliz;
using NPC;


namespace Jobs
{
    public class Nach0ChickenCoopJob : CraftingJobBase, IBlockJobBase, INPCTypeDefiner
    {
        public static float StaticCraftingCooldown = 5f;

        public override string NPCTypeKey { get { return "Nach0ChickenCoopJob"; } }

        public override float CraftingCooldown
        {
            get { return StaticCraftingCooldown; }
            set { StaticCraftingCooldown = value; }
        }

        private static float BlockPlacementCooldown = 0.5f;
        private static ushort typeStraw = ItemTypes.IndexLookup.GetIndex("straw");
        private static ushort typeFenceX = ItemTypes.IndexLookup.GetIndex("Nach0ChickenFencex");
        private static ushort typeFenceZ = ItemTypes.IndexLookup.GetIndex("Nach0ChickenFencez");
        private static ushort typeCornerXP = ItemTypes.IndexLookup.GetIndex("Nach0ChickenFenceCornerx+");
        private static ushort typeCornerXN = ItemTypes.IndexLookup.GetIndex("Nach0ChickenFenceCornerx-");
        private static ushort typeCornerZN = ItemTypes.IndexLookup.GetIndex("Nach0ChickenFenceCornerz-");
        private static ushort typeCornerZP = ItemTypes.IndexLookup.GetIndex("Nach0ChickenFenceCornerz+");

        // The coop is defined by a number of rows and columns. The job block is facing in a specific direction, that direction
        // specifies if rows/columns are vertical or horizontal.
        // As an example: the job block faces east (right/X+): then the coop is three vertical rows with horizontal columns (east of it)
        public string CoopDirection = "none";
        public const int NumberOfRows = 5;
        public const int NumberOfCols = 5;

        // rows should always be an uneven number to have the whole coop symmetric. HalfRow is used to get from the job block to the start of a row
        public const int HalfRow = (NumberOfRows - 1) / 2;

        public static ushort[,] coopAreaXP = new ushort[,] {
            { typeCornerXP, typeFenceX, 0, typeFenceX, typeCornerZN },
            { typeFenceZ, typeStraw, typeStraw, typeStraw, typeFenceZ },
            { typeFenceZ, typeStraw, typeStraw, typeStraw, typeFenceZ },
            { typeFenceZ, typeStraw, typeStraw, typeStraw, typeFenceZ },
            { typeCornerZP, typeFenceX, typeFenceX, typeFenceX, typeCornerXN }
        };
        public static ushort[,] coopAreaXN = new ushort[,] {
            { typeCornerXP, typeFenceZ, 0, typeFenceZ, typeCornerZN },
            { typeFenceX, typeStraw, typeStraw, typeStraw, typeFenceX },
            { typeFenceX, typeStraw, typeStraw, typeStraw, typeFenceX },
            { typeFenceX, typeStraw, typeStraw, typeStraw, typeFenceX },
            { typeCornerXN, typeFenceZ, typeFenceZ, typeFenceZ, typeCornerZP }
        };
        public static ushort[,] coopAreaZP = new ushort[,] {
            { typeCornerXP, typeFenceX, 0, typeFenceX, typeCornerZN },
            { typeFenceZ, typeStraw, typeStraw, typeStraw, typeFenceZ },
            { typeFenceZ, typeStraw, typeStraw, typeStraw, typeFenceZ },
            { typeFenceZ, typeStraw, typeStraw, typeStraw, typeFenceZ },
            { typeCornerXN, typeFenceX, typeFenceX, typeFenceX, typeCornerZP }
        };
        public static ushort[,] coopAreaZN = new ushort[,] {
            { typeCornerXP, typeFenceX, 0, typeFenceX, typeCornerZN },
            { typeFenceZ, typeStraw, typeStraw, typeStraw, typeFenceZ },
            { typeFenceZ, typeStraw, typeStraw, typeStraw, typeFenceZ },
            { typeFenceZ, typeStraw, typeStraw, typeStraw, typeFenceZ },
            { typeCornerXN, typeFenceX, typeFenceX, typeFenceX, typeCornerZP }
        };
        public static ushort[,] coopArea;

        public bool coopTestDone = false;

        public override int MaxRecipeCraftsPerHaul { get { return 4; } }

        // create new instance (when job block is placed)
        public override ITrackableBlock InitializeOnAdd(Vector3Int pos, ushort blockType, Players.Player owner)
        {
            string chickenCoopDirection = ItemTypes.IndexLookup.GetName(blockType);
            CoopDirection = chickenCoopDirection.Substring(chickenCoopDirection.Length - 2); // Will save x+, x-, z+, z-

            this.InitializeJob(owner, pos, 0);
            return this;
        }

        // to be implemented to allow savegame load + save
        // public JSONNode GetJSON()
        // public ITrackableBlock InitializeFromJSON(Players.Player owner, JSONNode node)

        NPCTypeStandardSettings INPCTypeDefiner.GetNPCTypeDefinition()
        {
            return new NPCTypeStandardSettings()
            {
                keyName = NPCTypeKey,
                printName = "Chicken coop",
                maskColor1 = new UnityEngine.Color32(84, 2, 2, 1),
                type = NPCTypeID.GetNextID()
            };
        }

        public override void OnNPCAtJob(ref NPCBase.NPCState state)
        {
            if (!coopTestDone)
            {
                if (checkChickenCoop(ref state) == false)
                {
                    return;
                }
            }

            base.OnNPCAtJob(ref state); // Normal work
            state.SetCooldown(this.CraftingCooldown);
            return;
        }

        // check if the coop is set up correctly.
        // Gameplay wise it would be nice if the NPC would build the coop itself
        private bool checkChickenCoop(ref NPCBase.NPCState state)
        {
            Vector3Int pos = base.position;
            int rowStepX = 0, rowStepZ = 0, colStepX = 0, colStepZ = 0;
            switch (CoopDirection)
            {
                case "x+":
                    pos = pos.Add(0, 0, -HalfRow);
                    rowStepX = 1;   // rows are west->east (X+)
                    colStepZ = 1;   // cols are north->south (Z+)
                    coopArea = coopAreaXP;
                    break;
                case "x-":
                    pos = pos.Add(0, 0, -HalfRow);
                    rowStepX = -1;  // rows are east->west (X-)
                    colStepZ = 1;   // cols are north->south (Z+)
                    coopArea = coopAreaXN;
                    break;
                case "z+":
                    pos = pos.Add(-HalfRow, 0, 0);
                    rowStepZ = 1;   // rows are north->south (Z+)
                    colStepX = 1;   // cols are west->east (X+)
                    coopArea = coopAreaZP;
                    break;
                case "z-":
                    pos = pos.Add(-HalfRow, 0, 0);
                    rowStepZ = -1;  // rows are south->north (Z-)
                    colStepX = 1;   // cols are west->east (X+)
                    coopArea = coopAreaZN;
                    break;
            }

            // iterator over all rows and columns to check the block types
            // this could be extended to have the NPC place the actual blocks.
            // that would involve setting the NPC goal to make it move around
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfCols; j++)
                {
                    ushort expectedType = coopArea[i, j];

                    if (expectedType != 0)
                    {
                        // all outer blocks are on the same height (jobblock / fence).
                        // all inner blocks (straw) one lower
                        Vector3Int checkPos = pos;
                        if (i > 0 && i < (NumberOfRows - 1) && j > 0 && j < (NumberOfCols - 1))
                        {
                            checkPos = checkPos.Add(0, -1, 0);
                        }

                        ushort foundType;
                        if (!World.TryGetTypeAt(checkPos, out foundType) || foundType != expectedType)
                        {
                            ItemTypes.ItemType newType = ItemTypes.GetType(expectedType);
                            ServerManager.TryChangeBlock(checkPos, expectedType);
                            state.SetIndicator(new Shared.IndicatorState(BlockPlacementCooldown, expectedType, true, false), true);
                            state.SetCooldown(BlockPlacementCooldown);
                            return false;
                        }
                    }
                    pos = pos.Add(colStepX, 0, colStepZ);
                }
                pos = pos.Add(colStepX * -NumberOfCols, 0, colStepZ * -NumberOfCols); // reset col position
                pos = pos.Add(rowStepX, 0, rowStepZ);   // next row
            }

            coopTestDone = true;
            return true;
        }

    }
}
