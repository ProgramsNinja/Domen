using Domen.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Vacancies
{
    public class Vacancy
    {

        private Vacancy(Guid id, Guid companyId, string description, VacancyWorkflow workflow)
        {
            if (description == null) 
                throw new ArgumentNullException(nameof(description));
            if (workflow == null) 
                throw new ArgumentNullException(nameof(workflow));

            Id = id;
            CompanyId = companyId;
            Description = description;
            Workflow = workflow;
        }

        public Guid Id { get; private set; }
        public Guid CompanyId { get; private set; }
        public string Description { get; private set; }
        public VacancyWorkflow Workflow { get; private set; }

        public static Vacancy Create(Guid companyId, string description, VacancyWorkflow workflow)
            => new(Guid.NewGuid(), companyId, description, workflow);

        public Candidate CreateCandidate(CandidateDocument candidateDocument, Guid? referralId)
            => Candidate.Create( candidateDocument, referralId, Workflow.ToCandidate());
    }
}
