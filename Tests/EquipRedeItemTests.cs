using System;
using NUnit.Framework;
using ITgestao;
using ITgestao.ItemsNS;

namespace Tests
{
    [TestFixture]
    public class EquipRedeItemTests
    {
        /// <summary>
        /// Testa a criação de um item genérico e verifica se é válido
        /// </summary>
        [Test]
        public void Create_EquipRedeItemValid()
        {
            EquipRede _item = new EquipRede(123, EquipRede.EquipRedeTipos.Router);
            _item.Descricao = "Descricao Teste";
            _item.IpInsere("127.0.0.1");

            // Verifica o Id do item correspondo ao inicializado
            Assert.AreEqual(_item.Id, 123);
            Assert.AreEqual(_item.Descricao, "Descricao Teste");

            // Verifica se ficou inicializado
            Assert.IsTrue(_item.Initialized);
            // Verifica o tipo de item no inventário
            Assert.AreEqual(_item.Tipo, (new EquipRede(1, EquipRede.EquipRedeTipos.Router)).GetType());
            

            Assert.IsTrue(_item.IsValid());
        }

        /// <summary>
        /// Testa a criação de um item genérico e verifica se as datas são invalidas 
        /// </summary>
        [Test]
        public void Create_EquipRedeInvalidDates()
        {
            EquipRede _item = new EquipRede(123, EquipRede.EquipRedeTipos.Router);

            // A data de fabrico nao pode ser futura
            Assert.Throws<ArgumentException>(() =>
            {
                _item.DataFabricoSet(DateTime.Now.AddYears(1));
            });

            // A data de fabrico nao pode ser futura
            Assert.Throws<ArgumentException>(() =>
            {
                _item.DataAquisicaoSet(DateTime.Now.AddYears(1));
            });
        }

        /// <summary>
        /// Testa a criação de um item genérico e verifica se as datas são validas 
        /// </summary>
        [Test]
        public void Create_EquipRedeDates()
        {
            EquipRede _item = new EquipRede(123, EquipRede.EquipRedeTipos.Router);

            DateTime _setdate = DateTime.Now.AddDays(-11);
            _item.DataFabricoSet(_setdate);

            Assert.AreEqual(_setdate, _item.DataFabricoGet);

            
            _setdate = DateTime.Now.AddDays(-12);
            _item.DataAquisicaoSet(_setdate);
            Assert.AreEqual(_setdate, _item.DataAquisicaoGet);

            // As duas nao sao iguais
            Assert.AreNotEqual(_item.DataFabricoGet, _item.DataAquisicaoGet);

        }


        /// <summary>
        /// Testa a criação a parte dos ips do EquipRede
        /// </summary>
        [Test]
        public void Create_EquipRedeItemIps()
        {
            EquipRede _item = new EquipRede(123, EquipRede.EquipRedeTipos.Router);

            // Adiciona um ip e verifica se ficou
            _item.IpInsere("127.0.0.1");
            Assert.IsTrue(_item.IpExiste("127.0.0.1"));
            // Tem de ter um ip
            Assert.AreEqual(_item.IpCount, 1);

            // Tenta adicionar o mesmo ip têm de dar exepção
            Assert.Throws<ArgumentException>(() =>
            {
                _item.IpInsere("127.0.0.1");
            });
            // Tem de continuar com 1 ip
            Assert.AreEqual(_item.IpCount, 1);

            // Remove o ip adicionado
            _item.IpRemove("127.0.0.1");
            Assert.IsFalse(_item.IpExiste("127.0.0.1"));
            Assert.AreEqual(_item.IpCount, 0);

            // Tenta remover um ip que nao existe têm de dar exption
            Assert.Throws<ArgumentException>(() =>
            {
                _item.IpRemove("127.0.0.2");
            });

            // Tenta adicionar um ip inválido
            Assert.Throws<ArgumentException>(() =>
            {
                _item.IpInsere("INVALIDO");
            });
        }

        /// <summary>
        /// Testa a criação a parte dos macs do EquipRede
        /// </summary>
        [Test]
        public void Create_EquipRedeItemMac()
        {
            EquipRede _item = new EquipRede(123, EquipRede.EquipRedeTipos.Router);

            // Adiciona um ip e verifica se ficou
            _item.MacInsere("00:00:00:00:00:01");
            Assert.IsTrue(_item.MacExiste("00:00:00:00:00:01"));
            // Tem de ter um ip
            Assert.AreEqual(_item.MacCount, 1);

            // Tenta adicionar o mesmo ip têm de dar exepção
            Assert.Throws<ArgumentException>(() =>
            {
                _item.MacInsere("00:00:00:00:00:01");
            });

            // Tem de continuar com 1 ip
            Assert.AreEqual(_item.MacCount, 1);

            // Remove o ip adicionado
            _item.MacRemove("00:00:00:00:00:01");
            Assert.IsFalse(_item.MacExiste("00:00:00:00:00:01"));
            Assert.AreEqual(_item.MacCount, 0);

            // Tenta remover um ip que nao existe têm de dar exption
            Assert.Throws<ArgumentException>(() =>
            {
                _item.MacRemove("00:00:00:00:00:02");
            });

            // Tenta remover um ip Inválido
            Assert.Throws<ArgumentException>(() =>
            {
                _item.MacRemove("0R:00:00:00:00:01");
            });
        }

        /// <summary>
        /// Testa a criação de um item genérico
        /// </summary>
        [Test]
        public void Create_EquipRedeItem()
        {
            Item _item = new EquipRede(123, EquipRede.EquipRedeTipos.Router);
            // Verifica o Id do item correspondo ao inicializado
            Assert.AreEqual(_item.Id, 123);
            // Verifica se ficou inicializado
            Assert.IsTrue(_item.Initialized);
            // Verifica o tipo de item no inventário
            Assert.AreEqual(_item.Tipo, (new EquipRede(1, EquipRede.EquipRedeTipos.Router)).GetType());
        }

        /// <summary>
        /// Testa a adição de um item genérico ao inventário
        /// </summary>
        [Test]
        public void EquipRedeItemAddtoInventory()
        {
            // Limpa o inventário
            Inventario.getInstance().RemoveAll();
            // Cria um item com o id 123
            Item _item = new EquipRede(123, EquipRede.EquipRedeTipos.Router);

            // Diz ao item para se adicionar ao inventário com instancia 0
            bool result = _item.AddToInventario(Inventario.getInstance());

            // Vai ao inventário buscar o item com o id 123
            Item _item2 = (Item)Inventario.getInstance(0).GetItemById(123);

            // Verifica se o tipo do item buscado corresponde
            Assert.AreEqual(_item2.Tipo, (new EquipRede(1, EquipRede.EquipRedeTipos.Router)).GetType());

            // Verifica se foi adicionado
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Testa adição de "numeroitems" items (timeout 30Seg depende do processador/disco/ram)
        /// </summary>
        [Test, Timeout(30000)]
        public void EquipRedeesAdicionaInventarioCycle()
        {
            int numeroitems = 200;

            Inventario.getInstance(20).RemoveAll();
            var _inv = Inventario.getInstance(20);

            EquipRede _comp = new EquipRede(1, EquipRede.EquipRedeTipos.Router);
            Assert.AreEqual(_inv.TotalItems, 0);

            _inv.Adiciona(_comp);
            Assert.AreEqual(_inv.TotalItems, 1);

            for (int i = 2; i <= numeroitems; i++)
            {
                EquipRede _comp2 = new EquipRede(i, EquipRede.EquipRedeTipos.Router);
                _comp2.IpInsere("127.0.0.1");
                _comp2.IpInsere("127.0.0.2");
                _comp2.IpInsere("127.0.0.3");
                _comp2.IpInsere("127.0.0.4");
                _comp2.IpInsere("127.0.0.5");
                _comp2.MacInsere("00:00:00:00:00:01");
                _comp2.MacInsere("00:00:00:00:00:02");
                _comp2.MacInsere("00:00:00:00:00:03");
                _comp2.MacInsere("00:00:00:00:00:04");
                _comp2.MacInsere("00:00:00:00:00:05");
                _comp2.AddToInventario(20);
                Assert.AreEqual(_inv.TotalItems, i);
            }
            Assert.AreEqual(_inv.TotalItems, numeroitems);
        }

        /// <summary>
        /// Testa a adição de um item genérico ao inventário em duplicado
        /// </summary>
        [Test]
        public void EquipRedeItemAddtoInventoryDuplicate()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                // Limpa o inventário
                Inventario.getInstance().RemoveAll();
                // Cria um item com o id 123
                Item _item = new EquipRede(123, EquipRede.EquipRedeTipos.Router);

                // Diz ao item para se adicionar ao inventário com instancia 0 2 vezes
                bool result = _item.AddToInventario(Inventario.getInstance());
                bool result2 = _item.AddToInventario(Inventario.getInstance());
            });
        }

        /// <summary>
        /// Testa a adição de um item genérico ao inventário id inteiro em duplicado
        /// </summary>
        [Test]
        public void EquipRedeItemAddtoInventoryByIdDuplicate()
        {
            int idinventario = 100;
            int itemid = 100;
            // Limpa o inventário
            Inventario.getInstance(idinventario).RemoveAll();

            // Cria um item com o id itemid
            Item _item = new EquipRede(itemid, EquipRede.EquipRedeTipos.Router);

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
        public void EquipRedeItemDelfromInventoryById()
        {
            int idinventario = 100;
            int itemid = 100;
            // Limpa o inventário
            Inventario.getInstance(idinventario).RemoveAll();

            // Cria um item com o id itemid
            Item _item = new EquipRede(itemid, EquipRede.EquipRedeTipos.Router);

            // Diz ao item para se adicionar ao inventário com instancia idinventario 2 vezes
            _item.AddToInventario(idinventario);
            bool res = _item.RemoveFromInventario(idinventario);

            Assert.IsTrue(res);
        }

        /// <summary>
        /// Testa a Remocao de um item genérico ao inventário id inteiro em duplicado
        /// </summary>
        [Test]
        public void EquipRedeItemDelfromInventory()
        {
            int idinventario = 100;
            int itemid = 100;
            // Limpa o inventário
            Inventario.getInstance(idinventario).RemoveAll();

            // Cria um item com o id itemid
            Item _item = new EquipRede(itemid, EquipRede.EquipRedeTipos.Router);

            // Diz ao item para se adicionar ao inventário com instancia idinventario 2 vezes
            _item.AddToInventario(Inventario.getInstance(idinventario));
            bool res = _item.RemoveFromInventario(idinventario);

            Assert.IsTrue(res);
        }


        /// <summary>
        /// Testa a criação de um item genérico inválido (negativo)
        /// </summary>
        [Test]
        public void Create_EquipRedeItemInvalido()
        {
            Assert.Throws<IdBadException>(() =>
            {
                Item _item = new EquipRede(-123, EquipRede.EquipRedeTipos.Router);
            });
        }
    }
}
