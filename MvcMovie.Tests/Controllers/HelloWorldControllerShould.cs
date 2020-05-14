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
        [InlineData("Taro", 1)]
        [InlineData("Jiro", 2)]
        public void ReturnStringForWelcome(string name, int ID)
        {
            var result = _sut.Welcome(name, ID);

            var expect = HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");

            Assert.True(result.Equals(expect));
        }

        [Theory]
        [InlineData("Taro")]
        [InlineData("Jiro")]
        public void ReturnStringWithDefaultIDForWelcome(string name)
        {
            var result = _sut.Welcome(name);

            var expect = HtmlEncoder.Default.Encode($"Hello {name}, ID: 1");

            Assert.True(result.Equals(expect));
        }

    }
}
