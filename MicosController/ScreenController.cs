using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Runtime.InteropServices;


namespace MicosController
{



    class ScreenController
    {

        /// <summary>aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        /// スクリーンショットに関するインポート系
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.Dll")]
        static extern int GetWindowRect(IntPtr hWnd, out Rect rect);


        [DllImport("user32.dll")]
        extern static IntPtr GetForegroundWindow();


        /// <summary>aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        /// テンプレート画像用変数
        /// </summary>
        /// <returns></returns>

        public string url_temp_pic_Micoszaikoscreen { get; set; }
        public string url_temp_pic_Micoscompscreen { get; set; }

        public System.Diagnostics.Process Micos_Process { get; set; }

        public string Micos_process_name { get; set; }





        public bool Check_Zaiko_Screen()
        {
            Rect rect;
            Activate_MicosWindow();

            Bitmap a = CaptureActiveWindow();
            a.Save(@"C:\Users\e33230-user3\OneDrive - hqhamamatsu.onmicrosoft.com\デスクトップ\Mandrill2.jpg",
                 System.Drawing.Imaging.ImageFormat.Jpeg);

            IntPtr activeWindow = GetForegroundWindow();  //他の関数でMicosウインドウをアクティブにしてからIntPtrを取得すれば、Micosの画面がキャプチャできる。
            GetWindowRect(activeWindow, out rect);
            Rectangle rectangle = new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);

            Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.CopyFromScreen(new Point(rectangle.X, rectangle.Y), new Point(0, 0), rectangle.Size);

            graphics.Dispose();

            bitmap.Save(
                @"C:\Users\e33230-user3\OneDrive - hqhamamatsu.onmicrosoft.com\デスクトップ\Mandrill.jpg",
                 System.Drawing.Imaging.ImageFormat.Jpeg
                );

            return true;
        }

        private void Activate_MicosWindow()
        {
            //micosのプロセスを探す
            System.Diagnostics.Process[] ps =
                System.Diagnostics.Process.GetProcessesByName(Micos_process_name);
            if (0 < ps.Length)
            {
                //見つかった時は、アクティブにする
                Microsoft.VisualBasic.Interaction.AppActivate(ps[0].Id);
            }
            else
            {
                Console.WriteLine("error, micos is not found");
            }
        }

        private static Bitmap CaptureActiveWindow() //周りのマージンみたいなのなしでキャプチャしてくれる。
        {
            //アクティブなウィンドウのデバイスコンテキストを取得
            IntPtr hWnd = NativeMethods.GetForegroundWindow();
            IntPtr winDC = NativeMethods.GetWindowDC(hWnd);
            //ウィンドウの大きさを取得
            NativeMethods.RECT winRect = new NativeMethods.RECT();
            NativeMethods.DwmGetWindowAttribute(
                hWnd,
                NativeMethods.DWMWA_EXTENDED_FRAME_BOUNDS,
                out var bounds,
                Marshal.SizeOf(typeof(NativeMethods.RECT)));
            NativeMethods.GetWindowRect(hWnd, ref winRect);
            //Bitmapの作成
            var offsetX = bounds.left - winRect.left;
            var offsetY = bounds.top - winRect.top;
            Bitmap bmp = new Bitmap(bounds.right - bounds.left, bounds.bottom - bounds.top);

            //Graphicsの作成
            using (var g = Graphics.FromImage(bmp))
            {
                //Graphicsのデバイスコンテキストを取得
                IntPtr hDC = g.GetHdc();
                //Bitmapに画像をコピーする
                Console.WriteLine(winRect);
                NativeMethods.BitBlt(hDC, 0, 0, bmp.Width, bmp.Height, winDC, offsetX, offsetY, NativeMethods.SRCCOPY);
                //解放
                g.ReleaseHdc(hDC);
            }
            NativeMethods.ReleaseDC(hWnd, winDC);

            return bmp;
        }

    }
}
