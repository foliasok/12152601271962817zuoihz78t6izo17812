using Microsoft.VisualStudio.TestTools.UnitTesting;
using CelloveszetCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelloveszetCLI.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        // teszt esetek beállítása
        [DataRow(22,29,12,23,29)]
        [DataRow(16,45,87,33,87)]
        [DataRow(96,49,67,45,96)]
        [DataRow(44,3,12,77,77)] 
        public void LegnagyobbTest(int elsoloves, int masodikloves,int harmadikloves, int negyedikloves, int expected)
        {
            // tesztelés
            Assert.AreEqual(expected, Program.Legnagyobb(elsoloves, masodikloves, harmadikloves, negyedikloves));
        }
    }
}