using System;

#if __UNIFIED__
using ObjCRuntime;
#else
using MonoTouch.ObjCRuntime;
#endif

[assembly: LinkWith (
	"libFlurry_6.5.0.a", 
	LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.ArmV6 | LinkTarget.ArmV7 | LinkTarget.Arm64,
	ForceLoad = true, 
	Frameworks = "SystemConfiguration Security")]
