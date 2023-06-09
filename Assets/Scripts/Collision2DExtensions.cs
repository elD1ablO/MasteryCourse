﻿using UnityEngine;

public static class Collision2DExtensions
{
    public static bool WasHitByPlayer(this Collision2D collision)
    {
        return collision.collider.GetComponent<PlayerMovementController>() != null;
    }

    public static bool HitFromBottom(this Collision2D collision)
    {
        return collision.contacts[0].normal.y > 0.5;
    }

    public static bool HitFromTop(this Collision2D collision)
    {
        return collision.contacts[0].normal.y < -0.5;
    }
    public static bool HitFromSide(this Collision2D collision)
    {
        return collision.contacts[0].normal.x < -0.5f || collision.contacts[0].normal.x > 0.5f;
    }
}

