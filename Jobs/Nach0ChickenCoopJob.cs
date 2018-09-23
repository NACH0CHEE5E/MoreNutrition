using System.Collections.Generic;
using BlockTypes.Builtin;
using Pipliz.Mods.APIProvider.Jobs;
using Server.NPCs;
using NPC;
using Pipliz;
using Pipliz.JSON;


namespace Jobs
{
    public class Nach0ChickenCoopJob : BlockJobBase, IBlockJobBase, INPCTypeDefiner
    {

        public override string NPCTypeKey { get { return "Nach0ChickenCoopJob"; } }

        private static float CraftingCooldown = 15f;
        private static float BlockPlacementCooldown = 1f;
        private static float MissingItemCooldown = 2f;
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
            { typeCornerZP, typeFenceX, 0, typeFenceX, typeCornerXN },
            { typeFenceZ, typeStraw, typeStraw, typeStraw, typeFenceZ },
            { typeFenceZ, typeStraw, typeStraw, typeStraw, typeFenceZ },
            { typeFenceZ, typeStraw, typeStraw, typeStraw, typeFenceZ },
            { typeCornerXP, typeFenceX, typeFenceX, typeFenceX, typeCornerZN }
        };
        public static ushort[,] coopAreaZP = new ushort[,] {
            { typeCornerXP, typeFenceZ, 0, typeFenceZ, typeCornerZP },
            { typeFenceX, typeStraw, typeStraw, typeStraw, typeFenceX },
            { typeFenceX, typeStraw, typeStraw, typeStraw, typeFenceX },
            { typeFenceX, typeStraw, typeStraw, typeStraw, typeFenceX },
            { typeCornerZN, typeFenceZ, typeFenceZ, typeFenceZ, typeCornerXN }
        };
        public static ushort[,] coopAreaZN = new ushort[,] {
            { typeCornerZN, typeFenceZ, 0, typeFenceZ, typeCornerXN },
            { typeFenceX, typeStraw, typeStraw, typeStraw, typeFenceX },
            { typeFenceX, typeStraw, typeStraw, typeStraw, typeFenceX },
            { typeFenceX, typeStraw, typeStraw, typeStraw, typeFenceX },
            { typeCornerXP, typeFenceZ, typeFenceZ, typeFenceZ, typeCornerZP }
        };
        public static ushort[,] coopArea;

        public bool coopTestDone = false;

        // currenty one item consumed, one item produced and one byproduct with a chance.
		// If more products are needed those should be defined as List<ushort> item...
        private static ushort ConsumedItem = ItemTypes.IndexLookup.GetIndex("Nach0ChickenFeed");
        private static ushort ProducedItem = ItemTypes.IndexLookup.GetIndex("Nach0Egg");
        private static ushort ByproductItem = ItemTypes.IndexLookup.GetIndex("Nach0ChickenCorpse");
		private static float ByproductChance = 0.20f;

        // create new instance (when job block is placed)
        public ITrackableBlock InitializeOnAdd(Vector3Int pos, ushort blockType, Players.Player owner)
        {
            base.InitializeJob(owner, pos, 0);
            return this;
        }

        // load from savegame
        public override ITrackableBlock InitializeFromJSON(Players.Player owner, JSONNode node)
        {
            base.InitializeJob(owner, (Vector3Int)node["position"], node.GetAs<int>("npcID"));
            return this;
        }

        NPCTypeStandardSettings INPCTypeDefiner.GetNPCTypeDefinition()
        {
            return new NPCTypeStandardSettings()
            {
                keyName = NPCTypeKey,
                printName = "Chicken coop",
                maskColor1 = new UnityEngine.Color32(84, 2, 2, 1),
                type = NPCTypeID.GetNextID(),
				inventoryCapacity = 0.1f
            };
        }

        public override void OnNPCAtJob(ref NPCBase.NPCState state)
        {
            if (!this.coopTestDone)
            {
                string chickenCoopDirection = ItemTypes.IndexLookup.GetName(base.worldType);
                this.CoopDirection = chickenCoopDirection.Substring(chickenCoopDirection.Length - 2);

                if (this.checkChickenCoop(ref state) == false)
                {
                    return;
                }
            }

            // regular work, consume straw and produce eggs
            Stockpile stockpile;
            Stockpile.TryGetStockpile(this.Owner, out stockpile);
            if (!stockpile.TryRemove(ConsumedItem))
            {
                state.SetIndicator(new Shared.IndicatorState(MissingItemCooldown, ConsumedItem, true, false), true);
                return;
            }
            state.Inventory.Add(ProducedItem);
			if (Pipliz.Random.NextFloat(0.0f, 1.0f) > (1.0f - ByproductChance)) {
				state.Inventory.Add(ByproductItem);
			}
            state.SetIndicator(new Shared.IndicatorState(CraftingCooldown, ProducedItem), true);

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
                            ItemTypes.ItemType inventoryType = newType;
                            if (inventoryType.ParentItemType != null)
                            {
                                inventoryType = inventoryType.ParentItemType;
                            }
                            // try to consume the item from the stockpile
                            Stockpile stockpile;
                            if (!Stockpile.TryGetStockpile(this.Owner, out stockpile))
                            {
                                return false;
                            }
                            if (!stockpile.TryRemove(inventoryType.ItemIndex))
                            {
                                state.SetIndicator(new Shared.IndicatorState(MissingItemCooldown, inventoryType.ItemIndex, true, false), true);
                                // state.SetCooldown(MissingItemCooldown);
                                return false;
                            }

                            // change the block in the world
                            ServerManager.TryChangeBlock(checkPos, expectedType);
                            state.SetIndicator(new Shared.IndicatorState(BlockPlacementCooldown, expectedType), true);
                            // state.SetCooldown(BlockPlacementCooldown);
                            return false;
                        }
                    }
                    pos = pos.Add(colStepX, 0, colStepZ);
                }
                pos = pos.Add(colStepX * -NumberOfCols, 0, colStepZ * -NumberOfCols); // reset col position
                pos = pos.Add(rowStepX, 0, rowStepZ);   // next row
            }

            this.coopTestDone = true;
            return true;
        }

    }
}
