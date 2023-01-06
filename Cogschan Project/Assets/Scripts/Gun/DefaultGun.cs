using UnityEngine;

/// <summary>
/// A dummy weapon for testing purposes, may be repurposed into pistol.
/// </summary>
public class DefaultGun : Gun
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private GameObject particle;

    public override bool HipFire(Transform hitTransform)
    {
        if (!base.HipFire(hitTransform))
            return false;
        OnFire(hitTransform);
        return true;
    }

    public override bool ADSFire(Transform hitTransform)
    {
        if (!base.ADSFire(hitTransform))
            return false;
        OnFire(hitTransform);
        return true;
    }



    // Run when the gun fires
    private void OnFire(Transform hitTransform)
    {
        if (hitTransform != null)
        {
            Hitbox hitbox = hitTransform.GetComponent<Hitbox>();
            if (hitbox != null)
            {
                Instantiate(particle, hitTransform.position, Quaternion.identity);
                //Debug.Log("yes hit!");
                hitbox.TakeHit(damage);

            }
            else
            {
                //Instantiate(vfxHitRed, transform.position, Quaternion.identity);
                Debug.Log("FUCK!");
            }
        }
    }
}