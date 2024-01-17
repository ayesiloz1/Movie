using System;
using System.Collections.Generic;
using System.Reflection;
namespace AttributePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<Person> people = new List<Person>(){
                new Person{FirstName="Bob", LastName="Smith", SSN="123-45-6789", Position="Manager", Department="Sales", Email="bobsmith@gmail.com", Phone="535-555-1234"},
                new Person{FirstName="Billy", LastName="Jones", SSN="237-15-0021", Position="Professor", Department="Computer Science", Email="billyjones@gmail.com", Phone="255-555-2345"},
                new Person{FirstName="Will", LastName="Smith", SSN="133-55-6559", Position="Actor", Department="Action", Email="willsmith@yahoo.com,", Phone="551-555-3456"},
                new Person{FirstName="John", LastName="Doe", SSN="123-45-6789", Position="Manager", Department="Sales", Email="johndoe@outlook.com", Phone="555-555-4567"},
                new Person{FirstName="Jane", LastName="Doe", SSN="123-45-6789", Position="Manager", Department="Sales", Email="janedoe@outlook.com", Phone="555-555-5678"},
            };
            foreach (Person p in people)
            { 
                Console.WriteLine(p.ToStringRedacted());
                Console.WriteLine("--------------------");
            }
            

            // Console.WriteLine(t1);
/*
            ConstructorInfo[] c = t1.GetConstructors();

            foreach (ConstructorInfo ci in c)
            {
                Console.WriteLine(ci);
            } */
            /*
            PropertyInfo[] p = t1.GetProperties();
            foreach (PropertyInfo pi in p)
            {
                Console.WriteLine(pi);
            }*/
            /*MemberInfo[] m = t1.GetMembers();
            foreach (MemberInfo mi in m)
            {
                Console.WriteLine(mi);
                mi.GetCustomAttributes();
                object[] attributes = mi.GetCustomAttributes(true);
                foreach (object o in attributes)
                {
                    Console.WriteLine(o);
                    if (o is PersonalInformationAttribute)
                    {
                        Console.WriteLine("Personal - don't print");
                        PersonalInformationAttribute pia = (PersonalInformationAttribute)o;
                        if(pia.Level==3)
                            Console.WriteLine("Super Private");
                        else
                        
                            Console.WriteLine("Sort of Private");
                    }
                    else if (o is EmploymentInformationAttribute)
                    {
                        EmploymentInformationAttribute eia = (EmploymentInformationAttribute)o;
                     
                        if(eia.Level==3)
                            Console.WriteLine("Wow Super super Private");
                        else
                            Console.WriteLine("Not so private");
                        
                    }
                    else if (o is ContactInformationAttribute)
                    {
                        ContactInformationAttribute cia = (ContactInformationAttribute)o;
                        if(cia.Level==3)
                            Console.WriteLine("Incredibly Private");
                        else
                            Console.WriteLine("Maybe Not so private");
                }
                Console.WriteLine("-------------------- ");
            }*/
/* 
            int x =10;
            bool b =true;
            Console.WriteLine(x.GetType());
            Console.WriteLine(b.GetType());
*/

            
        }
    }
}

