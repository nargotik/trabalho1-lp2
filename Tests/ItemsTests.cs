using System;
using NUnit.Framework;
using ITgestao;
using ITgestao.ItemsNS;

namespace Tests
{
    [TestFixture]
    public class ItemsTests
    {
        /// <summary>
        /// Testa a criação de um item genérico
        /// </summary>
        [Test]
        public void Create_GenericItem()
        {
            Item _item = new Generico(123);
            // Verifica o Id do item correspondo ao inicializado
            Assert.AreEqual(_item.Id, 123);
            // Verifica se ficou inicializado
            Assert.IsTrue(_item.Initialized);
            // Verifica o tipo de item no inventário
            Assert.AreEqual(_item.Tipo, (new Generico(1)).GetType());
        }

        /// <summary>
        /// Testa a adição de um item genérico ao inventário
        /// </summary>
        [Test]
        public void GenericItemAddtoInventory()
        {
            // Limpa o inventário
            Inventario.getInstance().RemoveAll();
            // Cria um item com o id 123
            Item _item = new Generico(123);

            // Diz ao item para se adicionar ao inventário com instancia 0
            bool result = _item.AddToInventario(Inventario.getInstance());

            // Vai ao inventário buscar o item com o id 123
            Item _item2 = (Item)Inventario.getInstance(0).GetItemById(123);

            // Verifica se o tipo do item buscado corresponde
            Assert.AreEqual(_item2.Tipo, (new Generico(1)).GetType());

            // Verifica se foi adicionado
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Testa a adição de um item genérico ao inventário em duplicado
        /// </summary>
        [Test]
        public void GenericItemAddtoInventoryDuplicate()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                // Limpa o inventário
                Inventario.getInstance().RemoveAll();
                // Cria um item com o id 123
                Item _item = new Generico(123);

                // Diz ao item para se adicionar ao inventário com instancia 0 2 vezes
                bool result = _item.AddToInventario(Inventario.getInstance());
                bool result2 = _item.AddToInventario(Inventario.getInstance());
            });
        }

        /// <summary>
        /// Testa a adição de um item genérico ao inventário id inteiro em duplicado
        /// </summary>
        [Test]
        public void GenericItemAddtoInventoryByIdDuplicate()
        {
            int idinventario = 100;
            int itemid = 100;
            // Limpa o inventário
            Inventario.getInstance(idinventario).RemoveAll();

            // Cria um item com o id itemid
            Item _item = new Generico(itemid);

            // Diz ao item para se adicionar ao inventário com instancia idinventario 2 vezes
            _item.AddToInventario(idinventario);
            Assert.Throws<ArgumentException>(() =>
            {
                _item.AddToInventario(idinventario);
            });
            
            Item _item2 = 
                (Item)Inventario
                .getInstance(idinventario)
                .GetItemById(itemid);

            Assert.AreEqual(_item2.Id, itemid);
        }

        /// <summary>
        /// Testa a Remocao de um item genérico ao inventário id inteiro em duplicado
        /// </summary>
        [Test]
        public void GenericItemDelfromInventoryById()
        {
            int idinventario = 100;
            int itemid = 100;
            // Limpa o inventário
            Inventario.getInstance(idinventario).RemoveAll();

            // Cria um item com o id itemid
            Item _item = new Generico(itemid);

            // Diz ao item para se adicionar ao inventário com instancia idinventario 2 vezes
            _item.AddToInventario(idinventario);
            bool res = _item.RemoveFromInventario(idinventario);

            Assert.IsTrue(res);
        }

        /// <summary>
        /// Testa a Remocao de um item genérico ao inventário id inteiro em duplicado
        /// </summary>
        [Test]
        public void GenericItemDelfromInventory()
        {
            int idinventario = 100;
            int itemid = 100;
            // Limpa o inventário
            Inventario.getInstance(idinventario).RemoveAll();

            // Cria um item com o id itemid
            Item _item = new Generico(itemid);

            // Diz ao item para se adicionar ao inventário com instancia idinventario 2 vezes
            _item.AddToInventario(Inventario.getInstance(idinventario));
            bool res = _item.RemoveFromInventario(idinventario);

            Assert.IsTrue(res);
        }


        /// <summary>
        /// Testa a criação de um item genérico inválido (negativo)
        /// </summary>
        [Test]
        public void Create_GenericItemInvalido()
        {
            Assert.Throws<IdBadException>(() =>
            {
                Item _item = new Generico(-123);
            });
        }
    }
}
