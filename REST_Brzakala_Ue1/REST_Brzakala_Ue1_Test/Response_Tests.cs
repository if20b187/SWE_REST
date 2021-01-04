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
    public class TestResponse
    {
        
        [Test]
        public void ResponseGetTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.AllMsg.Add(1, "Meine Nachricht");

            getRq.Append(
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "1 Meine Nachricht\n\r" +
                "\n");
            string request = getRq.ToString();
            res.ResponseGet();

            Assert.AreEqual(request, res.responseMsg);

        }
        [Test]
        public void ResponseGetMoreTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.AllMsg.Add(1, "Meine Nachricht");
            res.AllMsg.Add(2, "was anderes");

            getRq.Append(
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "1 Meine Nachricht\n" +
                "2 was anderes\n\r" +
                "\n");
            string request = getRq.ToString();
            res.ResponseGet();

            Assert.AreEqual(request, res.responseMsg);

        }
        [Test]
        public void ResponseGetIdTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.AllMsg.Add(1, "Meine Nachricht");
            res.AllMsg.Add(2, "was anderes");
            res.lastPart = "2";
            getRq.Append(
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "was anderes\r\n" +
                "");
            string request = getRq.ToString();
            res.ResponseGetId();

            Assert.AreEqual(request, res.responseMsg);

        }
        [Test]
        public void ResponsePostTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.AllMsg.Add(res.msgCounter, "Meine Nachricht");
            res.ResponsePost();
            getRq.Append(
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "Nachricht id: 1" +
                "");
            string request = getRq.ToString();

            Assert.AreEqual(request, res.responseMsg);

        }
        [Test]
        public void ResponsePutTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.AllMsg.Add(res.msgCounter, "Meine Nachricht");
            res.lastPart = "1";
            res.ResponsePut();
            getRq.Append(
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "Nachricht id: 1 is updated." +
                "");
            string request = getRq.ToString();

            Assert.AreEqual(request, res.responseMsg);

        }
        [Test]
        public void ResponseDeleteIdTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.AllMsg.Add(1, "Meine Nachricht");
            res.AllMsg.Add(2, "was anderes");
            res.lastPart = "2";
            res.ResponseDeleteId();
            getRq.Append(
                "HTTP/1.1 200 OK\r\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "Nachricht id: 2 is deleted." +
                "");
            string request = getRq.ToString();

            Assert.AreEqual(request, res.responseMsg);

        }
        [Test]
        public void ResponseFailedTest()
        {
            Response res = new Response();
            StringBuilder getRq = new StringBuilder();

            res.ResponseFailed();
            getRq.Append(
                "HTTP/1.1 404 Not Found\n" +
                "Content-Type: text/plain\r\n\r" +
                "\n" +
                "Fehler\r\n" +
                "\r\n");
            string request = getRq.ToString();

            Assert.AreEqual(request, res.responseMsg);

        }

    }
}