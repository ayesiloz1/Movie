using System;
namespace AttributePractice{
    public class PersonalInformationAttribute : Attribute {
        public int Level {get; set;}
        public PersonalInformationAttribute(int l){
            Level = l;
        }
    }
    public class EmploymentInformationAttribute : Attribute
    {
        public int Level { get; set; }
    
        public EmploymentInformationAttribute(int l)
        {
            Level = l;
        }
    }

    public class ContactInformationAttribute : Attribute
    {
        public int Level { get; set; }
    
        public ContactInformationAttribute(int l)
        {
            Level = l;
        }
    }
}