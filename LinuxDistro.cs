/// —————————————————————————————————————————————
//?
//!? 📜 LinuxDistro.cs
//!? 🖋️ Galacticai 📅 2022
//!  ⚖️ GPL-3.0-or-later
//?  🔗 Dependencies:
//      + (phil-harmoniq) Shell.NET
//?
/// —————————————————————————————————————————————

using Shell.NET;
using System.Text;
using System.Text.RegularExpressions;

namespace GalacticLib.Platforms {
    /// <summary> Determine linux distro information </summary>
    public static class LinuxDistro {
        public enum LinuxDistroName {
            AlpineLinux,
            AmazonLinux,
            Arch,
            CentOS7,
            Debian,
            ElementaryOS,
            Fedora,
            KDENeon,
            LinuxMint,
            OpenSUSE,
            OracleLinux,
            SparkyLinux,
            SUSE,
            Ubuntu,
            ZorinOS,

            Other
        }

        public static LinuxDistroName NameFromID(string linuxDistro)
            => linuxDistro.ToLowerInvariant() switch {
                "alpine" => LinuxDistroName.AlpineLinux,
                "amzn" => LinuxDistroName.AmazonLinux,
                "arch" => LinuxDistroName.Arch,
                "centos" => LinuxDistroName.CentOS7,
                "debian" => LinuxDistroName.Debian,
                "elementary" => LinuxDistroName.ElementaryOS,
                "fedora" => LinuxDistroName.Fedora,
                "linuxmint" => LinuxDistroName.LinuxMint,
                "ol" => LinuxDistroName.OracleLinux,
                "neon" => LinuxDistroName.KDENeon,

                "opensuse" => LinuxDistroName.OpenSUSE,
                "opensuse-leap" => LinuxDistroName.OpenSUSE,
                "suse opensuse" => LinuxDistroName.OpenSUSE,

                "rhel fedora" => LinuxDistroName.Fedora,
                "sparky" => LinuxDistroName.SparkyLinux,
                "suse" => LinuxDistroName.SUSE,
                "ubuntu" => LinuxDistroName.Ubuntu,
                "ubuntu debian" => LinuxDistroName.Ubuntu,
                "zorin" => LinuxDistroName.ZorinOS,

                _ => LinuxDistroName.Other
            };


        /// <summary> Information about the currently running Linux OS </summary>
        public record Current {

            private static Bash _Bash = new();
            private static Bash Bash => _Bash ??= new();


            private static readonly string _KernelString
                = Bash.Command("uname -r").Output;

            /// <summary> Indicates whether this linux is running in WSL (Windows Subsystem for Linux) </summary>
            public static bool IsWSL
                => Regex.IsMatch(_KernelString.ToLowerInvariant(), "(microsoft|wsl)");

            /// <summary> 
            /// <c> uname -r </c> 
            /// <br/> Kernel version  (Trimmed down to version only)
            /// </summary>
            /// <returns> # Example: 5.13.0.0 (as <see cref="System.Version"/>) </returns>
            public static Version GetKernelVersion() {
                    //? Trim leading/trailing space
                    //"  ~~>12.34.56.78.etc.etc<~~ Abcd Abcd   "
                string kernelRaw = _KernelString[..' '];
                string[] kernelPartsRaw = kernelRaw.Trim().Split('.');

                int[] kernelParts = { 0, 0, 0, 0 };
                for (int i = 0; i < 4; i++) {
                    if (int.TryParse(kernelPartsRaw[i], out int part_int))
                        kernelParts[i] = part_int;
                    else {
                        if (i == 0) continue;
                        else break;
                    }
                }
                Version kernel_Version
                    = new(kernelParts[0], kernelParts[1], kernelParts[2], kernelParts[3]);
                return kernel_Version;
            }

            private static string _ParseReleaseCommandString(string variable)
                => ". /etc/*-release && echo $" + variable;


            /// <summary> <c> >> /etc/*-release >> $ID </c> <br/>
            ///     ID of this distro <br/><br/>
            ///     # Example: ubuntu
            /// </summary>
            public static LinuxDistroName ID
                => NameFromID(Bash.Command(_ParseReleaseCommandString("ID")).Output);

            /// <summary> <c> >> /etc/*-release >> $ID_LIKE </c> <br/>
            ///     ID of the distro this is based on <br/><br/>
            ///     # Example: debian (<see cref="string"/>)
            /// </summary>
            public static LinuxDistroName BaseID
                => NameFromID(Bash.Command(_ParseReleaseCommandString("ID_LIKE")).Output);

            /// <summary> <c> >> /etc/*-release >> $VERSION_ID </c> <br/>
            ///     Version presented in a numerical way <br/><br/>
            ///     # Example: 20.04 (as <see cref="System.Version"/>) <br/>
            ///     <br/>
            ///  !!!  Except Arch and CentOS 5~6 AND maybe others ¯\_(ツ)_/¯
            /// </summary>
            public static Version Version
                => Version.Parse(Bash.Command(_ParseReleaseCommandString("VERSION_ID")).Output);

            /// <summary> <c> >> /etc/*-release >> $NAME </c> <br/>
            ///     Short Name of this distro <br/><br/>
            ///     # Example: Debian GNU/Linux 11 (bullseye)
            /// </summary>
            public static string Name
                => Bash.Command(_ParseReleaseCommandString("NAME")).Output;

            /// <summary> <c> >> /etc/*-release >> $PRETTY_NAME </c> <br/>
            ///     Long Name of this distro <br/><br/>
            ///     # Example: Debian GNU/Linux
            /// </summary>
            public static string PrettyName
                => Bash.Command(_ParseReleaseCommandString("PRETTY_NAME")).Output;

            /// <summary> <c> >> /etc/*-release >> $HOME_URL </c> <br/>
            ///     Home page URL (<see cref="string"/>) of this distro <br/><br/>
            ///     # Example: https://www.ubuntu.com/ (as <see cref="string"/>)
            /// </summary>
            public static string Homepage
                => Bash.Command(_ParseReleaseCommandString("HOME_URL")).Output;

        }
    }
}
