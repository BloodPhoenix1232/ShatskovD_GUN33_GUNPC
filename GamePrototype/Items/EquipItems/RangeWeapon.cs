using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems
{
    public sealed class RangeWeapon : EquipItem
    {
        public RangeWeapon(uint damage, uint durability, string name) : base(durability, name) => Damage = damage;

        public uint Damage { get; set; }

        public override EquipSlot Slot => EquipSlot.Weapon;
    }
}