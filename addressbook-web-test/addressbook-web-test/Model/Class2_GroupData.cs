﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_test
{
    public class Class2_GroupData : IEquatable<Class2_GroupData>, IComparable<Class2_GroupData>
    {
        public Class2_GroupData()
        { 
        }

        public Class2_GroupData(string name)
        {
            Name = name;
        }

        public bool Equals(Class2_GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name;
        }

        public int CompareTo(Class2_GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return Name.CompareTo(other.Name);
        }

        public string Name { get; set; }


        public string Header { get; set; }


        public string Footer { get; set; }


 
        }
    }
