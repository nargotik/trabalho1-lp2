using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ITgestao;
using ITgestao.ItemsNS;

namespace Tests
{
    [TestClass]
    public class InventarioTests
    {
        /// <summary>
        /// Testa a Remocao de um inventario não existente
        /// </summary>
        [TestMethod]
        public void RemoveItemNotExistente_Inventario()
        {
            int id = 20;
            var _inv = new Inventario(id);

            var _item1 = new Generico(1, "Serial 1");
            //_inv.Adiciona(_item1);

            Assert.IsFalse(
                _inv.Remove(_item1)
                );

        }

        /// <summary>
        /// Testa a Remocao de um inventario  existente
        /// </summary>
        [TestMethod]
        public void RemoveItemExistente_Inventario()
        {
            int id = 20;
            var _inv = new Inventario(id);

            var _item1 = new Generico(1, "Serial 1");
            _inv.Adiciona(_item1);

            Assert.IsTrue(
                _inv.Remove(_item1)
                );

        }

        /// <summary>
        /// Testa a Remocao de um inventario existente
        /// </summary>
        [TestMethod]
        public void RemoveItemExistenteById_Inventario()
        {
            int id = 20;
            var _inv = new Inventario(id);

            var _item1 = new Generico(1, "Serial 1");
            _inv.Adiciona(_item1);

            Assert.IsTrue(
                _inv.RemoveById(1)
                );

        }

        /// <summary>
        /// Testa a Remocao de um inventario invexistente
        /// </summary>
        [TestMethod]
        public void RemoveItemInexistenteById_Inventario()
        {
            int id = 20;
            var _inv = new Inventario(id);

            Assert.IsFalse(
                _inv.RemoveById(9999)
                );

        }


        /// <summary>
        /// Testa a edicao de um inventario
        /// </summary>
        [TestMethod]
        public void EditaItem_Inventario()
        {
            int id = 20;
            var _inv = new Inventario(id);

            var _item1 = new Generico(1, "Serial 1");
            _inv.Adiciona(_item1);
            var _item2 = new Generico(1, "ADIHDSAUDYAISUDSAD");


            _inv.Edita(_item2);

            Assert.AreEqual(
                _item2.Serial
                , 
                (_inv.GetItemById(1) as Generico).Serial
                );
            
        }

        /// <summary>
        /// Testa a criação de um inventario
        /// </summary>
        [TestMethod]
        public void Create_Inventario()
        {
            int id = 20;
            int expected = 20;
            var _inv = new Inventario(id);
            Assert.AreEqual(_inv.Empresa, expected);

        }

        /// <summary>
        /// Cria um inventário com id inválido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IdBadException))]
        public void Create_Inventario_IdBad_Trows()
        {
            // Id negativo
            var _inv = new Inventario(-23);
        }

        /// <summary>
        /// Teste adicionar ao inventário um item inválido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidEquipamentoException))]
        public void AdicionaInventarioBadObject_Trows()
        {
            
            var _inv = new Inventario(20);
            // Tenta adicionar um inventário no inventário
            _inv.Adiciona(_inv);
        }

        /// <summary>
        /// Testa adição de inventários duplicados
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AdicionaInventarioDuplicate_Trows()
        {

            var _inv = new Inventario(20);
            var item1 = new Generico(1);
            var item2 = new Generico(1);
            // Tenta adicionar um inventário no inventário
            _inv.Adiciona(item1);
            _inv.Adiciona(item2);
        }

        /// <summary>
        /// Testa a edição de inventários que nao existe
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NotExists))]
        public void EditNotExists_Trows()
        {

            var _inv = new Inventario(20);
            var item1 = new Generico(1);
            // Tenta adicionar um inventário no inventário
            _inv.Edita(item1);
        }


    }
}
