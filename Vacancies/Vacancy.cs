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
            ArgumentNullException.ThrowIfNull(description, nameof(description));
            ArgumentNullException.ThrowIfNull(workflow, nameof(workflow));

            Id = id;
            CompanyId = companyId;
            Description = description;
            Workflow = workflow;
        }

        public Guid Id { get; private set; }
        public Guid CompanyId { get; private init; }
        public string Description { get; private init; }
        public VacancyWorkflow Workflow { get; private init; }

        public static Vacancy Create(Guid companyId, string description, VacancyWorkflow workflow)
            => new(Guid.NewGuid(), companyId, description, workflow);

        public Candidate CreateCandidate(CandidateDocument candidateDocument, Guid? referralId)
            => Candidate.Create(Id, referralId, candidateDocument, Workflow.ToCandidate());
    }
}
