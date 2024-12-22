using Domen.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Vacancies
{
    public class VacancyWorkflowStep
    {
        private VacancyWorkflowStep(Guid? userId, Guid? roleId, string description, int stepNumber)
        {
            if (userId is null && roleId is null)
            {
                throw new ArgumentException("Должен быть указан либо UserId, либо RoleId.");
            }

            if (description == null)
            {
                throw new ArgumentException("Описание не должно быть пустым.");
            }
           


            UserId = userId;
            RoleId = roleId;
            Description = description;
            StepNumber = stepNumber;
        }

        public Guid? UserId { get; private set; }
        public Guid? RoleId { get; private set; }
        public string Description { get; private set; }
        public int StepNumber { get; private set; }


        public static VacancyWorkflowStep Create(Guid? userId, Guid? roleId, string description, int stepNumber)
        {
            if (stepNumber <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(stepNumber));
            }

            return new VacancyWorkflowStep(userId, roleId, description, stepNumber);
        }

        public CandidateWorkflowStep ToCandidate()
            =>CandidateWorkflowStep.Create(UserId, RoleId, StepNumber);
    }
}
