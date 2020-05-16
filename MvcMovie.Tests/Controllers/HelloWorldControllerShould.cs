using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Controllers;
using Xunit;

namespace MvcMovie.Tests.Controllers
{
    public class HelloWorldControllerShould
    {
        private HelloWorldController _sut;

        public HelloWorldControllerShould()
        {
            _sut = new HelloWorldController();
        }

        [Fact]
        public void ReturnViewResultForIndex()
        {
            var result = _sut.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Theory]
        [InlineData("Taro", 3)]
        public void ReturnViewResultForWelcome(string name, int numTimes)
        {
            var result = _sut.Welcome(name, numTimes);

            Assert.IsType<ViewResult>(result);
        }

    }
}
