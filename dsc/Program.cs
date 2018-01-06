using System;
using System.Runtime.InteropServices;

namespace dsc
{
  class Program
  {
    [DllImport("user32")]
    public static extern IntPtr FindWindow(string strclassName, string strWindowName);

    [DllImport("user32")]
    private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("user32")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwLong);

    [DllImport("user32", EntryPoint = "FindWindowEx")]
    public static extern IntPtr FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string lpsz1, string lpsz2);

    const int GWL_STYLE = -16;
    const int LVS_ICON = 0x0000;
    const int LVS_REPORT = 0x0001;
    const int LVS_SMALLICON = 0x0002;
    const int LVS_LIST = 0x0003;
    const int LVS_TYPEMASK = 0x0003;
    const int LVS_NOSCROLL = 0x2000;

    static void Main(string[] args)
    {
      IntPtr hWnd;
      hWnd = FindWindow("Progman", "Program Manager");
      hWnd = FindWindowEx(hWnd, IntPtr.Zero, "SHELLDLL_DefView", null);
      hWnd = FindWindowEx(hWnd, IntPtr.Zero, "SysListView32", null);

      var oStyle = GetWindowLong(hWnd, GWL_STYLE);
      var nStyle = LVS_SMALLICON | LVS_NOSCROLL;
      SetWindowLong(hWnd, GWL_STYLE, (oStyle & ~(LVS_TYPEMASK | LVS_NOSCROLL)) | nStyle);
      return;
    }
  }
}
