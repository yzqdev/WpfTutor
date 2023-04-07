
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System.Collections.ObjectModel;
 
using ToDo.Models;

namespace ToDo.ViewModel
{
    public class MainViewModel : ObservableRecipient
    {
        public MainViewModel()
        {
            MenuModels = new ObservableCollection<MenuModel>();
            menuModels.Add(new MenuModel() { IconFont = "\xe635", Title = "�ҵ�һ��Ŷ", BackColor = "#218868", Display = false });
            menuModels.Add(new MenuModel() { IconFont = "\xe6b6", Title = "��Ҫ", BackColor = "#EE3B3B",  });
            menuModels.Add(new MenuModel() { IconFont = "\xe6e1", Title = "�Ѽƻ��ճ�", BackColor = "#218868",  });
            menuModels.Add(new MenuModel() { IconFont = "\xe614", Title = "�ѷ������", BackColor = "#EE3B3B",  });
            menuModels.Add(new MenuModel() { IconFont = "\xe755", Title = "����", BackColor = "#218868",  });

            MenuModel = MenuModels[0];
            
            SelectedCommand = new RelayCommand<MenuModel>(t => Select(t));
            SelectedTaskCommand = new RelayCommand<TaskInfo>(t => SelectedTask(t));
        }

        private ObservableCollection<MenuModel> menuModels;

        public ObservableCollection<MenuModel> MenuModels
        {
            get { return menuModels; }
            set { SetProperty(ref menuModels, value); }
        }

        public RelayCommand<MenuModel> SelectedCommand { get; set; }
        public RelayCommand<TaskInfo> SelectedTaskCommand { get; set; }

        private MenuModel menuModel;

        public MenuModel MenuModel
        {
            get { return menuModel; }
            set { SetProperty(ref menuModel , value); }
        }

        private TaskInfo info;

        public TaskInfo Info
        {
            get { return info; }
            set { SetProperty(ref info, value); }
        }

        private void Select(MenuModel model)
        {
            MenuModel = model;
        }

        public void AddTaskInfo(string content)
        {
            MenuModel.TaskInfos.Add(new TaskInfo()
            {
                Content = content
            });
        }

        public void SelectedTask(TaskInfo task)
        {
            Info = task;
            Messenger.Send(task, "Expand");
        }
    }
}