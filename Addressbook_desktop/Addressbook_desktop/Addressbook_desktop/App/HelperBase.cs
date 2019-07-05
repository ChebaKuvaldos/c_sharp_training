using AutoItX3Lib;

namespace Addressbook_desktop
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected string WinTitle;
        protected AutoItX3 aux;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.aux = manager.Aux;
            WinTitle = ApplicationManager.WinTitle;
        }
    }
}