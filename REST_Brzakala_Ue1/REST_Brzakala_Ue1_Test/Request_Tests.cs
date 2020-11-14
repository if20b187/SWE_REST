using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using REST_BRZAKALA_UE1;

namespace REST_BRZAKALA_TESTS
{
    [TestFixture]
    public class Tests
    {
        readonly RequestSplit get = new RequestSplit();
        readonly RequestSplit post = new RequestSplit();
        readonly StringBuilder br = new StringBuilder();
        readonly StringBuilder po = new StringBuilder();

        [SetUp]
        public void RequestGet()
        {
            br.Append(
                "GET /message HTTP/1.1\n" +
                "Host: localhost:8080\n" +
                "User-Agent: insomnia/2020.4.2\n" +
                "Content-Type: text/plain\n" +
                "Accept: */*\n" +
                "Content-Length: 0\n" +
                "");
            po.Append(
                "POST /message HTTP/1.1\n" +
                "Host: localhost:8080\n" +
                "User-Agent: insomnia/2020.4.2\n" +
                "Content-Type: text/plain\n" +
                "Accept: */*\n" +
                "Content-Length: 10\n" +
                "\n" +
                "My Message" +
                "");

            string request = br.ToString();
            string repost = po.ToString();
            get.split(request);
            post.split(repost);
        }
        // GET TESTS
        [Test]
        public void TestMethod()
        {

            Assert.AreEqual("GET", get.Method);

        }
        [Test]
        public void TestUrl()
        {
            Assert.AreEqual("/message", get.Url);

        }
        [Test]
        public void TestVersion()
        {
            Assert.AreEqual("HTTP/1.1", get.Version);

        }
        [Test]
        public void TestHost()
        {
            Assert.AreEqual("localhost", get.RequestBody["Host"]);

        }
        [Test]
        public void TestUser()
        {
            Assert.AreEqual("insomnia/2020.4.2", get.RequestBody["User-Agent"]);

        }
        [Test]
        public void TestConType()
        {
            Assert.AreEqual("text/plain", get.RequestBody["Content-Type"]);

        }
        [Test]
        public void TestConLen()
        {
            Assert.AreEqual("0", get.RequestBody["Content-Length"]);

        }
        [Test]
        public void TestContent()
        {
            Assert.AreEqual("", get.ContentStr);

        }
        // POST TESTS
        [Test]
        public void TestMethodPost()
        {

            Assert.AreEqual("POST", post.Method);

        }
        [Test]
        public void TestUrlPost()
        {
            Assert.AreEqual("/message", post.Url);

        }
        [Test]
        public void TestVersionPost()
        {
            Assert.AreEqual("HTTP/1.1", post.Version);

        }
        [Test]
        public void TestContentPost()
        {
            Assert.AreEqual("My Message", post.ContentStr);

        }
        [Test]
        public void TestContentLength()
        {
            Assert.AreEqual(10, post.ContentLength);

        }
    }
}