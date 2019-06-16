using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace addressbook_web_test
{
    [TestFixture]
    public class Test4_RemoveContact : AuthTestBase
    {
        [Test]
        public void RemoveContactTest()
        {
            app.Contacts.RemoveContact(0);

        }
    }
}
