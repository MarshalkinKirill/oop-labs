using Isu.Core.Abstuctions;
using Isu.Core.Enums;
using Isu.Core.SystemObjects;
using Isu.Core.SystemObjects.Types;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Isu.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            var Isu = new Service();
            String groupName = "M3212";
            Group M3212 = Isu.AddGroup(new GroupName(groupName));
            Student Kirill = Isu.AddStudent(M3212, "Kirill");
            Assert.AreEqual(Status.Studying, Kirill.GetStatus());
            Assert.AreEqual(Kirill, M3212.GetList()[0]);
        }

        [TestMethod]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            var Isu = new Service();
            String groupName = "M3212";
            Group M3212 = Isu.AddGroup(new GroupName(groupName));
            Student Kirill = Isu.AddStudent(M3212, "Kirill");
            Student Kirill2 = Isu.AddStudent(M3212, "Kirill2");
            Student Kirill3 = Isu.AddStudent(M3212, "Kirill3");
            Action acrual = () => Isu.AddStudent(M3212, "Kirill4");
            Assert.ThrowsException<Exception>(acrual);
        }

        [TestMethod]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            var Isu = new Service();
            String groupName = "M32121";
            Action acrual = () => Isu.AddGroup(new GroupName(groupName));
            Assert.ThrowsException<Exception>(acrual);
        }

        [TestMethod]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            var Isu = new Service();
            Group M3212 = Isu.AddGroup(new GroupName("M3212"));
            Group M3213 = Isu.AddGroup(new GroupName("M3213"));
            Student Kirill = Isu.AddStudent(M3212, "Kirill");
            Assert.AreEqual(Status.Studying, Kirill.GetStatus());
            Assert.AreEqual(Kirill, M3212.GetList()[0]);
            Isu.ChangeStudentGroup(Kirill, M3213);
            Assert.AreEqual(Status.Studying, Kirill.GetStatus());
            Assert.AreEqual(Kirill, M3213.GetList()[0]);
            Assert.AreEqual(0, M3212.GetList().Count);
        }
    }
}
