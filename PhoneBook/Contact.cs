using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace PhoneBook
{
    /// <summary>
    /// This is the blueprint for an contact
    /// </summary>
    public class Contact
    {
        private const string TEXT_FILE_NAME = "FileTest3.txt";
        /// <summary>
        /// Holds the name of the contact
        /// </summary>
        /// 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Group { get; set; }

        public string Work { get; set; }

        public string Address { get; set; }

        public async static Task<ICollection<Contact>> GetContacts()
        {
            var contacts = new List<Contact>();
            var fileContent = await FileHelper.ReadTextFileAsync(TEXT_FILE_NAME);
            var lines = fileContent.Split(new char[] { '\r', '\n' });
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                var lineParts = line.Split(',');
                var contact = new Contact
                {
                    FirstName = lineParts[0],
                    LastName = lineParts[1],
                    PhoneNumber = lineParts[2],
                    Email = lineParts[3],
                    Group = lineParts[4],
                    Work = lineParts[5],
                    Address = lineParts[6]
                };
                contacts.Add(contact);
            }
            return contacts;
        }

        /// <summary>
        /// Write contact to file
        /// </summary>
        /// <param name="contact">The contact object to write</param>
        public static void WriteContact(Contact contact)
        {
            var contactData = $"{contact.FirstName},{contact.LastName},{contact.PhoneNumber},{contact.Email},{contact.Group},{contact.Work},{contact.Address}";
            FileHelper.WriteTextFileAsync(TEXT_FILE_NAME, contactData);

        }

        public async static void DeleteContactAsync(string Firstname, string Lastname)
        {
            string Content;
            var contacts = new List<Contact>();
            var fileContent = await FileHelper.ReadTextFileAsync(TEXT_FILE_NAME);
            var lines = fileContent.Split(new char[] { '\r', '\n' });
            int i = 0;
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                var lineParts = line.Split(',');
                var contact = new Contact
                {
                    FirstName = lineParts[0],
                    LastName = lineParts[1],
                    PhoneNumber = lineParts[2],
                    Email = lineParts[3],
                    Group = lineParts[4],
                    Work = lineParts[5],
                    Address = lineParts[6]
                };

                if (contact.FirstName == Firstname && contact.LastName == Lastname)
                {
                    Content = $"{contact.FirstName},{contact.LastName},{contact.PhoneNumber},{contact.Email},{contact.Group},{contact.Work},{contact.Address}";
                    string ReplaceContent = "";

                    

                    var localFolder = ApplicationData.Current.LocalFolder;
                    var textFile = await localFolder.CreateFileAsync
                        (TEXT_FILE_NAME, CreationCollisionOption.OpenIfExists);

                    String strFile = await FileHelper.ReadTextFileAsync(TEXT_FILE_NAME);
                    String newContent = strFile.Replace(Content, ReplaceContent);

                    var newtextFile = await localFolder.CreateFileAsync
                        (TEXT_FILE_NAME, CreationCollisionOption.ReplaceExisting);


                    using (var textStream = await newtextFile.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        
                        var textWriter = new DataWriter(textStream);
                        textWriter.WriteString(newContent+ Environment.NewLine);
                        await textWriter.StoreAsync();
                    }
                }

                    
            }


        }

        public async static void EditContactAsync(List<string>EditContactInformation)
        {

            string FirstName = EditContactInformation[0];
            string LastName = EditContactInformation[1];
                
           

            List<string> ReplacementContent = new List<string>();
            string Content;
            string ReplaceContent = string.Empty;
            var contacts = new List<Contact>();
            var fileContent = await FileHelper.ReadTextFileAsync(TEXT_FILE_NAME);
            var lines = fileContent.Split(new char[] { '\r', '\n' });
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                var lineParts = line.Split(',');
                var contact = new Contact
                {
                    FirstName = lineParts[0],
                    LastName = lineParts[1],
                    PhoneNumber = lineParts[2],
                    Email = lineParts[3],
                    Group = lineParts[4],
                    Work = lineParts[5],
                    Address = lineParts[6]
                };

                if (contact.FirstName == FirstName && contact.LastName == LastName)
                {
                    Content = $"{contact.FirstName},{contact.LastName},{contact.PhoneNumber},{contact.Email},{contact.Group},{contact.Work},{contact.Address}";

                   for(int j = 0; j < EditContactInformation.Count; j++)
                    {
                        if (string.IsNullOrEmpty(EditContactInformation[j]))
                        {
                            ReplacementContent.Add(lineParts[j]);
                        }
                        else
                            ReplacementContent.Add(EditContactInformation[j]);
                                                    
                    }


                    ReplaceContent = $"{ReplacementContent[0]},{ReplacementContent[1]},{ReplacementContent[2]},{ReplacementContent[3]},{ReplacementContent[4]},{ReplacementContent[5]},{ReplacementContent[6]}";
                        

                    var localFolder = ApplicationData.Current.LocalFolder;
                    var textFile = await localFolder.CreateFileAsync
                        (TEXT_FILE_NAME, CreationCollisionOption.OpenIfExists);

                    String strFile = await FileHelper.ReadTextFileAsync(TEXT_FILE_NAME);
                    String newContent = strFile.Replace(Content, ReplaceContent);

                    var newtextFile = await localFolder.CreateFileAsync
                        (TEXT_FILE_NAME, CreationCollisionOption.ReplaceExisting);


                    using (var textStream = await newtextFile.OpenAsync(FileAccessMode.ReadWrite))
                    {

                        var textWriter = new DataWriter(textStream);
                        textWriter.WriteString(newContent + Environment.NewLine);
                        await textWriter.StoreAsync();
                    }
                }


            }




        }

    }
    

}
        
    

