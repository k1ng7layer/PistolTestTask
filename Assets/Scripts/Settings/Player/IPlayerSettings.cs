using Settings.Weapon;

namespace Settings.Player
{
    public interface IPlayerSettings
    {
        float Speed { get; }
        WeaponSettings[] Weapons { get; }
    }
}