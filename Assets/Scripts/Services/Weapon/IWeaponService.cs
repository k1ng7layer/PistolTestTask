using Models.Entity;

namespace Services.Weapon
{
    public interface IWeaponService
    {
        WeaponEntity CurrentWeaponEntity { get; }
    }
}