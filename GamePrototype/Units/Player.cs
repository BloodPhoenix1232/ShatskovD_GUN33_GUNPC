using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System.Text;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {            
        }

        public override uint GetUnitDamage()
        {
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon) 
            {
                weapon.ReduceDurability(3);
                Console.WriteLine($"Текущая прочность оружия: {weapon.Durability}");
                if(weapon.Durability <= 0)
                {
                    _equipment.Remove(EquipSlot.Weapon);
                    Inventory.TryRemove(weapon);
                }
                return BaseDamage + weapon.Damage;
            }

            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item1) && item1 is RangeWeapon rangeWeapon)
            {
                rangeWeapon.ReduceDurability(3);
                Console.WriteLine($"Текущая прочность оружия: {rangeWeapon.Durability}");
                return BaseDamage + rangeWeapon.Damage;
            }
            return BaseDamage;
        }

        public override void HandleCombatComplete()
        {
            var items = Inventory.Items;
            Console.WriteLine(items.Count);
            for (int i = 0; i < items.Count; i++) 
            {
                if (items[i] is EconomicItem economicItem) 
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(items[i]);
                }
            }
        }

        public override void AddItemToInventory(Item item)
        {
            if (item is EquipItem equipItem && _equipment.TryAdd(equipItem.Slot, equipItem)) 
            {
                // Item was equipped
                return;
            }
            else if(item is EquipItem equipItem1 && !_equipment.TryAdd(equipItem1.Slot, equipItem1))
            {
                Console.WriteLine($"Введите 'Yes' если хотите заменить текущее оружие на {equipItem1.Name}, иначе напишите что угодно");
                string answer = Console.ReadLine();
                if (answer == "Yes")
                {
                    ChangeEquipItem(equipItem1);
                }
                base.AddItemToInventory(item);
                return;
            }
            base.AddItemToInventory(item);
        }

        public void ChangeEquipItem(EquipItem equipItem)
        {
            _equipment.Remove(equipItem.Slot);
            _equipment.TryAdd(equipItem.Slot, equipItem);
            Console.WriteLine($"Ваше текущее оружие: {equipItem.Name}.");
        }

        private void UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion) 
            {
                Health += healthPotion.HealthRestore;
            }

            if (economicItem is Grindstone grindstone)
            {
                if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon)
                {
                    //Console.WriteLine("Текущая прочность оружия: " + weapon.Durability);
                    weapon.Repair(grindstone.DurabilityBoost);
                    Console.WriteLine("Точильный камень использован, текущая прочность оружия: " + weapon.Durability);
                }
            }
        }

        protected override uint CalculateAppliedDamage(uint damage)
        {
            _equipment.TryGetValue(EquipSlot.Armour, out var item);
            _equipment.TryGetValue(EquipSlot.Helmet, out var item1);

            if (item is Armour armour && item1 is Helmet helmet)
            {
                damage -= (uint)(damage * Math.Min(1f, (armour.Defence + helmet.Defence) / 100f));
                armour.ReduceDurability(2);
                helmet.ReduceDurability(3);
            }

            else if (item is Armour armourOnly)
            {
                damage -= (uint)(damage * Math.Min(1f, (armourOnly.Defence / 100f)));
                armourOnly.ReduceDurability(2);
            }

            else if (item1 is Helmet helmetOnly)
            {
                damage -= (uint)(damage * Math.Min(1f, (helmetOnly.Defence / 100f)));
                helmetOnly.ReduceDurability(3);
            }
            return damage;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Health {Health}/{MaxHealth}");
            builder.AppendLine("Loot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }
    }
}
