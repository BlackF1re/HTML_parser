using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML_parser
{
    public class Card
    {
        public int Id;
        /*
        Всего строк: 6501
        Строк на одну карточку: 13
        Карточек: 500
        */
        public string UniversityName;
        public string ProgramName;
        public string ProgramName2;//what?
        public string Level;
        public string ProgramCode;
        public string StudyForm;
        public string Duration;
        public string Qualification; //same as Level
        public string StudyLang;
        public string Curator;
        public string PhoneNumber;
        public string Email;
        public string Cost;

        public Card(int id, string universityName, string programName, string programName2, string level, string programCode, string studyForm, string duration, string qualification, string studyLang, string curator, string phoneNumber, string email, string cost)
        {
            Id = id;
            UniversityName = universityName;
            ProgramName = programName;
            ProgramName2 = programName2;
            Level = level;
            ProgramCode = programCode;
            StudyForm = studyForm;
            Duration = duration;
            Qualification = qualification;
            StudyLang = studyLang;
            Curator = curator;
            PhoneNumber = phoneNumber;
            Email = email;
            Cost = cost;
        }
    }
}
