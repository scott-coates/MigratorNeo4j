function Chocolatey-Help {
@"
$h1
Chocolatey - Your local machine NuGet repository AKA your local tools repository  AKA a kind of apt-get for Windows

'I'm a tools enabler, a global silent installer. I met your mother. Some want to call me apt-get for Windows, I just want to get #chocolatey!'

Version: `'$chocVer'`
Install Directory: `'$nugetPath`'
$h1
Chocolatey allows you to install application nuggets and run executables from anywhere.
$h2
Known Issues
$h2
 * There is no automated uninstallation.
 * See https://github.com/chocolatey/chocolatey/issues
$h2
Release Notes
$h2
NOTE: Abbreviated, please see the wiki (https://github.com/chocolatey/chocolatey/wiki/ReleaseNotes) for the full set of notes.
v0.9.8
 * .12
  - Fixed an issue with write-host and write-error overrides
  - Fixed an issue with getting the full path to powershell
  - Reduced window pop ups
 * .13
  - New Command! WebPI - chocolatey webpi (cwebpi) will install items from Web PI. Alternatively, you can specify -source webpi
  - New Command! Gem - chocolatey gem (cgem) will install Ruby Gems. Alternatively, you can specify -source ruby
  - New Command! Pack - chocolatey pack (cpack) will package your chocolatey package
  - New Command! Push - chocolatey push (cpush) will push your chocolatey package to http://chocolatey.org/
  - You can call install with a packages.config file that contains id, version, and source!
 * .14
  - Enhancement - 64 bit url added to Install-ChocolateyZipPackage
  - Enhancement - main helpers work with files not coming from HTTP
  - Enhancement - Pass -ValidExitCodes to both install helpers
  - Fix - CList now only includes recent versions without -all switch
  - Fix - packages with .config in the name now work again
 * .15
  - Enhancement - Chocolatey's default folder is now C:\Chocolatey (breaking change)
  - Enhancement - Use -force to reinstall existing packages (breaking change)
  - Install now supports all with a custom package source to install every package from a source!
  - Enhancement - Support Prerelease flag for Install, Update, Version, and List
  - Fix - Now parses the correct version of a package you have installed
 * .16
  - Install upgrade fix
$h2
$h2
using (var legalese = new LawyerText()) {
$h2
Package License Acceptance Terms
$h2
The act of running chocolatey to install a package constitutes acceptance of the license for the application, executable(s), or other artifacts that are brought to your machine as a result of a chocolatey install.
This acceptance occurs whether you know the license terms or not. It is suggested that you read and understand the license terms of any package you plan to install prior to installation through chocolatey.
If you do not accept the license of a package you are installing, please uninstall it and any artifacts that end up on your machine as a result of the install.
$h2
Waiver of Responsibility
$h2
The use of chocolatey means that an individual using chocolatey assumes the responsibility for any changes (including any damages of any sort) that occur to the system as a result of using chocolatey. 
This does not supercede the verbage or enforcement of the license for chocolatey (currently Apache 2.0), it is only noted here that you are waiving any rights to collect damages by your use of chocolatey. 
It is recommended you read the license (http://www.apache.org/licenses/LICENSE-2.0) to gain a full understanding (especially section 8. Limitation of Liability) prior to using chocolatey.
$h2
}
$h2
$h2
Usage
$h2
chocolatey [install [packageName [-source source] [-version version] | pathToPackagesConfig]  | installmissing packageName [-source source] | update packageName [-source source] [-version version] | list [packageName] [-source source] | help | version [packageName] | webpi packageName | gem packageName [-version version]]

example: chocolatey install nunit
example: chocolatey install nunit -version 2.5.7.10213
example: chocolatey install packages.config
example: chocolatey installmissing nunit
example: chocolatey update nunit -source http://somelocalfeed.com/nuget/
example: chocolatey help
example: chocolatey list (might take awhile)
example: chocolatey list nunit
example: chocolatey version
example: chocolatey version nunit

A shortcut to 'chocolatey install' is 'cinst'
cinst [packageName  [-source source] [-version version] | pathToPackagesConfig]
example: cinst 7zip
example: cinst ruby -version 1.8.7
example: cinst packages.config
$h1
"@ | Write-Host
}
