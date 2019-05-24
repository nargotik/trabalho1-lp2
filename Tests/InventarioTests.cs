using System;
using NUnit.Framework;
using ITgestao;
using ITgestao.ItemsNS;

namespace Tests
{
    [TestFixture]
    public class InventarioTests
    {
        /// <summary>
        /// Testa a Remocao de um inventario não existente
        /// </summary>
        [Test]
        public void RemoveItemNotExistente_Inventario()
        {

            var _item1 = new Generico(1, "Serial 1");
            //_inv.Adiciona(_item1);

            Assert.IsFalse(
                Inventario.getInstance().Remove(_item1)
                );

        }

        /// <summary>
        /// Testa a Remocao de um inventario  existente
        /// </summary>
        [Test]
        public void RemoveItemExistente_Inventario()
        {

            var _item1 = new Generico(1, "Serial 1");
            Inventario.getInstance().Adiciona(_item1);


            Assert.IsTrue(
                Inventario.getInstance().Remove(_item1)
                );

        }

        /// <summary>
        /// Testa a Remocao de um inventario existente
        /// </summary>
        [Test]
        public void RemoveItemExistenteById_Inventario()
        {

            {
                Inventario inv = Inventario.getInstance();

                var _item1 = new Generico(1, "Serial 1");
                inv.Adiciona(_item1);

                Assert.IsTrue(
                    inv.RemoveById(1)
                    );
            }
            

        }

        /// <summary>
        /// Testa a Remocao de um inventario invexistente
        /// </summary>
        [Test]
        public void RemoveItemInexistenteById_Inventario()
        {
            {
                Inventario _inv = Inventario.getInstance();
                Assert.IsFalse(
                    _inv.RemoveById(9999)
                    );
            }
            

        }


        /// <summary>
        /// Testa a edicao de um inventario
        /// </summary>
        [Test]
        public void EditaItem_Inventario()
        {

            int id = 20;
            var _inv = Inventario.getInstance(id);

            _inv.RemoveAll();

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
        [Test]
        public void Create_Inventario()
        {
            int id = 20;
            int expected = 20;
            var _inv = Inventario.getInstance(id);
            Assert.AreEqual(_inv.Empresa, expected);

        }

        /// <summary>
        /// Cria um inventário com id inválido
        /// </summary>
        [Test]

        public void Create_Inventario_IdBad_Trows()
        {
            Assert.Throws<IdBadException>(() =>
            {
                // Id negativo
                var _inv = Inventario.getInstance(-23);
            });
            
        }

        /// <summary>
        /// Teste adicionar ao inventário um item inválido
        /// </summary>
        [Test]
        public void AdicionaInventarioBadObject_Trows()
        {
            Assert.Throws<InvalidEquipamentoException>(() =>
            {
                var _inv = Inventario.getInstance(10);
                // Tenta adicionar um inventário no inventário
                Inventario.getInstance(20).Adiciona(_inv);
            });
            
        }

        /// <summary>
        /// Teste adicionar ao inventário um item nulo 
        /// </summary>
        [Test]

        public void AdicionaInventarioNullObject_Trows()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                //var _inv = Inventario.getInstance(10);
                // Tenta adicionar um inventário no inventário
                Inventario.getInstance(20).Adiciona(null);
            });
            
        }

        /// <summary>
        /// Testa adição de inventários duplicados
        /// </summary>
        [Test]

        public void AdicionaInventarioDuplicate_Trows()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var _inv = Inventario.getInstance(20);
                var item1 = new Generico(1);
                var item2 = new Generico(1);
                // Tenta adicionar um inventário no inventário
                _inv.Adiciona(item1);
                _inv.Adiciona(item2);
            });
            
        }

        /// <summary>
        /// Testa adição de "numeroitems" items (timeout 30Seg depende do processador/disco/ram)
        /// </summary>
        [Test, Timeout(30000)]
        public void AdicionaInventarioCycle()
        {
            int numeroitems = 1100;

            var _inv = Inventario.getInstance(20);
            _inv.RemoveAll();
            Assert.AreEqual(_inv.TotalItems, 0);

            _inv.Adiciona(new Generico(1));
            Assert.AreEqual(_inv.TotalItems, 1);

            for (int i = 2; i <= numeroitems; i++)
            {
                _inv.Adiciona(new Generico(i));
                Assert.AreEqual(_inv.TotalItems, i);
            }
            Assert.AreEqual(_inv.TotalItems, numeroitems);
        }

        /// <summary>
        /// Testa a edição de inventários que nao existe
        /// </summary>
        [Test]

        public void EditNotExists_Trows()
        {
            Assert.Throws<NotExists>(() =>
            {
                var _inv = Inventario.getInstance(20);

                _inv.RemoveAll();

                var item1 = new Generico(22);
                _inv.Edita(item1);
            });
            
        }

    }
}