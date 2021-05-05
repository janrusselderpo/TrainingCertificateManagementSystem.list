using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCMS.list
{
    class Program
    {

        public static void Main(string[] args)
        {

            menu m = new menu();
            m.login();
        }


        public class menu
        {
            List<Employees> listEmployees = new List<Employees>();
            List<Certificates> listCertificates = new List<Certificates>();
            List<forCertification> listForCertification = new List<forCertification>();
            List<CertifiedEmployees> listCertifiedEmployees = new List<CertifiedEmployees>();
            public class Employees
            {
                public int EmpID { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Position { get; set; }
                public string Email { get; set; }

            }
            public class Certificates
            {
                public int CertID { get; set; }
                public string Certificate { get; set; }
                public string Code { get; set; }
                public string DateCreated { get; set; }
                public int Validity { get; set; }
            }
            public class forCertification
            {
                public int ReqID { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Certificate { get; set; }
                public string DateRequested { get; set; }
                public DateTime RequestValidity { get; set; }

            }
            public class CertifiedEmployees
            {
                public int CeID { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Certificate { get; set; }
                public string DateIssued { get; set; }
                public DateTime ExpiryDate { get; set; }
            }

            public void MainMenu()
            {

                Console.WriteLine("Training Certification Management System");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("1 - Manage Employees " +
                                  "\n2 - Manage Certificates" +
                                  "\n0 - Log Out");

                Console.Write("Type a number:");
                string option = Console.ReadLine();
                Console.Clear();
                if (option == "1")
                {
                    EmployeeManager();
                }
                if (option == "2")
                {
                    CertificatesManager();
                }
                if (option == "0")
                {
                    login();
                }
                else
                {
                    Console.WriteLine("Invalid option please select again\n\n");
                    MainMenu();
                }
            }

            public void EmployeeManager()
            {
                Console.Clear();
                Console.WriteLine("MANAGE EMPLOYEES");
                Console.WriteLine("----------------");
                Console.WriteLine("1 - Add employee to database");
                Console.WriteLine("2 - Edit employee information in database");
                Console.WriteLine("3 - Remove an Employee from the database");
                Console.WriteLine("4 = View certificates by employee");
                Console.WriteLine("0 = Return to main menu");
                Console.WriteLine("Select an option:");
                string option = Console.ReadLine();
                Console.Clear();
                if (option == "1")
                {
                    add();
                }

                if (option == "2")
                {
                    edit();
                }
                if (option == "3")
                {
                    delete();
                }
                if (option == "4")
                {
                    //SHOW SQL TABLE OF EMPLOYEES CERTIFICATE
                    certified();
                }

                if (option == "0")
                {
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Invalid option please select again\n\n");
                    EmployeeManager();
                }
            }

            public void CertificatesManager()
            {
                Console.Clear();
                Console.WriteLine("CERTIFICATES MANAGER");
                Console.WriteLine("----------------");
                Console.WriteLine("1 - Manage Certificates");
                Console.WriteLine("2 - Manage Requests");
                Console.WriteLine("0 = Return to main menu");
                Console.WriteLine("Select an option: ");
                string option = Console.ReadLine();
                Console.Clear();

                if (option == "1")
                {
                    ManageCertificates();
                }
                if (option == "2")
                {
                    ManageRequests();
                }
                if (option == "0")
                {
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("Invalid option please select again\n\n");
                    CertificatesManager();
                }
            }

            public void add()
            {
                Console.Clear();

                Console.WriteLine("ID |           Name           |  Position  | Email");
                foreach (var Employees in listEmployees)
                {
                    Console.WriteLine(Employees.EmpID + " | " + Employees.FirstName + " " + Employees.LastName + " | " + Employees.Position + " | " + Employees.Email);
                    Console.WriteLine("------------------------------------------------------");
                }

                Console.WriteLine("\nAdd an employee to data base?");
                Console.WriteLine("1 - continue| 0 - return to employee menu\n");

                String option = Console.ReadLine();
                if (option == "1")
                {
                    Console.WriteLine("Enter employee ID(Number): ");
                    string id = Console.ReadLine();
                    int number;
                    if (int.TryParse(id, out number))
                    {
                        int intID = Convert.ToInt32(id);

                        Console.WriteLine("Enter First Name:");
                        String fname = Console.ReadLine().ToLower();
                        Console.WriteLine("Enter Last Name:");
                        String lname = Console.ReadLine().ToLower();
                        Console.WriteLine("Position:");
                        String pos = Console.ReadLine();
                        Console.WriteLine("Email:");
                        String email = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(fname) || string.IsNullOrWhiteSpace(lname) || string.IsNullOrWhiteSpace(pos) || string.IsNullOrWhiteSpace(email) )
                        {
                            Console.WriteLine("An entry was found empty(No entry should be left empty)");
                            Console.WriteLine("Enter any key to reset ADD");
                            String reset = Console.ReadLine();
                            add();
                        }
                        if (int.TryParse(fname +lname, out number))
                        {
                            Console.WriteLine("Input must be a letter");
                            Console.WriteLine("Enter any key to continue");
                            String reset = Console.ReadLine();
                            add();
                        }
                        else
                        {
                            if (listEmployees.Any(e => e.EmpID == intID))
                            {
                                Console.WriteLine("Employee Id already exists please use a new Id");
                                Console.WriteLine("\nEnterany key to reset ADD");
                                String reset = Console.ReadLine();
                                add();
                            }
                            if (listEmployees.Any(e => e.FirstName + e.LastName == fname + lname))
                            {
                                Console.WriteLine("\nEmployee name exists please enter a new name");
                                Console.WriteLine("Enter any key to reset ADD");
                                String reset = Console.ReadLine();
                                add();
                            }
                            else
                            {
                                listEmployees.Add(new Employees
                                {
                                    EmpID = intID,
                                    FirstName = fname,
                                    LastName = lname,
                                    Position = pos,
                                    Email = email

                                }); ;
                                Console.WriteLine("\nEmployee has been added");
                                Console.WriteLine("Enter any key to reset ADD");
                                String reset = Console.ReadLine();
                                add();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number");
                        Console.WriteLine("Enter any key to reset ADD");
                        String reset = Console.ReadLine();
                        add();
                    } 
                }
                if (option == "0")
                {
                    EmployeeManager();
                }
                else
                {
                    Console.WriteLine("Invalid option please select again\n\n");
                    String reset = Console.ReadLine();
                    add();
                }
            }
        
        public void edit()
            {
                Console.Clear();

                Console.WriteLine("ID |           Name           |  Position  | Email");
                foreach (var Employees in listEmployees)
                {
                    Console.WriteLine(Employees.EmpID + " | " + Employees.FirstName + " " + Employees.LastName + " | " + Employees.Position + " | " + Employees.Email);
                    Console.WriteLine("------------------------------------------------------");
                }

                if (!listEmployees?.Any() ?? false)
                {
                    Console.WriteLine("\nSorry there is no data to edit");
                    Console.WriteLine("Add data first before function");
                    String check = Console.ReadLine();
                    EmployeeManager();
                }
                else
                { 
                    Console.WriteLine("Edit employee information in lists");
                    Console.WriteLine("1 - continue | 0 - return to employee menu");
                    String option = Console.ReadLine();

                    if (option == "1")
                    {
                        Console.WriteLine("\nSelect an employee Id from the table above to edit:");
                        String optID = Console.ReadLine();
                        int id = Convert.ToInt32(optID);
                        int number;
                            if (int.TryParse(optID, out number))
                            {
                                Console.WriteLine("\nChoose an option to continue");
                                Console.WriteLine("1 - edit by column | 2 - Edit all columns | 0 - Cancel");
                                String select = Console.ReadLine();
                                if (select == "1")
                                {
                                    Console.WriteLine("Select column to edit");
                                    Console.WriteLine("1 - Name| 2 - Position | 3 - Email| 0 - Cancel");

                                    String choice = Console.ReadLine();
                                    if (choice == "1")
                                    {

                                        Console.WriteLine("Enter First Name");
                                        String fName = Console.ReadLine().ToLower();
                                        Console.WriteLine("Enter Last Name");
                                        String lName = Console.ReadLine().ToLower();
                                        if (int.TryParse(optID, out number))
                                        {
                                        Console.WriteLine("Input must be a letter");
                                        Console.WriteLine("Enter any key to continue");
                                        String reset = Console.ReadLine();
                                        edit();
                                        }
                                        else
                                        {
                                            if (string.IsNullOrWhiteSpace(fName) || string.IsNullOrWhiteSpace(fName))
                                            {
                                                Console.WriteLine("Please enter a valid input");
                                                String reset = Console.ReadLine();
                                                edit();
                                            }
                                            else
                                            {
                                                foreach (var Employees in listEmployees.Where(e => e.EmpID == id))
                                                {
                                                    String firstname = Employees.FirstName;

                                                    foreach (var ForCertification in listForCertification.Where(e => e.FirstName == firstname))
                                                    {
                                                        ForCertification.FirstName = fName;
                                                        ForCertification.LastName = lName;
                                                    }
                                                    foreach (var CeritifiedEmployees in listCertifiedEmployees.Where(e => e.FirstName == firstname))
                                                    {
                                                        CeritifiedEmployees.FirstName = fName;
                                                        CeritifiedEmployees.LastName = lName;
                                                    }
                                                    Employees.FirstName = fName;
                                                    Employees.LastName = lName;
                                                }
                                                Console.WriteLine("Data updated enter any key to continue");
                                                String update = Console.ReadLine();
                                                edit();
                                            }
                                        }
                                    }
                                    if (choice == "2")
                                    {
                                        Console.WriteLine("Enter Position");
                                        String pos = Console.ReadLine().ToLower();
                                        if (string.IsNullOrWhiteSpace(pos))
                                        {
                                            Console.WriteLine("Please enter a valid input");
                                            String reset = Console.ReadLine();
                                            edit();
                                        }
                                        else
                                        {
                                            foreach (var Employees in listEmployees.Where(e => e.EmpID == id))
                                            {
                                                Employees.Position = pos;
                                            }
                                            Console.WriteLine("Data updated enter any key to continue");
                                            String update = Console.ReadLine();
                                            edit();
                                        }
                                    }
                                    if (choice == "3")
                                    {
                                        Console.WriteLine("Enter Email");
                                        String email = Console.ReadLine();
                                        if (string.IsNullOrWhiteSpace(email))
                                        {
                                            Console.WriteLine("Please enter a valid input");
                                            String reset = Console.ReadLine();
                                            edit();
                                        }
                                        else
                                        {
                                            foreach (var Employees in listEmployees.Where(e => e.EmpID == id))
                                            {
                                                Employees.Email = email;
                                            }
                                            Console.WriteLine("Data updated enter any key to continue");
                                            String update = Console.ReadLine();
                                            edit();
                                        }
                                    }
                                    if (choice == "0")
                                    {
                                        edit();
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nPlease select an input given from above");
                                        Console.WriteLine("Restarting edit");
                                        edit();
                                    }
                                }
                                if (select == "2")
                                {
                                    Console.WriteLine("Enter First Name");
                                    String fName = Console.ReadLine().ToLower();
                                    Console.WriteLine("Enter Last Name");
                                    String lName = Console.ReadLine().ToLower();
                                    Console.WriteLine("Enter Position");
                                    String pos = Console.ReadLine().ToLower();
                                    Console.WriteLine("Enter Email");
                                    String email = Console.ReadLine().ToLower();

                                    if (string.IsNullOrWhiteSpace(fName) || string.IsNullOrWhiteSpace(lName) || string.IsNullOrWhiteSpace(pos) || string.IsNullOrWhiteSpace(email))
                                    {
                                        Console.WriteLine("An entry was found empty(No entry should be left empty)");
                                        Console.WriteLine("Enter any key to reset ADD");
                                        String reset = Console.ReadLine();
                                        edit();
                                    }
                                    if (int.TryParse(fName + lName, out number))
                                    {
                                        Console.WriteLine("Input must be a letter");
                                        Console.WriteLine("Enter any key to continue");
                                        String reset = Console.ReadLine();
                                        edit();
                                    }
                                    else
                                    {
                                        foreach (var Employees in listEmployees.Where(e => e.EmpID == id))
                                        {
                                            Employees.FirstName = fName;
                                            Employees.LastName = lName;
                                            Employees.Position = pos;
                                            Employees.Email = email;
                                        }
                                        Console.WriteLine("Data updated enter any key to continue");
                                        String update = Console.ReadLine();
                                        edit();
                                    }
                                }
                                if (select == "0")
                                {
                                 edit();
                                }    
                                else
                                {
                                Console.WriteLine("Please enter a valid input");
                                String reset = Console.ReadLine();
                                edit();
                            }
                            }
                            else
                            {
                                Console.WriteLine("Please select an existing ID");
                                String reset = Console.ReadLine();
                                edit();
                            }
                    }
                    if (option == "0")
                    {
                        EmployeeManager();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option please select again\n\n");
                        String reset = Console.ReadLine();
                        edit();
                    }
                }
            }

        public void delete()
        {
                
            Console.Clear();
            Console.WriteLine("ID |           Name           |  Position  | Email");
            foreach (var Employees in listEmployees)
            {
                Console.WriteLine(Employees.EmpID + " | " + Employees.FirstName+ " " + Employees.LastName+ " | " +Employees.Position + " | " + Employees.Email);
                Console.WriteLine("------------------------------------------------------");
            }

            if (!listEmployees?.Any() ?? false)
            {
                Console.WriteLine("\nSorry there is no data to edit");
                Console.WriteLine("Add data first before using this function");
                String check = Console.ReadLine();
                EmployeeManager();
            }
            else 
            { 
                Console.WriteLine("Delete employee information in database");
                Console.WriteLine("1 - continue | 0 - return to employee menu");
                String option = Console.ReadLine();

                if (option == "1")
                {
                    Console.WriteLine("Select an employee ID to delete");
                    String optID = Console.ReadLine();
                    int id = Convert.ToInt32(optID);

                    Console.WriteLine("Delete Employee? \n1 - Continue | 0 - Return");
                    String del = Console.ReadLine();

                    if (del == "1")
                    {
                            foreach (var Employees in listEmployees.Where(e => e.EmpID == id))
                            {
                                String firstname = Employees.FirstName;
                                listForCertification.RemoveAll(x => x.FirstName == firstname);
                                listCertifiedEmployees.RemoveAll(x => x.FirstName == firstname);
                            }
                            listEmployees.RemoveAll(x => x.EmpID == id);
                            Console.WriteLine("Data deleted enter any key to continue");
                            String update = Console.ReadLine();
                            delete();
                    }
                    if (del == "0")
                        {
                            delete();
                        }    
                    else
                    {
                        Console.WriteLine("Invalid option please again");
                            Console.WriteLine("Enter any key to continue");
                        delete();
                    }
                }
                if(option == "0")
                {
                        EmployeeManager();
                }
                else
                {
                        Console.WriteLine("Invalid option please select again\n\n");
                        String reset = Console.ReadLine();
                        delete();
                }
            }
        }

        public void ManageCertificates()
        {
            Console.Clear();
            Console.WriteLine("MANAGE CERTIFICATES");
            Console.WriteLine("----------------");
            Console.WriteLine("1 - Add certificate to database");
            Console.WriteLine("2 - Edit certificate in database");
            Console.WriteLine("3 - Remove a certifcate from the database");
            Console.WriteLine("0 = Return to main menu");
            Console.WriteLine("Select an option:");
            string option = Console.ReadLine();
            Console.Clear();
            if (option == "1")
            {
                addC();
            }
            if (option == "2")
            {
                editC();
            }
            if (option == "3")
            {
                deleteC();
            }
            if (option == "0")
            {
                CertificatesManager();
            }
            else
            {
                Console.WriteLine("Invalid option please select again\n\n");
                ManageCertificates();
            }
        }
        public void addC()
        {
            Console.Clear();

            Console.WriteLine("ID | Certificate Name |  Code  | Date Created(dd.MM.yyyy) | Validity ");
            foreach (var Certificates in listCertificates)
            {
                Console.WriteLine(Certificates.CertID + " | " + Certificates.Certificate+ " " + Certificates.Code+ " | " + Certificates.DateCreated + " | " + Certificates.Validity);
                Console.WriteLine("------------------------------------------------------");
            }

            Console.WriteLine("\nAdd a certificate to data base?");
            Console.WriteLine("1 - continue| 0 - return to employee menu");

            String Choice = Console.ReadLine();
            if (Choice == "1")
                {

                    Console.WriteLine("\nPlease enter values for the following");
                    Console.WriteLine("Certificate ID(Number): ");
                    string id = Console.ReadLine();
                    int number;
                    if (int.TryParse(id, out number))
                    {
                        int intID = Convert.ToInt32(id);

                        Console.WriteLine("Certificate Name:");
                        String certN = Console.ReadLine().ToLower();
                        Console.WriteLine("Certificate Code:");
                        String code = Console.ReadLine().ToUpper();
                        Console.WriteLine("Validity(by months):");
                        String val = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(certN) || string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(val))
                        {
                            Console.WriteLine("An entry was found empty(No entry should be left empty)");
                            Console.WriteLine("Enter any key to reset ADD");
                            String reset = Console.ReadLine();
                            addC();
                        }
                        else
                        {
                            if (int.TryParse(val, out number))
                            {
                                if (listCertificates.Any(e => e.CertID == intID))
                                {
                                    Console.WriteLine("Certificate Id already exists please use a new Id");
                                    Console.WriteLine("\nEnter any key to reset ADD");
                                    String reset = Console.ReadLine();
                                    addC();
                                }
                                if (listCertificates.Any(e => e.Certificate == certN))
                                {
                                    Console.WriteLine("\nCertificate already exists please enter a new one");
                                    Console.WriteLine("Enter any key to reset ADD");
                                    String reset = Console.ReadLine();
                                    addC();
                                }
                                if (listCertificates.Any(e => e.Code == code))
                                {
                                    Console.WriteLine("\nCode already exists please enter a new one");
                                    Console.WriteLine("Enter any key to reset ADD");
                                    String reset = Console.ReadLine();
                                    addC();
                                }
                                else
                                {
                                    String date = DateTime.Now.ToString("dd.MM.yyyy");
                                    int intVal = Convert.ToInt32(val);

                                    listCertificates.Add(new Certificates
                                    {
                                        CertID = intID,
                                        Certificate = certN,
                                        Code = code,
                                        DateCreated = date,
                                        Validity = intVal,
                                    });
                                    Console.WriteLine("Certificate has been added");
                                    Console.WriteLine("Enter any key to continue");
                                    String reset = Console.ReadLine();
                                    addC();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid option");
                                Console.WriteLine("Enter any key to continue");
                                String reset = Console.ReadLine();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid ID");
                        Console.WriteLine("Enter any key to restart function");
                        String reset = Console.ReadLine();
                        addC();
                    }
            }
            if(Choice == "0")
                {
                    CertificatesManager();
                }
            else
            {
                    Console.WriteLine("Please enter a valid option");
                    Console.WriteLine("Enter any key to continue");
                    String reset = Console.ReadLine();
                addC();
            }
        }
        public void editC()
        {

            Console.Clear();
            Console.WriteLine("ID | Certificate Name |  Code  | Date Created(dd.MM.yyyy) | Validity ");
            foreach (var Certificates in listCertificates)
            {
                Console.WriteLine(Certificates.CertID + " | " + Certificates.Certificate+ " " + Certificates.Code+ " | " + Certificates.DateCreated + " | " + Certificates.Validity);
                Console.WriteLine("------------------------------------------------------");
            }

                if (!listCertificates?.Any() ?? false)
                {
                    Console.WriteLine("\nSorry there is no data to edit");
                    Console.WriteLine("Add data first before using this function");
                    String check = Console.ReadLine();
                    ManageCertificates();
                }
                else
                {
                    Console.WriteLine("Edit Certificate details in lists");
                    Console.WriteLine("1 - continue | 0 - return to certificates menu");
                    String option = Console.ReadLine();

                    if (option == "1")
                    {

                        Console.WriteLine("\nSelect an certificate Id from the table above to edit:");
                        String optID = Console.ReadLine();
                        int id = Convert.ToInt32(optID);
                        int number;
                        if (int.TryParse(optID, out number))
                        {
                            Console.WriteLine("\nChoose an option to continue");
                            Console.WriteLine("1 - edit by column | 2 - Edit all columns | 0 - Cancel");
                            String select = Console.ReadLine();
                            if (select == "1")
                            {
                                Console.WriteLine("Select column to edit");
                                Console.WriteLine("1 - Certificate Name| 2 - Code | 3 - Validity| 0 - Cancel");

                                String choice = Console.ReadLine();
                                if (choice == "1")
                                {
                                    Console.WriteLine("Enter Certificate Name");
                                    String certN = Console.ReadLine().ToLower();
                                    if (string.IsNullOrWhiteSpace(certN))
                                    {
                                        Console.WriteLine("Please enter a valid input");
                                        String reset = Console.ReadLine();
                                        editC();
                                    }
                                    else
                                    {
                                        foreach (var Certificates in listCertificates.Where(e => e.CertID == id))
                                        {
                                            Certificates.Certificate = certN;                           
                                        }
                                        Console.WriteLine("Data updated enter any key to continue");
                                        String update = Console.ReadLine();
                                        editC();   
                                    }
                                }
                                if (choice == "2")
                                {
                                    Console.WriteLine("Enter Code");
                                    String code = Console.ReadLine().ToLower();
                                    if (string.IsNullOrWhiteSpace(code))
                                    {
                                        Console.WriteLine("Please enter a valid input");
                                        String reset = Console.ReadLine();
                                        editC();
                                    }
                                    else
                                    {
                                        foreach (var Certificates in listCertificates.Where(e => e.CertID == id))
                                        {
                                            String certt = Certificates.Code;

                                            foreach (var ForCertification in listForCertification.Where(e => e.Certificate == certt))
                                            {
                                                ForCertification.Certificate = code;
                                            }
                                            foreach (var CertifiedEmployees in listCertifiedEmployees.Where(e => e.Certificate == certt))
                                            {
                                                CertifiedEmployees.Certificate = code;
                                            }
                                            Certificates.Code = code;
                                        }
                                        Console.WriteLine("Data updated enter any key to continue");
                                        String update = Console.ReadLine();
                                        editC();
                                    }
                                }
                                if (choice == "3")
                                {
                                    Console.WriteLine("Enter Validity(By Months)");
                                    String val = Console.ReadLine();
                                    if (int.TryParse(optID, out number))
                                    {
                                        int intVal = Convert.ToInt32(val);
                                        if (string.IsNullOrWhiteSpace(val))
                                        {
                                            Console.WriteLine("Please enter a valid input");
                                            String reset = Console.ReadLine();
                                            editC();
                                        }
                                        else
                                        {
                                            foreach (var Certificates in listCertificates.Where(e => e.CertID == id))
                                            {
                                                string code = Certificates.Code;
                                                
                                                foreach (var CertifiedEmployees in listCertifiedEmployees.Where(e => e.Certificate == code))
                                                {
                                                    String dateissued = CertifiedEmployees.DateIssued;
                                                    long dd = long.Parse(dateissued);
                                                    var date = new DateTime(dd);
                                                    var expiry = date.AddMonths(Convert.ToInt32(val));
                                                    CertifiedEmployees.ExpiryDate = expiry;
                                                }
                                                Certificates.Validity = intVal;

                                            }
                                            Console.WriteLine("Data updated enter any key to continue");
                                            String update = Console.ReadLine();
                                            editC();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a number");
                                        String reset = Console.ReadLine();
                                        editC();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nPlease select an input given from above");
                                    Console.WriteLine("Restarting edit");
                                    editC();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Enter values for the following:");
                                Console.WriteLine("Certificate Name:");
                                String certN = Console.ReadLine().ToLower();
                                Console.WriteLine("Code");
                                String code = Console.ReadLine().ToLower();
                                Console.WriteLine("Validity");
                                String val = Console.ReadLine().ToLower();
                                if (int.TryParse(optID, out number))
                                {
                                    int intVal = Convert.ToInt32(val);
                                    foreach (var Certificates in listCertificates.Where(e => e.CertID == id))
                                    {
                                        Certificates.Certificate = certN;
                                        Certificates.Code = code;
                                        Certificates.Validity = intVal;
                                    }
                                    Console.WriteLine("Data updated enter any key to continue");
                                    String update = Console.ReadLine();
                                    editC();
                                }
                                else
                                {
                                    Console.WriteLine("\nPlease select an input given from above");
                                    Console.WriteLine("Restarting edit");
                                    editC();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                        }
                    }
                    if(option == "0")
                    {
                        ManageCertificates();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        Console.WriteLine("Enter any key to continue");
                        String update = Console.ReadLine();
                        editC();
                    }
                }
            }
        public void deleteC()
        {
                Console.Clear();
                Console.Clear();
                Console.WriteLine("ID | Certificate Name |  Code  | Date Created(dd.MM.yyyy) | Validity ");
                foreach (var Certificates in listCertificates)
                {
                    Console.WriteLine(Certificates.CertID + " | " + Certificates.Certificate + " " + Certificates.Code + " | " + Certificates.DateCreated + " | " + Certificates.Validity);
                    Console.WriteLine("------------------------------------------------------");
                }

                if (!listCertificates?.Any() ?? false)
                {
                    Console.WriteLine("\nSorry there is no data to edit");
                    Console.WriteLine("Add data first before using this function");
                    String check = Console.ReadLine();
                    ManageCertificates();
                }
                else
                {
                    Console.WriteLine("Delete Certificate information in database");
                    Console.WriteLine("1 - continue | 0 - return to manage certificate menu");
                    String option = Console.ReadLine();

                    if (option == "1")
                    {
                        Console.WriteLine("Select a certfiicate ID to delete");
                        String optID = Console.ReadLine();
                        int number;

                        if (int.TryParse(optID, out number))
                        {
                            int id = Convert.ToInt32(optID);
                            if (listCertificates.Any(e => e.CertID != id))
                            {
                                Console.WriteLine("Certificate Id does not exist please enter a existing Id");
                                Console.WriteLine("Enter any key to continue");
                                String reset = Console.ReadLine();
                                deleteC();
                            }

                            Console.WriteLine("Delete certificate? \n1 - Continue | 0 - Cancel");
                            String del = Console.ReadLine();

                            if (del == "1")
                            {
                                foreach (var Certificates in listCertificates.Where(e => e.CertID == id))
                                {
                                    String certificate = Certificates.Code;
                                    listForCertification.RemoveAll(x => x.Certificate == certificate);
                                    listCertifiedEmployees.RemoveAll(x => x.Certificate == certificate);
                                }
                                listCertificates.RemoveAll(x => x.CertID == id);

                                Console.WriteLine("Data deleted enter any key to continue");
                                String update = Console.ReadLine();
                                deleteC();
                            }
                            if (del == "0")
                            { 
                                 deleteC();
                            }
                            else
                            {
                                Console.WriteLine("Invalid input please try again\n");
                                deleteC();
                            }
                        }
                    }
                    if (option == "0")
                    {
                       ManageCertificates();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option please select again\n\n");
                        String reset = Console.ReadLine();
                        deleteC();
                    }
                }
            }

        public void ManageRequests()
        {
            Console.Clear();
            Console.WriteLine("MANAGE REQUESTS");
            Console.WriteLine("----------------");
            Console.WriteLine("1 - Accept Requests");
            Console.WriteLine("2 - Delete Requests");
            Console.WriteLine("0 = Return to Certificates Manager");
            Console.WriteLine("Select an option:");
            string option = Console.ReadLine();
            Console.Clear();
            if (option == "1")
            {
                aReq();
            }
            if (option == "2")
            {
                dReq();
            }
            if (option == "0")
            {
                CertificatesManager();
            }
            else
            {
                ManageRequests();
            }
        }

        public void aReq()
        {
                Console.Clear();
                Console.WriteLine("ID |           Name           |  Certificate  | Date Issued | Expiry Date");
                foreach (var forCertification in listForCertification)
                {
                    Console.WriteLine(forCertification.ReqID + " | " + forCertification.FirstName + " "+ forCertification.LastName+ " | " + forCertification.Certificate + " | " + forCertification.DateRequested+ " | " + forCertification.RequestValidity);
                }
                if (!listForCertification?.Any() ?? false)
                {
                    Console.WriteLine("\nSorry there is no requests to accept");
                    Console.WriteLine("Add data first before using this function");
                    String check = Console.ReadLine();
                    ManageRequests();
                }
                else
                {
                    Console.WriteLine("Accept Requests?");
                    Console.WriteLine("1 - yes | 0 - return to Manage Requests");
                    String Option = Console.ReadLine();

                    if (Option == "1")
                    {
                        Console.WriteLine("Select a request Id to accept:");
                        String id = Console.ReadLine();
                        Console.WriteLine("Accept selected requests?");
                        Console.WriteLine("1 - Yes | 0 - No, select again?");
                        String confirmation = Console.ReadLine();
                        if (confirmation == "1")
                        {
                            int number;
                            if (int.TryParse(id, out number))
                            {
                                int intID = Convert.ToInt32(id);
                                if (listForCertification.Any(e => e.ReqID != intID))
                                {
                                    Console.WriteLine("Request ID doesn't exist please select a existing Request ID");
                                    Console.WriteLine("Enter any key to continue");
                                    String reset = Console.ReadLine();
                                    aReq();
                                }
                                else
                                {
                                    foreach (var forCertification in listForCertification.Where(e => e.ReqID == intID))
                                    {
                                        String firstname = forCertification.FirstName;
                                        String lastname = forCertification.LastName;
                                        String certificate = forCertification.Certificate;
                                        foreach (var Certificates in listCertificates.Where(e => e.Certificate == certificate))
                                        {
                                            var code = Certificates.Code;
                                            var date = DateTime.Now;
                                            var expiry = date.AddMonths(Convert.ToInt32(code));
                                            var datenow = date.ToString("dd.MM.yyyy");

                                            var highestID = listForCertification.Any() ? listForCertification.Select(x => x.ReqID).Max() : 1;

                                            listCertifiedEmployees.Add(new CertifiedEmployees
                                            {
                                                CeID = highestID,
                                                FirstName = firstname,
                                                LastName = lastname,
                                                Certificate = certificate,
                                                DateIssued = datenow,
                                                ExpiryDate = expiry
                                            });
                                            listForCertification.RemoveAll(e => e.ReqID == intID);
                                            Console.WriteLine("Requests has been accepted");
                                            Console.WriteLine("Press any key to continue");
                                            String option = Console.ReadLine();
                                            aReq();
                                        }
                                    }
                                }
                            }
                        }
                        if (confirmation == "0")
                        {

                            aReq();
                        }
                        else
                        {
                            Console.WriteLine("Please select a valid option");
                            Console.WriteLine("Resetting function, press any key to continue");
                            String option = Console.ReadLine();
                            aReq();
                        }
                    }
                    if (Option == "0")
                    {
                        ManageRequests();
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid option");
                        String reset = Console.ReadLine();
                        aReq();
                    }
                }
        }
            public void dReq()
            {
                Console.Clear();
                // Show employee table

                Console.WriteLine("ID |           Name           |  Certificate  | Date Issued | Expiry Date");
                foreach (var forCertification in listForCertification)
                {
                   Console.WriteLine(forCertification.ReqID + " | " + forCertification.FirstName + " " + forCertification.LastName + " | " + forCertification.Certificate + " | " + forCertification.DateRequested + " | " + forCertification.RequestValidity);
                }
                if (!listForCertification?.Any() ?? false)
                {
                    Console.WriteLine("\nSorry there is no requests to delete");
                    Console.WriteLine("Add data first before using this function");
                    String check = Console.ReadLine();
                    ManageRequests();
                }
                else
                {
                    Console.WriteLine("Delete certificate in database");
                    Console.WriteLine("1 - continue | 0 - return to Manage Certificates menu");
                    String option = Console.ReadLine();

                    if (option == "1")
                    {
                        Console.WriteLine("Select a Requests ID to delete");
                        String id = Console.ReadLine();
                        Console.WriteLine("Delete Requests? \n1 - Continue | 0 - Cancel");
                        String del = Console.ReadLine();

                        int number;
                        if (int.TryParse(id, out number))
                        {
                            int intID = Convert.ToInt32(id);
                            if (del == "1")
                            {
                                listForCertification.RemoveAll(e => e.ReqID == intID);
                                Console.WriteLine("Requests has been deleted");
                                Console.WriteLine("Enter any key to continue");
                                String restart = Console.ReadLine();
                                dReq();
                            }
                            if (del == "0")
                            {
                                dReq();
                            }
                            else
                            {
                                Console.WriteLine("Invalid input");
                                Console.WriteLine("Enter any key to continue");
                                String restart = Console.ReadLine();
                                dReq();
                            }
                        }
                    }
                    else
                    {
                        ManageRequests();
                    }
                }
            }
            public void login()
        {
          
            Console.Clear();
            Console.WriteLine("LOGIN");
            Console.WriteLine("Username");
            String user = Console.ReadLine().ToString().ToLower();
            Console.WriteLine("Password");
            String pass = Console.ReadLine().ToString().ToLower(); ;
            Console.Clear();
            if (user == "admin" && pass == "admin")
            {
                MainMenu();
            }
            if (user == "user" && pass == "")
            {
                userM();
            }
            if (String.IsNullOrWhiteSpace(user) || String.IsNullOrWhiteSpace(pass))
            {
                login();
            }
            if (user.Length <= 0 || pass.Length <= 0)
            {
                login();
            }
            else
            {
                Console.WriteLine("Incorrect username or password please try again");
                Console.WriteLine("Enter any key to continue");
                    String reset = Console.ReadLine();
                login();
            }
        }

        public void userM()
        {
            Console.Clear();
            Console.WriteLine("EMPLOYEE MENU");
            Console.WriteLine("--------------");
            Console.WriteLine("1 - File a certificate request");
            Console.WriteLine("0 - Log out");
            String req = Console.ReadLine();
            if (req == "1")
            {
                FileRequests();
            }
            else
            {
                login();
            }

        }

        public void FileRequests()
         {
                Console.Clear();
                if (!listEmployees?.Any() ?? false)
                {
                    Console.WriteLine("\nSorry there is no employee in the lists");
                    Console.WriteLine("There must be an employee in the lists to file a request");
                    String check = Console.ReadLine();
                    FileRequests();
                }
                if (!listCertificates?.Any() ?? false)
                {
                    Console.WriteLine("\nSorry there is no certificates  in the lists");
                    Console.WriteLine("There must be an certificates  in the lists to file a request");
                    String check = Console.ReadLine();
                    FileRequests();
                }
                else
                {
                    Console.WriteLine("File a Requests?");
                    Console.WriteLine("1 - Yes | 0 - no(logout)");
                    String option = Console.ReadLine();

                    if (option == "1")
                    {
                        Console.WriteLine("ID |           Name           |  Position  | Email\n");
                        foreach (var Employees in listEmployees)
                        {
                            Console.WriteLine(Employees.EmpID + " | " + Employees.FirstName + " " + Employees.LastName + " | " + Employees.Position + " | " + Employees.Email);
                            Console.WriteLine("------------------------------------------------------");
                        }
                        Console.WriteLine("\nSelect Employee ID");
                        String optID = Console.ReadLine();

                        Console.WriteLine("ID | Certificate Name |  Code  | Date Created(dd.MM.yyyy) | Validity ");
                        foreach (var Certificates in listCertificates)
                        {
                            Console.WriteLine(Certificates.CertID + " | " + Certificates.Certificate + " " + Certificates.Code + " | " + Certificates.DateCreated + " | " + Certificates.Validity);
                            Console.WriteLine("------------------------------------------------------");
                        }

                        Console.WriteLine("\nSelect certificate ID\n");
                        String optID2 = Console.ReadLine();

                        int number;
                        if (int.TryParse(optID + optID2, out number))
                        {
                            int id = Convert.ToInt32(optID);
                            int id2 = Convert.ToInt32(optID2);
                            foreach (var Employees in listEmployees.Where(e => e.EmpID == id))
                            {
                                String firstname = Employees.FirstName;
                                String lastname = Employees.LastName;
                                foreach (var Certificates in listCertificates.Where(e => e.CertID == id2))
                                {
                                    int val = Certificates.Validity;
                                    string code = Certificates.Code;
                                    var date = DateTime.Now;
                                    var expiry = date.AddMonths(Convert.ToInt32(6));
                                    string datenow = date.ToString("dd.MM.YY");

                                    var highestID = listForCertification.Any() ? listForCertification.Select(x => x.ReqID).Max() : 1;
                                    listForCertification.Add(new forCertification
                                    {
                                        ReqID = highestID,
                                        FirstName = firstname,
                                        LastName = lastname,
                                        Certificate = code,
                                        DateRequested = datenow,
                                        RequestValidity = expiry
                                    });
                                    Console.WriteLine("Request has been filed");
                                    Console.WriteLine("Enter any key to continue");
                                    String reset = Console.ReadLine();
                                    FileRequests();
                                }
                            }

                        }
                    }
                    if (option == "0")
                    {
                        login();
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid option");
                        Console.WriteLine("Enter any key to continue");
                        String reset = Console.ReadLine();
                    }
                }

        }

        public void certified()
        {
            Console.Clear();
            Console.WriteLine("ID |           Name           |  Certificate | Date issued | Expiry Date");
            foreach (var CertifiedEmployees in listCertifiedEmployees)
            {
               Console.WriteLine(CertifiedEmployees.CeID + " | " + CertifiedEmployees.FirstName + " " + CertifiedEmployees.LastName + " | " + CertifiedEmployees.DateIssued + " | " + CertifiedEmployees.ExpiryDate);
               Console.WriteLine("------------------------------------------------------");
            }
                if (!listCertifiedEmployees?.Any() ?? false)
                {
                    Console.WriteLine("\nSorry there is no data to edit");
                    Console.WriteLine("Add data first before using this function");
                    String check = Console.ReadLine();
                    EmployeeManager();
                }
                else
                {

                    Console.WriteLine("1 - Delete a row | 0 - return to Manage Employees");
                    String select = Console.ReadLine();

                    if (select == "1")
                    {
                        Console.WriteLine("Delete a certified employee in the database?");
                        Console.WriteLine("1 - continue | 0 - cancel");
                        String option = Console.ReadLine();

                        if (option == "1")
                        {
                            Console.WriteLine("Select an employee ID to delete");
                            String optID = Console.ReadLine();
                            Console.WriteLine("1 - Continue | 0 - Cancel");
                            String del = Console.ReadLine();

                            int number;
                            if (int.TryParse(optID, out number))
                            {
                                int intID = Convert.ToInt32(optID);
                                if (del == "1")
                                {
                                    listCertifiedEmployees.RemoveAll(e => e.CeID == intID);
                                    Console.WriteLine("Requests has been accepted");
                                    Console.WriteLine("Enter any key to continue");
                                    String restart = Console.ReadLine();
                                    certified();
                                }
                                else
                                {
                                    certified();
                                }
                            }
                        }
                        if (option == "0")
                        {
                            certified();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                            Console.WriteLine("Enter any key to continue");
                            String restart = Console.ReadLine();
                            certified();
                        }
                    }
                    if (select == "0")
                    {
                        EmployeeManager();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        Console.WriteLine("Enter any key to continue");
                        String restart = Console.ReadLine();
                        certified();
                    }
                }
        }
 
        }
    }
}
