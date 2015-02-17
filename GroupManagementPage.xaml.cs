using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace GeoShare
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GroupManagementPage : Page
    {
        public GroupManagementPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            GroupManagementPageParameters data = e.Parameter as GroupManagementPageParameters;
            welcomeMessage.Text = "Hello " + data.FullName + "!!! ";
        }

        private async void addNewGroup_Click(object sender, RoutedEventArgs e)
        {
            var contactPicker = new ContactPicker();
            contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.PhoneNumber);
            var contacts = await contactPicker.PickContactsAsync();
            this.Frame.Navigate(typeof(GroupCreationPage), contacts);
            
        }

    }
}
