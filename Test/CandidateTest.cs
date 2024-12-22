using System;
using System.Linq;
using Xunit;
using Domen.Candidates;
using Domen.Vacancies;
using Domen;

namespace Test
{
    public class CandidateTest
    {
        [Fact]
        public void Create_ValidParameters_ReturnsCandidate()
        {
            var vacancyId = Guid.NewGuid();
            var referralId = Guid.NewGuid();
            var document = new CandidateDocument("Joe","5 year");
            var step = CandidateWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), 1);
            var workflow = CаndidateWorkflow.Create(new[] { step });

            var candidate = Candidate.Create(document,referralId, workflow);

            Assert.NotNull(candidate);
            Assert.Equal(vacancyId, candidate.VacancyId);
            Assert.Equal(referralId, candidate.ReferralId);
            Assert.Equal(document, candidate.Document);
            Assert.Equal(Status.InProcessing, candidate.Status);
        }

        [Fact]
        public void Approve_ValidEmployee_UpdatesStatus()
        {
            var employee = new Employee(Guid.NewGuid(), "Fsdsdds.", Guid.NewGuid(), Guid.NewGuid());
            var step = CandidateWorkflowStep.Create(employee.Id, employee.RoleId, 1);
            var workflow = CаndidateWorkflow.Create(new[] { step });
            var candidate = Candidate.Create(new CandidateDocument("Joe", "5 year"),Guid.NewGuid(), workflow);

            candidate.Approve(employee, "Approved");

            Assert.Equal(Status.Approved, candidate.Status);
        }

    }
}
