using Domen.Candidates;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class CandidateWorkflowTest
    {

        [Fact]
        public void Approve_ThrowArgumentNullException_EmployeeIsNull()
        {
            var steps = new[] { CandidateWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), 1) };
            var workflow = CаndidateWorkflow.Create(steps);
            Employee employee = null;
            string feedback = "feedback";

            var exception = Assert.Throws<ArgumentNullException>(() => workflow.Approve(employee, feedback));
            Assert.StartsWith("Пользователь не может быть null.", exception.Message);
            Assert.Equal("employee", exception.ParamName);
        }

        [Fact]
        public void Approve_ThrowArgumentException_FeedbackIsInvalid()
        {
            var steps = new[] { CandidateWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), 1) };
            var workflow = CаndidateWorkflow.Create(steps);
            var employee = new Employee(Guid.NewGuid(), "Employee", Guid.NewGuid(), Guid.NewGuid());
            string feedback = "";

            var exception = Assert.Throws<ArgumentException>(() => workflow.Approve(employee, feedback));
            Assert.StartsWith("Обратная связь не может быть пустой или состоять из пробелов.", exception.Message);
            Assert.Equal("feedback", exception.ParamName);
        }
    }
}
