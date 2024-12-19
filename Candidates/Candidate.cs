using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;

namespace Domen.Candidates
{
    public class Candidate
    {
        public Candidate(Guid id, Guid? referralId,
            CondidateWorkflow workflow, CandidateDocuments document)
        {
            Id = id;
            ReferralId = referralId;
            Workflow = workflow ?? throw new ArgumentNullException(nameof(workflow));
            Document = document ?? throw new ArgumentNullException(nameof(document));
        }

        public Guid Id { get; init; }
        public Guid VacancyId { get; private set; }
        public Guid? ReferralId { get; private set; }
        public CondidateWorkflow Workflow { get; private set; }
        public CandidateDocuments Document { get; private set; }

        public static Candidate Create(CandidateDocuments document,
            Guid? referralId, CondidateWorkflow workflow)
        {
            if (document == null) throw new ArgumentNullException(nameof(document));
            if (workflow == null) throw new ArgumentNullException(nameof(workflow));

            return new Candidate(Guid.NewGuid(), referralId, workflow, document);
        }
        public void Approve(Employee employee, string feedback)
        {
            ArgumentNullException.ThrowIfNull(nameof(employee));

            Workflow.Approve(employee, feedback);
        }

        public void Reject(Employee employee, string feedback)
        {
            Workflow.Reject(employee, feedback);
        }

        public void Restart()
        {
            Workflow.Restart();
        }
    }
}
