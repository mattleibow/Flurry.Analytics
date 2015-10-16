using System;

namespace Flurry.Ads {
	
//	public enum FlGender : uint
//	{
//		Male = 1,
//		Female = 2
//	}

	public enum AdError : uint
	{
		DidFailToRender = 0,
		DidFailToFetchAd = 1,
		ClickActionFailed = 2
	}

	public enum AdSize : uint
	{
		BannerTop = 1,
		BannerBottom = 2,
		Fullscreen = 3
	}

	public enum AdType : uint
	{
		WebBanner = 1,
		WebTakeover = 2,
		VideoTakeover = 3,
		AdBanner = 4,
		AdTakeover = 5,
		NetworkBanner = 6,
		NetworkTakeover = 7
	}
}

namespace Flurry.Ads.Native {

	public enum AssetType : uint
	{
		String = 0,
		Image = 1,
		Video = 2,
		VastVideo = 3,
		RichMedia = 4,
		Unknown = 5
	}
}
