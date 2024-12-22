﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class VacancyWorkflowStepTest
    {
        [Fact]
        public void Create_ValidStepNumber_ReturnsStep()
        {
            int stepNumber = 1;

            var step = VacancyWorkflowStep.Create(Guid.NewGuid(), Guid.NewGuid(), "description", stepNumber);

            Assert.NotNull(step);
            Assert.Equal(stepNumber, step.StepNumber);
        }
        [Fact]
        public void Create_NegativeStepNumber()
        {
            Guid? userId = Guid.NewGuid();
            Guid? roleId = Guid.NewGuid();
            string description = "Test";
            int negativeStepNumber = -14;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => VacancyWorkflowStep.Create(userId, roleId, description, negativeStepNumber));
            Assert.Equal("stepNumber", exception.ParamName);
        }
        [Fact]
        public void NullUserIdRoleId()
        {
            Guid? userId = null;
            Guid? roleId = null;
            string description = "Test";
            int stepNumber = 1;

            var exception = Assert.Throws<ArgumentException>(() => VacancyWorkflowStep.Create(userId, roleId, description, stepNumber));
            Assert.Equal("Должен быть указан либо UserId, либо RoleId.", exception.Message);
        }
        [Fact]
        public void DescriptionIsNull()
        {
            Guid? userId = Guid.NewGuid();
            Guid? roleId = null;
            string description = null;
            int stepNumber = 1;

            Assert.Throws<ArgumentNullException>(() => VacancyWorkflowStep.Create(userId, roleId, description, stepNumber));
        }
        [Fact]
        public void NullUserId()
        {
            Guid? userId = Guid.NewGuid();
            Guid? roleId = null;
            string description = "Test";
            int stepNumber = 1;

            var step = VacancyWorkflowStep.Create(userId, roleId, description, stepNumber);

            Assert.Equal(userId, step.UserId);
            Assert.Null(step.RoleId);
            Assert.Equal(description, step.Description);
            Assert.Equal(stepNumber, step.StepNumber);
        }
        [Fact]
        public void NullRoleId()
        {
            Guid? userId = null;
            Guid? roleId = Guid.NewGuid();
            string description = "Test";
            int stepNumber = 1;

            var step = VacancyWorkflowStep.Create(userId, roleId, description, stepNumber);

            Assert.Null(step.UserId);
            Assert.Equal(roleId, step.RoleId);
            Assert.Equal(description, step.Description);
            Assert.Equal(stepNumber, step.StepNumber);
        }
    }
}
