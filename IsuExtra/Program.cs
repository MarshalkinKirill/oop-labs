﻿using System;
using System.Collections.Generic;
using System.Text;
using Isu.Services.Types;
using Isu.Services;
using Isu.Tools.Enums;
using IsuExtra.Core.Types;
using IsuExtra.Core.Tools;
using IsuExtra.Core;

namespace IsuExtra
{
    internal class Program
    {
        private static void Main()
        {
            List<Faculty> faculties = new List<Faculty>();
            faculties.Add(new Faculty("1", "M"));
            faculties.Add(new Faculty("2", "P"));
            faculties.Add(new Faculty("3", "K"));

            IsuExtraService Isu = new IsuExtraService(faculties);

            //Group M3212
            Schadule schadule1 = new Schadule();
            GroupName groupName1 = new GroupName("M3212");
            Isu.AddGroup(groupName1, schadule1);
            Group M3212 = Isu.GroupService.FindGroup(groupName1);
            List<Class> classes1 = new List<Class>();
            classes1.Add(new Class(M3212, ("Sunday", "09:30"), new Mentor("VALERA"), 111));
            classes1.Add(new Class(M3212, ("Wednesday", "09:30"), new Mentor("KEKW"), 111));
            classes1.Add(new Class(M3212, ("Friday", "09:30"), new Mentor("PSGLGD"), 111));
            Isu.GetGroupSchadule(M3212).AddClasses(classes1);
            Isu.AddStudent(M3212, "Kirill");
            Isu.AddStudent(M3212, "Denis");

            //Group P3207
            Schadule schadule2 = new Schadule();
            GroupName groupName2 = new GroupName("M3212");
            Isu.AddGroup(groupName2, schadule2);
            Group P3207 = Isu.GroupService.FindGroup(groupName2);
            List<Class> classes2 = new List<Class>();
            classes2.Add(new Class(P3207, ("Sunday", "11:30"), new Mentor("VALERA"), 111));
            classes2.Add(new Class(P3207, ("Wednesday", "11:30"), new Mentor("KEKW"), 111));
            classes2.Add(new Class(P3207, ("Friday", "11:30"), new Mentor("PSGLGD"), 111));
            Isu.GetGroupSchadule(P3207).AddClasses(classes2);
            Isu.AddStudent(P3207, "Ame");
            Isu.AddStudent(P3207, "Yatoro");

            //Group K3111
            Schadule schadule3 = new Schadule();
            GroupName groupName3 = new GroupName("M3212");
            Isu.AddGroup(groupName3, schadule3);
            Group K3111 = Isu.GroupService.FindGroup(groupName3);
            List<Class> classes3 = new List<Class>();
            classes3.Add(new Class(K3111, ("Sunday", "13:30"), new Mentor("VALERA"), 111));
            classes3.Add(new Class(K3111, ("Wednesday", "13:30"), new Mentor("KEKW"), 111));
            classes3.Add(new Class(K3111, ("Friday", "13:30"), new Mentor("PSGLGD"), 111));
            Isu.GetGroupSchadule(K3111).AddClasses(classes3);
            Isu.AddStudent(K3111, "Meposhka");
            Isu.AddStudent(K3111, "Xinq");

            //Add elective modules to the faculties
            Schadule electiveSchadule1 = new Schadule();
            List<Class> electiveClasses1 = new List<Class>();
            electiveClasses1.Add(new Class("1", ("Sunday", "13:30"), new Mentor("VALERA"), 111));
            electiveClasses1.Add(new Class("1", ("Wednesday", "13:30"), new Mentor("KEKW"), 111));
            electiveClasses1.Add(new Class("1", ("Friday", "13:30"), new Mentor("PSGLGD"), 111));
            electiveSchadule1.AddClasses(electiveClasses1);
            List<Flow> electiveFlows1 = new List<Flow>();
            electiveFlows1.Add(new Flow(10, electiveSchadule1));
            Isu.AddElectiveModule(Isu.Faculty[0], "qwe", electiveFlows1);

            Schadule electiveSchadule2 = new Schadule();
            List<Class> electiveClasses2 = new List<Class>();
            electiveClasses2.Add(new Class("1", ("Sunday", "15:30"), new Mentor("VALERA"), 111));
            electiveClasses2.Add(new Class("1", ("Wednesday", "15:30"), new Mentor("KEKW"), 111));
            electiveClasses2.Add(new Class("1", ("Friday", "15:30"), new Mentor("PSGLGD"), 111));
            electiveSchadule2.AddClasses(electiveClasses2);
            List<Flow> electiveFlows2 = new List<Flow>();
            electiveFlows2.Add(new Flow(10, electiveSchadule2));
            Isu.AddElectiveModule(Isu.Faculty[1], "qwq", electiveFlows2);
            //Console.WriteLine(Isu.Faculty[0].ElectiveModules[0].Name);
            //Add students to the elective modules
            Isu.AddStudentToElectiveModule(Isu.GroupService.FindStudent("Kirill"), Isu.Faculty[0].ElectiveModules[0]);
            Isu.AddStudentToElectiveModule(Isu.GroupService.FindStudent("Kirill"), faculties[1].ElectiveModules[0]);
            Isu.AddStudentToElectiveModule(Isu.GroupService.FindStudent("Ame"), faculties[0].ElectiveModules[0]);
            Isu.AddStudentToElectiveModule(Isu.GroupService.FindStudent("Ame"), faculties[1].ElectiveModules[0]);

            //Delete student from elective module
            Isu.DeleteStudentFromElectiveModule(Isu.GroupService.FindStudent("Ame"), faculties[1].ElectiveModules[0]);

            //Get flow
            List<Flow> catchFlows = Isu.GetElectiveModuleFlows(faculties[0].ElectiveModules[0]);
            
            //Get unstudying students
            List<Student> students = Isu.GetUnsignedStudents(P3207);
            
        }
    }
}
