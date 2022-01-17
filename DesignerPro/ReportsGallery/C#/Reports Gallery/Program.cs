using System;
using System.Text;
using System.Windows.Forms;

namespace GrapeCity.ActiveReports.Samples.ReportsGallery
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
#if NETCOREAPP3_1_OR_GREATER
			Application.SetHighDpiMode(HighDpiMode.DpiUnawareGdiScaled);
#endif
			Application.Run(new ReportsForm());
		}
	}
}
