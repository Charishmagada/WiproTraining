using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    internal class MessageUtil
    {
        [DllImport("user32.dll", EntryPoint = "MessageBox")] // user32.dll predefined one present in GAC folder.
        public static extern int ShowMessageBox(int hwnd, string text, string caption, uint type);
    }
}

