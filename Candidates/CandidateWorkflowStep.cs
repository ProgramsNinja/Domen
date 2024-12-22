using Domen.Vacancies;
using Domen.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domen.Candidates
{
    public class CandidateWorkflowStep
    {
        public CandidateWorkflowStep(Guid? userId, Guid? roleId,
             Status status, int stepNumber, string feedback)
        {
            if (userId != null && roleId != null)
            {
                throw new ArgumentException("UserId и RoleId не могут быть указаны одновременно.");
            }

            UserId = userId;
            RoleId = roleId;
            Status = status;
            StepNumber = stepNumber;
            Feedback = feedback;
        }

        public Guid? UserId { get; private set; }
        public Guid? RoleId { get; private set; }
        public Status Status { get; private set; }
        public string Feedback { get; private set; }
        public int StepNumber { get; private set; }

        public static CandidateWorkflowStep Create(Guid? userId, Guid? roleId, int stepnumber)
        {
            if (stepnumber <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(stepnumber), "Номер шага должен быть больше нуля.");
            }

            return new CandidateWorkflowStep(
                userId,
                roleId,
                Status.InProcessing,
                stepnumber,
                feedback: null);
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

            if (string.IsNullOrEmpty(feedback))
            {
                throw new ArgumentNullException(nameof(feedback));
            }

            if (UserId == null && RoleId == null)
            {
                throw new InvalidOperationException("Невозможно одобрить шаг, так как ни UserId, ни RoleId не установлены.");
            }

            Status = Status.Approved;
            Feedback = feedback;
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

            if (string.IsNullOrEmpty(feedback))
            {
                throw new ArgumentNullException(nameof(feedback));
            }

            if (UserId == null && RoleId == null)
            {
                throw new InvalidOperationException("Невозможно отклонить шаг, так как ни UserId, ни RoleId не установлены.");
            }

            Status = Status.Rejected;
            Feedback = feedback;
        }

        public void Restart()
        {
            Status = Status.Restarted;
            Feedback = null;
        }
        private void ValidateStatusChange(Employee employee)
        {
            if (Status != Status.InProcessing)
            {
                throw new InvalidOperationException("Статус может быть изменён только, если он находится в обработке.");
            }

            if (employee.Id != UserId && employee.RoleId != RoleId)
            {
                throw new UnauthorizedAccessException("Пользователь не имеет прав на изменение статуса этого шага.");
            }
        }
    }
}
