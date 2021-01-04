using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using REST_BRZAKALA_core;

namespace REST_BRZAKALA_TESTS
{
    [TestFixture]
    public class Tests
    {
 
        // GET TESTS
        [Test]
        public void TestMethod()
        {
            RequestSplit testMet = new RequestSplit();
            StringBuilder req = new StringBuilder();

            req.Append(
                "GET /message HTTP/1.1\n" +
                "Host: localhost:8080\n" +
                "User-Agent: insomnia/2020.4.2\n" +
                "Content-Type: text/plain\n" +
                "Accept: */*\n" +
                "Content-Length: 0\n" +
                "");

            testMet.split(req.ToString());
            Assert.AreEqual("GET", testMet.Method);
        }
        [Test]
        public void TestUrl()
        {
            RequestSplit testUrl = new RequestSplit();
            StringBuilder req = new StringBuilder();

            req.Append(
                "GET /message HTTP/1.1\n" +
                "Host: localhost:8080\n" +
                "User-Agent: insomnia/2020.4.2\n" +
                "Content-Type: text/plain\n" +
                "Accept: */*\n" +
                "Content-Length: 0\n" +
                "");

            testUrl.split(req.ToString());
            Assert.AreEqual("/message", testUrl.Url);

        }
        
        [Test]
        public void TestVersion()
        {
            RequestSplit testVersion = new RequestSplit();
            StringBuilder req = new StringBuilder();

            req.Append(
                "GET /message HTTP/1.1\n" +
                "Host: localhost:8080\n" +
                "User-Agent: insomnia/2020.4.2\n" +
                "Content-Type: text/plain\n" +
                "Accept: */*\n" +
                "Content-Length: 0\n" +
                "");

            testVersion.split(req.ToString());
            Assert.AreEqual("HTTP/1.1", testVersion.Version);
        }
        
        [Test]
        public void TestHost()
        {
            RequestSplit testHost = new RequestSplit();
            StringBuilder req = new StringBuilder();

            req.Append(
                "GET /message HTTP/1.1\n" +
                "Host: localhost:8080\n" +
                "User-Agent: insomnia/2020.4.2\n" +
                "Content-Type: text/plain\n" +
                "Accept: */*\n" +
                "Content-Length: 0\n" +
                "");

            testHost.split(req.ToString());
            Assert.AreEqual("localhost", testHost.RequestBody["Host"]);
            

        }
        [Test]
        public void TestUser()
        {
            RequestSplit testUser = new RequestSplit();
            StringBuilder req = new StringBuilder();

            req.Append(
                "GET /message HTTP/1.1\n" +
                "Host: localhost:8080\n" +
                "User-Agent: insomnia/2020.4.2\n" +
                "Content-Type: text/plain\n" +
                "Accept: */*\n" +
                "Content-Length: 0\n" +
                "");

            testUser.split(req.ToString());
            Assert.AreEqual("insomnia/2020.4.2", testUser.RequestBody["User-Agent"]);
            

        }
        [Test]
        public void TestConType()
        {
            RequestSplit testCon = new RequestSplit();
            StringBuilder req = new StringBuilder();

            req.Append(
                "GET /message HTTP/1.1\n" +
                "Host: localhost:8080\n" +
                "User-Agent: insomnia/2020.4.2\n" +
                "Content-Type: text/plain\n" +
                "Accept: */*\n" +
                "Content-Length: 0\n" +
                "");

            testCon.split(req.ToString());
            Assert.AreEqual("text/plain", testCon.RequestBody["Content-Type"]);
           

        }
        [Test]
        public void TestConLen()
        {
            RequestSplit testCon = new RequestSplit();
            StringBuilder req = new StringBuilder();

            req.Append(
                "GET /message HTTP/1.1\n" +
                "Host: localhost:8080\n" +
                "User-Agent: insomnia/2020.4.2\n" +
                "Content-Type: text/plain\n" +
                "Accept: */*\n" +
                "Content-Length: 0\n" +
                "");

            testCon.split(req.ToString());
            Assert.AreEqual("0", testCon.RequestBody["Content-Length"]);

        }
        [Test]
        public void TestContent()
        {
            RequestSplit testCon = new RequestSplit();
            StringBuilder req = new StringBuilder();

            req.Append(
                "GET /message HTTP/1.1\n" +
                "Host: localhost:8080\n" +
                "User-Agent: insomnia/2020.4.2\n" +
                "Content-Type: text/plain\n" +
                "Accept: */*\n" +
                "Content-Length: 0\n" +
                "");

            testCon.split(req.ToString());
            Assert.AreEqual("", testCon.ContentStr);

        }
        // POST TESTS
        [Test]
        public void TestMethodPost()
        {
            RequestSplit testMp = new RequestSplit();
            StringBuilder req = new StringBuilder();

            req.Append(
                "POST /message HTTP/1.1\n" +
                "Host: localhost:8080\n" +
                "User-Agent: insomnia/2020.4.2\n" +
                "Content-Type: text/plain\n" +
                "Accept: */*\n" +
                "Content-Length: 10\n" +
                "\n" +
                "My Message" +
                "");

            testMp.split(req.ToString());
            Assert.AreEqual("POST", testMp.Method);

        }
        [Test]
        public void TestUrlPost()
        {
            RequestSplit testUp = new RequestSplit();
            StringBuilder req = new StringBuilder();

            req.Append(
                "POST /message HTTP/1.1\n" +
                "Host: localhost:8080\n" +
                "User-Agent: insomnia/2020.4.2\n" +
                "Content-Type: text/plain\n" +
                "Accept: */*\n" +
                "Content-Length: 10\n" +
                "\n" +
                "My Message" +
                "");

            testUp.split(req.ToString());
            Assert.AreEqual("/message", testUp.Url);

        }
        [Test]
        public void TestVersionPost()
        {
            RequestSplit testVp = new RequestSplit();
            StringBuilder req = new StringBuilder();

            req.Append(
                "POST /message HTTP/1.1\n" +
                "Host: localhost:8080\n" +
                "User-Agent: insomnia/2020.4.2\n" +
                "Content-Type: text/plain\n" +
                "Accept: */*\n" +
                "Content-Length: 10\n" +
                "\n" +
                "My Message" +
                "");

            testVp.split(req.ToString());
            Assert.AreEqual("HTTP/1.1", testVp.Version);

        }
        [Test]
        public void TestContentPost()
        {
            RequestSplit testCp = new RequestSplit();
            StringBuilder req = new StringBuilder();

            req.Append(
                "POST /message HTTP/1.1\n" +
                "Host: localhost:8080\n" +
                "User-Agent: insomnia/2020.4.2\n" +
                "Content-Type: text/plain\n" +
                "Accept: */*\n" +
                "Content-Length: 10\n" +
                "\n" +
                "My Message" +
                "");

            testCp.split(req.ToString());
            Assert.AreEqual("My Message", testCp.ContentStr);

        }
        [Test]
        public void TestContentLength()
        {
            RequestSplit testClp = new RequestSplit();
            StringBuilder req = new StringBuilder();

            req.Append(
                "POST /message HTTP/1.1\n" +
                "Host: localhost:8080\n" +
                "User-Agent: insomnia/2020.4.2\n" +
                "Content-Type: text/plain\n" +
                "Accept: */*\n" +
                "Content-Length: 10\n" +
                "\n" +
                "My Message" +
                "");

            testClp.split(req.ToString());
            Assert.AreEqual(10, testClp.ContentLength);

        }
        
        
    }
}