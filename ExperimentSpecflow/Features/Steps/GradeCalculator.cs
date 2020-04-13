using FluentAssertions;
using GradeShared;
using GradeShared.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ExperimentSpecflow.Features.Steps
{
    [Binding]
    public class GradeCalculatorSteps
    {
        private GradeCalculator sut;
        private int score;
        private string actualGrade;

        [Given(@"เกณฑ์การประเมินเกรดในระบบเป็นดังนี้")]
        public void Givenเกณฑการประเมนเกรดในระบบเปนดงน(Table table)
        {
            sut = new GradeCalculator();
            sut.Gradings = table.CreateSet<Grading>();
        }

        [Given(@"นักเรียนได้คะแนนสอบ '(.*)' คะแนน")]
        public void Givenนกเรยนไดคะแนนสอบคะแนน(int inputScore)
        {
            score = inputScore;
        }

        [When(@"ทำการประเมินเกรด")]
        public void Whenทำการประเมนเกรด()
        {
            actualGrade = sut.GetGradeByScore(score);
        }

        [Then(@"ผลการประเมินจะต้องได้เกรด '(.*)'")]
        public void Thenผลการประเมนจะตองไดเกรด(string expectedGrade)
        {
            actualGrade.Should().Be(expectedGrade);
        }
    }
}
