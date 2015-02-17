using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace GeoShare
{
    public class TodoItem
    {
        public int Id { get; set; }

       // [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        public long PhoneNumber { get; set; }
      //  [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }
    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MobileServiceCollection<TodoItem, TodoItem> items;
        private IMobileServiceTable<TodoItem> todoTable =
            App.MobileService.GetTable<TodoItem>();
        public MainPage()
        {
            this.InitializeComponent();
       /*     InputScope scope = new InputScope();
            InputScopeName name = new InputScopeName();
            name.NameValue = InputScopeNameValue.Number;
            scope.Names.Add(name);
            enterPhoneNumber.InputScope = scope;*/
        }
        private async void InsertTodoItem(TodoItem todoItem)
        {
            await todoTable.InsertAsync(todoItem);
            items.Add(todoItem);
        }
        private async void RefreshTodoItems()
        {
            items = await todoTable
                .ToCollectionAsync();
          //  ListItems.ItemsSource = items;
        }
        private async void UpdateCheckedTodoItem(TodoItem item)
        {
            await todoTable.UpdateAsync(item);
        }
        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshTodoItems();
        }
  
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           // RefreshTodoItems();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(GroupManagementPage),
                new GroupManagementPageParameters { PhoneNumber = enterPhoneNumber.Text, FullName = enterFullName.Text });
            var fullName = new TodoItem { Text = enterFullName.Text,
                                          PhoneNumber = Convert.ToInt64(enterPhoneNumber.Text)};
   
            InsertTodoItem(fullName);
            
        }
    }
}
