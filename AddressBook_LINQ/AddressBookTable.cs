using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;

namespace AddressBook_LINQ
{
    public class AddressBookTable
    {
        public DataTable CreateAddressBookDataTable()
        {
            //DataTable 
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("AddressBookName", typeof(string));
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("Zip", typeof(int));
            dataTable.Columns.Add("PhoneNumber", typeof(long));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("AddressBookType", typeof(string));

            dataTable.Rows.Add("MyBook-1" ,"Ismael ", "Whitlatch", "2319  Burton Avenue", "Memphis", "Tennessee", 38117, 9017658987, "sa5bxlla2e@temporary-mail.net","Friend");
            dataTable.Rows.Add("MyBook-2","Christopher ", "Forst", "2846  Tori Lane", "Salt Lake City", "Utah", 84113, 8015870002, "ctmgz50esj@temporary-mail.net","Family");
            dataTable.Rows.Add("MyBook-3", "David ", "Washington", "3379  Echo Lane", "Memphis", "New Mexico", 88352, 2699626511, "wkephpw9q2@temporary-mail.net","Friend");
            dataTable.Rows.Add("MyBook-4", "Byron ", "Daniels", "4385  West Street", "Grand Rapids", "Michigan", 49546, 6165758233, "6y4ug4knmib@temporary - mail.net","Profession");
            dataTable.Rows.Add("MyBook-5", "James ", "Juarez", "12564  Clay Street", "Indianapolis", "Indiana", 46214, 3174103617, "penlzpd00f@temporary - mail.net","Profession");
            return dataTable;
        }
        public void DisplayContacts(DataTable addresstable)
        {
            var contacts = addresstable.Rows.Cast<DataRow>();

            foreach (var contact in contacts)
            {
                Console.WriteLine("First Name : " + contact.Field<string>("FirstName") + " - " + "Last Name : " + contact.Field<string>("LastName") + " - " + "Address : " + contact.Field<string>("Address") + " - " + "City : " + contact.Field<string>("City") + " - " + "State : " + contact.Field<string>("State")
                    + " - " + "Zip : " + contact.Field<int>("Zip") + " - " + "Phone Number : " + contact.Field<long>("PhoneNumber") + " - " + "Email : " + contact.Field<string>("Email") + " ");
                Console.WriteLine();
            }
        }
        //UC 4
        public void EditContact(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("LastName") == "Daniels");
            int count = contacts.Count();
            if (count > 0)
            {
                foreach (var contact in contacts)
                {
                    contact.SetField("LastName", "Lopez");
                    contact.SetField("City", "Washington Dc");
                    contact.SetField("State", "America");
                }
                Console.WriteLine("Contact is Changed Successfully");
                
            }
            else
            {
                Console.WriteLine("Contact Does not Found!");
                DisplayContacts(table);
            }
        }
        //UC 5
        public void DeleteContact(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("LastName") == "Forst");
            int count = contacts.Count();
            if (count > 0)
            {
                foreach (var row in contacts.ToList())
                {
                    row.Delete();
                    Console.WriteLine("The Contact is deleted succesfully.");
                }
            }
            else
            {
                Console.WriteLine("Contact Does Not Found!");
                DisplayContacts(table);
            }
        }
        //UC 6
        public void RetrieveContactByCityOrState(DataTable table)
        {
            var contacts = table.AsEnumerable().Where(x => x.Field<string>("State") == "Utah");
            int count = contacts.Count();
            if (count > 0)
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine("First Name : " + contact.Field<string>("FirstName") + " | " + "Last Name : " + contact.Field<string>("LastName") + " | " + "Address : " + contact.Field<string>("Address") + " | " + "City : " + contact.Field<string>("City") + " | " + "State : " + contact.Field<string>("State")
                        + " | " + "Zip : " + contact.Field<int>("Zip") + " | " + "Phone Number : " + contact.Field<long>("PhoneNumber") + " | " + "Email : " + contact.Field<string>("Email") + " ");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Contact Does Not Found");
            }
        }
        //UC 7
        public void CheckSizeByCityOrState(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>().GroupBy(x => x["City"].Equals("Memphis")).Count();

            Console.WriteLine("Size : {0} ", contacts);
        }
        //UC 8
        public void SortContactsByLastName(DataTable table)
        {
            var contacts = table.Rows.Cast<DataRow>()
                           .OrderBy(x => x.Field<string>("LastName"));
            DisplayContacts(contacts.CopyToDataTable());
        }
        //UC 9
        public void CheckCountByType(DataTable table)
        {
            var Profession = table.Rows.Cast<DataRow>()
                                         .Where(x => x["AddressBookType"].Equals("Profession")).Count();
            Console.WriteLine("'Profession' : {0} ", Profession);
            var Family = table.Rows.Cast<DataRow>()
                             .Where(x => x["AddressBookType"].Equals("Family")).Count();
            Console.WriteLine("'Family' : {0} ", Family);
            var Friends = table.Rows.Cast<DataRow>()
                             .Where(x => x["AddressBookType"].Equals("Friends")).Count();
            Console.WriteLine("'Profession' : {0} ", Friends);
        }
    }
}

