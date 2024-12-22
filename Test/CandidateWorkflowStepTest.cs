using Domen;
using Domen.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class CandidateWorkflowStepTest
    {
        [Fact]
        public void Create_ValidParameters_ReturnsInstance()
        {
            Guid? employerId = Guid.NewGuid();
            Guid? roleId = Guid.NewGuid();
            int stepNumber = 1;

            var step = CandidateWorkflowStep.Create(employerId, roleId, stepNumber);

            Assert.NotNull(step);
            Assert.Equal(employerId, step.UserId);
            Assert.Equal(roleId, step.RoleId);
            Assert.Equal(stepNumber, step.StepNumber);
            Assert.Equal(Status.InProcessing, step.Status);
        }
        [Fact]
        public void Approve_ValidEmployee_ChangesStatusToApproved()
        {
            var employee = new Employee(Guid.NewGuid(), "Грин Е.И", Guid.NewGuid(), Guid.NewGuid());

            var step = CandidateWorkflowStep.Create(employee.Id, employee.RoleId, 1);
            var workflow = CаndidateWorkflow.Create(new[] { step });


            workflow.Approve(employee, "Approved");

            Assert.Equal(Status.Approved, step.Status);
            Assert.Equal("Approved", step.Feedback);
        }

        [Fact]
        public void Approve_InvalidEmployee_ThrowsException()
        {
            var validEmployee = new Employee(Guid.NewGuid(), "Грин Е.И (авторизированный)", Guid.NewGuid(), Guid.NewGuid());
            var invalidEmployee = new Employee(Guid.NewGuid(), "Петров А.Г (не авторизированный)", Guid.NewGuid(), Guid.NewGuid());

            var step = CandidateWorkflowStep.Create(validEmployee.Id, validEmployee.RoleId, 1);
            var workflow = CаndidateWorkflow.Create(new[] { step });

            Assert.Throws<UnauthorizedAccessException>(() => workflow.Approve(invalidEmployee, "Approved"));
        }
    }
}
