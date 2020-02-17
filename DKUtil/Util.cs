using System;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Configuration;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.Globalization;


namespace Util
{
    public static class Helper
    {
        /// <summary>
        /// Get string value between [first] a and [last] b.
        /// </summary>
        public static string Between(this string value, string a, string b)
        {
            int posA = value.IndexOf(a);
            int posB = value.LastIndexOf(b);
            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }

        /// <summary>
        /// Get string value after [first] a.
        /// </summary>
        public static string Before(this string value, string a)
        {
            int posA = value.IndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            return value.Substring(0, posA);
        }

        /// <summary>
        /// Get string value after [last] a.
        /// </summary>
        public static string After(this string value, string a)
        {
            int posA = value.LastIndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= value.Length)
            {
                return "";
            }
            return value.Substring(adjustedPosA);
        }

        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        public static string GetUntilOrEmpty(this string text, string stopAt = "-")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }

        public static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        static readonly string[] SizeSuffixes =
                   { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return "0.0 bytes"; }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }

        public static void process(string Path_FFMPEG, string strParam)
        {
            try
            {
                Process proc = new Process();

                //ffmpeg.StartInfo.UseShellExecute = false;
                //ffmpeg.StartInfo.RedirectStandardOutput = true;
                //ffmpeg.StartInfo.FileName = Path_FFMPEG;
                //ffmpeg.StartInfo.Arguments = strParam;

                //ffmpeg.Start();

                //ffmpeg.WaitForExit();
                proc.StartInfo.FileName = "ffmpeg";
                proc.StartInfo.Arguments = strParam;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.UseShellExecute = false;
                if (!proc.Start())
                {
                    Console.WriteLine("Error starting");
                    return;
                }
                StreamReader reader = proc.StandardError;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Substring(0, 4).TrimStart() == "size")
                    {
                        Match m = Regex.Match(line, @"\d+");
                        if (m.Success)
                            Console.WriteLine(m.Value);
                        else
                            Console.WriteLine("**" + line);
                        //Console.WriteLine(m.Value);
                        //var eventArgs = new ProgEventArgs((copiedBytes * 1.0 / response.ContentLength) * 100);
                    }
                    //Console.WriteLine(line);
                }
                proc.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ^                 # Start of string
        // (?:               # Try to match...
        // (?:               # Try to match...
        // ([01]?\d|2[0-3]): # HH:
        // )?                # (optionally).
        // ([0 - 5]?\d):     # MM: (required)
        // )?                # (entire group optional, so either HH:MM:, MM: or nothing)
        // ([0 - 5]?\d)      # SS (required)
        // $                 # End of string
        public static bool IsValidTime(string thetime)
        {
            Regex checktime =
             new Regex(@"^(?:(?:([01]?\d|2[0-3]):)?([0-5]?\d):)?([0-5]?\d)$");

            return checktime.IsMatch(thetime);
        }

        public static string GetFullPathWithoutExtension(string filePath)
        {
            return Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath));
        }

        public static bool IsNullorEmpty(string s)
        {
            if (s == null || s.Length == 0)
                return true;
            else
                return false;
        }

        public static bool IsNullorEmptyTrim(string s)
        {
            if (s == null || s.Trim().Length == 0)
                return true;
            else
                return false;
        }

        public static bool IsDecimal(string theValue)
        {
            try
            {
                Convert.ToDouble(theValue);
                return true;
            }
            catch
            {
                return false;
            }
        } // end IsDecimal

        public static bool IsDate(string theValue)
        {
            DateTime dtDate;
            try
            {
                dtDate = DateTime.Parse(theValue);
                return true;
            }
            catch
            {
                return false;
            }
        } // end IsDate

        public static bool IsAllDigits(string theValue)
        {
            return Regex.IsMatch(theValue, "^\\d+$");
        }

        public static bool IsAllDigits(string theValue, int number)
        {
            return Regex.IsMatch(theValue, "^\\d" + "{" + number.ToString() + "}$");
        }

        public static bool IsAlphaNumeric(string theValue)
        {
            return Regex.IsMatch(theValue, "^[0-9a-zA-Z]+$");
        }

        public static double FractionToDouble(string fraction)
        {
            double result;

            if (double.TryParse(fraction, out result))
            {
                return result;
            }

            string[] split = fraction.Split(new char[] { ' ', '/' });

            if (split.Length == 2 || split.Length == 3)
            {
                int a, b;

                if (int.TryParse(split[0], out a) && int.TryParse(split[1], out b))
                {
                    if (split.Length == 2)
                    {
                        return (double)a / b;
                    }

                    int c;

                    if (int.TryParse(split[2], out c))
                    {
                        return a + (double)b / c;
                    }
                }
            }

            throw new FormatException("Not a valid fraction.");
        }

        public static double FormattedTimeToSeconds(string timeString)
        {
            TimeSpan span;

            if (TimeSpan.TryParseExact(timeString, "mm\\:ss", CultureInfo.InvariantCulture, out span))
            {
                return span.TotalSeconds;                
            }
            else
            {
                return -1;
            }
        }

    }

    public class CustomSettings
    {
        public static readonly string ServerName =
            ConfigurationManager.AppSettings["servername"];
        public static readonly string DatabaseName =
            ConfigurationManager.AppSettings["dbname"];
        
    }

    public class Forms
    {
        static Bitmap m_PrintBitmap;
        static PrintDocument m_PrintDocument;
        static Form mFormToPrint;
        // adjustments needed for LDS but not CMS for reasons unknown
        static readonly int x_adjust = 2;
        static readonly int y_adjust = 40;

        public static bool Print(Form formToPrint, bool Landscape)
        {
            //if (formToPrint.MdiParent.WindowState== FormWindowState.Maximized)
            
            mFormToPrint = formToPrint;
            m_PrintBitmap = GetFormImage();
            m_PrintDocument = new PrintDocument();

            m_PrintDocument.DefaultPageSettings.Landscape = Landscape;

            m_PrintDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            m_PrintDocument.Print();
            return (true);
        }

        static Bitmap GetFormImage()
        {
            Bitmap bm = new Bitmap(mFormToPrint.Width, mFormToPrint.Height);
            Graphics grfx = Graphics.FromImage(bm);
            grfx.CopyFromScreen(mFormToPrint.Location.X + x_adjust, 
                mFormToPrint.Location.Y + y_adjust, 0, 0, mFormToPrint.Size, 
                CopyPixelOperation.SourceCopy);
            return (bm);
        }

        static void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (e.PageSettings.Landscape)
            {
                e.Graphics.DrawImage(m_PrintBitmap, e.Graphics.VisibleClipBounds);
            }
            else
            {
                // if full height is used then image is too squashed up
                e.Graphics.DrawImage(m_PrintBitmap, e.Graphics.VisibleClipBounds.X,
                    e.Graphics.VisibleClipBounds.Y,
                    e.Graphics.VisibleClipBounds.Width,
                    e.Graphics.VisibleClipBounds.Height / 2);
            }
            e.HasMorePages = false;
        }
               

        public static bool isOpenMDI(Form parentForm, string childFormName)
        {
            for (int x = 0; x < parentForm.MdiChildren.Length; x++)
            {
                if (parentForm.MdiChildren[x].Name == childFormName)
                {
                    return true;
                }
                x++;
            }
            return false;
        }
    }

    public class ExHandlers
    {
        
        public static void General(Exception ex)
        {
            MessageBox.Show("[" + ex.ToString() + "]",
                CustomSettings.DatabaseName + " - System Information");
            
            ExHandlers.SaveException(ex.ToString());
            
        }

        public static void SQL(SqlException ex)
        {
            string message = ex.ToString();

            if (ex.Errors.Count == 1)
            {
                if (!ex.Errors[0].Procedure.Equals(string.Empty))
                {
                    message += "\n\nStored procedure: " + ex.Errors[0].Procedure
                        + "\nLine number: " + ex.Errors[0].LineNumber;
                }
            }
            else
            {
                for (int x = 0; x < ex.Errors.Count; x++)
                {
                    message += "\n\nSQL Server Error " + x.ToString() +
                        "\n---------------\n";
                    if (!ex.Errors[x].Procedure.Equals(string.Empty))
                    {
                        message += "Stored procedure: " + ex.Errors[x].Procedure +
                            "\nLine number: " + ex.Errors[x].LineNumber + "\n";
                    }
                    message += "Error message: " + ex.Errors[x];
                }
            }
            MessageBox.Show(message, CustomSettings.DatabaseName + " - System Information");

            ExHandlers.SaveException(message);
            
        }

        private static void SaveException(string message)
        {
            if (!ExHandlers.SaveExceptionDB(message))
            {
                MessageBox.Show("The exception details were not saved to a database table.",
                    CustomSettings.DatabaseName + " - System Information");
            }
        }

        /// <summary>
        /// Requires a stored proc in database called 'save_exeception' taking an
        /// NVarchar parameter called @ex of size 4000.
        /// </summary>
        /// <param name="ex"></param>
        private static bool SaveExceptionDB(string exDesc)
        {
            string connectionString = "server=" + CustomSettings.ServerName +
                ";Trusted_Connection=yes; database=" + CustomSettings.DatabaseName;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("save_exception", cn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 600;
                    cmd.Parameters.Add(new SqlParameter("@ex",
                        SqlDbType.NVarChar, 4000));
                    cmd.Parameters[0].Value = exDesc;

                    cmd.ExecuteNonQuery();
                    return true;
                    
                }
            }
           
            catch (Exception)
            {
            
                return false;
                
            }
        }

        public static void COM(System.Runtime.InteropServices.COMException ex)
        {
            string message = 
                String.Format("COMException {0}\n{1}\n{2}", ex.ErrorCode, ex.Message, ex.StackTrace);
            MessageBox.Show(message, "COM Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ExHandlers.SaveException(message);
        }
    }
    
    public class ErrorMessageEventArgs : EventArgs
    {
        private string message;

        public ErrorMessageEventArgs(string message)
        {
            this.message = message;
        }

        public string Message
        {
            get { return message; }
        }
    }
    /// <summary>
    /// Uses late binding for automation of any version of Excel.
    /// Ref: http://pfsoft.com/Excel_NET_LATEBIND.html
    /// </summary>
    public class ExcelAutomationLB
    {
        private string AppProgID = "Excel.Application";
        private const int XlCSV = 6;
        private object oExcel = null;
        private object oWorkbooks = null;
        private object oWorkbook = null;

        public ExcelAutomationLB()
        {
            Type tExcelObj = Type.GetTypeFromProgID(AppProgID);
            // start Excel and get reference to new Excel process.
            oExcel = Activator.CreateInstance(tExcelObj);

            // turn off alerts to user
            object[] args = new object[1];
            args[0] = false;
            object obj = 
                oExcel.GetType().InvokeMember("DisplayAlerts", BindingFlags.SetProperty, null, oExcel, args);

            // get reference to workbooks collection
            oWorkbooks =
                oExcel.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, oExcel, null);
            
            

        }

        public void SaveAsCSV(string sourceFilePath, string targetFilePath)
        {
            // open source file
            object[] openArgs = new object[1];
            openArgs[0] = sourceFilePath;
            oWorkbook
                = oWorkbooks.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, oWorkbooks, openArgs); 

            object[] saveArgs = new object[2];

            saveArgs[0] = targetFilePath;
            saveArgs[1] = XlCSV;
            oWorkbook.GetType().InvokeMember("SaveAs", BindingFlags.InvokeMethod, null, oWorkbook, saveArgs);

        }

        public void QuitExcel()
        {
            oExcel.GetType().InvokeMember("Quit", BindingFlags.InvokeMethod, null, oExcel, null);
            
            Marshal.ReleaseComObject(oExcel);

            oExcel = null;
            oWorkbooks = null;
            oWorkbook = null;
             
            // force garbage collection - this makes sure Excel process is ended.
            GC.Collect();
            //GC.WaitForPendingFinalizers();
        }


    }

	public static class Dialogs
	{
		public static bool YesNo(string message, string title)
		{
			if (MessageBox.Show(message, title,
				MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				return true;
			else
				return false;
		}
    }


	//public static class Val
	//{
		
	//	public static bool IsNullorEmpty(string s)
	//	{
	//		if (s == null || s.Length == 0)
	//			return true;
	//		else
	//			return false;
	//	}

	//	public static bool IsNullorEmptyTrim(string s)
	//	{
	//		if (s == null || s.Trim().Length == 0)
	//			return true;
	//		else
	//			return false;
	//	}

	//	public static bool IsDecimal(string theValue)
	//	{
	//		try
	//		{
	//			Convert.ToDouble(theValue);
	//			return true;
	//		}
	//		catch
	//		{
	//			return false;
	//		}
	//	} // end IsDecimal

	//	public static bool IsDate(string theValue)
	//	{
	//		DateTime dtDate;
	//		try
	//		{
	//			dtDate=DateTime.Parse(theValue);
	//			return true;
	//		}
	//		catch 
	//		{
	//			return false;
	//		}
	//	} // end IsDate

	//	public static bool IsAllDigits(string theValue)
	//	{
	//		return Regex.IsMatch(theValue, "^\\d+$");
	//	}
	
	//	public static bool IsAllDigits(string theValue, int number)
	//	{
	//		return Regex.IsMatch(theValue, "^\\d" + "{" + number.ToString() + "}$");
	//	}

 //       public static bool IsAlphaNumeric(string theValue)
 //       {
 //           return Regex.IsMatch(theValue, "^[0-9a-zA-Z]+$");
 //       }
	//}

    public class MousePointer
    {
        public static void Hourglass()
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        public static void Default()
        {
            Cursor.Current = Cursors.Default;
        }
    }

    public class util
    {
        /* returns date as sttring of YYMMDD */
        public static string ReverseDate(DateTime inDate)
        {
            return inDate.ToString("yy") + inDate.ToString("MM") + inDate.ToString("dd");
        }
    }

		
	public class WinMsg
	{
		public enum WM_MESSAGE 
		{
			WM_APP = 32768,
			WM_ACTIVATE = 6,
			WM_ACTIVATEAPP = 28,
			WM_AFXFIRST = 864,
			WM_AFXLAST = 895,
			WM_ASKCBFORMATNAME = 780,
			WM_CANCELJOURNAL = 75,
			WM_CANCELMODE = 31,
			WM_CAPTURECHANGED = 533,
			WM_CHANGECBCHAIN = 781,
			WM_CHAR = 258,
			WM_CHARTOITEM = 47,
			WM_CHILDACTIVATE = 34,
			WM_CLEAR = 771,
			WM_CLOSE = 16,
			WM_COMMAND = 273,
			WM_COMMNOTIFY = 68,
			WM_COMPACTING = 65,
			WM_COMPAREITEM = 57,
			WM_CONTEXTMENU = 123,
			WM_COPY = 769,
			WM_COPYDATA = 74,
			WM_CREATE = 1,
			WM_CTLCOLORBTN = 309,
			WM_CTLCOLORDLG = 310,
			WM_CTLCOLOREDIT = 307,
			WM_CTLCOLORLISTBOX = 308,
			WM_CTLCOLORMSGBOX = 306,
			WM_CTLCOLORSCROLLBAR = 311,
			WM_CTLCOLORSTATIC = 312,
			WM_CUT = 768,
			WM_DEADCHAR = 259,
			WM_DELETEITEM = 45,
			WM_DESTROY = 2,
			WM_DESTROYCLIPBOARD = 775,
			WM_DEVICECHANGE = 537,
			WM_DEVMODECHANGE = 27,
			WM_DISPLAYCHANGE = 126,
			WM_DRAWCLIPBOARD = 776,
			WM_DRAWITEM = 43,
			WM_DROPFILES = 563,
			WM_ENABLE = 10,
			WM_ENDSESSION = 22,
			WM_ENTERIDLE = 289,
			WM_ENTERMENULOOP = 529,
			WM_ENTERSIZEMOVE = 561,
			WM_ERASEBKGND = 20,
			WM_EXITMENULOOP = 530,
			WM_EXITSIZEMOVE = 562,
			WM_FONTCHANGE = 29,
			WM_GETDLGCODE = 135,
			WM_GETFONT = 49,
			WM_GETHOTKEY = 51,
			WM_GETICON = 127,
			WM_GETMINMAXINFO = 36,
			WM_GETTEXT = 13,
			WM_GETTEXTLENGTH = 14,
			WM_HANDHELDFIRST = 856,
			WM_HANDHELDLAST = 863,
			WM_HELP = 83,
			WM_HOTKEY = 786,
			WM_HSCROLL = 276,
			WM_HSCROLLCLIPBOARD = 782,
			WM_ICONERASEBKGND = 39,
			WM_INITDIALOG = 272,
			WM_INITMENU = 278,
			WM_INITMENUPOPUP = 279,
			WM_INPUTLANGCHANGE = 81,
			WM_INPUTLANGCHANGEREQUEST = 80,
			WM_KEYDOWN = 256,
			WM_KEYUP = 257,
			WM_KILLFOCUS = 8,
			WM_MDIACTIVATE = 546,
			WM_MDICASCADE = 551,
			WM_MDICREATE = 544,
			WM_MDIDESTROY = 545,
			WM_MDIGETACTIVE = 553,
			WM_MDIICONARRANGE = 552,
			WM_MDIMAXIMIZE = 549,
			WM_MDINEXT = 548,
			WM_MDIREFRESHMENU = 564,
			WM_MDIRESTORE = 547,
			WM_MDISETMENU = 560,
			WM_MDITILE = 550,
			WM_MEASUREITEM = 44,
			WM_MENUCHAR = 288,
			WM_MENUSELECT = 287,
			WM_MOVE = 3,
			WM_MOVING = 534,
			WM_NCACTIVATE = 134,
			WM_NCCALCSIZE = 131,
			WM_NCCREATE = 129,
			WM_NCDESTROY = 130,
			WM_NCHITTEST = 132,
			WM_NCLBUTTONDBLCLK = 163,
			WM_NCLBUTTONDOWN = 161,
			WM_NCLBUTTONUP = 162,
			WM_NCMBUTTONDBLCLK = 169,
			WM_NCMBUTTONDOWN = 167,
			WM_NCMBUTTONUP = 168,
			WM_NCMOUSEMOVE = 160,
			WM_NCPAINT = 133,
			WM_NCRBUTTONDBLCLK = 166,
			WM_NCRBUTTONDOWN = 164,
			WM_NCRBUTTONUP = 165,
			WM_NEXTDLGCTL = 40,
			WM_NEXTMENU = 531,
			WM_NOTIFY = 78,
			WM_NOTIFYFORMAT = 85,
			WM_NULL = 0,
			WM_PAINT = 15,
			WM_PAINTCLIPBOARD = 777,
			WM_PAINTICON = 38,
			WM_PALETTECHANGED = 785,
			WM_PALETTEISCHANGING = 784,
			WM_PARENTNOTIFY = 528,
			WM_PASTE = 770,
			WM_PENWINFIRST = 896,
			WM_PENWINLAST = 911,
			WM_POWER = 72,
			WM_POWERBROADCAST = 536,
			WM_PRINT = 791,
			WM_PRINTCLIENT = 792,
			WM_QUERYDRAGICON = 55,
			WM_QUERYENDSESSION = 17,
			WM_QUERYNEWPALETTE = 783,
			WM_QUERYOPEN = 19,
			WM_QUEUESYNC = 35,
			WM_QUIT = 18,
			WM_RENDERALLFORMATS = 774,
			WM_RENDERFORMAT = 773,
			WM_SETCURSOR = 32,
			WM_SETFOCUS = 7,
			WM_SETFONT = 48,
			WM_SETHOTKEY = 50,
			WM_SETICON = 128,
			WM_SETREDRAW = 11,
			WM_SETTEXT = 12,
			WM_SETTINGCHANGE = 26,
			WM_SHOWWINDOW = 24,
			WM_SIZE = 5,
			WM_SIZECLIPBOARD = 779,
			WM_SIZING = 532,
			WM_SPOOLERSTATUS = 42,
			WM_STYLECHANGED = 125,
			WM_STYLECHANGING = 124,
			WM_SYSCHAR = 262,
			WM_SYSCOLORCHANGE = 21,
			WM_SYSCOMMAND = 274,
			WM_SYSDEADCHAR = 263,
			WM_SYSKEYDOWN = 260,
			WM_SYSKEYUP = 261,
			WM_TCARD = 82,
			WM_TIMECHANGE = 30,
			WM_TIMER = 275,
			WM_UNDO = 772,
			WM_USER = 1024,
			WM_USERCHANGED = 84,
			WM_VKEYTOITEM = 46,
			WM_VSCROLL = 277,
			WM_VSCROLLCLIPBOARD = 778,
			WM_WINDOWPOSCHANGED = 71,
			WM_WINDOWPOSCHANGING = 70,
			WM_WININICHANGE = 26,
			WM_KEYFIRST = 256,
			WM_KEYLAST = 264,
			WM_SYNCPAINT = 136,
			WM_MOUSEACTIVATE = 33,
			WM_MOUSEMOVE = 512,
			WM_LBUTTONDOWN = 513,
			WM_LBUTTONUP = 514,
			WM_LBUTTONDBLCLK = 515,
			WM_RBUTTONDOWN = 516,
			WM_RBUTTONUP = 517,
			WM_RBUTTONDBLCLK = 518,
			WM_MBUTTONDOWN = 519,
			WM_MBUTTONUP = 520,
			WM_MBUTTONDBLCLK = 521,
			WM_MOUSEWHEEL = 522,
			WM_MOUSEFIRST = 512,
			WM_MOUSELAST = 522,
			WM_MOUSEHOVER = 0x2A1,
			WM_MOUSELEAVE = 0x2A3
		};
	}

    
	public class BindingFormat
	{
		public static void DateTimeToCustomDateString1(object sender, System.Windows.Forms.ConvertEventArgs e) 
		{
			if (e.DesiredType != typeof(string)) return;
			if (e.Value.GetType() != typeof(DateTime)) return;
			e.Value = ((DateTime)e.Value).ToString("dd-MMM-yyyy");
		}

        public static void DateTimeToCustomDateString2(object sender, System.Windows.Forms.ConvertEventArgs e)
        {
            if (e.DesiredType != typeof(string)) return;
            if (e.Value.GetType() != typeof(DateTime)) return;
            e.Value = ((DateTime)e.Value).ToString("dd/MM/yy");
        }

		public static void DecimalToStandard(object sender, System.Windows.Forms.ConvertEventArgs e) 
		{
			if (e.DesiredType != typeof(string)) return;
			if (e.Value.GetType() != typeof(Decimal)) return;
			e.Value = ((Decimal)e.Value).ToString("N2");
		}

		public static void DoubleToFixed4(object sender, System.Windows.Forms.ConvertEventArgs e) 
		{
			if (e.DesiredType != typeof(string)) return;
			if (e.Value.GetType() != typeof(Double)) return;
			e.Value = ((Double)e.Value).ToString("F4");
		}


	}

	// Source: http://www.experts-exchange.com/Programming/Programming_Languages/C_Sharp/Q_21228131.html
	public class GeneralExceptionHandler 
	{

		public void Application_ThreadException(
			object sender, ThreadExceptionEventArgs e) 
		{
			try 
			{
				DialogResult result = ShowThreadExceptionDialog(
					e.Exception);

				if (result == DialogResult.Abort)
					Application.Exit();
			}
			catch 
			{
				// Fatal error, terminate program
				try 
				{
					MessageBox.Show("Fatal Error",
						"Fatal Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Stop);
				}
				finally 
				{
					Application.Exit();
				}
			}
		}

		///
		/// Creates and displays the error message.
		///
		private DialogResult ShowThreadExceptionDialog(Exception ex) 
		{
			string errorMessage=
				"Unhandled Exception:\n\n" +
				ex.Message + "\n\n" +
				ex.GetType() +
				"\n\nStack Trace:\n" +
				ex.StackTrace;

			return MessageBox.Show(errorMessage,
				"Application Error",
				MessageBoxButtons.AbortRetryIgnore,
				MessageBoxIcon.Error);
		}

	} // End ThreadExceptionHandler

    abstract public class EndlessProgressAsync
    {
        private BackgroundWorker backgroundWorker1;
        protected frmEndlessProgressBar frm;

        protected Form _parentForm;
        public Form ParentForm
        {
            set
            {
                _parentForm = value;
            }
        }

        private string _mainMessage;
        public string MainMessage
        {
            set
            {
                _mainMessage = value;
            }
        }

        private string _subMessage;
        public string SubMessage
        {
            set
            {
                _subMessage = value;
            }
        }

        private string _completedMessage;
        public string CompletedMessage
        {
            set
            {
                _completedMessage = value;
            }
        }

        // Backgroundworker error handling does not work in debug mode without this attribute
        [DebuggerNonUserCode()]
        protected virtual void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // any methods called here should also have the attribute:
            // [System.Diagnostics.DebuggerNonUserCodeAttribute()]

            // the method being called must be called Run() and return bool. For methods
            // with other signatures, backgroundWorker1_DoWork must be overriden in sub class

            e.Result = Run();
        }

        [DebuggerNonUserCode()]
        protected virtual bool Run()
        {
            return true;
        }



        protected virtual void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            frm.Close();

            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                if (e.Error is SqlException)
                    ExHandlers.SQL((SqlException)e.Error);
                if (e.Error is COMException)
                    ExHandlers.COM((COMException)e.Error);
                else
                    ExHandlers.General(e.Error);
            }
            else
            {
                if ((bool)e.Result)
                {
                    // handle the case where the operation succeeded.
                    MessageBox.Show(
                            _completedMessage,
                            CustomSettings.DatabaseName + " - System Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            MousePointer.Default();

        }

        private void InitializeBackgoundWorker()
        {
            backgroundWorker1.DoWork +=
                new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorker1_RunWorkerCompleted);
            //backgroundWorker1.ProgressChanged +=
            //    new ProgressChangedEventHandler(
            //backgroundWorker1_ProgressChanged);
        }

        public EndlessProgressAsync()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            InitializeBackgoundWorker();
        
        }

        public void Start()
        {
            MousePointer.Hourglass();

            try
            {

                frm = new frmEndlessProgressBar();
                frm.label1.Text = this._mainMessage;
                frm.label2.Text = this._subMessage;

                if (this._parentForm != null)
                {
                    frm.MdiParent = this._parentForm;
                }
                else
                {
                    frm.MdiParent = Application.OpenForms[0];
                }

                frm.Show();

                backgroundWorker1.RunWorkerAsync();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                    CustomSettings.DatabaseName + " - System Information");

            }
        }

    }

    /// <summary>
    /// //////////////////////////////////////////////
    /// </summary>

    public class ComboBoxItem
    {
        string displayValue;
        int hiddenValue;

        //Constructor
        public ComboBoxItem(string d, int h)
        {
            displayValue = d;
            hiddenValue = h;
        }

        //Accessor
        public int HiddenValue
        {
            get
            {
                return hiddenValue;
            }
        }

        //Override ToString method
        public override string ToString()
        {
            return displayValue;
        }
    }

    // Source: Microsoft KB319401 HOW TO: Sort a ListView Control by a Column in Visual C# .NET
    /// <summary>
    /// This class is an implementation of the 'IComparer' interface.
    /// </summary>
    //public class ListViewColumnSorter : IComparer
    //{
    //    /// <summary>
    //    /// Specifies the column to be sorted
    //    /// </summary>
    //    private int ColumnToSort;
    //    /// <summary>
    //    /// Specifies the order in which to sort (i.e. 'Ascending').
    //    /// </summary>
    //    private SortOrder OrderOfSort;
    //    /// <summary>
    //    /// Case insensitive comparer object
    //    /// </summary>
    //    private CaseInsensitiveComparer ObjectCompare;

    //    /// <summary>
    //    /// Class constructor.  Initializes various elements
    //    /// </summary>
    //    public ListViewColumnSorter()
    //    {
    //        // Initialize the column to '0'
    //        ColumnToSort = 0;

    //        // Initialize the sort order to 'none'
    //        OrderOfSort = SortOrder.None;

    //        // Initialize the CaseInsensitiveComparer object
    //        ObjectCompare = new CaseInsensitiveComparer();
    //    }

    //    /// <summary>
    //    /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
    //    /// </summary>
    //    /// <param name="x">First object to be compared</param>
    //    /// <param name="y">Second object to be compared</param>
    //    /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
    //    public int Compare(object x, object y)
    //    {
    //        int compareResult;
    //        ListViewItem listviewX, listviewY;

    //        // Cast the objects to be compared to ListViewItem objects
    //        listviewX = (ListViewItem)x;
    //        listviewY = (ListViewItem)y;

    //        // Compare the two items
    //        compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

    //        // Calculate correct return value based on object comparison
    //        if (OrderOfSort == SortOrder.Ascending)
    //        {
    //            // Ascending sort is selected, return normal result of compare operation
    //            return compareResult;
    //        }
    //        else if (OrderOfSort == SortOrder.Descending)
    //        {
    //            // Descending sort is selected, return negative result of compare operation
    //            return (-compareResult);
    //        }
    //        else
    //        {
    //            // Return '0' to indicate they are equal
    //            return 0;
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
    //    /// </summary>
    //    public int SortColumn
    //    {
    //        set
    //        {
    //            ColumnToSort = value;
    //        }
    //        get
    //        {
    //            return ColumnToSort;
    //        }
    //    }

    //    /// <summary>
    //    /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
    //    /// </summary>
    //    public SortOrder Order
    //    {
    //        set
    //        {
    //            OrderOfSort = value;
    //        }
    //        get
    //        {
    //            return OrderOfSort;
    //        }
    //    }

    //}


}
