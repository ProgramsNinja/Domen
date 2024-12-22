using Domen.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Vacancies
{
    public class VacancyWorkflow
    {
        private VacancyWorkflow(IReadOnlyCollection<VacancyWorkflowStep> steps)
        {
            Steps = steps ?? throw new ArgumentNullException(nameof(steps));
        }

        public IReadOnlyCollection<VacancyWorkflowStep> Steps { get; private set; }

        public static VacancyWorkflow Create(IReadOnlyCollection<VacancyWorkflowStep> steps)
            => new VacancyWorkflow(steps);

        public CаndidateWorkflow ToCandidate()
            => CаndidateWorkflow.Create(Steps.Select(step => step.ToCandidate()).ToArray());
    }
}
