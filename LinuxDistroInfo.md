# Linux Distro information

#### Notes:
> `$ID` is common between all distros

> `$VERSION_ID` is common between all except Arch, CentOS 6~5

## Results:

- ### Debian 11 
```bash
$   cat /etc/*-release
>>
    PRETTY_NAME = "Debian GNU/Linux 11 (bullseye)"
    NAME = "Debian GNU/Linux"
    VERSION_ID = "11"
    VERSION = "11 (bullseye)"
    VERSION_CODENAME = bullseye
    ID = debian
    HOME_URL = "https://www.debian.org/"
    SUPPORT_URL = "https://www.debian.org/support"
    BUG_REPORT_URL = "https://bugs.debian.org/"
```

<br/>

- ### Ubuntu 20.04
```bash
$   cat /etc/*-release
>>
    DISTRIB_ID=Ubuntu
    DISTRIB_RELEASE=20.04
    DISTRIB_CODENAME=focal
    DISTRIB_DESCRIPTION = "Ubuntu 20.04 LTS"
    NAME="Ubuntu"
    VERSION="20.04 LTS (Focal Fossa)"
    ID=ubuntu
    ID_LIKE = debian
    PRETTY_NAME="Ubuntu 20.04 LTS"
    VERSION_ID="20.04"
    HOME_URL="https://www.ubuntu.com/"
    SUPPORT_URL="https://help.ubuntu.com/"
    BUG_REPORT_URL="https://bugs.launchpad.net/ubuntu/"
    PRIVACY_POLICY_URL="https://www.ubuntu.com/legal/terms-and-policies/privacy-policy"
    VERSION_CODENAME=focal
    UBUNTU_CODENAME = focal
```

<br/>
- ### KDE Neon v5.22
```bash
$   cat /etc/*-release
>>
    DISTRIB_ID=neon
    DISTRIB_RELEASE=20.04
    DISTRIB_CODENAME=focal
    DISTRIB_DESCRIPTION="KDE neon User Edition 5.22"
    NAME="KDE neon"
    VERSION="5.22"
    ID=neon
    ID_LIKE="ubuntu debian"
    PRETTY_NAME="KDE neon User Edition 5.22"
    VARIANT="User Edition"
    VARIANT_ID=user
    VERSION_ID="20.04"
    HOME_URL="https://neon.kde.org/"
    SUPPORT_URL="https://neon.kde.org/"
    BUG_REPORT_URL="https://bugs.kde.org/"
    LOGO=start-here-kde-neon
    PRIVACY_POLICY_URL="https://www.ubuntu.com/legal/terms-and-policies/privacy-policy"
    VERSION_CODENAME=focal
    UBUNTU_CODENAME=focal
```
```bash
$   cat /etc/lsb-release
    DISTRIB_ID=neon
    DISTRIB_RELEASE=20.04
    DISTRIB_CODENAME=focal
    DISTRIB_DESCRIPTION="KDE neon User Edition 5.22"
```

<br/>

- ### Arch (unknown version)
```bash
$   cat /etc/os-release
>>
    NAME="Arch Linux"
    ID=arch
    PRETTY_NAME="Arch Linux"
    ANSI_COLOR="0;36"
    HOME_URL="https://www.archlinux.org/"
    SUPPORT_URL="https://bbs.archlinux.org/"
    BUG_REPORT_URL="https://bugs.archlinux.org/"
```
```bash
# ! `lsb-release` is not installed by default
$   cat /etc/lsb-release
>>
    LSB_VERSION=1.4-14
    DISTRIB_ID=Arch
    DISTRIB_RELEASE = rolling
    DISTRIB_DESCRIPTION="Arch Linux"
```
```
X   Empty/Missing: /etc/arch-version
```

<br/>

- ### Amazon Linux 2016.09
```bash
$   cat /etc/os-release
>>
    NAME="Amazon Linux AMI"
    VERSION="2016.09"
    ID="amzn"
    ID_LIKE="rhel fedora"
    VERSION_ID="2016.09"
    PRETTY_NAME="Amazon Linux AMI 2016.09"
    ANSI_COLOR="0;33"
    CPE_NAME="cpe:/o:amazon:linux:2016.09:ga"
    HOME_URL="http://aws.amazon.com/amazon-linux-ami/"
```
```
X   Empty/Missing: cat /etc/lsb-release
```
```bash
$   cat /etc/system-release
>>
    Amazon Linux AMI release 2016.09
```

<br/>

- ### CentOS 7
```bash
$   cat /etc/os-release
>>
    NAME="CentOS Linux"
    VERSION="7 (Core)"
    ID="centos"
    ID_LIKE="rhel fedora"
    VERSION_ID="7"
    PRETTY_NAME="CentOS Linux 7 (Core)"
    ANSI_COLOR="0;31"
    CPE_NAME="cpe:/o:centos:centos:7"
    HOME_URL="https://www.centos.org/"
    BUG_REPORT_URL="https://bugs.centos.org/"

    CENTOS_MANTISBT_PROJECT="CentOS-7"
    CENTOS_MANTISBT_PROJECT_VERSION="7"
    REDHAT_SUPPORT_PRODUCT="centos"
    REDHAT_SUPPORT_PRODUCT_VERSION="7"
```
```
X   Empty/Missing: /etc/lsb-release
```

<br/>

- ### CentOS 6 and 5
```
X   Empty/Missing: /etc/os-release
```
```bash
$   cat /etc/lsb-release
>>
    LSB_VERSION=base-4.0-amd64:base-4.0-noarch:core-4.0-amd64:core-4.0-noarch
```
```bash
$   cat /etc/centos-release
>>
    CentOS release 6.7 (Final)
```

<br/>

- ### Fedora 22
```bash
$   cat  /etc/os-release
>>
    NAME=Fedora
    VERSION="22 (Twenty Two)"
    ID=fedora
    VERSION_ID = 22
    PRETTY_NAME="Fedora 22 (Twenty Two)"
    ANSI_COLOR="0;34"
    CPE_NAME="cpe:/o:fedoraproject:fedora:22"
    HOME_URL="https://fedoraproject.org/"
    BUG_REPORT_URL="https://bugzilla.redhat.com/"
    REDHAT_BUGZILLA_PRODUCT="Fedora"
    REDHAT_BUGZILLA_PRODUCT_VERSION=22
    REDHAT_SUPPORT_PRODUCT="Fedora"
    REDHAT_SUPPORT_PRODUCT_VERSION=22
    PRIVACY_POLICY_URL=https://fedoraproject.org/wiki/Legal:PrivacyPolicy
```
```
X   Empty/Missing: /etc/lsb-release
```
```bash
$   cat /etc/fedora-release
>>
    Fedora release 22 (Twenty Two)
```

<br/>

- ### openSUSE Tumbleweed
```bash
$   cat  /etc/os-release
>>
    NAME=openSUSE
    VERSION="20150725 (Tumbleweed)"
    VERSION_ID="20150725"
    PRETTY_NAME="openSUSE 20150725 (Tumbleweed) (x86_64)"
    ID=opensuse
    ANSI_COLOR = "0;32"
    CPE_NAME="cpe:/o:opensuse:opensuse:20150725"
    BUG_REPORT_URL="https://bugs.opensuse.org"
    HOME_URL="https://opensuse.org/"
    ID_LIKE="suse"
```
```
X   Empty/Missing: /etc/lsb-release
```
```bash
$   cat /etc/SuSE-release
>>
    openSUSE 20150725 (x86_64)
    VERSION = 20150725
    CODENAME = Tumbleweed
    # /etc/SuSE-release is deprecated and will be removed in the future, use /etc/os-release instead
```