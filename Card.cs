using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML_parser
{
    public class Card
    {
        /*
        Всего строк: 6001
        Строк на одну карточку: 12
        Карточек: 500
        */

        private int Id;
        private string UniversityName;
        private string ProgramName;
        private string Level;
        private string ProgramCode;
        private string StudyForm;
        private string Duration;
        private string StudyLang;
        private string Curator;
        private string PhoneNumber;
        private string Email;
        private string Cost;

        public Card(int id, string universityName, string programName, string level, string studyForm, string programCode, string duration, string studyLang, string curator, string phoneNumber, string email, string cost)
        {
            this.Id = id;
            this.UniversityName = universityName;
            this.ProgramName = programName;
            this.Level = level;
            this.StudyForm = studyForm;
            this.ProgramCode = programCode;
            this.Duration = duration;
            this.StudyLang = studyLang;
            this.Curator = curator;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Cost = cost;

    }
    }
}
