using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Colibri_GP
{
    public class GameAgent : MonoBehaviour
    {
        public enum Faction
        {
            Player,
            Enemy
        }
        public Faction GameFaction;
    }
}