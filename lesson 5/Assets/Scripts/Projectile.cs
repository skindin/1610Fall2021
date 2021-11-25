using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum projectileType
{
    good,
    bad
}

public class Projectile : MonoBehaviour
{
    public projectileType type;

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
            GameManager.main.ProjectileHit(this);
    }
}
