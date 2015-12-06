using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WalkUpAdvertisingShellWeb.ControllerHelper
{
    public static class Enumerations
    {

        public enum ModifyActionRequired
        {
            None = 0,
            Add = 1,
            Update = 2,
            Delete = 3
        };
    }
}