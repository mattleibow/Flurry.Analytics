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
	"libFlurryAds_7.6.6.a", 
	LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.ArmV7 | LinkTarget.Arm64,
	ForceLoad = true, 
	SmartLink = true,
	Frameworks = "Foundation SystemConfiguration UIKit Security CoreGraphics CoreMedia MediaPlayer AVFoundation",
	WeakFrameworks = "AdSupport StoreKit",
	LinkerFlags = "-lz")]
