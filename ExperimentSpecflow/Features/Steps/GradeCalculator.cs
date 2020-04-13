using FluentAssertions;
using GradeShared;
using GradeShared.Models;
using System;
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
        private Func<string> getScoreFunc;

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

        [When(@"ทำการประเมินเกรด")]
        [Scope(Tag = "exception")]
        public void WhenทำการประเมนเกรดWithException()
        {
            getScoreFunc = sut.Invoking(it => it.GetGradeByScore(score));
        }

        [Then(@"ผลการประเมินจะต้องได้เกรด '(.*)'")]
        public void Thenผลการประเมนจะตองไดเกรด(string expectedGrade)
        {
            actualGrade.Should().Be(expectedGrade);
        }

        [Then(@"ระบบจะต้องแจ้งเตือนข้อผิดพลาด")]
        public void Thenระบบจะตองแจงเตอนขอผดพลาด()
        {
            getScoreFunc
                .Should()
                .Throw<ArgumentException>();
        }
    }
}
