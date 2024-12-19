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
        public string Name { get; private set; }
        public IReadOnlyCollection<VacancyWorkflowStep> Steps { get; private set; }

        public VacancyWorkflow(string name, IReadOnlyCollection<VacancyWorkflowStep> steps)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Steps = steps ?? throw new ArgumentNullException(nameof(steps));
        }
        public CondidateWorkflow Create()
        {
            return CondidateWorkflow.Create(this);
        }
    }
}
