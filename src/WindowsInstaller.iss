#define MyAppName "SunnyCalc"
#define MyAppVersion "1.0"
#define MyAppPublisher "Pracovní skupina Sluníčka"
#define MyAppURL "https://github.com/FrNecas/IVS-proj2"
#define MyAppExeName "SunnyCalc.App.exe"
#define SourcesBaseDir ".."

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{C5018FF8-E0CA-4166-A4A4-38CF2CC097C5}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes
ArchitecturesInstallIn64BitMode=x64
ArchitecturesAllowed=x64
LicenseFile={#SourcesBaseDir}\src\InstallerLicense.txt
OutputDir={#SourcesBaseDir}\src\install\windows
OutputBaseFilename=SunnyCalcInstaller
SetupIconFile={#SourcesBaseDir}\src\SunnyCalc.App\Assets\icon.ico
Compression=lzma2/ultra64
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "czech"; MessagesFile: "compiler:Languages\Czech.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "{#SourcesBaseDir}\src\publish\selfContainedPackages\windows\SunnyCalc.App.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "Help.html"; DestDir: "{app}"; DestName: "Help.html"

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
