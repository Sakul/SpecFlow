using FluentAssertions;
using GradeShared;
using GradeShared.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace ExperimentSpecflow
{
    public class GradeCalculatorTests
    {
        // Normal cases
        // ใส่ข้อมูลที่ได้คะแนน 60 จะต้องได้เกรด F
        // ใส่ข้อมูลที่ได้คะแนน 70 จะต้องได้เกรด D
        // ใส่ข้อมูลที่ได้คะแนน 80 จะต้องได้เกรด C
        // ใส่ข้อมูลที่ได้คะแนน 90 จะต้องได้เกรด B
        // ใส่ข้อมูลที่ได้คะแนน 95 จะต้องได้เกรด A
        // ใส่ข้อมูลที่ได้คะแนนเกิน 90 ขึ้นไปจะต้องได้เกรด A

        // Alternative cases
        // ใส่ข้อมูลที่ได้คะแนน 0 จะต้องได้เกรด F
        // ใส่ข้อมูลที่ได้คะแนน 61 จะต้องได้เกรด D
        // ใส่ข้อมูลที่ได้คะแนน 71 จะต้องได้เกรด C
        // ใส่ข้อมูลที่ได้คะแนน 81 จะต้องได้เกรด B
        // ใส่ข้อมูลที่ได้คะแนน 91 จะต้องได้เกรด A

        // Exception cases
        // ใส่ข้อมูลที่ได้คะแนน -65 ระบบจะต้องแจ้งเตือนข้อผิดพลาด
        // ใส่ข้อมูลที่ได้คะแนน 120 ระบบจะต้องแจ้งเตือนข้อผิดพลาด

        private GradeCalculator sut;

        public GradeCalculatorTests()
        {
            sut = new GradeCalculator();
            sut.Gradings = new List<Grading>
            {
                new Grading{ MinScore = 91, Grade = "A" },
                new Grading{ MinScore = 81, Grade = "B" },
                new Grading{ MinScore = 71, Grade = "C" },
                new Grading{ MinScore = 61, Grade = "D" },
                new Grading{ MinScore = 0, Grade = "F" },
            };
        }

        // Normal cases
        // ใส่ข้อมูลที่ได้คะแนน 60 จะต้องได้เกรด F
        [Fact]
        public void Input_60_Score_Grade_Must_Be_F()
        {
            var actual = sut.GetGradeByScore(60);
            actual.Should().Be("F");
        }

        // ใส่ข้อมูลที่ได้คะแนน 70 จะต้องได้เกรด D
        [Fact]
        public void Input_70_Score_Grade_Must_Be_D()
        {
            var actual = sut.GetGradeByScore(70);
            actual.Should().Be("D");
        }

        // ใส่ข้อมูลที่ได้คะแนน 80 จะต้องได้เกรด C
        [Fact]
        public void Input_80_Score_Grade_Must_Be_C()
        {
            var actual = sut.GetGradeByScore(80);
            actual.Should().Be("C");
        }

        // ใส่ข้อมูลที่ได้คะแนน 90 จะต้องได้เกรด B
        [Fact]
        public void Input_90_Score_Grade_Must_Be_B()
        {
            var actual = sut.GetGradeByScore(90);
            actual.Should().Be("B");
        }

        // ใส่ข้อมูลที่ได้คะแนน 95 จะต้องได้เกรด A
        [Fact]
        public void Input_95_Score_Grade_Must_Be_A()
        {
            var actual = sut.GetGradeByScore(95);
            actual.Should().Be("A");
        }

        // ใส่ข้อมูลที่ได้คะแนนเกิน 90 ขึ้นไปจะต้องได้เกรด A
        [Theory]
        [InlineData(91)]
        [InlineData(92)]
        [InlineData(93)]
        [InlineData(94)]
        [InlineData(95)]
        [InlineData(96)]
        [InlineData(97)]
        [InlineData(98)]
        [InlineData(99)]
        public void Input_Score_More_Than_90_Grade_Must_Be_A(int score)
        {
            var actual = sut.GetGradeByScore(score);
            actual.Should().Be("A");
        }

        // Alternative cases
        // ใส่ข้อมูลที่ได้คะแนน 0 จะต้องได้เกรด F
        [Fact]
        public void Input_0_Score_Grade_Must_Be_F()
        {
            var actual = sut.GetGradeByScore(0);
            actual.Should().Be("F");
        }

        // ใส่ข้อมูลที่ได้คะแนน 61 จะต้องได้เกรด D
        [Fact]
        public void Input_61_Score_Grade_Must_Be_D()
        {
            var actual = sut.GetGradeByScore(61);
            actual.Should().Be("D");
        }

        // ใส่ข้อมูลที่ได้คะแนน 71 จะต้องได้เกรด C
        [Fact]
        public void Input_71_Score_Grade_Must_Be_C()
        {
            var actual = sut.GetGradeByScore(71);
            actual.Should().Be("C");
        }

        // ใส่ข้อมูลที่ได้คะแนน 81 จะต้องได้เกรด B
        [Fact]
        public void Input_81_Score_Grade_Must_Be_B()
        {
            var actual = sut.GetGradeByScore(81);
            actual.Should().Be("B");
        }

        // ใส่ข้อมูลที่ได้คะแนน 91 จะต้องได้เกรด A
        [Fact]
        public void Input_91_Score_Grade_Must_Be_A()
        {
            var actual = sut.GetGradeByScore(91);
            actual.Should().Be("A");
        }

        // Exception cases
        // ใส่ข้อมูลที่ได้คะแนน -65 ระบบจะต้องแจ้งเตือนข้อผิดพลาด
        [Fact]
        public void Input_Negative_65_Score_Then_System_Must_Throw_An_Exception()
        {
            sut.Invoking(it => it.GetGradeByScore(-65))
                .Should()
                .Throw<ArgumentException>();
        }

        // ใส่ข้อมูลที่ได้คะแนน 120 ระบบจะต้องแจ้งเตือนข้อผิดพลาด
        [Fact]
        public void Input_120_Score_Then_System_Must_Throw_An_Exception()
        {
            sut.Invoking(it => it.GetGradeByScore(120))
                .Should()
                .Throw<ArgumentException>();
        }
    }
}
