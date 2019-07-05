using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutoItX3Lib;

namespace Addressbook_desktop
{

    public class ApplicationManager
    {
        
        private GroupHelper groupHelper;
        private AutoItX3 aux;
        public static string WinTitle = "Free Address Book";

        public ApplicationManager()
        {
            aux = new AutoItX3();
            aux.Run(@"D:\CSharpForSoftwareTesting\addressbook\AddressBook.exe","",aux.SW_SHOW);
            aux.WinWait(WinTitle);
            aux.WinActivate(WinTitle);
            aux.WinWaitActive(WinTitle);
            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }
        }
    }
}
