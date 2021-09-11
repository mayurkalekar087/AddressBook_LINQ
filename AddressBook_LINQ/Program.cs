using System;
using System.Data;

namespace AddressBook_LINQ
{
   public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book Using LINQ !");
            Console.WriteLine("------------------------------------");

            AddressBookTable addressBookTable = new AddressBookTable();

            DataTable dataTable = addressBookTable.CreateAddressBookDataTable();

            addressBookTable.EditContact(dataTable);
            //addressBookTable.DeleteContact(dataTable);    
            addressBookTable.DisplayContacts(dataTable);
           

        }
    }
}
