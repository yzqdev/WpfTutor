using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfWeb.ViewModel {
    public class Beauty:ObservableObject {
        /// <summary>
        /// 1.使用relaycommand
        /// </summary>
        public AsyncRelayCommand ClickCommand { get; }

        private string _name;
        public string Name {
            get { return _name; }
            set {
                SetProperty(ref _name, value);
            }
        }
        private string _ResponseText;
        public string ResponseText {
            get { return _ResponseText; }
            set {
                SetProperty(ref _ResponseText, value);
            }
        }
        private List<string> _ItemSource;
        public List<string> ItemSource {
            get { return _ItemSource; }
            set {
                SetProperty(ref _ItemSource, value);
            }
        }
        public Beauty() {
            Name = "初始名字";
            ItemSource= new List<string>() { "aaa","bbbb","cccc"};
            ClickCommand = new AsyncRelayCommand(GetAsync);

          
        }
        async Task GetAsync() {
            var client = new HttpClient();
            using HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos");

            response.EnsureSuccessStatusCode();


            var jsonResponse = await response.Content.ReadAsStringAsync();
            Debug.WriteLine($"{jsonResponse}\n");
            ResponseText = jsonResponse;
            // Expected output:
            //   GET https://jsonplaceholder.typicode.com/todos/3 HTTP/ 1.1
            //   {
            //     "userId": 1,
            //     "id": 3,
            //     "title": "fugiat veniam minus",
            //     "completed": false
            //   }
        }
    }
}
