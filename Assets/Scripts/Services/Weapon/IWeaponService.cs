namespace Services.Weapon
{
    public interface IWeaponService
    {
        Models.Weapons.Weapon CurrentWeapon { get; }
    }
}