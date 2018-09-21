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

        private static ushort strawType = ItemTypes.IndexLookup.GetIndex("straw");
        private static ushort Nach0ChickenFencexType = ItemTypes.IndexLookup.GetIndex("Nach0ChickenFencex");
        private static ushort Nach0ChickenFencezType = ItemTypes.IndexLookup.GetIndex("Nach0ChickenFencez");
        private static ushort Nach0ChickenFenceCornerCornerxpType = ItemTypes.IndexLookup.GetIndex("Nach0ChickenFenceCornerx+");
        private static ushort Nach0ChickenFenceCornerCornerxmType = ItemTypes.IndexLookup.GetIndex("Nach0ChickenFenceCornerx-");
        private static ushort Nach0ChickenFenceCornerCornerzmType = ItemTypes.IndexLookup.GetIndex("Nach0ChickenFenceCornerz-");
        private static ushort Nach0ChickenFenceCornerCornerzpType = ItemTypes.IndexLookup.GetIndex("Nach0ChickenFenceCornerz+");
        string blockDir = "q";
        private Vector3Int strawPosition1 = Vector3Int.maximum;
        private Vector3Int strawPosition2 = Vector3Int.maximum;
        private Vector3Int strawPosition3 = Vector3Int.maximum;
        private Vector3Int strawPosition4 = Vector3Int.maximum;
        private Vector3Int strawPosition5 = Vector3Int.maximum;
        private Vector3Int strawPosition6 = Vector3Int.maximum;
        private Vector3Int strawPosition7 = Vector3Int.maximum;
        private Vector3Int strawPosition8 = Vector3Int.maximum;
        private Vector3Int strawPosition9 = Vector3Int.maximum;
        private Vector3Int fencePosition1 = Vector3Int.maximum;
        private Vector3Int fencePosition2 = Vector3Int.maximum;
        private Vector3Int fencePosition3 = Vector3Int.maximum;
        private Vector3Int fencePosition4 = Vector3Int.maximum;
        private Vector3Int fencePosition5 = Vector3Int.maximum;
        private Vector3Int fencePosition6 = Vector3Int.maximum;
        private Vector3Int fencePosition7 = Vector3Int.maximum;
        private Vector3Int fencePosition8 = Vector3Int.maximum;
        private Vector3Int fencePosition9 = Vector3Int.maximum;
        private Vector3Int fencePosition10 = Vector3Int.maximum;
        private Vector3Int fencePosition11 = Vector3Int.maximum;
        private Vector3Int fencePosition12 = Vector3Int.maximum;
        private Vector3Int fencePosition13 = Vector3Int.maximum;
        private Vector3Int fencePosition14 = Vector3Int.maximum;
        private Vector3Int fencePosition15 = Vector3Int.maximum;
        private static float waitForStraw = 8f;

        private void calculateStrawPosition1()
        {
            if (!World.TryGetTypeAt(position, out ushort type1))
                return;

            string chickenCoopDirection = ItemTypes.IndexLookup.GetName(type1);
            chickenCoopDirection = chickenCoopDirection.Substring(chickenCoopDirection.Length - 2); //Will save x+, x-, z+, z-
            blockDir = chickenCoopDirection;

            switch (chickenCoopDirection)
            {
                case "x+":
                    blockDir = "xp";
                    strawPosition1 = position + Vector3Int.down + new Vector3Int(1, 0, 0);
                    strawPosition2 = position + Vector3Int.down + new Vector3Int(1, 0, 1);
                    strawPosition3 = position + Vector3Int.down + new Vector3Int(1, 0, -1);
                    strawPosition4 = position + Vector3Int.down + new Vector3Int(2, 0, 0);
                    strawPosition5 = position + Vector3Int.down + new Vector3Int(2, 0, 1);
                    strawPosition6 = position + Vector3Int.down + new Vector3Int(2, 0, -1);
                    strawPosition7 = position + Vector3Int.down + new Vector3Int(3, 0, 0);
                    strawPosition8 = position + Vector3Int.down + new Vector3Int(3, 0, 1);
                    strawPosition9 = position + Vector3Int.down + new Vector3Int(3, 0, -1);
                    fencePosition1 = position + new Vector3Int(0, 0, 1);
                    fencePosition2 = position + new Vector3Int(0, 0, 2);
                    fencePosition3 = position + new Vector3Int(1, 0, 2);
                    fencePosition4 = position + new Vector3Int(2, 0, 2);
                    fencePosition5 = position + new Vector3Int(3, 0, 2);
                    fencePosition6 = position + new Vector3Int(4, 0, 2);
                    fencePosition7 = position + new Vector3Int(4, 0, 1);
                    fencePosition8 = position + new Vector3Int(4, 0, 0);
                    fencePosition9 = position + new Vector3Int(4, 0, -1);
                    fencePosition10 = position + new Vector3Int(4, 0, -2);
                    fencePosition11 = position + new Vector3Int(3, 0, -2);
                    fencePosition12 = position + new Vector3Int(2, 0, -2);
                    fencePosition13 = position + new Vector3Int(1, 0, -2);
                    fencePosition14 = position + new Vector3Int(0, 0, -2);
                    fencePosition15 = position + new Vector3Int(0, 0, -1);
                    break;
                case "x-":
                    blockDir = "xm";
                    strawPosition1 = position + Vector3Int.down + new Vector3Int(-1, 0, 0);
                    strawPosition2 = position + Vector3Int.down + new Vector3Int(-1, 0, -1);
                    strawPosition3 = position + Vector3Int.down + new Vector3Int(-1, 0, 1);
                    strawPosition4 = position + Vector3Int.down + new Vector3Int(-2, 0, 0);
                    strawPosition5 = position + Vector3Int.down + new Vector3Int(-2, 0, 1);
                    strawPosition6 = position + Vector3Int.down + new Vector3Int(-2, 0, -1);
                    strawPosition7 = position + Vector3Int.down + new Vector3Int(-3, 0, 0);
                    strawPosition8 = position + Vector3Int.down + new Vector3Int(-3, 0, 1);
                    strawPosition9 = position + Vector3Int.down + new Vector3Int(-3, 0, -1);
                    fencePosition1 = position + new Vector3Int(0, 0, -1);
                    fencePosition2 = position + new Vector3Int(0, 0, -2);
                    fencePosition3 = position + new Vector3Int(-1, 0, -2);
                    fencePosition4 = position + new Vector3Int(-2, 0, -2);
                    fencePosition5 = position + new Vector3Int(-3, 0, -2);
                    fencePosition6 = position + new Vector3Int(-4, 0, -2);
                    fencePosition7 = position + new Vector3Int(-4, 0, -1);
                    fencePosition8 = position + new Vector3Int(-4, 0, 0);
                    fencePosition9 = position + new Vector3Int(-4, 0, 1);
                    fencePosition10 = position + new Vector3Int(-4, 0, 2);
                    fencePosition11 = position + new Vector3Int(-3, 0, 2);
                    fencePosition12 = position + new Vector3Int(-2, 0, 2);
                    fencePosition13 = position + new Vector3Int(-1, 0, 2);
                    fencePosition14 = position + new Vector3Int(0, 0, 2);
                    fencePosition15 = position + new Vector3Int(0, 0, 1);
                    break;
                case "z+":
                    blockDir = "zp";
                    strawPosition1 = position + Vector3Int.down + new Vector3Int(0, 0, 1);
                    strawPosition2 = position + Vector3Int.down + new Vector3Int(-1, 0, 1);
                    strawPosition3 = position + Vector3Int.down + new Vector3Int(1, 0, 1);
                    strawPosition4 = position + Vector3Int.down + new Vector3Int(0, 0, 2);
                    strawPosition5 = position + Vector3Int.down + new Vector3Int(-1, 0, 2);
                    strawPosition6 = position + Vector3Int.down + new Vector3Int(1, 0, 2);
                    strawPosition7 = position + Vector3Int.down + new Vector3Int(0, 0, 3);
                    strawPosition8 = position + Vector3Int.down + new Vector3Int(-1, 0, 3);
                    strawPosition9 = position + Vector3Int.down + new Vector3Int(1, 0, 3);
                    fencePosition1 = position + new Vector3Int(-1, 0, 0);
                    fencePosition2 = position + new Vector3Int(-2, 0, 0);
                    fencePosition3 = position + new Vector3Int(-2, 0, 1);
                    fencePosition4 = position + new Vector3Int(-2, 0, 2);
                    fencePosition5 = position + new Vector3Int(-2, 0, 3);
                    fencePosition6 = position + new Vector3Int(-2, 0, 4);
                    fencePosition7 = position + new Vector3Int(-1, 0, 4);
                    fencePosition8 = position + new Vector3Int(0, 0, 4);
                    fencePosition9 = position + new Vector3Int(1, 0, 4);
                    fencePosition10 = position + new Vector3Int(2, 0, 4);
                    fencePosition11 = position + new Vector3Int(2, 0, 3);
                    fencePosition12 = position + new Vector3Int(2, 0, 2);
                    fencePosition13 = position + new Vector3Int(2, 0, 1);
                    fencePosition14 = position + new Vector3Int(2, 0, 0);
                    fencePosition15 = position + new Vector3Int(1, 0, 0);
                    break;
                case "z-":
                    blockDir = "zm";
                    strawPosition1 = position + Vector3Int.down + new Vector3Int(0, 0, -1);
                    strawPosition2 = position + Vector3Int.down + new Vector3Int(1, 0, -1);
                    strawPosition3 = position + Vector3Int.down + new Vector3Int(-1, 0, -1);
                    strawPosition4 = position + Vector3Int.down + new Vector3Int(0, 0, -2);
                    strawPosition5 = position + Vector3Int.down + new Vector3Int(-1, 0, -2);
                    strawPosition6 = position + Vector3Int.down + new Vector3Int(1, 0, -2);
                    strawPosition7 = position + Vector3Int.down + new Vector3Int(0, 0, -3);
                    strawPosition8 = position + Vector3Int.down + new Vector3Int(-1, 0, -3);
                    strawPosition9 = position + Vector3Int.down + new Vector3Int(1, 0, -3);
                    fencePosition1 = position + new Vector3Int(1, 0, 0);
                    fencePosition2 = position + new Vector3Int(2, 0, 0);
                    fencePosition3 = position + new Vector3Int(2, 0, -1);
                    fencePosition4 = position + new Vector3Int(2, 0, -2);
                    fencePosition5 = position + new Vector3Int(2, 0, -3);
                    fencePosition6 = position + new Vector3Int(2, 0, -4);
                    fencePosition7 = position + new Vector3Int(1, 0, -4);
                    fencePosition8 = position + new Vector3Int(0, 0, -4);
                    fencePosition9 = position + new Vector3Int(-1, 0, -4);
                    fencePosition10 = position + new Vector3Int(-2, 0, -4);
                    fencePosition11 = position + new Vector3Int(-2, 0, -3);
                    fencePosition12 = position + new Vector3Int(-2, 0, -2);
                    fencePosition13 = position + new Vector3Int(-2, 0, -1);
                    fencePosition14 = position + new Vector3Int(-2, 0, 0);
                    fencePosition15 = position + new Vector3Int(-1, 0, 0);
                    break;

                default:
                    strawPosition1 = position;
                    Log.Write("<color=red>PROBLEM WITH BLOCKPOS</color>");
                    break;
            }
        }

        public override int MaxRecipeCraftsPerHaul { get { return 4; } }

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
            //Initialize strawPosition if is not initialized
            if (strawPosition1 == Vector3Int.maximum)
                calculateStrawPosition1();

            if (!World.TryGetTypeAt(strawPosition1, out ushort type1) || type1 != strawType
                || !World.TryGetTypeAt(strawPosition2, out ushort type2) || type2 != strawType
                || !World.TryGetTypeAt(strawPosition3, out ushort type3) || type3 != strawType
                || !World.TryGetTypeAt(strawPosition4, out ushort type4) || type4 != strawType
                || !World.TryGetTypeAt(strawPosition5, out ushort type5) || type5 != strawType
                || !World.TryGetTypeAt(strawPosition6, out ushort type6) || type6 != strawType
                || !World.TryGetTypeAt(strawPosition7, out ushort type7) || type7 != strawType
                || !World.TryGetTypeAt(strawPosition8, out ushort type8) || type8 != strawType
                || !World.TryGetTypeAt(strawPosition9, out ushort type9) || type9 != strawType)
            {
                state.SetIndicator(new Shared.IndicatorState(waitForStraw, "straw"));    //Wait X time saying that he doesn't have straw
                return; // don't do any work
            }
            if (blockDir.Equals("xp"))
            {
                if (!World.TryGetTypeAt(fencePosition1, out ushort type10) || type10 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition2, out ushort type11) || type11 != Nach0ChickenFenceCornerCornerxpType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFenceCorner"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition3, out ushort type12) || type12 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition4, out ushort type13) || type13 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition5, out ushort type14) || type14 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition6, out ushort type15) || type15 != Nach0ChickenFenceCornerCornerzmType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFenceCorner"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition7, out ushort type16) || type16 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition8, out ushort type17) || type17 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition9, out ushort type18) || type18 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition9, out ushort type19) || type19 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition10, out ushort type20) || type20 != Nach0ChickenFenceCornerCornerxmType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFenceCorner"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition11, out ushort type21) || type21 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition12, out ushort type22) || type22 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition13, out ushort type23) || type23 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition14, out ushort type24) || type24 != Nach0ChickenFenceCornerCornerzpType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFenceCorner"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition15, out ushort type25) || type25 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                else
                {
                    base.OnNPCAtJob(ref state); //Normal work
                }
            }
            if (blockDir.Equals("xm"))
            {
                if (!World.TryGetTypeAt(fencePosition1, out ushort type10) || type10 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition2, out ushort type11) || type11 != Nach0ChickenFenceCornerCornerxpType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFenceCorner"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition3, out ushort type12) || type12 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition4, out ushort type13) || type13 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition5, out ushort type14) || type14 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition6, out ushort type15) || type15 != Nach0ChickenFenceCornerCornerzmType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFenceCorner"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition7, out ushort type16) || type16 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition8, out ushort type17) || type17 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition9, out ushort type18) || type18 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition9, out ushort type19) || type19 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition10, out ushort type20) || type20 != Nach0ChickenFenceCornerCornerxmType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFenceCorner"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition11, out ushort type21) || type21 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition12, out ushort type22) || type22 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition13, out ushort type23) || type23 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition14, out ushort type24) || type24 != Nach0ChickenFenceCornerCornerzpType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFenceCorner"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition15, out ushort type25) || type25 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "Nach0ChickenFence"));    //Wait X time saying that he doesn't have straw
                }
                else
                {
                    base.OnNPCAtJob(ref state); //Normal work
                }
            }
            if (blockDir.Equals("zp"))
            {
                if (!World.TryGetTypeAt(fencePosition1, out ushort type10) || type10 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "blackplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition2, out ushort type11) || type11 != Nach0ChickenFenceCornerCornerzpType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "ironblock"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition3, out ushort type12) || type12 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "redplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition4, out ushort type13) || type13 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "redplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition5, out ushort type14) || type14 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "redplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition6, out ushort type15) || type15 != Nach0ChickenFenceCornerCornerxpType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "bricks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition7, out ushort type16) || type16 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "blackplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition8, out ushort type17) || type17 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "blackplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition9, out ushort type18) || type18 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "blackplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition10, out ushort type20) || type20 != Nach0ChickenFenceCornerCornerzmType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "clay"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition11, out ushort type21) || type21 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "redplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition12, out ushort type22) || type22 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "redplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition13, out ushort type23) || type23 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "redplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition14, out ushort type24) || type24 != Nach0ChickenFenceCornerCornerxmType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "stonebricks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition15, out ushort type25) || type25 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "blackplanks"));    //Wait X time saying that he doesn't have straw
                }
                else
                {
                    base.OnNPCAtJob(ref state); //Normal work
                }
            }
            if (blockDir.Equals("zm"))
            {
                if (!World.TryGetTypeAt(fencePosition1, out ushort type10) || type10 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "blackplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition2, out ushort type11) || type11 != Nach0ChickenFenceCornerCornerzmType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "clay"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition3, out ushort type12) || type12 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "redplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition4, out ushort type13) || type13 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "redplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition5, out ushort type14) || type14 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "redplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition6, out ushort type15) || type15 != Nach0ChickenFenceCornerCornerxmType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "stonebricks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition7, out ushort type16) || type16 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "blackplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition8, out ushort type17) || type17 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "blackplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition9, out ushort type18) || type18 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "blackplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition10, out ushort type20) || type20 != Nach0ChickenFenceCornerCornerzpType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "ironblock"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition11, out ushort type21) || type21 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "redplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition12, out ushort type22) || type22 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "redplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition13, out ushort type23) || type23 != Nach0ChickenFencexType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "redplanks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition14, out ushort type24) || type24 != Nach0ChickenFenceCornerCornerxpType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "bricks"));    //Wait X time saying that he doesn't have straw
                }
                if (!World.TryGetTypeAt(fencePosition15, out ushort type25) || type25 != Nach0ChickenFencezType)
                {
                    state.SetIndicator(new Shared.IndicatorState(waitForStraw, "blackplanks"));    //Wait X time saying that he doesn't have straw
                }
                else
                {
                    base.OnNPCAtJob(ref state); //Normal work
                }
            }
            else
                state.SetIndicator(new Shared.IndicatorState(waitForStraw, "planks"));
                Log.Write($"blockDir = {blockDir}");
                //Log.Write($"Error with chicken coop");
        }
    }
}
