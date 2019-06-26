using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace addressbook_web_test
{
    public class Class3_ContactData : IEquatable<Class3_ContactData>, IComparable<Class3_ContactData>
    {

        private string allPhones;
        private string allEmails;
        private string contactInfo;

        public Class3_ContactData()
        {
        }

        public Class3_ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public Class3_ContactData(string contactInfo)
        {
            ContactInfo = contactInfo;
        }



        public bool Equals(Class3_ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            if ((Firstname == other.Firstname)
                && (Lastname == other.Lastname))
            {
                return true;
            }
            return false;
        }
        
        public override int GetHashCode()
        {
            return Lastname.GetHashCode();
        }
        
        public override string ToString()
        {
            return ("Firstname=" + Firstname) + ("Lastname=" + Lastname);
        }


        public int CompareTo(Class3_ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
        }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string AllPhones { get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
             set
            {
                allPhones = value;
            } }
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ ()-]","") + "\r\n";

        }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllEmails
        {
            get
            {
                if (allPhones != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanEm(Email) + CleanEm(Email2) + CleanEm(Email3)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanEm(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";

        }
        

        public string Homepage { get; set; }
        
        public string Birthday { get; set; }

        public string Bday { get; set; }

        public string Bmonth { get; set; }

        public string Byear { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }

        public string Notes { get; set; }
        
        public string ContactInfo
        {
            get
            {
                if (contactInfo != null)
                {
                    return contactInfo;
                }
                else
                {
                    contactInfo = "";

                    if (Firstname != "")
                    {
                        contactInfo += Firstname + " ";
                    }

                    if (Lastname != "")
                    {
                        contactInfo += Lastname + "\r\n";
                    }

                    if (Address != "")
                    {
                        contactInfo += Address + "\r\n\r\n";
                    }

                    if (HomePhone != "")
                    {
                        contactInfo += "H: " + CleanUp(HomePhone);
                    }

                    if (MobilePhone != "")
                    {
                        contactInfo += "M: " + CleanUp(MobilePhone);
                    }

                    if (WorkPhone != "")
                    {
                        contactInfo += "W: " + CleanUp(WorkPhone) + "\r\n";
                    }

                    if (Email != "")
                    {
                        contactInfo += Email + "\r\n";
                    }

                    if (Email2 != "")
                    {
                        contactInfo += Email2 + "\r\n";
                    }
                    if (Email3 != "")
                    {
                        contactInfo += Email3 + "\r\n";
                    }
                    if (Birthday != "")
                    {
                        contactInfo += "\r\n" + Birthday;
                    }
                    else Birthday = null;
                    if (Bday != "")
                    {
                        contactInfo += "\r\n" + Bday;
                    }
                    else Bmonth = null;
                    if (Byear != "")
                    {
                        contactInfo += "\r\n" + Bmonth;
                    }
                    else Byear = null;
                    if (Byear != "")
                    {
                        contactInfo += "\r\n" + Byear;
                    }
                    else Byear = null; 
                    return contactInfo.Trim();

                }
            }

        
        set
            {
                contactInfo = value;
            }
        }


    }
}
