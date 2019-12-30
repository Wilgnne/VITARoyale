using UnityEngine;
using Loot;

namespace Weapons
{
    public abstract class BaseController : MonoBehaviour
    {
        public abstract bool Append (LootSpecs specs);
    }
}