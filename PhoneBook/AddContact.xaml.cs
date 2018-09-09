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
using Windows.Media.SpeechRecognition;
using Windows.Media.SpeechSynthesis;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PhoneBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddContact : Page
    {
        public AddContact()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            var contact = new Contact
            {

                FirstName = firstnameText.Text,
                LastName = lastnameText.Text,
                PhoneNumber = phonenumberText.Text,
                Email = emailText.Text,
                Group = groupText.Text,
                Work = WorkText.Text,
                Address = AddressText.Text
            };


            Contact.WriteContact(contact);

            if (contact.FirstName != "")
            {
                var dialog = new MessageDialog("You have succesfully added your contact information");
                await dialog.ShowAsync();
            }

            else
            {
                var dialog = new MessageDialog("You have to input the contact's First Name Before adding contact");
                
                await dialog.ShowAsync();
            }
         
           

            
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        SpeechSynthesizer Speechsynthesizer = new SpeechSynthesizer();
        
        private async void button_Click_1(object sender, RoutedEventArgs e)
        {
            var speechRecognizer = new SpeechRecognizer();

            // Compile the dictation grammar by default.
            await speechRecognizer.CompileConstraintsAsync();

           SpeechRecognitionResult speechRecognitionResult = await speechRecognizer.RecognizeWithUIAsync();

            // Do something with the recognition result.
            var messageDialog = new MessageDialog(speechRecognitionResult.Text, "Text spoken");
            await messageDialog.ShowAsync();

        }

        private void StopSpeechTo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
