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

        public static LinuxDistroName FromID(string linuxDistro)
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

            private static Bash _Bash;
            private static Bash Bash => _Bash ??= new();


            private static readonly string _KernelString
                = Bash.Command("uname -r").Output;

            /// <summary> Indicates whether this linux is running in WSL (Windows Subsystem for Linux) </summary>
            public static bool IsWSL
                => Regex.IsMatch(_KernelString.ToLowerInvariant(), @"(microsoft|wsl)");

            /// <summary> <c> uname -r </c> >> (Trimmed down to version only) <br/>
            ///     Kernel version <br/><br/>
            ///     # Example: 5.13.0.0 (as <see cref="System.Version"/>)
            /// </summary>
            public static Version KernelVersion
                => _GetKernelVersion();
            private static Version _GetKernelVersion() {
                try {
                    //? Trim leading/trailing space
                    //"  ~~>12.34.56.78.etc.etc<~~ Abcd Abcd   "
                    string kernelString = _KernelString.Trim()[..' ']; //? Get once

                    StringBuilder versionStringBuilder = new();
                    int dotCount = 0;
                    for (int i = 0; i < kernelString.Length; i++) {

                        //? Skip double dots
                        // "12.34.56~~>..~~>.78.etc.etc"
                        if (i > 0 && kernelString[i] == '.')
                            //!? INFO: Step into only if in range
                            if (kernelString[i - 1] == '.')
                                continue;

                        //? Accept dots
                        // "12~~>.<~~34~~>.<~~56~~>.<~~78~~>.<~~etc~~>.<~~etc"
                        if (kernelString[i].Equals('.')) {
                            dotCount++;

                            //? Reject >=5 numbers (4 dots only)
                            //"12.34.56.78<~~.etc.etc"
                            if (dotCount >= 5)
                                break;

                            versionStringBuilder.Append(kernelString[i]);
                        }

                        //? Accept digits
                        // "~~>12<~~.~~>34<~~.~~>56<~~.~~>78<~~.etc.etc"
                        else if (char.IsDigit(kernelString[i]))
                            versionStringBuilder.Append(kernelString[i]);

                        //? Reject otherwise
                        // "12.34.56.78~~> Abcd whatever"
                        else break;

                    }

                    //? Done
                    //"12.34.56.78"
                    return new Version(versionStringBuilder.ToString());

                } catch {
                    //! Something went wrong
                    return new Version(0, 0, 0, 0);
                }
            }

            private static string _ParseReleaseCommandString(string variable)
                => ". /etc/*-release && echo $" + variable;


            /// <summary> <c> >> /etc/*-release >> $ID </c> <br/>
            ///     ID of this distro <br/><br/>
            ///     # Example: ubuntu
            /// </summary>
            public static LinuxDistroName ID
                => FromID(Bash.Command(_ParseReleaseCommandString("ID")).Output);

            /// <summary> <c> >> /etc/*-release >> $ID_LIKE </c> <br/>
            ///     ID of the distro this is based on <br/><br/>
            ///     # Example: debian (<see cref="string"/>)
            /// </summary>
            public static LinuxDistroName BaseID
                => FromID(Bash.Command(_ParseReleaseCommandString("ID_LIKE")).Output);

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
