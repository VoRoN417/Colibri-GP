using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Colibri_GP
{
    public interface IDamageable2D
    {
        float Health { get; }
        void ReceiveDamage(float damageAmount, Vector2 hitPosition, GameAgent sender);
        void ReceiveHeal(float healAmount, Vector2 hitPosition, GameAgent sender);
    }
}