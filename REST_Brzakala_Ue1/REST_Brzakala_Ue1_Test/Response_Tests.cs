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
    public class TestResponse
    {
        Response res = new Response();
        StringBuilder getRq = new StringBuilder();

        [SetUp]
        public void RequestGet()
        {
            res.AllMsg.Add(1, "Meine Nachricht");


        }
        [Test]
        public void ResponseGetTest()
        {
            getRq.Append(
                "HTTP/1.1 200 OK\n" +
                "Content-Type: text/plain\n" +
                "\n" +
                "1 Meine Nachricht\n" +
                "\n");
            string request = getRq.ToString();
            res.ResponseGet();

            Assert.AreEqual(request, res.responseMsg);

        }
        [Test]
        public void ResponseGetMoreTest()
        {
            res.AllMsg.Add(2, "was anderes");

            getRq.Append(
                "HTTP/1.1 200 OK\n" +
                "Content-Type: text/plain\n" +
                "\n" +
                "1 Meine Nachricht\n" +
                "2 was anderes\n" +
                "\n");
            string request = getRq.ToString();
            res.ResponseGet();

            Assert.AreEqual(request, res.responseMsg);

        }
        [Test]
        public void ResponseGetIdTest()
        {
            res.AllMsg.Clear();
            res.AllMsg.Add(1, "Meine Nachricht");
            res.AllMsg.Add(2, "was anderes");
            res.lastPart = "2";
            getRq.Append(
                "HTTP/1.1 200 OK\n" +
                "Content-Type: text/plain\n" +
                "\n" +
                "was anderes\n" +
                "");
            string request = getRq.ToString();
            res.ResponseGetId();

            Assert.AreEqual(request, res.responseMsg);

        }
        [Test]
        public void ResponsePostTest()
        {
            res.AllMsg.Clear();
            res.AllMsg.Add(res.msgCounter, "Meine Nachricht");
            res.ResponsePost();
            getRq.Append(
                "HTTP/1.1 200 OK\n" +
                "Content-Type: text/plain\n" +
                "\n" +
                "Nachricht id: 1" +
                "");
            string request = getRq.ToString();

            Assert.AreEqual(request, res.responseMsg);

        }
        [Test]
        public void ResponsePutTest()
        {
            res.AllMsg.Clear();
            res.AllMsg.Add(res.msgCounter, "Meine Nachricht");
            res.lastPart = "1";
            res.ResponsePut();
            getRq.Append(
                "HTTP/1.1 200 OK\n" +
                "Content-Type: text/plain\n" +
                "\n" +
                "Nachricht id: 1 is updated." +
                "");
            string request = getRq.ToString();

            Assert.AreEqual(request, res.responseMsg);

        }
        [Test]
        public void ResponseDeleteIdTest()
        {
            res.AllMsg.Clear();
            res.AllMsg.Add(1, "Meine Nachricht");
            res.AllMsg.Add(2, "was anderes");
            res.lastPart = "2";
            res.ResponseDeleteId();
            getRq.Append(
                "HTTP/1.1 200 OK\n" +
                "Content-Type: text/plain\n" +
                "\n" +
                "Nachricht id: 2 is deleted." +
                "");
            string request = getRq.ToString();

            Assert.AreEqual(request, res.responseMsg);

        }
        [Test]
        public void ResponseFailedTest()
        {
            res.ResponseFailed();
            getRq.Append(
                "HTTP/1.1 404 Not Found\n" +
                "Content-Type: text/plain\n" +
                "\n" +
                "Fehler\n" +
                "\n");
            string request = getRq.ToString();

            Assert.AreEqual(request, res.responseMsg);

        }

    }
}