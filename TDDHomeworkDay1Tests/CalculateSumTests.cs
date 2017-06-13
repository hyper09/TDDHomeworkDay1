using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDHomeworkDay1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using FluentAssertions;

namespace TDDHomeworkDay1.Tests
{
    [TestClass()]
    public class CalculateSumTests
    {
        [TestMethod()]
        public void GroupSize_is_3_get_sum_of_cost_should_get_6_15_24_21()
        {
            //arrange
            var target = new CalculateSum(new StubEntities().GetEntitys(), "Cost", 3);
            var expected = new List<int>() { 6, 15, 24, 21 };

            //act
            var actual = target.CalculateSumByColumnAndGroupSize();

            //assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        public void GroupSize_is_4_get_sum_of_revenue_should_get_50_66_60()
        {
            //arrange
            var target = new CalculateSum(new StubEntities().GetEntitys(), "Revenue", 4);
            var expected = new List<int>() { 50, 66, 60 };

            //act
            var actual = target.CalculateSumByColumnAndGroupSize();

            //assert
            CollectionAssert.AreEquivalent(expected, actual);
        }

        //or [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void When_input_groupSize_is_negative_or_zero_should_throw_argumentException()
        {
            Action act = () => new CalculateSum(new StubEntities().GetEntitys(), "Revenue", 0);
            Action act2 = () => new CalculateSum(new StubEntities().GetEntitys(), "Revenue", -1);

            act.ShouldThrow<ArgumentException>();//FluentAssertions
            act2.ShouldThrow<ArgumentException>();
        }

        [TestMethod()]
        public void When_input_column_name_is_not_exist_should_throw_argumentException()
        {
            Action act = () => new CalculateSum(new StubEntities().GetEntitys(), "XXXXX", 3);

            act.ShouldThrow<ArgumentException>();
        }

        internal class StubEntities
        {
            internal List<Entity> GetEntitys()
            {
                return new List<Entity>() {
                new Entity(){ Id = 1, Cost = 1, Revenue = 11, SellPrice = 21 },
                new Entity(){ Id = 2, Cost = 2, Revenue = 12, SellPrice = 22 },
                new Entity(){ Id = 3, Cost = 3, Revenue = 13, SellPrice = 23 },
                new Entity(){ Id = 4, Cost = 4, Revenue = 14, SellPrice = 24 },
                new Entity(){ Id = 5, Cost = 5, Revenue = 15, SellPrice = 25 },
                new Entity(){ Id = 6, Cost = 6, Revenue = 16, SellPrice = 26 },
                new Entity(){ Id = 7, Cost = 7, Revenue = 17, SellPrice = 27 },
                new Entity(){ Id = 8, Cost = 8, Revenue = 18, SellPrice = 28 },
                new Entity(){ Id = 9, Cost = 9, Revenue = 19, SellPrice = 29 },
                new Entity(){ Id = 10, Cost = 10, Revenue = 20, SellPrice = 30 },
                new Entity(){ Id = 11, Cost = 11, Revenue = 21, SellPrice = 31 }
            };
            }
        }
    }
}