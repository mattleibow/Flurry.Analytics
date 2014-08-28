using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libFlurry_5.2.0.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true, Frameworks = "SystemConfiguration Security")]
