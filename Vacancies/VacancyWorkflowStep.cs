﻿using Domen.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Vacancies
{
    public class VacancyWorkflowStep
    {
        public Guid UserId { get; private set; }
        public Guid RoleId { get; private set; }
        public string Description { get; private set; }
        public int StepNumber { get; private set; }

        public CandidateWorkflowStep Create()
        {
            return CandidateWorkflowStep.Create(this);
        }
    }
}
