using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Candidates
{
    public class CandidateDocuments
    {
        public string Name { get; private set; }
        public string WorkExperience { get; private set; }

        public CandidateDocuments(string name, string workExperience)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(workExperience))
            {
                throw new ArgumentException("WorkExperience cannot be null or empty.", nameof(workExperience));
            }

            Name = name;
            WorkExperience = workExperience;
        }
    }
}
