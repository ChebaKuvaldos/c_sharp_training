using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_desktop
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public string GroupWinTitle = "Group editor";
        public string DeleteWinTitle = "Delete group";

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsEditor();
            string count = aux.ControlTreeView(GroupWinTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount","#0","");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(GroupWinTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });

            }
            CloseGroupsEditor();
            return list;
        }

        internal void DeleteGroup(GroupData group)
        {
            OpenGroupsEditor();
            DoesGroupExist(group);
            SelectGroupForRemoval();
            InitDeleteButton();
            SubmitRemoval();
            CloseGroupsEditor();
        }

        public void CreateGroup(GroupData group)
        {
            OpenGroupsEditor();
            CreateNewGroup();
            FillFormGroupCreation(group);
            CloseGroupsEditor();
        }

        public void DoesGroupExist(GroupData group)
        {
            group = new GroupData()
            {
                Name = "FrRmvl"
            };
            List<GroupData> list = new List<GroupData>();
            
            string count = aux.ControlTreeView(GroupWinTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", 
                "GetItemCount", "#0", "");
            if (Convert.ToInt32(count) == 1)
            {
                list.Add(group);
            }
            return;
        }

        private void SelectGroupForRemoval()
        {
            aux.ControlTreeView(GroupWinTitle, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", 
                "Select", "#0|#1", "");
        }

        private void InitDeleteButton()
        {
            aux.ControlClick(GroupWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait(DeleteWinTitle);
        }

        private void SubmitRemoval()
        {
            aux.ControlClick(DeleteWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.WinWait(GroupWinTitle); 
        }

        public void OpenGroupsEditor()
        {
            aux.ControlClick(WinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GroupWinTitle);
        }

        public void CreateNewGroup()
        {
            aux.ControlClick(GroupWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d53");
        }

        public void FillFormGroupCreation(GroupData group)
        {
            aux.Send(group.Name);
            aux.Send("{ENTER}");
        }
        public void CloseGroupsEditor()
        {
            aux.ControlClick(GroupWinTitle, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }
    }
}
