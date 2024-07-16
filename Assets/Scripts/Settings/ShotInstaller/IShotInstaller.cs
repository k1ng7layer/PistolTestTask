using System;
using System.Collections.Generic;

namespace Settings.ShotInstaller
{
    public interface IShotInstaller
    {
        HashSet<Type> ShotTypes { get; }
        HashSet<Type> GetShots();
    }
}