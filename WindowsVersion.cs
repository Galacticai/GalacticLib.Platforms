/// —————————————————————————————————————————————
//?
//!? 📜 WindowsVersion.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies: No special dependencies
//?
/// —————————————————————————————————————————————

namespace GalacticLib.Platforms {
    /// <summary> Windows versions </summary>
    public record WindowsVersion {
        public static readonly Version
        //? Windows                Version                  // PLATFORM ID
            Windows11            = new(10, 0, 22000, 194),  // Win32NT
            Windows10            = new(10, 0, 10240),       // Win32NT
            Windows81            = new(6, 3),               // Win32NT
            Windows8             = new(6, 2),               // Win32NT
            Windows7_2008r2      = new(6, 1),               // Win32NT
            WindowsVista_2008    = new(6, 0),               // Win32NT
            Windows2003          = new(5, 2),               // Win32NT
            WindowsXP            = new(5, 1),               // Win32NT
            Windows2000          = new(5, 0),               // Win32NT
            WindowsMe            = new(4, 90),              // Win32Windows
            Windows98            = new(4, 10),              // Win32Windows
            Windows95_NT40       = new(4, 0);               // Win32Windows
    }
}
