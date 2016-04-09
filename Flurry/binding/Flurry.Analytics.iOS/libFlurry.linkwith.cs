using System;

#if __UNIFIED__
using Foundation;
using ObjCRuntime;
#else
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
#endif

[assembly: LinkerSafe]
	
[assembly: LinkWith (
#if __TVOS__
	"libFlurrytvOS_1.0.0.a",
	LinkTarget.Simulator64 | LinkTarget.Arm64,
#else
	"libFlurry_7.6.0.a", 
	LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.ArmV7 | LinkTarget.Arm64,
#endif
	ForceLoad = true, 
	SmartLink = true,
	Frameworks = "Foundation SystemConfiguration UIKit Security"
#if !__TVOS__
	, WeakFrameworks = "WatchConnectivity"
#endif
)]
