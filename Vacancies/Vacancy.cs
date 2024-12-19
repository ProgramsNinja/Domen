﻿using Domen.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Vacancies
{
    public class Vacancy
    {

        public Guid Id { get; private init; }
        public string Description { get; private set; }
        public VacancyWorkflow Workflow { get; private set; }

        public Vacancy(Guid id, string description, VacancyWorkflow workflow)
        {
            Id = id;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Workflow = workflow ?? throw new ArgumentNullException(nameof(workflow));
        }

        public Candidate Create(CandidateDocument document, Guid? referralId)
        {
            return Candidate.Create(document, referralId);
        }
    }
}
