/// <summary>
/// Abstract class for all guns.
/// </summary>
public abstract class Gun
{
    /// <summary>
    /// The maximum ammo a gun can have in one magazine.
    /// </summary>
    protected int MaxAmmo;
    /// <summary>
    /// The maximum ammo a gun can have in reserve.
    /// </summary>
    protected int MaxReserveAmmo;

    /// <summary>
    /// The ammo count of the gun.
    /// </summary>
    public int Ammo { get; protected set; }
    /// <summary>
    /// The amount of ammo in reserve to be used when reloading..
    /// </summary>
    public int ReserveAmmo { get; protected set; }
    /// <summary>
    /// The frequency at which the gun can fire.
    /// </summary>
    public float FireRate { get; protected set; }

    /// <summary>
    /// Fire without aiming down sights.
    /// </summary>
    public abstract void HipFire();
    /// <summary>
    /// Fire while aiming down sights.
    /// </summary>
    public abstract void ADSFire();
    /// <summary>
    /// Reload the gun.
    /// </summary>
    public virtual void Reload()
    {
        int neededAmmo = MaxAmmo - Ammo;
        int ammoReloaded = neededAmmo < ReserveAmmo ? neededAmmo : ReserveAmmo;
        Ammo += ammoReloaded;
        ReserveAmmo -= ammoReloaded;
    }
}
