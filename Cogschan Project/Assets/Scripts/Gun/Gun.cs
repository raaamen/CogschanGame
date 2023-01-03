using UnityEngine;

/// <summary>
/// Abstract class for all guns.
/// </summary>
public abstract class Gun : MonoBehaviour
{
    /// <summary>
    /// The maximum ammo a gun can have in one magazine.
    /// </summary>
    [SerializeField]
    [Tooltip("The maximum ammo a gun can have in one magizine.")]
    protected int MaxAmmo;
    /// <summary>
    /// The maximum ammo a gun can have in reserve.
    /// </summary>
    [SerializeField]
    [Tooltip("THe maximum ammo a gun can have in reserve")]
    protected int MaxReserveAmmo;
    /// <summary>
    /// The amount of time it takes to reload
    /// </summary>
    [SerializeField]
    [Tooltip("The amount of time it takes to reload.")]
    protected float ReloadTime;
    /// <summary>
    /// The amount of time between shots.
    /// </summary>
    [SerializeField]
    [Tooltip("The amount of time between shots.")]
    private float _fireRate;
    private float fireClock;
    private float reloadClock;

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
    public float FireRate { get { return _fireRate; } protected set { _fireRate = value; } }
    /// <summary>
    /// Whether or not the gun can fire.
    /// </summary>
    public bool CanFire => fireClock <= 0 && Ammo > 0;
    /// <summary>
    /// Whether or not the gun is reloading.
    /// </summary>
    public bool IsReloading => reloadClock > 0;

    /// <summary>
    /// Fire without aiming down sights. Returns false if unable to fire.
    /// </summary>
    /// <param name="hitTransform">The transform the crosshair is currently pointed at.</param>
    public virtual bool HipFire(Transform hitTransform)
    {
        if (!CanFire)
            return false;
        Ammo -= 1;
        fireClock = FireRate;
        return true;
    }
    /// <summary>
    /// Fire while aiming down sights. Returns false if unable to fire.
    /// </summary>
    /// <param name="hitTransform">The transform the crosshair is currently pointed at.</param>
    public virtual bool ADSFire(Transform hitTransform)
    {
        if (!CanFire)
            return false;
        Ammo -= 1;
        fireClock = FireRate;
        return false;
    }
    /// <summary>
    /// Reload the gun.
    /// </summary>
    public virtual void Reload()
    {
        reloadClock = ReloadTime;
        int neededAmmo = MaxAmmo - Ammo;
        int ammoReloaded = neededAmmo < ReserveAmmo ? neededAmmo : ReserveAmmo;
        Ammo += ammoReloaded;
        ReserveAmmo -= ammoReloaded;
    }

    protected virtual void Start()
    {
        Ammo = MaxAmmo;
        ReserveAmmo = MaxReserveAmmo;
    }

    protected virtual void Update()
    {
        if (IsReloading)
            reloadClock -= Time.deltaTime;
        if (!CanFire)
            fireClock -= Time.deltaTime;
    }
}