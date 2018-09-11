using PhoneBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PhoneBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditContact : Page
    {
        public EditContact()
        {
            this.InitializeComponent();
        }

        private async void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> EditPhoneBookContact = new List<string>();
                            

            

            

            if (!(string.IsNullOrEmpty(FirsNameTxt.Text) && string.IsNullOrEmpty(LastNameTxt.Text)))
            {
                if (!((string.IsNullOrEmpty(PhoneNumberTxt.Text)) && (string.IsNullOrEmpty(EmailAddressTxt.Text)) && (string.IsNullOrEmpty(GroupTxt.Text)) && (string.IsNullOrEmpty(WorkTxt.Text)) && (string.IsNullOrEmpty(AddressTxt.Text))))
                {
                    EditPhoneBookContact.Add(FirsNameTxt.Text);
                    EditPhoneBookContact.Add(LastNameTxt.Text);
                    EditPhoneBookContact.Add(PhoneNumberTxt.Text);
                    EditPhoneBookContact.Add(EmailAddressTxt.Text);
                    EditPhoneBookContact.Add(GroupTxt.Text);
                    EditPhoneBookContact.Add(WorkTxt.Text);
                    EditPhoneBookContact.Add(AddressTxt.Text);

                    Contact.EditContactAsync(EditPhoneBookContact);

                    var dialog = new MessageDialog($"You have succesfully updated {FirsNameTxt.Text} {LastNameTxt.Text}'s information. ");

                    await dialog.ShowAsync();
                }
                else
                {
                    var dialog = new MessageDialog("Along With FirstName And LastName You Must Enter The Field To Be Edited");

                    await dialog.ShowAsync();
                }
            }
            else
            {
                var dialog = new MessageDialog("Please Enter The Contact's FirstName And LastName.");

                await dialog.ShowAsync();
            }





        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
