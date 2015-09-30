using NUnit.Framework;
using System;

namespace brett_stale_o_meter
{
    public enum Travel
    {
        None = 1,
        Medium = 2,
        High = 3
    }

    public class StaleOMeterTests
    {
        private int _workSatisfactionIndex = 10;
        private int _projectSatisfactionIndex = 4;
        private int _brettsDesiredProjectDuration = 180;
        private readonly DateTime _projectStartDate = DateTime.Parse("08-03-2015");
        private int _travelIndex = (int)Travel.None;

        /*
           Indicates if current project is a pillar/forge project or an embedded staff aug project
           4 = staff aug
           1 = mixed or tollerable
           0.5 = pillarforge
        */
        private double _forgeOrPillarTeamIndex = 4;

        [Test]
        public void TestWhetherBrettIsStaleOnThisProject()
        {
            var actualProjectDuration = ((DateTime.Today - _projectStartDate).TotalDays * _travelIndex)*_forgeOrPillarTeamIndex;

            Assert.That((int)actualProjectDuration, Is.LessThan(_brettsDesiredProjectDuration), 
               "Brett is overdue by " + (actualProjectDuration - _brettsDesiredProjectDuration) + "days");
        }

        [Test]
        public void TestBrettsWorkSatisfaction()
        {
            Assert.That(_workSatisfactionIndex, Is.GreaterThanOrEqualTo(8), "Brett work satisfaction is low.");
        }

        [Test]
        public void TestBrettsProjectSatisfaction()
        {
            Assert.That(_projectSatisfactionIndex, Is.GreaterThanOrEqualTo(8), "Brett project satisfaction is low.");
        }
    }
}
