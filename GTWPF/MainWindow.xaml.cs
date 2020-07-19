using GI;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace GTWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow MainApp;
        
    
        
        public MainWindow()
        {
            InitializeComponent();
            RepairWindowBehavior(this);
            MainApp = this;
            GI.Gdebug.toShow = (str) =>
            {
                MessageBox.Show(str);
                return true;
            };
            ToolButton.Visibility = Visibility.Hidden;
            toolgrid.MouseDown += (s, e) =>
            {
                PageBase.Children.RemoveAt(PageBase.Children.Count - 1);
                toolshowing = false;
             };
        }
        internal void Addtext(string text)
        {
            this.Dispatcher.Invoke(() =>
            {
                system_outputbox.Text += text;
                sys_roll.ScrollToEnd();
            });
        }


        /// <summary>
        /// 加载gasoline代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //获取GIInfo
            system_outputbox.Text += "Gasoline for GTWPF version " + GIInfo.GIVersion.ToString()+Environment.NewLine;
            
            System.Xml.XmlDocument codes = new System.Xml.XmlDocument();
            codes.LoadXml(App.xmlcodes);

            WPFLib._function_Thread_override_.Load();
            Gasoline.StartGas(new System.Collections.Generic.Dictionary<string,GI.Lib.ILib> {
                {"IO",new WPFLib.IO_Lib() },
                {"Page",new WPFLib.Page_Lib() },
                {"Control",new WPFLib.Control_Lib() }
            }, codes);


        }
        private void Window_Closed(object sender, EventArgs e)
        {
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
            
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        #region 最大化处理
        public static void RepairWindowBehavior(Window wpfWindow)

        {
            if (wpfWindow == null)
                return;

            wpfWindow.SourceInitialized += delegate
            {
                IntPtr handle = (new WindowInteropHelper(wpfWindow)).Handle;
                HwndSource source = HwndSource.FromHwnd(handle);
                if (source != null)
                {
                    source.AddHook(WindowProc);
                }
            };
        }
        private static IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:
                WmGetMinMaxInfo(hwnd, lParam);
                handled = true;
                break;
            }

            return (IntPtr)0;
        }
        private static void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
        {
            MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

            int MONITOR_DEFAULTTONEAREST = 0x00000002;
            IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);

            if (monitor != IntPtr.Zero)
            {
                MONITORINFO monitorInfo = new MONITORINFO();
                GetMonitorInfo(monitor, monitorInfo);
                RECT rcWorkArea = monitorInfo.rcWork;
                RECT rcMonitorArea = monitorInfo.rcMonitor;
                mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
                mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
            }

            Marshal.StructureToPtr(mmi, lParam, true);
        }
        [DllImport("user32")]
        internal static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);
        [DllImport("User32")]
        internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);
        #region Nested type: MINMAXINFO
        [StructLayout(LayoutKind.Sequential)]
        internal struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        }
        #endregion
        #region Nested type: MONITORINFO
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal class MONITORINFO
        {
            public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
            public RECT rcMonitor;
            public RECT rcWork;
            public int dwFlags;
        }
        #endregion
        #region Nested type: POINT
        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            public int x;
            public int y;
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        #endregion
        #region Nested type: RECT
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        internal struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public static readonly RECT Empty;

            public int Width
            {
                get { return Math.Abs(right - left); }
            }
            public int Height
            {
                get { return bottom - top; }
            }

            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            public RECT(RECT rcSrc)
            {
                left = rcSrc.left;
                top = rcSrc.top;
                right = rcSrc.right;
                bottom = rcSrc.bottom;
            }

            public bool IsEmpty
            {
                get
                {
                    return left >= right || top >= bottom;
                }
            }

            public override string ToString()
            {
                if (this == Empty)
                {
                    return "RECT {Empty}";
                }
                return "RECT { left : " + left + " / top : " + top + " / right : " + right + " / bottom : " + bottom + " }";
            }

            public override bool Equals(object obj)
            {
                if (!(obj is Rect))
                {
                    return false;
                }
                return (this == (RECT)obj);
            }

            public override int GetHashCode()
            {
                return left.GetHashCode() + top.GetHashCode() + right.GetHashCode() + bottom.GetHashCode();
            }

            public static bool operator ==(RECT rect1, RECT rect2)
            {
                return (rect1.left == rect2.left && rect1.top == rect2.top && rect1.right == rect2.right && rect1.bottom == rect2.bottom);
            }

            public static bool operator !=(RECT rect1, RECT rect2)
            {
                return !(rect1 == rect2);
            }
        }
        #endregion

        #endregion


        //页面操作
        public ArrayList Pages = new ArrayList();//储存页面
        public const bool AllowBackToConsole = false;

        public void GotoPage(GasControl.Page.GasPage page)
        {
            
            Dispatcher.Invoke(new Action(()=>
            {
                ThicknessAnimation thicknessAnimation = new ThicknessAnimation();
                thicknessAnimation.From = new Thickness(0, 200, 0, 0);
                thicknessAnimation.To = new Thickness(0);
                thicknessAnimation.Duration = TimeSpan.FromMilliseconds(200);

                GasTitle.Content = page.title;
                Pages.Add(page);
                PageBase.Children.Clear();
                PageBase.Children.Add(page);

                ToolButton.Visibility = page.hastool ? Visibility.Visible : Visibility.Hidden;

                PageBase.Visibility = Visibility.Visible;
                page.BeginAnimation(Grid.MarginProperty, thicknessAnimation);

            }
            ));

        }
        public GasControl.Page.GasPage Return()
        {
            if (Pages.Count > 1)
            {
                GasControl.Page.GasPage rgp = Pages[Pages.Count - 1] as GasControl.Page.GasPage;
                Pages.Remove(rgp);
                PageBase.Children.Clear();
                GasControl.Page.GasPage page = Pages[Pages.Count - 1] as GasControl.Page.GasPage;
                PageBase.Children.Add(page);
                GasTitle.Content = page.title;

                ToolButton.Visibility = page.hastool ? Visibility.Visible : Visibility.Hidden;
                return rgp;
            }
            else
            {
                return null;
            }
            
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Return();
        } //左上角返回按钮

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Hide();
            Task.Run(() =>
            {
                Environment.Exit(0);
            });

        }
        bool toolshowing = false;
        Grid toolgrid = new Grid
        {
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Stretch,
            Background = Brushes.Transparent,
            
        };
        private void ToolButtonClick(object sender, RoutedEventArgs e)
        {
            if (toolshowing)
            {
                PageBase.Children.RemoveAt(PageBase.Children.Count - 1);
                toolshowing = false;
            }
            else
            {
                var page = Pages[Pages.Count - 1] as GasControl.Page.GasPage;
                toolgrid.Children.Clear();
                toolgrid.Children.Add(page.sp_tools);
                PageBase.Children.Add(toolgrid);
                toolshowing = true;
            }
        }
    }
}
