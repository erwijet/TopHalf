using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TopHalf
{
    using HWND = IntPtr;

    public partial class OverlayForm : Form
    {
        public const int WS_EX_LAYERED = 0x80000;
        public const int WM_NCHITTEST = 0x0084;
        public const int HTCAPTION = 2;

        public HWND hTargetWnd { get; set; }

        public OverlayForm()
        {
            InitializeComponent();

            hTargetWnd = IntPtr.Zero;

            listbox.DrawMode = DrawMode.OwnerDrawFixed;
            listbox.DrawItem += new DrawItemEventHandler(listbox_DrawItem);

            listbox.Items.AddRange(new ListBox.ObjectCollection(listbox, new object[] { "", "" }));

            foreach (KeyValuePair<IntPtr, string> window in OpenWindowGetter.GetOpenWindows())
            {
                IntPtr handle = window.Key;
                string title = window.Value;

                if (!IsIconic(handle))
                    listbox.Items.Add($"{handle}: {title}");
            }

            listbox.Items.Add("<CANCEL>");
        }

        private void listbox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox list = (ListBox)sender;
            if (e.Index > -1)
            {
                object item = list.Items[e.Index];
                e.DrawBackground();
                e.DrawFocusRectangle();
                Brush brush = new SolidBrush(e.ForeColor);
                SizeF size = e.Graphics.MeasureString(item.ToString(), e.Font);
                e.Graphics.DrawString(item.ToString(), e.Font, brush, e.Bounds.Left + (e.Bounds.Width / 2 - size.Width / 2), e.Bounds.Top + (e.Bounds.Height / 2 - size.Height / 2));
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            HatchBrush hb = new HatchBrush(HatchStyle.Percent50, this.TransparencyKey);
            e.Graphics.FillRectangle(hb, this.DisplayRectangle);
        }

        private void listbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listbox.SelectedIndex == -1)
                return;

            if (listbox.SelectedItem as string == "<CANCEL>")
            {
                Close();
                return;
            }

            if (hTargetWnd == IntPtr.Zero)
            {
                string lpCaption = (listbox.SelectedItem as string).Split(':')[1];
                lpCaption = lpCaption.Substring(1);

                HWND hWnd = FindWindowByCaption(IntPtr.Zero, lpCaption);

                hTargetWnd = hWnd;

                Rectangle rect = Screen.FromControl(this).Bounds;
                listbox.Items.Clear();
                listbox.Items.Add("MOVE UP");
                for (int i = 0; i < rect.Height / 37; i++) { listbox.Items.Add(""); }
                listbox.Items.Add("MOVE DOWN");
            }
            else if (listbox.SelectedItem as string == "MOVE UP" || listbox.SelectedItem as string == "MOVE DOWN")
            {
                Rectangle rect = Screen.FromControl(this).Bounds;
                int y = listbox.SelectedItem as string == "MOVE UP" ? 0 : rect.Height / 2;
                MoveWindow(hTargetWnd, 0, y, rect.Width, rect.Height / 2, true);
                this.Close();
            }
        }

        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool IsIconic(HWND hWnd);
    }

    public static class OpenWindowGetter
    {
        public static IDictionary<HWND, string> GetOpenWindows()
        {
            HWND shellWindow = GetShellWindow();
            Dictionary<HWND, string> windows = new Dictionary<HWND, string>();

            EnumWindows(delegate (HWND hWnd, int lParam)
            {
                if (hWnd == shellWindow) return true;
                if (!IsWindowVisible(hWnd)) return true;

                int length = GetWindowTextLength(hWnd);
                if (length == 0) return true;

                StringBuilder builder = new StringBuilder(length);
                GetWindowText(hWnd, builder, length + 1);

                windows[hWnd] = builder.ToString();
                return true;
            }, 0);

            return windows;
        }

        private delegate bool EnumWindowProc(HWND hWnd, int lParam);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowProc enumFunc, int lParam);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(HWND hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern int GetWindowTextLength(HWND hWnd);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(HWND hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetShellWindow();
    }
}
