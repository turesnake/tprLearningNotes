#region 程序集 UnityEditor.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// UnityEditor.CoreModule.dll
#endregion

using System;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace UnityEditor
{
    //
    // 摘要:
    //     Lets you programmatically build players or AssetBundles which can be loaded from
    //     the web.
    [NativeHeaderAttribute("Editor/Mono/BuildPipeline.bindings.h")]
    [StaticAccessorAttribute("BuildPipeline", UnityEngine.Bindings.StaticAccessorType.DoubleColon)]
    public class BuildPipeline
    {
        public BuildPipeline();

        //
        // 摘要:
        //     Is a player currently being built?
        public static bool isBuildingPlayer { get; }

        [Obsolete("BuildAssetBundle has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
        public static bool BuildAssetBundle(UnityEngine.Object mainAsset, UnityEngine.Object[] assets, string pathName, out uint crc, BuildAssetBundleOptions assetBundleOptions, BuildTarget targetPlatform);
        //
        // 摘要:
        //     Builds an asset bundle.
        //
        // 参数:
        //   mainAsset:
        //     Lets you specify a specific object that can be conveniently retrieved using AssetBundle.mainAsset.
        //
        //   assets:
        //     An array of assets to write into the bundle.
        //
        //   pathName:
        //     The filename where to write the compressed asset bundle.
        //
        //   assetBundleOptions:
        //     Automatically include dependencies or always include complete assets instead
        //     of just the exact referenced objects.
        //
        //   targetPlatform:
        //     The platform to build the bundle for.
        //
        //   crc:
        //     The optional crc output parameter can be used to get a CRC checksum for the generated
        //     AssetBundle, which can be used to verify content when downloading AssetBundles
        //     using UnityWebRequestAssetBundle.GetAssetBundle.
        [Obsolete("BuildAssetBundle has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
        public static bool BuildAssetBundle(UnityEngine.Object mainAsset, UnityEngine.Object[] assets, string pathName, BuildAssetBundleOptions assetBundleOptions, BuildTarget targetPlatform);
        //
        // 摘要:
        //     Builds an asset bundle, with custom names for the assets.
        //
        // 参数:
        //   assets:
        //     A collection of assets to be built into the asset bundle. Asset bundles can contain
        //     any asset found in the project folder.
        //
        //   assetNames:
        //     An array of strings of the same size as the number of assets. These will be used
        //     as asset names, which you can then pass to AssetBundle.Load to load a specific
        //     asset. Use BuildAssetBundle to just use the asset's path names instead.
        //
        //   pathName:
        //     The location where the compressed asset bundle will be written to.
        //
        //   assetBundleOptions:
        //     Automatically include dependencies or always include complete assets instead
        //     of just the exact referenced objects.
        //
        //   targetPlatform:
        //     The platform where the asset bundle will be used.
        //
        //   crc:
        //     An optional output parameter used to get a CRC checksum for the generated AssetBundle.
        //     (Used to verify content when downloading AssetBundles using UnityWebRequestAssetBundle.GetAssetBundle().)
        [Obsolete("BuildAssetBundleExplicitAssetNames has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
        public static bool BuildAssetBundleExplicitAssetNames(UnityEngine.Object[] assets, string[] assetNames, string pathName, BuildAssetBundleOptions assetBundleOptions, BuildTarget targetPlatform);
        [Obsolete("BuildAssetBundleExplicitAssetNames has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
        public static bool BuildAssetBundleExplicitAssetNames(UnityEngine.Object[] assets, string[] assetNames, string pathName, out uint crc, BuildAssetBundleOptions assetBundleOptions, BuildTarget targetPlatform);
        
        
        /*
            Build AssetBundles from a building map.

            This variant of the function lets you specify the names and contents of the bundles using a "build map" 
            rather than with the details set in the editor. 
            The map is simply an array of AssetBundleBuild objects, 
            each of which contains a bundle name and a list of the names of asset files to be added to the named bundle.
        
        参数:
          outputPath:
            Output path for the AssetBundles.
        
          builds:
            AssetBundle building map.   --- ab包的名字, 和包含的多个 assets 的 path;
        
          assetBundleOptions:
            AssetBundle building options. -- 压缩格式, 是否强制打包, ab包是否包含某些信息, 等等配置
        
          targetPlatform:
            Target build platform.
        
        返回结果:
            The manifest listing all AssetBundles included in this build.
        */
        public static AssetBundleManifest BuildAssetBundles(string outputPath, AssetBundleBuild[] builds, BuildAssetBundleOptions assetBundleOptions, BuildTarget targetPlatform);
        
        /*
            Build all AssetBundles specified in the editor.

            Use this function to build your asset bundles, after you have marked your assets for inclusion in named AssetBundles. 
            (See the Manual page about building AssetBundles for further details). 
            This function builds the bundles you have specified in the editor and will return the manifest that includes all of the included assets. 
            if the build was successful and false otherwise. 
            
            Additionally, error messages are shown in the console to explain most common build failures such as incorrect target folder paths.
        
        参数:
          outputPath:
            Output path for the AssetBundles.
            is a path to a folder somewhere within the project folder where the built bundles will be saved (eg, "Assets/MyBundleFolder").
            The folder will not be created automatically and the function will simply fail if it doesn't already exist.

        
          assetBundleOptions:
            AssetBundle building options.

        
          targetPlatform:
            Chosen target build platform.
        
        返回结果:
            The manifest listing all AssetBundles included in this build.
            This contains a list of all the assets included in the AssetBundle. Null is returned if any problems occur.
        */
        public static AssetBundleManifest BuildAssetBundles(string outputPath, BuildAssetBundleOptions assetBundleOptions, BuildTarget targetPlatform);



        //
        // 摘要:
        //     Checks if Unity can append the build.
        //
        // 参数:
        //   target:
        //     The BuildTarget to build.
        //
        //   location:
        //     The path where Unity builds the application.
        //
        // 返回结果:
        //     Returns a UnityEditor.CanAppendBuild enum that indicates whether Unity can append
        //     the build.
        [FreeFunctionAttribute]
        public static CanAppendBuild BuildCanBeAppended(BuildTarget target, string location);
        //
        // 摘要:
        //     Builds a player. These overloads are still supported, but will be replaced. Please
        //     use BuildPlayer (BuildPlayerOptions buildPlayerOptions) instead.
        //
        // 参数:
        //   scenes:
        //     The Scenes to include in the build. If empty, the build only includes the currently
        //     open Scene. Paths are relative to the project folder (AssetsMyLevelsMyScene.unity).
        //
        //   locationPathName:
        //     The path where the application will be built.
        //
        //   target:
        //     The BuildTarget to build.
        //
        //   options:
        //     Additional BuildOptions, like whether to run the built player.
        //
        //   levels:
        //
        // 返回结果:
        //     An error message if an error occurred.
        public static BuildReport BuildPlayer(EditorBuildSettingsScene[] levels, string locationPathName, BuildTarget target, BuildOptions options);
        //
        // 摘要:
        //     Builds a player. These overloads are still supported, but will be replaced. Please
        //     use BuildPlayer (BuildPlayerOptions buildPlayerOptions) instead.
        //
        // 参数:
        //   scenes:
        //     The Scenes to include in the build. If empty, the build only includes the currently
        //     open Scene. Paths are relative to the project folder (AssetsMyLevelsMyScene.unity).
        //
        //   locationPathName:
        //     The path where the application will be built.
        //
        //   target:
        //     The BuildTarget to build.
        //
        //   options:
        //     Additional BuildOptions, like whether to run the built player.
        //
        //   levels:
        //
        // 返回结果:
        //     An error message if an error occurred.
        public static BuildReport BuildPlayer(string[] levels, string locationPathName, BuildTarget target, BuildOptions options);
        //
        // 摘要:
        //     Builds a player.
        //
        // 参数:
        //   buildPlayerOptions:
        //     Provide various options to control the behavior of BuildPipeline.BuildPlayer.
        //
        // 返回结果:
        //     A BuildReport giving build process information.
        public static BuildReport BuildPlayer(BuildPlayerOptions buildPlayerOptions);
        //
        // 摘要:
        //     Builds one or more Scenes and all their dependencies into a compressed asset
        //     bundle.
        //
        // 参数:
        //   levels:
        //     Pathnames of levels to include in the asset bundle.
        //
        //   locationPath:
        //     Pathname for the output asset bundle.
        //
        //   target:
        //     Runtime platform on which the asset bundle will be used.
        //
        //   crc:
        //     Output parameter to receive CRC checksum of generated assetbundle.
        //
        //   options:
        //     Build options. See BuildOptions for possible values.
        //
        // 返回结果:
        //     String with an error message, empty on success.
        [Obsolete("BuildStreamedSceneAssetBundle has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
        public static string BuildStreamedSceneAssetBundle(string[] levels, string locationPath, BuildTarget target, BuildOptions options);
        //
        // 摘要:
        //     Builds one or more Scenes and all their dependencies into a compressed asset
        //     bundle.
        //
        // 参数:
        //   levels:
        //     Pathnames of levels to include in the asset bundle.
        //
        //   locationPath:
        //     Pathname for the output asset bundle.
        //
        //   target:
        //     Runtime platform on which the asset bundle will be used.
        //
        //   crc:
        //     Output parameter to receive CRC checksum of generated assetbundle.
        //
        //   options:
        //     Build options. See BuildOptions for possible values.
        //
        // 返回结果:
        //     String with an error message, empty on success.
        [Obsolete("BuildStreamedSceneAssetBundle has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
        public static string BuildStreamedSceneAssetBundle(string[] levels, string locationPath, BuildTarget target);
        [Obsolete("BuildStreamedSceneAssetBundle has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
        public static string BuildStreamedSceneAssetBundle(string[] levels, string locationPath, BuildTarget target, out uint crc, BuildOptions options);
        [Obsolete("BuildStreamedSceneAssetBundle has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
        public static string BuildStreamedSceneAssetBundle(string[] levels, string locationPath, BuildTarget target, out uint crc);
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static BuildTargetGroup GetBuildTargetGroup(BuildTarget platform);
        //
        // 摘要:
        //     Given a BuildTarget will return the well known string representation for the
        //     build target platform.
        //
        // 参数:
        //   targetPlatform:
        //     An instance of the BuildTarget enum.
        //
        // 返回结果:
        //     Target platform name represented by the passed in BuildTarget.
        [FreeFunctionAttribute("GetBuildTargetUniqueName", IsThreadSafe = true)]
        public static string GetBuildTargetName(BuildTarget targetPlatform);
        [FreeFunctionAttribute("ExtractCRCFromAssetBundleManifestFile")]
        public static bool GetCRCForAssetBundle(string targetPath, out uint crc);
        [FreeFunctionAttribute("ExtractHashFromAssetBundleManifestFile")]
        public static bool GetHashForAssetBundle(string targetPath, out Hash128 hash);
        //
        // 摘要:
        //     Returns the path of a player directory. For ex., Editor\Data\PlaybackEngines\AndroidPlayer.
        //     In some cases the player directory path can be affected by BuildOptions.Development.
        //
        // 参数:
        //   target:
        //     Build target.
        //
        //   options:
        //     Build options.
        //
        //   buildTargetGroup:
        //     Build target group.
        public static string GetPlaybackEngineDirectory(BuildTarget target, BuildOptions options);
        public static string GetPlaybackEngineDirectory(BuildTarget target, BuildOptions options, bool assertUnsupportedPlatforms);
        //
        // 摘要:
        //     Returns the path of a player directory. For ex., Editor\Data\PlaybackEngines\AndroidPlayer.
        //     In some cases the player directory path can be affected by BuildOptions.Development.
        //
        // 参数:
        //   target:
        //     Build target.
        //
        //   options:
        //     Build options.
        //
        //   buildTargetGroup:
        //     Build target group.
        public static string GetPlaybackEngineDirectory(BuildTargetGroup buildTargetGroup, BuildTarget target, BuildOptions options);
        [FreeFunctionAttribute(IsThreadSafe = true)]
        public static string GetPlaybackEngineDirectory(BuildTargetGroup buildTargetGroup, BuildTarget target, BuildOptions options, bool assertUnsupportedPlatforms);
        //
        // 摘要:
        //     Returns the mode currently used by players to initiate a connect to the host.
        //
        // 参数:
        //   targetPlatform:
        //
        //   buildOptions:
        [RequiredByNativeCodeAttribute]
        public static PlayerConnectionInitiateMode GetPlayerConnectionInitiateMode(BuildTarget targetPlatform, BuildOptions buildOptions);
        //
        // 摘要:
        //     Returns true if the specified build target is currently available in the Editor.
        //
        // 参数:
        //   buildTargetGroup:
        //     build target group
        //
        //   target:
        //     build target
        [FreeFunctionAttribute]
        public static bool IsBuildTargetSupported(BuildTargetGroup buildTargetGroup, BuildTarget target);
        //
        // 摘要:
        //     Lets you manage cross-references and dependencies between different asset bundles
        //     and player builds.
        [FreeFunctionAttribute]
        [Obsolete("PopAssetDependencies has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
        public static void PopAssetDependencies();
        //
        // 摘要:
        //     Lets you manage cross-references and dependencies between different asset bundles
        //     and player builds.
        [FreeFunctionAttribute]
        [Obsolete("PushAssetDependencies has been made obsolete. Please use the new AssetBundle build system introduced in 5.0 and check BuildAssetBundles documentation for details.")]
        public static void PushAssetDependencies();
        //
        // 摘要:
        //     Set a 16-bytes key for AssetBundle Encryption. Set NULL will remove the key from
        //     memory.
        //
        // 参数:
        //   password:
        [FreeFunctionAttribute("SetAssetBundleEncryptKey")]
        public static void SetAssetBundleEncryptKey(string password);
        //
        // 摘要:
        //     Writes out a "boot.config" file that contains configuration information for the
        //     very early stages of engine startup.
        //
        // 参数:
        //   outputFile:
        //     The location to write the file to.
        //
        //   target:
        //     The platform to target for this build.
        //
        //   options:
        //     Options for this build.
        public static void WriteBootConfig(string outputFile, BuildTarget target, BuildOptions options);
    }
}

