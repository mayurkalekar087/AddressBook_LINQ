using System;
using System.Data;

namespace AddressBook_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book Using LINQ !");
            Console.WriteLine("------------------------------------");
            AddressBookTable addressBookTable = new AddressBookTable();

            DataTable data = addressBookTable.CreateAddressBookDataTable();
            addressBookTable.DisplayContacts(data);
        }
    }
}
