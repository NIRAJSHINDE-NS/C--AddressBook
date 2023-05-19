namespace AddressBookInCSharp
{
    using System;
    using System.Collections.Generic;

    class AddressBook
    {
        static List<Contact> contacts = new List<Contact>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Address Book");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Search Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Display All Contacts");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        SearchContact();
                        break;
                    case 3:
                        DeleteContact();
                        break;
                    case 4:
                        DisplayContacts();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddContact()
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter phone number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter city: ");
            string city = Console.ReadLine();

            Console.Write("Enter address: ");
            string address = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Contact contact = new Contact(firstName, lastName, phoneNumber, city, address, email);
            contacts.Add(contact);

            Console.WriteLine("Contact added successfully!");
        }

        static void SearchContact()
        {
            Console.Write("Enter first name to search: ");
            string searchFirstName = Console.ReadLine();

            Console.Write("Enter last name to search: ");
            string searchLastName = Console.ReadLine();

            List<Contact> foundContacts = contacts.FindAll(contact =>
                contact.FirstName.Equals(searchFirstName, StringComparison.OrdinalIgnoreCase) &&
                contact.LastName.Equals(searchLastName, StringComparison.OrdinalIgnoreCase));

            if (foundContacts.Count > 0)
            {
                Console.WriteLine("Found " + foundContacts.Count + " contact(s):");
                foreach (var contact in foundContacts)
                {
                    Console.WriteLine("First Name: " + contact.FirstName);
                    Console.WriteLine("Last Name: " + contact.LastName);
                    Console.WriteLine("Phone Number: " + contact.PhoneNumber);
                    Console.WriteLine("City: " + contact.City);
                    Console.WriteLine("Address: " + contact.Address);
                    Console.WriteLine("Email: " + contact.Email);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        static void DeleteContact()
        {
            Console.Write("Enter first name of the contact to delete: ");
            string deleteFirstName = Console.ReadLine();

            Console.Write("Enter last name of the contact to delete: ");
            string deleteLastName = Console.ReadLine();

            bool contactDeleted = contacts.RemoveAll(contact =>
                contact.FirstName.Equals(deleteFirstName, StringComparison.OrdinalIgnoreCase) &&
                contact.LastName.Equals(deleteLastName, StringComparison.OrdinalIgnoreCase)) > 0;

            if (contactDeleted)
            {
                Console.WriteLine("Contact deleted successfully!");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        static void DisplayContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
            }
            else
            {
                Console.WriteLine("Contacts:");
                foreach (var contact in contacts)
                {
                    Console.WriteLine("First Name: " + contact.FirstName);
                    Console.WriteLine("Last Name: " + contact.LastName);
                    Console.WriteLine("Phone Number: " + contact.PhoneNumber);
                    Console.WriteLine("City: " + contact.City);
                    Console.WriteLine("Address: " + contact.Address);
                    Console.WriteLine("Email: " + contact.Email);
                    Console.WriteLine();
                }
            }
        }
    }

    class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public Contact(string firstName, string lastName, string phoneNumber, string city, string address, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            City = city;
            Address = address;
            Email = email;
        }
    }

}