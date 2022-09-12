using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace HYPERIONMobile.Skia.Tizen
{
	class Program
{
	static void Main(string[] args)
	{
		var host = new TizenHost(() => new HYPERIONMobile.App());
		host.Run();
	}
}
}
