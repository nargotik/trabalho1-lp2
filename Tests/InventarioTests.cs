using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITgestao;

namespace Tests
{
    [TestClass]
    public class InventarioTests
    {

        [TestMethod]
        public void Create_Inventario()
        {
            int id = 20;
            int expected = 20;
            var _inv = new Inventario(id);
            Assert.AreEqual(_inv.Empresa, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(IdBadException))]
        public void Create_Inventario_IdBad_Trows()
        {
            // Id negativo
            var _inv = new Inventario(-23);
        }
    }
}
