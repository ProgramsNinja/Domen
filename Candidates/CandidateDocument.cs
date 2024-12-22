using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Candidates
{
    public class CandidateDocument
    {
        public string Name { get; private set; }
        public string WorkExperience { get; private set; }

        public CandidateDocument(string name, string workExperience)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Поле имя не может быть пустым или пробелам", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(workExperience))
            {
                throw new ArgumentException("WorkExperience не может быть нулевым или пустым.", nameof(workExperience));
            }

            Name = name;
            WorkExperience = workExperience;
        }
    }
}
