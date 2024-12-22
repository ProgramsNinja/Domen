﻿using Domen.Vacancies;
using Domen.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Candidates
{
    public class CаndidateWorkflow
    {
        private CаndidateWorkflow(IReadOnlyCollection<CandidateWorkflowStep> steps)
        {
            if (steps == null || !steps.Any())
            {
                throw new ArgumentException("Шаги рабочего процесса не могут быть пустыми.", nameof(steps));
            }

            Steps = steps;
        }

        public IReadOnlyCollection<CandidateWorkflowStep> Steps { get;  set; }
        internal Status Status => GetStatus();

        public static CаndidateWorkflow Create(IReadOnlyCollection<CandidateWorkflowStep> steps)
        {
            if (steps == null || !steps.Any())
            {
                throw new ArgumentException("Для создания рабочего процесса должны быть указаны шаги.", nameof(steps));
            }

            return new CаndidateWorkflow (steps);
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
            GetCurrentInProcessingStep().Approve(employee, feedback);
        }

        public void Reject(Employee employee, string feedback)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Пользователь не может быть null.");
            }

            if (string.IsNullOrWhiteSpace(feedback))
            {
                throw new ArgumentException("Обратная связь не может быть пустой или состоять из пробелов.", nameof(feedback));
            }
            GetCurrentInProcessingStep().Reject(employee, feedback);
        }

        public void Restart()
        {
            foreach (var step in Steps)
            {
                step.Restart();
            }
        }

        private CandidateWorkflowStep GetCurrentInProcessingStep()
        {
            var status = GetStatus();

            if (status == Status.Approved)
            {
                throw new InvalidOperationException("Невозможно выполнить операцию: рабочий процесс уже утвержден.");
            }

            if (status == Status.Rejected)
            {
                throw new InvalidOperationException("Невозможно выполнить операцию: рабочий процесс отклонен.");
            }

            var currentStep = Steps
                .Where(step => step.Status == Status.InProcessing)
                .OrderBy(step => step.StepNumber)
                .FirstOrDefault();

            if (currentStep == null)
            {
                throw new InvalidOperationException("Текущий шаг с состоянием 'В процессе' не найден.");
            }

            return currentStep;
        }

        private Status GetStatus()
        {
            if (Steps.All(step => step.Status == Status.Approved))
            {
                return Status.Approved;
            }

            if (Steps.Any(step => step.Status == Status.Rejected))
            {
                return Status.Rejected;
            }

            return Status.InProcessing;
        }
    }
}