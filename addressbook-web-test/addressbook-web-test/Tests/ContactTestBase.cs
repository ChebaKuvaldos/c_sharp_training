using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace addressbook_web_test
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContactUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<Class3_ContactData> fromUI = app.Contacts.GetContactsList();
                List<Class3_ContactData> fromDB = Class3_ContactData.GetAllContactInfo();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
    }
}