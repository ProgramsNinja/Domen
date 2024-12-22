﻿using System;
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
            CаndidateWorkflow workflow, CandidateDocument document)
        {
            Id = id;
            ReferralId = referralId;
            Workflow = workflow ?? throw new ArgumentNullException(nameof(workflow));
            Document = document ?? throw new ArgumentNullException(nameof(document));
        }

        public Guid Id { get; private set; }
        public Guid VacancyId { get; private set; }
        public Guid? ReferralId { get; private set; }
        public CаndidateWorkflow Workflow { get; private set; }
        public CandidateDocument Document { get; private set; }
        public Status Status => Workflow.Status;

        public static Candidate Create(CandidateDocument document,
            Guid? referralId, CаndidateWorkflow workflow)
        {
            if (document == null) throw new ArgumentNullException(nameof(document));
            if (workflow == null) throw new ArgumentNullException(nameof(workflow));

            return new Candidate(Guid.NewGuid(), referralId, workflow, document);
        }
        public void Approve(Employee employee, string feedback)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Пользователь не может быть null.");
            }

            if (string.IsNullOrWhiteSpace(feedback))
            {
                throw new ArgumentException("Обратная связь не может быть пустой или состоять из пробелов.", nameof(feedback));
            }
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
