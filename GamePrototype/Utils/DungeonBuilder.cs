using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;

namespace GamePrototype.Utils
{
    public static class DungeonBuilder
    {
        public static DungeonRoom BuildDungeon(ChooseDifficulty difficulty)
        {
            var enter = new DungeonRoom("Enter");

            var monsterRoom = new DungeonRoom("Monster", difficulty == ChooseDifficulty.Hard ? UnitFactoryDemo.CreareHardGoblinEnemy() : UnitFactoryDemo.CreateGoblinEnemy());
            var monsterRoom1 = new DungeonRoom("Monster", difficulty == ChooseDifficulty.Hard ? UnitFactoryDemo.CreareHardGoblinEnemy() : UnitFactoryDemo.CreateGoblinEnemy());

            var emptyRoom = new DungeonRoom("Empty");

            var lootItemRoom = new DungeonRoom("Loot1", new RangeWeapon(15, 15, "Bow"));
            var lootRoom = new DungeonRoom("Loot1", new Gold());
            var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));

            var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

            if (difficulty == ChooseDifficulty.Easy)
            {
                enter.TrySetDirection(Direction.Right, monsterRoom);
                enter.TrySetDirection(Direction.Left, lootItemRoom);
                enter.TrySetDirection(Direction.Forward, lootStoneRoom);

                lootItemRoom.TrySetDirection(Direction.Left, monsterRoom);

                monsterRoom.TrySetDirection(Direction.Right, finalRoom);
                monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
                monsterRoom.TrySetDirection(Direction.Left, monsterRoom1);

                emptyRoom.TrySetDirection(Direction.Left, monsterRoom);
                emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);
                emptyRoom.TrySetDirection(Direction.Right, monsterRoom1);

                lootStoneRoom.TrySetDirection(Direction.Right, monsterRoom);
                lootStoneRoom.TrySetDirection(Direction.Forward, emptyRoom);

                monsterRoom1.TrySetDirection(Direction.Right, finalRoom);

                lootRoom.TrySetDirection(Direction.Forward, finalRoom);
                lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);
            }

            else if (difficulty == ChooseDifficulty.Hard)
            {
                enter.TrySetDirection(Direction.Right, monsterRoom);
                enter.TrySetDirection(Direction.Left, lootItemRoom);
                enter.TrySetDirection(Direction.Forward, lootStoneRoom);

                lootItemRoom.TrySetDirection(Direction.Left, monsterRoom);

                monsterRoom.TrySetDirection(Direction.Right, finalRoom);
                monsterRoom.TrySetDirection(Direction.Forward, lootRoom);
                monsterRoom.TrySetDirection(Direction.Left, monsterRoom1);

                emptyRoom.TrySetDirection(Direction.Left, monsterRoom);
                emptyRoom.TrySetDirection(Direction.Forward, lootStoneRoom);
                emptyRoom.TrySetDirection(Direction.Right, monsterRoom1);

                lootStoneRoom.TrySetDirection(Direction.Right, monsterRoom);
                lootStoneRoom.TrySetDirection(Direction.Forward, emptyRoom);

                monsterRoom1.TrySetDirection(Direction.Right, finalRoom);

                lootRoom.TrySetDirection(Direction.Forward, finalRoom);
                lootStoneRoom.TrySetDirection(Direction.Forward, finalRoom);
            }

            return enter;
        }
    }
}
