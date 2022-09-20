using System;
using UnityEngine;

namespace Enums
{ public enum CollectableType
    {
        Currency=2,
        Diamond=5,
    }
    public  class Collectable :MonoBehaviour
    {
        public CollectableType selectCollectable;

        public  int ReturnedValue()
        {
            switch (selectCollectable)
            {
                case CollectableType.Currency:
                    return 2;
                case CollectableType.Diamond:
                    return 5;
                default:
                    return 0;
            }
        }
    }
    
}
