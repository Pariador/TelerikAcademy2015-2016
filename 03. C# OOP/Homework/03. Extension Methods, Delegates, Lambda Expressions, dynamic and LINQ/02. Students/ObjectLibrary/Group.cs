namespace Students.ObjectLibrary
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Group
    {
        private static int nextNumber = 1;
        private string departmentName;
        private static List<Group> existungGroups = new List<Group>();

        public Group(string groupName)
        {
            this.DepartmentName = groupName;
            this.GroupNumber = Group.NextNumber;
            Group.NextNumber++;
            Group.ExistingGroups.Add(this);
        }

        public static int NextNumber
        {
            get
            {
                return Group.nextNumber;
            }
            private set
            {
                Group.nextNumber = value;
            }
        }
        private static List<Group> ExistingGroups
        {
            get
            {
                return Group.existungGroups;
            }
            set
            {
                Group.existungGroups = value;
            }
        }
        public string DepartmentName
        {
            get
            {
                return this.departmentName;
            }
            set
            {
                value = value.Trim();

                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Group name must not be Empty, null or Whitespace.");
                }

                if (Group.ExistingGroups.Any(grp => grp.DepartmentName == value))
                {
                    throw new Exception("A Group with that GroupName was alredy created.");
                }

                this.departmentName = value;
            }
        }
        public int GroupNumber { get; private set; }

        public static Group GetGroup(string groupName)
        {
            var resultGroup = Group.ExistingGroups.FirstOrDefault(grp => grp.DepartmentName == groupName);

            if (resultGroup == default(Group))
	        {
	    	    throw new ArgumentException("A group with that name doesn't exist."); 
	        }

            return resultGroup;
        }
        public static Group GetGroup(int groupNumber)
        {
            var resultGroup = Group.ExistingGroups.FirstOrDefault(grp => grp.GroupNumber == groupNumber);

            if (resultGroup == default(Group))
            {
                throw new ArgumentException("A group with that number doesn't exist."); 
            }

            return resultGroup;
        }
    }
}