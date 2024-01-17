using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;
using System.Reflection;
namespace AttributePractice{
    public class Person{
        [Required]
        public string FirstName {get; set;}
        [PersonalInformation(1)]
        public string LastName {get; set;}
        [PersonalInformation(3)]
        public string SSN {get; set;}
         public string Position { get; set; }
        public string Department { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public Person(){
            FirstName = "";
            LastName = "";
        }
        [Obsolete]
        public Person(string fname, string lname){
            FirstName = fname;
            LastName = lname;
        }
        public override string ToString(){
            return $"{FirstName} {LastName}";
        }
        [PersonalInformation(3)]

        [EmploymentInformation(3)]
        public string Job { get; set; }

        [ContactInformation(2)]
        public string Contact { get; set; }

       public string ToStringRedacted()
        {
            var result = new StringBuilder();
            var properties = GetType().GetProperties();

            foreach (var property in properties)
            {
                var attribute = (PersonalInformationAttribute)property.GetCustomAttribute(typeof(PersonalInformationAttribute));

                if (attribute == null || attribute.Level <= 1)
                {
                    result.AppendLine($"{property.Name}: {property.GetValue(this)}");
                }
                else
                {
                    result.AppendLine($"{property.Name}: *****");
                }
            }

            return result.ToString();
        }
        
    }
}