using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameObjectReflection
{
    public static class Reflections
    {
        public static GameObject menuContent(this VRCUiManager mngr)
        {
            return mngr.field_Public_GameObject_0;
        }
    }
}
